---
layout: post
title: AbpVnext_Winform_Blazor_Hybird
categories: windows
description: AbpVnext创建独立的DbMigrationProject
keywords: DbMigration
typora-root-url: ../

---

windows端软件开发，技术栈选型初探。采用技术栈组合：abp vnext框架，winform 和 blazor混合开发模式。以下是一些比较重要的步骤：

首先是建议一个空白项目，项目中创建winform项目，blazor webassembly server项目，然后再创建一个blazor webassembly class library的项目，然后把blazorwebassembly server中的页面移植到blazor webassembly class library项目中，默认情况下的页面控件渲染需要用到:

````shell
Microsoft.AspNetCore.Components.Web
````

![image-20231028170144163](/images/posts/image-20231028170144163.png)

然后把pages，shared文件夹从webassembly server项目中移动到webassembly class library项目中。

![image-20231028170540931](/images/posts/image-20231028170540931.png)

然后把pages和Shared文件夹从原来的blazor webassembly server项目删除，然后blazor webassembly server项目引用blazor webassembly library项目。

对于blazor webassembly library项目，需通过Edit Project File菜单，修改library项目的Csproj文件，加入配置：

````shel
<PropertyGroup>
  <TargetFramework>net7.0</TargetFramework>
 <AddRazorSupportForMvc>true</AddRazorSupportForMvc>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
````

![image-20231028171211998](/images/posts/image-20231028171211998.png)

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



