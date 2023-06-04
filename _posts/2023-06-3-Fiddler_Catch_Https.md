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

### 0.Fiddler常用快捷键

清除和删除抓包数据：Ctrl + X ；Delete； 

### 1.Fiddler设置https抓包

https抓包设置，使用的时候，Decode这个按钮一定要是被选中的状态，要不然https返回的报文还是会出现被加密的情况。

![JR5hPaITQX](/images/posts/JR5hPaITQX.png)

如果是从来没有启用过，初次启用https解密的时候，Fiddler会询问你证书设置，弹窗出来选择YSE即可。![PotPlayerMini64_Z2kFzk21hQ](/images/posts/PotPlayerMini64_Z2kFzk21hQ.png)

![PotPlayerMini64_RiCZRhiiYN](/images/posts/PotPlayerMini64_RiCZRhiiYN.png)

也可以选择Reset All Certificates清除所以证书。之后重新设置即可。

![Fiddler_6iH3TwCieu](/images/posts/Fiddler_6iH3TwCieu.png)





### 2.Fiddler设置只查看指定网址的数据包

Filters这个选项卡默认是没有被勾选的，勾选 “Use Filters”之后，然后"Show Only the following Hosts"勾选上，这个就可以只显示你需要的包含目标url网址的包，方面做数据分析。然后在input框中以英文逗号的方式，隔开每个url连接地址，那么过滤出来的就是我们需要的链接地址了。清理掉所有之前的记录，然后重新开始请求。之后进来的数据就都是你设置好的那个url网站的数据，其他的干扰信息不会流入到Fiddler中来。特别是在做爬虫项目的时候很有用。如下图：

![k4m34hIrX4](/images/posts/k4m34hIrX4.png)

### 3.提取Fiddler抓包数据到Postman中

如果熟悉chrome的抓包数据导入Postman的话，应该也会熟悉这个cURL格式的报文。在Fiddler这个里面也有类似的可以导出整个请求数据到cURL脚本格式，

![Fiddler_IaNut3YfwI](/images/posts/Fiddler_IaNut3YfwI.png)

![Fiddler_G8bEU9izKn](/images/posts/Fiddler_G8bEU9izKn.png)

导出来的cURL文本是bat结尾的，notepad++打开之后，看到的报文如下，它提取了该请求的url，请求方式，request head，cookie，token这些信息，还有表单入参；这个数据是可以直接导入到postman中的，复制整个CURL在PostMan中导入的时候。这种CURL格式的报文甚至可以直接丢给chatgpt让你们写出来代码进行模拟。

![notepad++_2D3ukBTeCg](/images/posts/notepad++_2D3ukBTeCg.png)

![Postman_sgp3SynusV](/images/posts/Postman_sgp3SynusV.png)

![Postman_1GdWIbRSku](/images/posts/Postman_1GdWIbRSku.png)



### 4.抓包过程中设置断点

在逆向分析的时候，可能会要在请求过程中篡改某些原始请求文本，以用来测试目标网站。设置断点的目的是为了运行时修改请求数据，默认情况下是disable的，也很少使用。但是在某些特殊情况下，会用到这个断点调试。

![Fiddler_zYn0RWIcHV](/images/posts/Fiddler_zYn0RWIcHV.png)

