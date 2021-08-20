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

我这里选择的是Refactoring Only：

<img src="https://cs-cn.top/images/posts/underscore_reflector845.png"/>

最终使用的效果就是如下：visualstudio 2019会把含有依赖注入的属性，自动给你补上，并且打上私有属性下划线。

<img src="https://cs-cn.top/images/posts/reflector_creator32.gif"/>

如果没有这个设置，那么编辑器给出来的自动提示就是如下这种：

<img src="https://cs-cn.top/images/posts/private_properties526.png"/>

这个设置在依赖注入的时候，使用起来特别方便。

### 4.VisualStudio2019提升效率技巧

1.Shift + Enter 

这个按键组合，专门用来快速输入`大花括号`，当你输入一个类或者方法，需要敲入 `{  }   `一对大花括号的时候，直接Shift +Enter即可快捷输入，并且光标会停留在花括号的真正中间开始的位置。

2.Move Class

这个功能可以把cs文件中的class类单独移动出去成为一个独立的class文件

<img src="https://cs-cn.top/images/posts/move_class750.png"/>

3.自动复制文件顶部的using语句

<img src="https://cs-cn.top/images/posts/auto_paste5327.png"/>

当你进行代码的复制粘贴的时候，如果从一个文件A复制了一段代码，带有using引用的，当你拷贝到B文件的时候，想要连同A文件顶部的相关的using语句也一并拷贝到B文件，那么就可以开启这个功能。

4.显示继承关系

<img src="https://cs-cn.top/images/posts/inheriant0411.png"/>

开启这个功能之后，可以使得visual studio 2019编辑器的侧边栏显示蓝色的标记，鼠标点击之后，可以在拥有继承关系的类之间引进跳转。





