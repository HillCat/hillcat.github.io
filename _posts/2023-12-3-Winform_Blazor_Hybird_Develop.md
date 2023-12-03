---
layout: post
title: Winform_Blazor_Hybird
categories: Math
description: Blazor
keywords: Blazor
typora-root-url: ../

---

在开发winform+Hybird应用的时候，Blazor webassembly被当作dll类库引入winform中。blazorwebAssembly中的css样式发生错位的话，是很难进行调试的。比如：

![image-20231203155441322](/images/posts/image-20231203155441322.png)

因为web页面已经嵌入了winform中，很难使用类似浏览器的dev工具进行样式的debug。
