---
layout: post
title: win10设置
categories: 工具
description: 关于操作系统win10的一些设置
keywords: 博客简介
typora-root-url: ../
---
日常积累的一些win10使用的设置备忘，方便重装系统做初始化。

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
