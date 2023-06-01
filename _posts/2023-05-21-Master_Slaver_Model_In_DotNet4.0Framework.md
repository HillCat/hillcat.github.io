---
layout: post
title: Master_Slaver_Model_In_DotNet4.0Framework
categories: dotnet
description: AI聊天记录
keywords: AI聊天记录
typora-root-url: ../
---

在.net framework 4.0下面使用同步方式实现类似异步的效果，master slaver模式监听和消费消息队列。

##### Question1：

can you write some demo let me familiar some scenario of use thread in .net framework 4.0. for example use master slave model, consumer some message queue from RabbitMq.The main thread cannot block the process.

##### Answer1:

Certainly! Here's an example that demonstrates a master-slave model using threads in the .NET Framework 4.0, where the main thread consumes messages from a RabbitMQ message queue while the slave threads process those messages. The main thread will not block the process, allowing asynchronous processing.

First, make sure you have the RabbitMQ client library installed via NuGet package manager. You can do this by running the following command in the NuGet Package Manager Console:

````bash
Install-Package RabbitMQ.Client
````



````csharp
using System;
using System.Collections.Concurrent;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class MasterSlaveExample
{
    private const string RabbitMqConnectionString = "your_rabbitmq_connection_string";
    private const string QueueName = "your_queue_name";
    private const int SlaveThreadCount = 4;

    private readonly BlockingCollection<string> messageQueue;
    private readonly ManualResetEventSlim resetEvent;
    private readonly IConnection rabbitMqConnection;

    public MasterSlaveExample()
    {
        messageQueue = new BlockingCollection<string>();
        resetEvent = new ManualResetEventSlim(false);

        var factory = new ConnectionFactory { Uri = new Uri(RabbitMqConnectionString) };
        rabbitMqConnection = factory.CreateConnection();
    }

    public void Run()
    {
        // Create slave threads
        var slaveThreads = new Thread[SlaveThreadCount];
        for (var i = 0; i < SlaveThreadCount; i++)
        {
            slaveThreads[i] = new Thread(ProcessMessage);
            slaveThreads[i].Start();
        }

        // Create and start the main thread
        var mainThread = new Thread(ConsumeMessages);
        mainThread.Start();

        // Wait for the main thread to finish
        mainThread.Join();

        // Signal slave threads to stop and wait for them to finish
        messageQueue.CompleteAdding();
        resetEvent.Wait();

        // Close RabbitMQ connection
        rabbitMqConnection.Close();
    }

    private void ConsumeMessages()
    {
        using (var channel = rabbitMqConnection.CreateModel())
        {
            channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var message = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
                messageQueue.Add(message);
            };

            channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);
        }
    }

    private void ProcessMessage()
    {
        foreach (var message in messageQueue.GetConsumingEnumerable())
        {
            // Perform processing on the message
            Console.WriteLine($"Processing message: {message}");
            Thread.Sleep(1000); // Simulating processing time
        }

        // Signal that the thread has finished
        resetEvent.Set();
    }
}

````

In the code above, the `MasterSlaveExample` class sets up a master-slave model. The `ConsumeMessages` method runs in the main thread and consumes messages from the RabbitMQ queue. Each received message is added to the `messageQueue` using the `BlockingCollection` class.

The `ProcessMessage` method represents the slave thread's work. It processes messages retrieved from the `messageQueue`. In this example, it simply prints the message and simulates processing time using `Thread.Sleep`.

The `Run` method sets everything up. It creates the slave threads, starts the main thread to consume messages, and waits for it to finish. Once the main thread is done, it signals the slave threads to stop by completing the `

##### Question2

does main thread not stop ,monitoring the message queue ,can not block the process.

##### Answer2

Apologies for the confusion. In order to ensure that the main thread does not block while monitoring the message queue, you can modify the example to use an event-driven approach with asynchronous methods. Here's an updated version:

````csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class MasterSlaveExample
{
    private const string RabbitMqConnectionString = "your_rabbitmq_connection_string";
    private const string QueueName = "your_queue_name";
    private const int SlaveThreadCount = 4;

    private readonly SemaphoreSlim semaphore;
    private readonly IConnection rabbitMqConnection;

    public MasterSlaveExample()
    {
        semaphore = new SemaphoreSlim(SlaveThreadCount);
        var factory = new ConnectionFactory { Uri = new Uri(RabbitMqConnectionString) };
        rabbitMqConnection = factory.CreateConnection();
    }

    public async Task RunAsync()
    {
        using (var channel = rabbitMqConnection.CreateModel())
        {
            channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                await ProcessMessageAsync(ea.Body.ToArray());
            };

            channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);

            // Keep the main thread running
            await Task.Delay(Timeout.Infinite);
        }
    }

    private async Task ProcessMessageAsync(byte[] messageBody)
    {
        await semaphore.WaitAsync();

        try
        {
            // Perform processing on the message
            var message = System.Text.Encoding.UTF8.GetString(messageBody);

````

##### Question3

as we all know ,in the .net framework 4.0 can not use async and await ,in this case ,you can simulator async in .net framework 4.0?

##### Answer3

You are correct. I apologize for the oversight. Asynchronous programming with `async` and `await` is not available in the .NET Framework 4.0. It was introduced in later versions, starting from .NET Framework 4.5.

If you are restricted to using the .NET Framework 4.0, you can achieve asynchronous behavior by using the `Task` class and the `ContinueWith` method for chaining tasks. Here's an updated version of the code that simulates asynchronous behavior:

````csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class MasterSlaveExample
{
    private const string RabbitMqConnectionString = "your_rabbitmq_connection_string";
    private const string QueueName = "your_queue_name";
    private const int SlaveThreadCount = 4;

    private readonly SemaphoreSlim semaphore;
    private readonly IConnection rabbitMqConnection;

    public MasterSlaveExample()
    {
        semaphore = new SemaphoreSlim(SlaveThreadCount);
        var factory = new ConnectionFactory { Uri = new Uri(RabbitMqConnectionString) };
        rabbitMqConnection = factory.CreateConnection();
    }

    public void Run()
    {
        using (var channel = rabbitMqConnection.CreateModel())
        {
            channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                Task.Factory.StartNew(() => ProcessMessage(ea.Body.ToArray()));
            };

            channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);

            // Keep the main thread running
            Thread.Sleep(Timeout.Infinite);
        }
    }

    private void ProcessMessage(byte[] messageBody)
    {
        semaphore.Wait();

        try
        {
            // Perform processing on the message
            var message = System.Text.Encoding.UTF8.GetString(messageBody);
            Console.WriteLine($"Processing message: {message}");
            Thread.Sleep(1000); // Simulating processing time
        }
        finally
        {
            semaphore.Release();
        }
    }
}

````

In this updated code, the `Run` method uses the `EventingBasicConsumer` to consume messages from the RabbitMQ queue. When a message is received, a new `Task` is created using `Task.Factory.StartNew`, which simulates the asynchronous behavior.

The `ProcessMessage` method represents the processing logic for each message. It uses `SemaphoreSlim` to limit the number of concurrent slave threads, ensuring only a specified number of threads can enter the processing block.

To run the example, you can call the `Run` method like this:

````csharp
var example = new MasterSlaveExample();
example.Run();

````

Please note that this approach is a simulation of asynchronous behavior in the .NET Framework 4.0 and does not provide the same benefits and guarantees as true asynchronous programming with `async` and `await`.