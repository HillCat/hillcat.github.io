---
layout: post
title: 并发和多线程
categories: .net
description: .net技术储备
keywords: English
---
多线程MutipleThreading 和并发Parallel编程在某些特定场景被经常使用到。此文对于常用的范式做个总结。

### 如何结束线程

线程初始化启动的时候，可以指定一个 `CancellationToken`让线程停止。还可以通过 `CancellationToken`对象直接抛出一个`token.ThrowIfCancellationRequested();`告诉线程内部Cancel掉线程。

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







