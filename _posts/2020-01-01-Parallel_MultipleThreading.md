---

layout: post
title: 并发和多线程
categories: DotNetCore
description: .net技术笔记
keywords: English
typora-root-url: ../
---
多线程MutipleThreading 和并发Parallel在提升代码性能某些特殊场景方面使用比较多，是属于.net的重点内容。

### 线程中断、结束、退出

结束Task，这里主要是使用Cancel Token; 一般是使用**CancellationTokenSource**对象的Token属性。命名空间属于：System.Threading.Tasks。

我这里对它的理解就是：CancellationTokenSource是一个发送信号的信号源，通过Token这个信号标志，把布尔状态告知Task内部线程。Task内部通过判断信号标志是Ture还是False，来触发以下3个场景：

1. 用来决定线程内部是否要抛异常，以杀掉当前线程；(**结束线程**)

2. 用来判断线程内部是否需要继续Sleeping(WaitHandle是否继续WaitOne)；(**结束等待**)

3. 判断线程内部的while,for循环是否需要break。(**结束循环**)

#### 1.Token.IsCancellationRequested(结束循环)

线程初始化启动的时候，可以指定一个 `CancellationToken`，通过`token.IsCancellationRequested`传递布尔值给到线程内部，让线程内部来做出相应的处理，这个只是传递一个布尔信号给到线程内，并不会真的kill线程，线程内部会根据这个布尔值去做相应的动作,线程会继续执行完后续代码才会退出。

```c#
using System.Threading;
using System.Threading.Tasks;

public  static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
             {
                 int i = 0;
                 while (true)
                 {
                     if (token.IsCancellationRequested)
                         break;
                     else
                         Console.WriteLine($"{i++}\t");

                 }
             }, token);
            t.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main program done.");
            Console.ReadKey();

            
        }
```



#### 2.CreateLinkedTokenSource(结束线程)

CreateLinkedTokenSource可以把不同的token对象链接起来，当其中的某个线程出现问题的时候，可以一次性取消多个线程。线程内部收到一个canceled state =true的信号之后，提前埋伏在线程内的代码`paranoid.Token.ThrowIfCancellationRequested();`，会被执行并抛出异常，这种方式会直接终止线程内部后续代码的执行。而线程内部没有收到canceled state =true的时候默认是false,埋伏在线程内的`paranoid.Token.ThrowIfCancellationRequested();`不会抛出异常，也就是说通过信号量来控制是否抛异常，从而达到kill杀死掉线程的目的。

`CreateLinkedTokenSource`这个方法里面传递一个不定长的数组，可以是很多个CancellationTokenSource对象，这个等于是把很多个CancellationTokenSource对象链接了起来，只要任意一个CancellationTokenSource对象处于Canceled State=true的状态，那么线程就会终止，这里是以抛出异常的方式终止。

```c#
private static void CompositeCancelationToken()
        {
            // it's possible to create a 'composite' cancelation source that involves several tokens
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            // make a token source that is linked on their tokens
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
              planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.Write($"{i++}\t");
                    Thread.Sleep(100);
                }
            }, paranoid.Token);

            paranoid.Token.Register(() => Console.WriteLine("Cancelation requested"));

            Console.ReadKey();

            // use any of the aforementioned token soures
            emergency.Cancel();
        }
```



#### 3.Token.WaitHandle.WaitOne(结束等待)

这种控制CancellationTokenSource状态的方式，也是发送一个canceled state =true的信号给到线程内部，线程内的Task 处于Sleeping的状态会被立即终止，并立即开始执行下一行代码。也就是说Task的Sleeping状态可以被打断。

```c#
private static void WaitingForTimeToPass()
        {
            // we've already seen the classic Thread.Sleep

            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("You have 5 seconds to disarm this bomb by pressing a key");
                bool canceled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(canceled ? "Bomb disarmed." : "BOOM!!!!");
            }, token);
            t.Start();

            // unlike sleep and waitone
            // thread does not give up its turn
            Thread.SpinWait(10000);
            Console.WriteLine("Are you still here?");

            Console.ReadKey();
            cts.Cancel();
        }
```

**应用场景思考**：在多线程执行的时候，线程之间并发，由A线程的Task任务修改CancellationTokenSource对象的状态给到B线程，B线程的Sleeping延时状态被立即打断，B线程会立即开始执行下一行代码。减少不必要的Sleeping时间，提升代码速度。如果在Sleeping过程中没有收到canceled state =true的信号，那么B线程还是会照常执行代码。

### 线程的顺序控制

#### Task.WaitAll

当Task.WaitAll在等待多个线程执行完毕的时候，如果A线程的执行耗时是5秒钟，而B线程耗时是3秒钟，而Task.WaitAll等待4秒钟，那么当等待结束的那一刻，A线程的状态其实是“正在执行”，因为Task.WaitAll这里的等待时间是4秒，A线程并未执行完毕。

```c#
class WaitingForTasks
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(3));
            var token = cts.Token;

            var t = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds");
                //Thread.Sleep(5000);

                for (int i = 0; i < 5; ++i)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("I'm done.");
            });
            t.Start();

            var t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            

            // start w/o token
            try
            {
                // throws on a canceled token
                Task.WaitAll(new[] { t, t2 }, 4000, token);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }

            Console.WriteLine($"Task t  status is {t.Status}.");
            Console.WriteLine($"Task t2 status is {t2.Status}.");

            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }
    }
```

#### task.ContinueWith

线程A和线程B，线程A执行一个耗时很长的任务，而线程B一直等待线程A，等到线程A执行完毕之后，线程B才开始执行。如果期间线程A执行过程中抛异常，那么线程B根据`t.IsFaulted`判断线程A是否抛异常，来决定要不要继续执行。如果发现线程A有异常，则线程B内部对A线程的异常进行处理。

```c#
 private static void SimpleContinuation()
        {
            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Boil water (task {Task.CurrentId}, then...");
                //throw null;
                Thread.Sleep(7000);
            });

            var task2 = task.ContinueWith(t =>
            {
                // alternatively can also rethrow exceptions
                if (t.IsFaulted)
                    throw t.Exception.InnerException;

                Console.WriteLine($"{t.Id} is {t.Status}, so pour into cup  {Task.CurrentId})");
            }/*, TaskContinuationOptions.NotOnFaulted*/);

            try
            {
                task2.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine("Exception: " + e);
                    return true;
                });
            }
        }
```



#### Task.Factory.ContinueWhenAll

任务A和任务B并发执行，当任务A和任务B都完成之后，任务C才开始执行。——ContinueWhenAll；

```c#
private static void ContinueWhen()
        {
            var task = Task.Factory.StartNew(() => "Task 1");
            var task2 = Task.Factory.StartNew(() => "Task 2");

            // also ContinueWhenAny
            var task3 = Task.Factory.ContinueWhenAll(new[] {task, task2},
                tasks =>
                {
                    Console.WriteLine("Tasks completed:");
                    foreach (var t in tasks)
                        Console.WriteLine(" - " + t.Result);
                    Console.WriteLine("All tasks done");
                });

            task3.Wait();
        }

```
任务A和任务B并发执行，当其中任何一个任务完成之后，任务C开始执行。——ContinueWhenAny;
```c#
  private static void ContinueWhen()
        {
            var task = Task.Factory.StartNew(() => "Task 1");
            var task2 = Task.Factory.StartNew(() => "Task 2");

            // also ContinueWhenAny
            var task3 = Task.Factory.ContinueWhenAny(new[] { task, task2 },
                t =>
                {
                    Console.WriteLine("Tasks completed:");
                    //foreach (var t in tasks)
                        Console.WriteLine(" - " + t.Result);
                    Console.WriteLine("All tasks done");
                });

            task3.Wait();
        }
```



### 子线程ChildTasks

Task里面包裹其他的Task，并且让内部的Task和外面的Task产生父子关系，使用`TaskCreationOptions.AttachedToParent`属性标注。然后通过`TaskContinuationOptions.OnlyOnFaulted`和`TaskContinuationOptions.OnlyOnRanToCompletion`分别指定，当内部子线程失败或者成功之后相应的业务逻辑。

```c#
 class ChildTasks
    {
        static void Main(string[] args)
        {
            var parent = new Task(() =>
            {
                // detached = just a subtask within a task
                // no relationship

                // attached

                var child = new Task(() =>
                {
                    Console.WriteLine("Child task starting...");
                    Thread.Sleep(3000);
                    Console.WriteLine("Child task finished.");

                    throw new Exception();
                }, TaskCreationOptions.AttachedToParent);

                var failHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Unfortunately, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent|TaskContinuationOptions.OnlyOnFaulted);

                var completionHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Hooray, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

                child.Start();

                Console.WriteLine("Parent task starting...");
                Thread.Sleep(1000);
                Console.WriteLine("Parent task finished.");
            });

            parent.Start();
            try
            {
                parent.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => true);
            }
        }
    }
```

### 多线程中的Barrier

A线程和B线程都是工作线程；A线程和B线程都是同时要干很多事情，A干得比较慢，B干得很快。我们强制把A线程和B线程要干的事情，划分为若干的阶段；并且这种划分是人为划分的；要求A线程和B线程在干活的速度上不要差距太大，比如A线程第一阶段请求了一个非常耗时的操作，B线程也是去请求一个耗时操作，但是A线程由于业务非常复杂导致A的这个第一阶段特别耗时，而B线程第一阶段请求已经提前完成了，B不想等A了，想要自己接着往下干；搞个东西拦着B，不让B往下走。引入Barrier对象。我把它理解为“防洪坝”，起到拦截线程内部进度的目的。

"防洪坝"这个对象第一个参数是数字，这里的2代表是计数器，从0开始累加，每挡住一次代码往下执行，计数器就会+1；直到计数器的值为2的时候，“防洪坝”开闸放水，计数器清零；通过在A线程和B线程的代码里面放置多个**barrier.SignalAndWait();**把2个线程内部的代码进行人为分隔；目的就是希望，跑得快的线程可以等一等跑得慢的线程，但是这个等待的时间，我又不想通过Thread.Sleeping来操作。因为等待的时间并不确定。下面的代码，首先定义了一个“防洪坝”对象，它的拦截周期是2，每拦截2次就会“开闸放水”并且清零。每拦截2次，就证明A线程和B线程的代码完成了某个阶段，也就是说拦截2次立马就会清零一次，并且把A线程和B线程的代码放行。并且这里，“防洪坝”每次开闸放水，都会打印输出`$"Phase {b.CurrentPhaseNumber} is finished."`;告诉控制台，当前阶段已经完成了。

```c#
class BarrierDemo
    {
        static Barrier barrier = new Barrier(2, b =>
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} is finished.");
            //b.ParticipantCount
            //b.ParticipantsRemaining

            // add/remove participants
        });

        public static void Water()
        {
            Console.WriteLine("Putting the kettle on (takes a bit longer).");
            Thread.Sleep(2000);
            barrier.SignalAndWait(); // signaling and waiting fused
            Console.WriteLine("Putting water into cup.");
            barrier.SignalAndWait();
            Console.WriteLine("Putting the kettle away.");

        }

        public static void Cup()
        {
            Console.WriteLine("Finding the nicest tea cup (only takes a second).");
            barrier.SignalAndWait();
            Console.WriteLine("Adding tea.");
            barrier.SignalAndWait();
            Console.WriteLine("Adding sugar");
        }

        static void Main(string[] args)
        {
            var water = Task.Factory.StartNew(Water);
            var cup = Task.Factory.StartNew(Cup);

            var tea = Task.Factory.ContinueWhenAll(new[] {water, cup}, tasks =>
            {
                Console.WriteLine("Enjoy your cup of tea.");
            });

            tea.Wait();
        }
    }
```

SignalAndWait()在这里从字面意思理解，就是通过barrier对象的方法，**监听信号以及执行等待**，如果信号触发满足了条件，则barrier会让线程**放行**，进入到下一阶段的代码执行。

### 多线程中的CountdownEvent

<img src="https://cs-cn.top/images/posts/CountDown024.png"/>

通过For循环同时开启多个线程，利用CountdownEvent对象来计数，它是以**倒计数**自减的方式，每当有线程结束的时候，计数器减一，直到计数器的值减为0；**cte.Signal();**方法主要是负责减数，**cte.Wait();**会等待所有的线程都执行完毕之后，才会把阻塞的代码放行。

```c#
 class CountDownEventDemo
    {
        private static int taskCount = 5;
        static CountdownEvent cte = new CountdownEvent(taskCount);
        static Random random = new Random();
        static void Main(string[] args)
        {
            var tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}.");
                    Thread.Sleep(random.Next(3000));
                    cte.Signal(); // also takes a signalcount 倒计时减数
                    //cte.CurrentCount/InitialCount
                    Console.WriteLine($"Exiting task {Task.CurrentId}.");
                });
            }

            var finalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Waiting for other tasks in task {Task.CurrentId}");
                cte.Wait();//等待Countdown倒计时的值=0，则证明所有的线程都执行完毕了
                Console.WriteLine("All tasks completed.");
            });

            finalTask.Wait();
        }
    }
```

### 多线程中的ManualResetEventSlim

ManualResetEventSlim应用场景较少，该部分内容待完善，

### 多线程中System.Threading.SemaphoreSlim 

System.Threading.SemaphoreSlim 是一个轻量级、快速的信号量，由 CLR 提供，用于在预计等待时间非常短的情况下在单个进程中等待。并且在信号量上调用 WaitAsync 会生成一个任务，当该线程被授予对信号量的访问权限时，该任务将完成。

当任务准备好时，释放信号量。当我们准备好时总是释放信号量是至关重要的，否则我们最终会得到一个永远锁定的信号量。
这就是为什么在 try...finally 子句中执行 Release 很重要；程序执行可能会崩溃或采取不同的路径，这样您就可以保证执行。

应该注意，只有在 SemaphoreSlim 上的所有其他操作都完成后才能使用 Dispose()。

### 多线程加锁

多线程同时对一个共享变量进行操作的时候，出现数据的覆盖，丢失，引起线程安全的问题；一般这个时候需要加锁。多线程只能锁应用类型变量。最佳的变量声明，是在类的内部提供如下的属性成员：

```c#
private static readonly object btnThreadCore = new object();
```

这样子的应用类型是静态的无法被外界修改的。

线程里面加锁，使用lock关键字。

lock的使用会牺牲部分性能，要求追求性能，推荐使用ConcurrentQueue<T>类型。



### 多线程中异常的处理

多个Task运行的时候，多个异常使用`AggregateException`进行捕获，然后通过`InnerExceptions`遍历之后，打印日志。

```c#
public static void BasicHandling()
    {
      var t = Task.Factory.StartNew(() =>
      {
        throw new InvalidOperationException("Can't do this!") {Source = "t"};
      });

      var t2 = Task.Factory.StartNew(() =>
      {
        var e = new AccessViolationException("Can't access this!");
        e.Source = "t2";
        throw e;
      });

      try
      {
        Task.WaitAll(t, t2);
      }
      catch (AggregateException ae)
      {
        foreach (Exception e in ae.InnerExceptions)
        {
          Console.WriteLine($"Exception {e.GetType()} from {e.Source}.");
        }
      }
    }
```

### 控制线程数量

下面这个是10000个任务发放给11个线程处理。当线程数量达到11个的时候，则不再追加线程会等待直到其中任何一个线程执行完毕，控制消费者的数量为11个线程。执行完毕之后，空闲的线程再接着领取任务。

````c#
{
    List<int> list = new List<int>();
    for(int i =0;i<10000;i++)
    {
        list.Add(i);
    }
    Action<int> action = i =>
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00"));
        Thread.Sleep(new Random(i).Next(100,300));
        
    };
    List<Task> taskList =new List<Task>();
    foreach(var i in list)
    {
        int k = i;
        taskList.Add(Task.Run(()=>action.Invoke(K)));
        if(taskList.Count>10){
            Task.WaitAny(taskList.ToArray());
            taskList=taskList.Where(t=>t.Status!=TaskStatus.RanToCompletion).Tolist();
        }
    }
    
    Task.WhenAll(taskList.ToArray());
}
````

