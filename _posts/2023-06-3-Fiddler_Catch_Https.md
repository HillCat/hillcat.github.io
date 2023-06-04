---
layout: post
title: Fiddler抓包常用的一些设置
categories: dotnet
description: 抓包设置
keywords: 抓包设置
typora-root-url: ../
---

Fddler抓包的常见设置，在软件测试人员这边用得比较多,比如模拟移动端网络不佳状态时候的那种缓慢的请求速度，以用来调试后端接口。还有可以用来进行逆向分析,https解密抓包，后台API接口性能测试等等。由于Fiddler的版本越来越趋向于商业目的，以前比较经典的免费版本很难找到了，所以这里我附上了以前比较经典的版本，可以作为收藏。

首先备注下我这里使用的系统环境和软件版本：windows10专业版本，Fiddler版本信息如下：

````bash
Progress Telerik Fiddler Web Debugger

v5.0.20192.25091 for .NET 4.6.1
Built: Tuesday, June 4, 2019

64-bit AMD64, VM: 123.0mb, WS: 84.0mb
.NET 4.7.1 WinNT 10.0.19045.0

You've run Progress Telerik Fiddler: 9 times.

Running on: homepc-430921:8888
Listening to: All Adapters
Gateway: 127.0.0.1:33210

Copyright ©2003-2019 Telerik EAD. All rights reserved.
````

Fiddler版本：[Fiddler_5.0.20192.25091.exe.zip](https://cs-cn.top/assets/tools/Fiddler_5.0.20192.25091.exe.zip)

### 1.Fiddler设置https抓包

很多人人为Fiddler没有办法解密https包，其实是可以的，具体的设置如下：

![JR5hPaITQX](/images/posts/JR5hPaITQX.png)

甚至对于https解密还可以有更加深入的了解。

![Fiddler_6iH3TwCieu](/images/posts/Fiddler_6iH3TwCieu.png)





### 2.Fiddler设置只查看指定网址的数据包

很多时候我们抓包的时候，都只关心我们目标网址，而不需要关心其他无关的url链接地址，这个时候就可以使用Filters这个选项卡，勾选 “Use Filters”之后，然后"Show Only the following Hosts"勾选上，然后再input框中以英文逗号的方式，隔开每个url连接地址，那么过滤出来的就是我们需要的链接地址了，即便我们重新开始请求，进来的请求连接地址也会是我们期望的那种，这个对于抓包非常常用。如下图：

![k4m34hIrX4](/images/posts/k4m34hIrX4.png)

### 3.抓包过程中设置断点

设置断点的目标是为了运行时修改请求数据，默认情况下是disable的。主要是请求发送给服务器之前进行修改，以及服务器响应回来之后进行修改。开启之后，每一个请求都会被拦截并且会被要求进行相关的修改。

![Fiddler_zYn0RWIcHV](/images/posts/Fiddler_zYn0RWIcHV.png)

