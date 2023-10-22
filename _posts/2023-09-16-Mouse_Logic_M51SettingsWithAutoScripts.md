---
layout: post
title: 刷英文视频的鼠标设置
categories: english
description: 英文学习
keywords: AI生成提速
typora-root-url: ../
---

在大量观看在线tube英文视频的时候，我比较喜欢单手操作鼠标，进行视频的取词翻译，以及视频的快进和快退操作。鼠标是罗技M510型号的，配合AutoHotKey Script脚本，可以把鼠标左侧的上下翻滚键，直接映射为键盘的左右键盘，这样子就可以做到不需要触摸键盘，用一个鼠标很轻松的观看youtube的视频。通过点击的方式+ Language Reactor插件实现纯英文字幕的生词翻译。我平时观看视频只显示英文字幕，没有开启中文字幕，只是偶尔会有生词的时候会要用到快退5秒，然后鼠标点击生词翻译。

![image-20230916112145134](/images/posts/image-20230916112145134.png)

罗技 M510鼠标，如下：

![image-20230916112454738](/images/posts/image-20230916112454738.png)

AutoHotkey脚本如下：

````shell
#Persistent
return

XButton1::Left  
XButton2::Right 

````

![image-20230916112637243](/images/posts/image-20230916112637243.png)

双击脚本可以运行。

### 开机启动

可以设置此脚本开机启动，Win +R打开命令行运行窗体，

```shell
Win +  R
```

第一种方式：打开启动文件夹：

```shell
shell:common start
```

第二种方式：如果只是针对自己当前windows账号登陆启动，则：

```shell
shell:start
```

不要把上面两个文件夹里面都放入AutoHotKey脚本，选择其中一个即可。

![image-20231022180805878](/images/posts/image-20231022180805878.png)

然后把我们修改的那个脚本丢入其中即可。下次开机启动系统，那么鼠标浏览器就自带了比较方便的快捷功能。

然后我们在观看youtube视频的时候，我们如果想鼠标单手操作，就可以点击向下翻滚键，就是快退5秒，效果如下：

![image-20230916222143495](/images/posts/image-20230916222143495.png)

chrome浏览器要安装Language Reactor插件。插件官方网站：https://www.languagereactor.com/ ，插件地址：[https://chrome.google.com/webstore/detail/language-reactor/hoombieeljmmljlkjmnheibnpciblicm](https://chrome.google.com/webstore/detail/language-reactor/hoombieeljmmljlkjmnheibnpciblicm)，如果不需要保存浏览的单词历史记录和卡片这些信息，使用Language Reactor其实已经可以满足大部分的需求了，因为Language Reactor的服务器速度还是非常快的。国内的访问速度，Language Reactor体验速度比Reverso Context要快不少。

![image-20230916222531569](/images/posts/image-20230916222531569.png)

![image-20230916222702906](/images/posts/image-20230916222702906.png)

