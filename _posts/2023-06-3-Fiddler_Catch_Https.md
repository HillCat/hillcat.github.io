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

### 0.Fiddler清除抓包数据

清除和删除抓包数据：Ctrl + X ；Delete； 还可以通过command输入cls清理数据包。

![e4d60f0c-6ab5-4ebc-abe3-61fa14ed5171](/images/posts/e4d60f0c-6ab5-4ebc-abe3-61fa14ed5171-1685845355540-9.gif)

### 1.Fiddler设置https抓包

https抓包设置，使用的时候，Decode这个按钮一定要是被选中的状态，要不然https返回的报文还是会出现被加密的情况。

![JR5hPaITQX](/images/posts/JR5hPaITQX.png)

如果是从来没有启用过，初次启用https解密的时候，Fiddler会询问你证书设置，弹窗出来选择YSE即可。![PotPlayerMini64_Z2kFzk21hQ](/images/posts/PotPlayerMini64_Z2kFzk21hQ.png)

![PotPlayerMini64_RiCZRhiiYN](/images/posts/PotPlayerMini64_RiCZRhiiYN.png)

也可以选择Reset All Certificates清除所以证书。之后重新设置即可。

![Fiddler_6iH3TwCieu](/images/posts/Fiddler_6iH3TwCieu.png)





### 2.Fiddler设置只查看指定网址的数据包

Filters这个选项卡默认是没有被勾选的，勾选 “Use Filters”之后，然后"Show Only the following Hosts"勾选上，这个就可以只显示你需要的包含目标url网址的包，方面做数据分析。然后在input框中以英文逗号的方式，隔开每个url连接地址，那么过滤出来的就是我们需要的链接地址了。清理掉所有之前的记录，然后重新开始请求。之后进来的数据就都是你设置好的那个url网站的数据，其他的干扰信息不会流入到Fiddler中来。特别是在做爬虫项目的时候很有用。如下图：

![PotPlayerMini64_7UurnWwSSw](/images/posts/PotPlayerMini64_7UurnWwSSw.png)

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

设置断点是为了拦截我们电脑浏览器端发送的请求到服务器端，拦截之后，浏览器或者小程序或者APP内部的请求不会被立马发送到服务器端，开启拦截，需要在如下菜单位置：Rules-->Automatic Breakpoints-->Before Requsts 开启，开启之后，随后的请求都会被拦截而暂停。这个时候我们可以在WebForms里面修改表单信息，用来测试目标服务器是否会对于错误的字段信息做出报错提示。修改完成之后，右侧下方这里会有个绿色的“Run to Completion"按钮，点击，请求就会接着发送出去。

![Fiddler_zYn0RWIcHV](/images/posts/Fiddler_zYn0RWIcHV.png)

![PotPlayerMini64_98z1L5568B](/images/posts/PotPlayerMini64_98z1L5568B.png)



![RMwjMe9mh0](/images/posts/RMwjMe9mh0.png)
