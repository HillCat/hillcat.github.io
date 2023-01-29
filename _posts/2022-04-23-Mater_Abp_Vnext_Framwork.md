---
layout: post
title: MasterAbpVnextFramwork读书笔记
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

ABP作者出版了一本书，叫做《Mater Abp Vnext Framwork》，感觉还比较全面。通过一个月的时间看完了英文版本，看的过程中做一些记录。

### AbpVnextDemo文件的初始化

abp vnext很多demo源码项目，建立了DbMigrator项目的，直接设置DbMigrator为启动项目运行即可。 如果使用控制台进行初始化一般会失败，并提示：

````c#
Invalid object name 'AbpSettings'.
````



![devenv_OXjUCbUB2j](/images/posts/devenv_OXjUCbUB2j.png)

![VsDebugConsole_LCsSRC4hPd](/images/posts/VsDebugConsole_LCsSRC4hPd.png)

### AbpVnext最简单的单层mvc项目初始化

项目背景：这里我需要使用abp框架来创建一个简单的mvc页面用来接收第三方程序通过http接口发送过来的文本消息，然后实时显示更新在页面中。就是这么一个简单的需求，并且是托管在本地iis里面。主要是用来实时显示OCR之后的英文视频字幕用来制作单词卡使用。这个网页程序等于是一个开机运行的托管网页端，用来实时接收另外一个程序发送过来的英文字幕。就是这么简单的一个需求。

技术方案：database采用sqlite3,采用mvc模式，并且配合SignalR来从后台接口中接收第三方发送方发出的文本信息并且实时更新到网页中。

项目用的是sqlite3,因为这个项目只是在本地运行用来测试使用。sqllite3直接去官方下载静态文件，exe放到c盘下面创建文件夹sqlite，然后把这个路径配置到全局环境即可。配置全局环境，在win10系统点击工具条放大镜，输入‘Environment’ 就可以修改win10系统环境变量。点击Path再点击Edit enviroment variable，增加变量C:\sqlite即可。然后cmd控制台命令创建数据库。

![H9KXlMwzsX](/images/posts/H9KXlMwzsX.png)

````c#
C:\sqlite>sqlite3 LiveCaptureReceiver.db
SQLite version 3.39.2 2022-07-21 15:24:47
Enter ".help" for usage hints.
````

数据库文件放入项目路径中并配置好数据库链接地址。visual studio切换到Package Manager Console初始化db.

````c#
PM> Add-Migration "InitialDb"
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
PM> Update-Database
Build started...
Build succeeded.
Done.
PM> 
````

启动项目，这个时候abp会报错：是因为还没有给mvc项目前端做初始化操作。

````c#
Could not find the bundle file '/libs/abp/core/abp.css' for the bundle 'Basic.Global'!
````

进入到项目文件cspro文件夹里面，cmd运行abp install-libs  ,通过abp的cli自动初始化前端mvc依赖。参考官方说明：[https://docs.abp.io/en/abp/latest/CLI#install-libs](https://docs.abp.io/en/abp/latest/CLI#install-libs)

![oa9nGCWHnS](/images/posts/oa9nGCWHnS.png)

然后是往mvc中添加signalR支持：参考：[https://community.abp.io/posts/realtime-notifications-via-signalr-in-abp-project-tsp2uqd3](https://community.abp.io/posts/realtime-notifications-via-signalr-in-abp-project-tsp2uqd3)

1.首先，在项目中新建文件夹SignalR，里面创建3个类：

1. INotificationClient.cs
2. UiNotificationClient.cs
3. UiNotificationHub.cs

执行下面命令行，安装SignalR依赖：

![3lkmNZMXuV](/images/posts/3lkmNZMXuV.png)

````c#
abp add-package Volo.Abp.AspNetCore.SignalR
````



往项目模块中添加：

````c#
context.Services.AddSignalR();
````



MVC页面中使用SigNaR，需要在页面中添加SignalR JS库的引用：

````c#
@section scripts {
    <abp-script type="typeof(SignalRBrowserScriptContributor)" />
}
````

创建一个SignalRHub类：

````c#
[HubRoute("/english-hub")]
    public class MessagingHub:AbpHub
    {
        public async Task BroadcastMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        
    }
````

abp模块的初始化方法OnApplicationInitialization中增加：

````c
 app.UseEndpoints(endpoints => { endpoints.MapHub<MessagingHub>("/english-hub"); });
````

mvc页面中添加js代码，调用SignalR：

````c#
var hubName = "english-hub";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/" + hubName)
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Information)
    .build();

var myNotificationManager = $.extend({}, myNotificationManager, {
    messageListeners: {
        notificationProcessMessages: []
    }
});

connection.on("receiveNotificationMessage", function (message) {
    if (!myNotificationManager.messageListeners.notificationProcessMessages) {
        return;
    }

    myNotificationManager.messageListeners.notificationProcessMessages.forEach(function (fn) {
        fn({
            message: message
        });
    });
});

connection.start().then(function () {
    abp.log.info(hubName + " connected.");
}).catch(function (err) {
    abp.log.error(err.toString());
});
````



### Abp的模块化开发

模块化开发：A模块调用B模块的时候，模块之间依赖关系，必须要明确声明，而且模块之间的依赖关系声明的时候是有先后顺序的。

下面是原书第五章 108页原文：

![sO6nBKsyfi](/images/posts/sO6nBKsyfi.png)

A模块调用B模块，当A模块需要对B模块初始化进行设置的时候，可以使用B模块内部已经定义好的Options后缀的class来设置模块，这个**Options后缀**的class遵循ABP Vnext框架默认的约定，主要是用来对被调用模块做初始化设置的。这样子，模块的调用者就可以传递参数到被调用的模块。

![ZEWaoCpfvm](/images/posts/ZEWaoCpfvm.png)

