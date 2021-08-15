---
layout: post
title: 并发和多线程
categories: .net
description: .net技术储备
keywords: English
---
多线程MutipleThreading 和并发Parallel在提升代码性能某些特殊场景方面使用比较多，是属于.net的重点内容。

### 如何结束Task

#### 1.CancellationTokenSource.Token.IsCancellationRequested

线程初始化启动的时候，可以指定一个 `CancellationToken`让线程停止。通过`token.IsCancellationRequested`传递布尔值给到线程内部，让线程内部来做出相应的处理，比如下面是通过break直接结束while循环，达到结束线程的目的。

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



#### 2.CancellationTokenSource.CreateLinkedTokenSource

CreateLinkedTokenSource可以把不同的token对象链接起来，当其中的某个线程出现问题的时候，可以一次性取消多个线程。

本质上，是通过`paranoid.Token.ThrowIfCancellationRequested();`抛出异常的方式来结束线程。

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



#### 3.CancellationTokenSource.Token.WaitHandle.WaitOne

这种结束Task的方法，是在Task 处于Sleeping等待过程中提前结束等待，如果在Sleeping过程中，突然canceled state = true，那么就会立即结束Sleeping，并且会立即开始执行下一行代码。

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

**思考**：上面第1种方法结合此方法，如果是在多线程执行的时候，线程之间并发，由A线程的Task任务修改CancellationTokenSource对象的状态，给到B线程，可以立即结束B线程的Sleeping延时，B线程会立即开始执行下一行代码。

