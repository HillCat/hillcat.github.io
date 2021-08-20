---
layout: post
title: VisualStudio使用技巧
categories: VisualStudio
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

#### 1.设置全局菜单、侧边栏字体大小：

<img src="https://cs-cn.top/images/posts/visualStudioSettings714.gif"/>

#### 2.设置代码编辑区域popup提示弹窗内字体大小：

<img src="https://cs-cn.top/images/posts/editorTootip736.gif"/>



### 3.自动注入私有属性设置

#### 1.自动生成私有变量属性

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

### 4.提升vs效率

#### 1.Shift + Enter 

这个按键组合，专门用来快速输入`大花括号`，当你输入一个类或者方法，需要敲入 `{  }   `一对大花括号的时候，直接Shift +Enter即可快捷输入，并且光标会停留在花括号的真正中间开始的位置。

#### 2.Move Class

这个功能可以把cs文件中的class类单独移动出去成为一个独立的class文件

<img src="https://cs-cn.top/images/posts/move_class750.png"/>

#### 3.自动复制文件顶部的using语句

<img src="https://cs-cn.top/images/posts/auto_paste5327.png"/>

当你进行代码的复制粘贴的时候，如果从一个文件A复制了一段代码，带有using引用的，当你拷贝到B文件的时候，想要连同A文件顶部的相关的using语句也一并拷贝到B文件，那么就可以开启这个功能。

#### 4.继承关系跳转

<img src="https://cs-cn.top/images/posts/inheriant0411.png"/>

开启这个功能之后，可以使得visual studio 2019编辑器的侧边栏显示蓝色的标记，鼠标点击之后，可以在拥有继承关系的类之间引进跳转。

#### 5.移除不用的Nuget包

这个是visual studio 2019 16.10.3 版本之后自带的功能，老版本的vs可能没有这个功能。

<img src="https://cs-cn.top/images/posts/remove_nugetPacket943.png"/>



#### 6.EditorConfig文件统一开发风格

visualStudio中可以为项目添加EditorConfig文件，来统一整个开发团队的开发规范，比如单行代码缩进量的控制。

具体的设置可以参考：[使用 EditorConfig 创建可移植的自定义编辑器设置](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options?view=vs-2019)

EditorConfig的更多规范参考[EditorConfig](https://editorconfig.org/)官方网站。

如果开启了EditorConfig文件，那么visualsudio编辑器的ErrorList提示里面会有Messages消息，提示你进行一些代码规范上面的操作：

<img src="https://cs-cn.top/images/posts/EditorConfig25.png"/>

