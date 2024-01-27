---
layout: post
title: Winform_Blazor_TailWindCss_Hybird
categories: Math
description: Blazor
keywords: Blazor
typora-root-url: ../

---

随着微软发布.net core 8.0，Blazor前端技术也趋于成熟，在winform +blazor混合技术这块，尝试开发一些小型应用，下面是一些趟坑记录：

## 1.Blazor在winform中加载css

在开发winform+Hybird应用的时候，Blazor webassembly构成的WebPage项目被当作dll类库引入winform中。Winform中的css样式出现渲染错误，一般是因为winform的wwwroot文件夹中head部分引入的css路径发生了错误导致的，winform中的head引入css需要指向Blazor WebAssembly项目的css路径。

````html
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>Blazor WinForms app</title>
    <base href="/" />
    <link rel="stylesheet" href="_content/WebPage/css/bootstrap/bootstrap.min.css" />
    <link href="_content/WebPage/css/site.css" rel="stylesheet" />
    <link href="Winform.styles.css" rel="stylesheet" />
</head>

````

![image-20231203202408300](/images/posts/image-20231203202408300.png)

## 2.Winform中使用abp vnext自带的依赖注入

如果项目结构是使用winform + abp vnext +blazor webAssembly模式，依赖注入就不能直接采用下面这种new ServiceCollection的方式。这个会跟Abp Vnext框架自带的依赖注入产生冲突，因此需要将手动的这种模式替换为abp vnext自带的依赖注入模式。

![image-20231210144839532](/images/posts/image-20231210144839532.png)

在使用Repository的时候，比如repository.GetDbContext()；使用这个方法的时候会遇到一个报错信息”访问了已经被释放的context上下文“，如果出现这种情况，需要在使用了repository的方法前面加上[UnitOfWork]的标记，使得blazor assembly调用的时候，abp框架可以把这个方法也计算到unitOfWork里面去而不被提前释放了dbContext上下文。

## 3.TailWindCss自动生成css

电脑中先安装node.js然后通过npx全局安装tailwind css。然后使用tailwind css生成tailwindcss.config.js配置文件。

在我们的.net project目录下面，cmd命令行执行：

````shell
npx tailwindcss init
````

![image-20231223170157210](/images/posts/image-20231223170157210.png)



执行完成之后，tailwindcss的cli命令行会生成一个tailwind.config.js的配置文件。

这个里面还需要设置一下，如下：

````js
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html}'],
  theme: {
    extend: {},
  },
  plugins: [],
}

````

另外，在编写界面的时候我们可以开启tailwindcss的即时编译功能，visual studio 2022的hot reload开启"保存的时候热加载",这样子编写和调试blazor的时候就可以看到实时的css效果反应。

1.在project的根目录创建Styles文件夹，里面创建app.css，内容如下：

```shel
@tailwind base;
@tailwind components;
@tailwind utilities;

```

2.在blazor页面公共入口引入css

![image-20231223190108390](/images/posts/image-20231223190108390.png)

添加

````shell
<link href="/css/app.css" rel="stylesheet" />
````

这个文件在wwwroot\css路径下面是不存在的，我们利用tailwindcss的cli命令生成。

````shell
npx tailwindcss -i .\Styles\app.css -o .\wwwroot\css\app.css --watch
````

执行完成，会在wwwroot\css下面创建app.css文件，

![image-20231223190341458](/images/posts/image-20231223190341458.png)



## 4.TailWindCss Flowbite替换BootStrap

微软官方默认的Blazor Demo采用的是BootStrap的css样式，不太灵活也比较丑，而且这个BootStrap样式和TailWindCss样式会有冲突，包括如果使用其他的组件，比如AntedDesign，MudBlazor都会有冲突。从零开始开发自己项目，建议剥离BootStrap，使用TailWindCss快速构建原型。

![image-20240127234915649](/images/posts/image-20240127234915649.png)

[https://play.tailwindcss.com/](https://play.tailwindcss.com/)

基于tailwindcss的生态，已经有了Flowbite Pro - Figma这个设计系统，可以完美替换掉blazor这个默认的皮肤，设计出符合自己的产品布局或者官方网站，基于blazor，而不依托其他的blazor控件。实现轻量化。Figma设计系统目前被抖音公司内部前端广泛采用，这个是目前UI这块提升效率的一个趋势。

![image-20240128014854547](/images/posts/image-20240128014854547.png)



从上面的步骤中，其实还推荐安装POSTCSS cli这个工具，方便自动化项目的css

````shell
npm install tailwindcss postcss autoprefixer postcss-cli
````

具体的flowbite在blazor中的使用方法参考说明文档：

[https://flowbite.com/docs/getting-started/blazor/](https://flowbite.com/docs/getting-started/blazor/)

总之：有了blazor的技术栈，我们在不使用任何blazor组件的情况下，完全可以使用html css js这种原生html组件来构建我们轻量级的winform blazor web hybrid应用界面。并且实现高度定制化。

