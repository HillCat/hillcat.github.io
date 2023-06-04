---
layout: post
title: Fiddler抓包常用的一些设置
categories: dotnet
description: 抓包设置
keywords: 抓包设置
typora-root-url: ../
---

Fiddler抓包设置。

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

https抓包设置，使用的时候，Decode这个按钮一定要是被选中的状态，要不然https返回的报文还是会出现被加密的情况。

![JR5hPaITQX](/images/posts/JR5hPaITQX.png)

如果是从来没有启用过，初次启用https解密的时候，Fiddler会询问你证书设置，弹窗出来选择YSE即可。![PotPlayerMini64_Z2kFzk21hQ](/images/posts/PotPlayerMini64_Z2kFzk21hQ.png)

![PotPlayerMini64_RiCZRhiiYN](/images/posts/PotPlayerMini64_RiCZRhiiYN.png)

也可以选择Reset All Certificates清除所以证书。之后重新设置即可。

![Fiddler_6iH3TwCieu](/images/posts/Fiddler_6iH3TwCieu.png)





### 2.Fiddler设置只查看指定网址的数据包

很多时候我们抓包的时候，都只关心我们目标网址，而不需要关心其他无关的url链接地址，这个时候就可以使用Filters这个选项卡，勾选 “Use Filters”之后，然后"Show Only the following Hosts"勾选上，然后再input框中以英文逗号的方式，隔开每个url连接地址，那么过滤出来的就是我们需要的链接地址了，即便我们重新开始请求，进来的请求连接地址也会是我们期望的那种，这个对于抓包非常常用。特别是当你需要逆向分析某个平台的请求过程，或者开发一些爬虫程序的时候。如下图：

![k4m34hIrX4](/images/posts/k4m34hIrX4.png)

### 3.抓包过程中设置断点

在逆向分析的时候，可能会要在请求过程中篡改某些原始请求文本，以用来测试目标网站。设置断点的目的是为了运行时修改请求数据，默认情况下是disable的，也很少使用。但是在某些特殊情况下，会用到这个断点调试。

![Fiddler_zYn0RWIcHV](/images/posts/Fiddler_zYn0RWIcHV.png)

