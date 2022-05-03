---

layout: post
title: Blazor_MudBlazor初探
categories: DotNetCore
description: DotNetCoreCosoleApplication
keywords: .net
typora-root-url: ../
---

关于快速开发类工具的探索篇，一个是控制台程序，一个是基于快速UI开发的Blazor技术：

### Blazor_MudBlazor框架

1.首先是nuget package控制台安装MubBlazor模板文件

````c#
dotnet new --install MudBlazor.Templates
````



![devenv_LQ8dZ8odbL](/images/posts/devenv_LQ8dZ8odbL.png)

安装完mudBlazor模板文件之后，visual studio 2022新建就可以看到MubBlazor了：

![mOfLvZeilG](/images/posts/mOfLvZeilG.png)





控制台里面可以实用依赖注入，可以配置appsettings.json数据，快速实现一些功能比用UI界面要更快。

### 控制台读取appsetting.json配置文件

为了更好的编写控制台程序，安装下面的nuget包,可以使得顺利读取appsettings.json文件以及配置文件中的节点，让节点作为对象属性映射到我们定义好的class对象属性上：

````c#
Microsoft.Extensions.Configuration
Microsoft.Extensions.Configuration.FileExtensions
Microsoft.Extensions.Configuration.Json
Microsoft.Extensions.Configuration.Binder
````



![rcFWik7sDF](/images/posts/rcFWik7sDF.png)

### 开启依赖注入功能

参考：[https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/](https://espressocoder.com/2018/12/03/build-a-console-app-in-net-core-like-a-pro/)

````c#
Microsoft.Extensions.DependencyInjection
````



### EfCore 插件自动生成实体类

![MEszWGUwhk](/images/posts/MEszWGUwhk.png)
