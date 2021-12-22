---
layout: post
title: 快速粘贴web报文请求到postman
categories: DotNetCore
description: 接口调试技巧
keywords: postman
typora-root-url: ../
---

前后端分离之后，调试API查找BUG成了每日必做的功课。为了快速还原和定位到问题。使用一键快速粘贴chrome请求报文到postman：

第一步：copy as cURL（bash） 拷贝请求方式为curl数据。

![image-20211222094120468](/images/posts/image-20211222094120468.png)

第二步: Import里面粘贴到Raw text

![image-20211222095634402](/images/posts/image-20211222095634402.png)

Swagger里面的curl也是支持postman直接粘贴RawText形式的。

