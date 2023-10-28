---
layout: post
title: AbpVnext_Winform_Blazor_Hybird
categories: windows
description: AbpVnext创建独立的DbMigrationProject
keywords: DbMigration
typora-root-url: ../

---

技术栈选用：abp vnext框架，winform 和 blazor混合开发模式。以下是一些比较重要的步骤：

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
