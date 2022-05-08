---
layout: post
title: win10设置
categories: 工具
description: 关于操作系统win10的一些设置
keywords: 博客简介
typora-root-url: ../
---
日常积累的一些win10使用的设置备忘，方便重装系统做初始化。

### win10桌面某些图标变白色的解决办法

参考：[https://thegeekpage.com/how-to-fix-the-white-blank-shortcut-icons-from-the-desktop-in-windows-10-easily/](https://thegeekpage.com/how-to-fix-the-white-blank-shortcut-icons-from-the-desktop-in-windows-10-easily/)

### PotPlayer播放器播放英文视频的设置

potPlayer是windows上面体验比较好的播放器，最新版本的播放器官方需要番蔷才能访问。学习英文这块我常用的播放器是mpv 播放器，以及这个potplayer播放器。特别是观看中英文双语字幕的电影的时候，这个播放器的体验是最好的，并且有很多的快捷键设置。官方下载地址：[https://potplayer.daum.net/](https://potplayer.daum.net/)

![MmotnV7JaN](/images/posts/MmotnV7JaN.png)

快捷键Alt + E调出中英文字幕：调节potplayer字幕的大小

![Hl7yHBwSsk](/images/posts/Hl7yHBwSsk.png)

![8gKfSE36C2](/images/posts/8gKfSE36C2.png)自定义potplaer的快捷键，屏幕中央点击’选项‘，进入，基本--->快捷键---->添加

找到字幕快捷键设置，把它设置为键盘左边的数字键3：

![haNWxSPT7p](/images/posts/haNWxSPT7p.png)

复制到剪切板，这个功能，使用条件，选择“总是使用”，并且放到最高优先级：

![4fsUBlOWhX](/images/posts/4fsUBlOWhX.png)



设置完成之后，欧陆词典的剪切板取词功能开启之后，就可以实现边看视频的时候，边查生词的功能了，甚至还可以查短语，使用鼠标框选字幕区域即可：鼠标shift键结合鼠标框选，就可以选择词组：

![Smn1UawaOk](/images/posts/Smn1UawaOk.png)

![M36SBqBRvO](/images/posts/M36SBqBRvO.png)

### win10开机激活数字键盘

默认系统情况下，冷启动系统之后，右侧的数字小键盘是默认不会启用的。开机的时候输入开机密码，发现小键盘Num Lock每次都要手动开启比较麻烦，可以直接设置系统注册表，达到win10开机激活数字键盘的目的：

![lLNLYGLwH1](/images/posts/lLNLYGLwH1.png)

### 微软输入法

使用系统默认自带的微软输入法已经足够使用了。但是相对于搜狗国产输入法，输入一些特殊字符和特定的时间会比较麻烦。

如果要输入完整的日期，则需要进一步设置，可以参考:[用微软拼音输入法快速输入自定义格式日期](https://blog.walterlv.com/ime/2017/09/18/date-time-format-using-microsoft-pinyin.html)

另外，按键设置这里，**微软输入法会和visual studio 2019里面的ctrl +shift + F搜索键产生冲突**，需要禁止掉微软输入法这个快捷键，如果你发现简体中文突然变为了繁体中文，就是因为这个组合键导致的，很容易误操作。

![anjian_settings_123423.png](/images/posts/anjian_settings_123423.png)

### 输入法切换ctrl+shift

![shortcut_settings_124827.png](/images/posts/shortcut_settings_124827.png)

![language_bar_options_23837.png](/images/posts/language_bar_options_23837.png)



### 英文字体间距特别大

这种是微软拼音输入法全角和半角切换导致的问题，

Win + i 键，进入道区域和时间设置，微软拼音输入法的全角和半角切换 shift + 空格，打开，切换一下即可。

### 进程和端口号查看器

如果发现端口号被占用，导致Nginx启动失败，你可以使用

CurrPorts这个工具查看，是否80端口被其他程序占用，如果被占用，则使用kill操作，结束那个程序，把80端口给腾出来，因为我们这个upupw要用到80端口。

[https://www.nirsoft.net/utils/cports.zip](https://www.nirsoft.net/utils/cports.zip)

另外WinDbg这个工具，调试进行和CPU爆高分析工具。也会要查找IIS中的进程，用这个工具可以很方便查找。

​                               

###  Win10如何关闭Docker虚拟机功能

解决Vmme这个进程占用太多内存的问题，如果不使用DockerDesktop，默认的虚拟机子系统可以关闭，防止占用太多系统内存。

打开控制面板，把下面没有勾选的Hyper-V勾选上，然后就会出现Hyper-V Manager工具，就可以手动关闭这个虚拟子系统了。

![image-20211031002644530](/images/posts/image-20211031002644530.png![kMPbB8IeXS](/images/posts/kMPbB8IeXS.png)

![8fpoExyZIh](/images/posts/8fpoExyZIh.png)

如果上面的方法不管用，使用手工命令行关闭wsl即可：

![aU9KciNr1i](/images/posts/aU9KciNr1i.png)

还有一个问题就是win10经常会弹出来IIS报错的时候要求visual studio进行实时调试：关闭的办法参考微软文档：

[https://docs.microsoft.com/zh-cn/visualstudio/debugger/just-in-time-debugging-in-visual-studio?view=vs-2022](https://docs.microsoft.com/zh-cn/visualstudio/debugger/just-in-time-debugging-in-visual-studio?view=vs-2022)



需要删除注册表的选项：

计算机\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\.NETFramework

![image-20220124013724629](/images/posts/image-20220124013724629.png)

计算机\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion\AeDebug

![image-20220124013847000](/images/posts/image-20220124013847000.png)

删除上面两个注册表信息，然后重启电脑。

具体删除注册表，参考[微软文档](https://docs.microsoft.com/zh-cn/visualstudio/debugger/debug-using-the-just-in-time-debugger?view=vs-2022#disable-just-in-time-debugging-from-the-windows-registry)。



### win10切换为英文之后中文变小的问题解决办法

修改系统注册表，把微软雅黑字体放在优先级最高的前面即可。

![image-20220130025732936](/images/posts/image-20220130025732936.png)



### 3.端口被占用的问题

如果发现端口被占用，可以使用

CurrPorts这个工具查看。对于本地调试部署程序比较方便。

[https://www.nirsoft.net/utils/cports.zip](https://www.nirsoft.net/utils/cports.zip)

​                               

 ![img](../images/posts/(R5S7%_%SBF7_ST`ULQ)X]X.png)

### IDM下载神器

chrome浏览器扩展的正确安装方法：[https://www.internetdownloadmanager.com/register/new_faq/chrome_extension2.html](https://www.internetdownloadmanager.com/register/new_faq/chrome_extension2.html![bvkys9ZrkS](/images/posts/bvkys9ZrkS.png)

![image-20220221050723711](/images/posts/image-20220221050723711.png)

有了这个工具之后，非常容易从youtube上面下载视频：视频右上角就会出现Download this video的弹出框。

![6DvyNXkoLI](/images/posts/6DvyNXkoLI.png)

如果要精心学习某些TED演讲材料或者是其他感兴趣的英文材料，可以非常方便使用这个IDM工具下载各种视频文件：

![FSacJvYOb3](/images/posts/FSacJvYOb3.png)

如果是电脑上面开启了代理，要注意设置为系统默认代理模式：

![TU2qdq2JLw](/images/posts/TU2qdq2JLw.png)

网络上有破解版本，但是我看了下，这个软件的永久授权费用是24.95美元，大约是163.81RMB，永久授权一台电脑。具体的价格可以参考官方地址。但是网络上面有很多的插件其实都是无法使用的，如果觉得你是比较喜欢看视频来学习英文的，可以考虑这个软件，它的下载速度真的非常快。并且是可以下载视频的文本，可以看上面那个截图，我看起了English learning Reactor插件，它能够自动检测出来英文字幕和中文字幕。真的非常强大。
