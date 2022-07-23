---
layout: post
title: MasterAbpVnextFramwork读书笔记
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

ABP作者出版了一本书，叫做《精通abp vnext框架》，英文名字《Mater Abp Vnext Framwork》，感觉还比较全面。通过一个月的时间看完了英文版本，看的过程中做一些记录。

### AbpVnext项目初始化

平时自己做小项目，采用abp官方生成的最新的.net6版本，database采用sqlite3,采用mvc模式，下载下来截图大概是这样子：

项目背景：我这里是为了使用一个网页端接收sharex发送过来的OCR文本，排版之后实时显示在网页上面，用来划词制卡。自己倒腾一个小工具，直接用abp最新版本的倒腾一下。所以直接从abp官方生成一个项目模板。接下项目初始化。

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

启动项目，这个时候abp会报错：

````c#
Could not find the bundle file '/libs/abp/core/abp.css' for the bundle 'Basic.Global'!
````





### Abp的模块化开发

模块化开发：A模块调用B模块的时候，模块之间依赖关系，必须要明确声明，而且模块之间的依赖关系声明的时候是有先后顺序的。

下面是原书第五章 108页原文：

![sO6nBKsyfi](/images/posts/sO6nBKsyfi.png)

A模块调用B模块，当A模块需要对B模块初始化进行设置的时候，可以使用B模块内部已经定义好的Options后缀的class来设置模块，这个**Options后缀**的class遵循ABP Vnext框架默认的约定，主要是用来对被调用模块做初始化设置的。这样子，模块的调用者就可以传递参数到被调用的模块。

![ZEWaoCpfvm](/images/posts/ZEWaoCpfvm.png)

