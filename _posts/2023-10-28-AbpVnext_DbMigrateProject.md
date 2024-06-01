---
layout: post
title: AbpVnext_Winform_Blazor_Hybird
categories: windows
description: AbpVnext创建独立的DbMigrationProject
keywords: DbMigration
typora-root-url: ../

---

随着前端的发展，现在主流的desktop app开发模型都是富交互的web混合开发模式，微软的.net core8即将在下个月正式发布生产版本，此版本是LTS版本的。目前阶段blazor生态已经趋近于成熟。业余时间正在把abp vnext框架的生态和blazor生态整合为我自己的一些经验。这里记录一些入坑经验。

winform之中继承abp vnext core项目，把winform弄成模块化的，然后winform窗体界面中植入webview2（blazor web view）,blazor的page页面最初是放置在blazor web assembly server中的，winform需要引用这些web page组件（包括blazor 的路由组件），常规的方式都是把blazor page的这个项目转为library的方式引入winform中使用。常用blazor hybird开发winform的好处是可以节省代码量，还有app运行的内存量也在很大程度上远远少于Electronic这种基于nodejs的技术栈。

首先是创建一个Blazor server的page的项目，然后建立一个Blazor Library项目，library项目已经内置了Microsoft.AspNetCore.Components.Web组件。

````shell
Microsoft.AspNetCore.Components.Web
````

![image-20231028170144163](/images/posts/image-20231028170144163.png)

然后把page项目中的pages，shared文件夹从webassembly server项目中移动到webassembly class library项目中，还有_Imports.razor,一并移入。

![image-20231028170540931](/images/posts/image-20231028170540931.png)

然后把pages和Shared项目头部引用改为当前的Library命名空间引用。

对于blazor webassembly library项目，需通过Edit Project File菜单，修改library项目的Csproj文件，加入配置：

````shel
<AddRazorSupportForMvc>true</AddRazorSupportForMvc>
````

![image-20231028171211998](/images/posts/image-20231028171211998.png)

使得Library这个项目支持mvc的路由，静态wwwroot根目录的特性。在测试 整合的过程中遇到了不少的坑，abp vnext的整合就花费了不少时间。另外整合winform和blazor page项目的时候也遇到不少坑。在此做点笔记。

#### 1.踩坑

遇到了样式错位没有加载的情况

![image-20231028171458625](/images/posts/image-20231028171458625.png)

还有几个文件需要从Assembly server中拷贝到Class Library中，

```shell
_Imports.razor
App.razor

```

然后_Imports.razor中还需要修改最后1行代码如下：并且添加对于自身class library project中shared文件夹的引用。

![image-20231028172902288](/images/posts/image-20231028172902288.png)

然后是没有的Nuget包需要安装上：

![image-20231028173142748](/images/posts/image-20231028173142748.png)

然后是blazor Server项目中原来的 2个文件删除掉：

```shell
_Imports.razor
App.razor
```

并且blazor  server project中的program.cs中引用的命名空间修改为引用class library库。

Blazor Server项目中的Data文件夹转移到Class Library项目中，并且要修改命名空间：

![image-20231028175501311](/images/posts/image-20231028175501311.png)

#### 2.踩坑2

找不到路由

![image-20231028175717567](/images/posts/image-20231028175717567.png)

Library Project中缺少_Host.cshtml文件，并且需要引入nuget包，以支持路由功能：

![image-20231028181547335](/images/posts/image-20231028181547335.png)



#### 3.踩坑3

找不到根目录wwwroot

![image-20231028205322969](/images/posts/image-20231028205322969.png)
