---
layout: post
title: VisualStudio快捷键
categories: .net
description: VisualStudio常用技巧
keywords: trpora
---

VisualStudio中常用的快捷键：

### 1.常用快捷技巧

Ctrl + Home键：回到文档的顶部

Ctrl+End键：回到文档的底部

Home键：移动到行首，按两次Home键，直接移动到边框最左端

Ctrl +R 连按2次：修改变量名



### 2.给VisualStudio2019设置合适的字号

**1.设置全局菜单、侧边栏字体大小：**

<img src="https://cs-cn.top/images/posts/visualStudioSettings714.gif"/>

**2.设置代码编辑区域popup提示弹窗内字体大小：**

<img src="https://cs-cn.top/images/posts/editorTootip736.gif"/>



### 3.VisualStudio2019变量名规范

**1.自动生成私有变量属性。**

可以强制设置私有变量为 ‘_' 带有下划线的小驼峰方式：

<img src="https://cs-cn.top/images/posts/UnderScore055.png"/>

设置完毕之后：

<img src="https://cs-cn.top/images/posts/underscore_15.png"/>

我这里设置的是通过反射的方式来生成私有变量：

<img src="https://cs-cn.top/images/posts/underscore_reflector845.png"/>

最终使用的效果就是如下：

<img src="https://cs-cn.top/images/posts/reflector_creator32.gif"/>

如果没有这个设置，那么编辑器给出来的自动提示就是如下这种：

<img src="https://cs-cn.top/images/posts/private_properties526.png"/>
