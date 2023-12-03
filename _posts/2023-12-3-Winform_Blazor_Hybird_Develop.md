---
layout: post
title: Winform_Blazor_Hybird
categories: Math
description: Blazor
keywords: Blazor
typora-root-url: ../

---

随着微软发布.net core 8.0，Blazor前端技术也趋于成熟，在winform +blazor混合技术这块，尝试开发一些小型应用，下面是一些趟坑记录：

#### 1.Blazor在winform中加载css

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
