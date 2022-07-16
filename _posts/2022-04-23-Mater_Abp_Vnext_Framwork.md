---
layout: post
title: MasterAbpVnextFramwork读书笔记
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

ABP作者出版了一本书，叫做《精通abp vnext框架》，英文名字《Mater Abp Vnext Framwork》，感觉还比较全面。通过一个月的时间看完了英文版本，看的过程中做一些记录。

### Abp的模块化开发

模块化开发：A模块调用B模块的时候，模块之间依赖关系，必须要明确声明，而且模块之间的依赖关系声明的时候是有先后顺序的。

下面是原书第五章 108页原文：

![sO6nBKsyfi](/images/posts/sO6nBKsyfi.png)

A模块调用B模块，当A模块需要对B模块初始化进行设置的时候，可以使用B模块内部已经定义好的Options后缀的class来设置模块，这个**Options后缀**的class遵循ABP Vnext框架默认的约定，主要是用来对被调用模块做初始化设置的。这样子，模块的调用者就可以传递参数到被调用的模块。

![ZEWaoCpfvm](/images/posts/ZEWaoCpfvm.png)

