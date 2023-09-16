---
layout: post
title: 刷英文视频的鼠标设置
categories: english
description: 英文学习
keywords: AI生成提速
typora-root-url: ../
---

在大量观看在线tube英文视频的时候，我比较喜欢单手操作鼠标，进行视频的取词翻译，以及视频的快进和快退操作。鼠标是罗技M510型号的，配合AutoHotKey Script脚本，可以把鼠标左侧的上下翻滚键，直接映射为键盘的左右键盘，这样子就可以做到不需要触摸键盘，用一个鼠标很轻松的观看tube的视频。通过点击的方式+ English Reactor插件实现纯英文字幕的生词翻译。我平时观看视频只显示英文字幕，没有开启中文字幕，只是偶尔会有生词的时候会要用到快退5秒，然后鼠标点击生词翻译。

![image-20230916112145134](/images/posts/image-20230916112145134.png)

罗技 M510鼠标，如下：

![image-20230916112454738](/images/posts/image-20230916112454738.png)

默认情况下，这个上下翻滚键盘是翻页的。映射为视频快进和快退键，使用如下脚本即可：如果不会编写脚本不要紧，去问ChatGPT即可，AutoHotKey的脚本还可以有很多其他功能。只要你能够想到，ChatGPT基本上都能写出来。下面这段脚本是ChatGPT给我写出来的鼠标翻滚键映射到键盘的左右键：在观看各种视频的时候，小技巧很实用。

````shell
; 配置罗技M510鼠标的两个侧边按钮为左右箭头键
; 注意：您需要安装AutoHotkey并将此脚本保存为.ahk文件，然后运行脚本以生效。

#Persistent
return

XButton1::Left  ; 将侧边按钮1映射为左箭头键
XButton2::Right ; 将侧边按钮2映射为右箭头键

````

![image-20230916112637243](/images/posts/image-20230916112637243.png)
