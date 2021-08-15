---
layout: post
title: 并发和多线程
categories: .net
description: .net技术储备
keywords: English
---
多线程MutipleThreading 和并发Parallel在提升代码性能某些特殊场景方面使用比较多，是属于.net的重点内容。

### 如何结束Task

结束Task，这里主要是使用Cancel Token; 一般是使用**CancellationTokenSource**对象的Token属性。命名空间属于：System.Threading.Tasks。

为了更好理解这里的CancelToken下面给出Token的英文释义：

<img src="https://cs-cn.top/images/posts/cancel_token053.png"/>

<img src="https://cs-cn.top/images/posts/token_931.png"/>



#### 1.Token.IsCancellationRequested

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



#### 2.CreateLinkedTokenSource

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



#### 3.Token.WaitHandle.WaitOne

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

