---
layout: post
title: 通过美剧学英语_anki如何制卡(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

本文介绍的这种anki制卡方法，最早可以追溯到2020年，来至于[youtube](https://www.youtube.com/watch?v=bbg6ztWecbU)播主`Matt vs japan`，我以前有提到过`Matt vs japan`，国内有人把他的方法搬运到B站，去搜索`subs2srs`还能看到这个插件的视频教程。不过，subs2srs这个插件比较老了，文本使用的是另外的一个插件，它们是同一个作者开发的。

视频卡片效果如下:mp4和mp3可以帮助回忆剧情，复习口语，复习的时候也可以模仿跟读。

![66667777](/images/posts/66667777.gif)

我的电脑系统是`window10 pro Version 22H2` (中文界面改为了英文界面)；安装的anki版本是`Anki Version ⁨2.1.55 QT5`(英文界面)。

在操作之前，**强烈建议**把文件夹视图调整为：显示文件名后缀。

如何显示文件名后缀？

进行如下设置，打上勾即可。文件视图，把文件名后缀这个勾选上即可(我的系统设置的是英文界面)。

![QQ_k87NMkPdKG](/images/posts/QQ_k87NMkPdKG.png)



## mpv anki视频制卡

### 1.安装chocolatey

最先要安装的是chocolatey。

chocolatey如何安装，文档如下：

[https://docs.chocolatey.org/en-us/choco/setup](https://docs.chocolatey.org/en-us/choco/setup)

按照上面地址的文档说明，chocolate安装方式有2种，一种是通过cmd安装，一种是powershell方式安装。选择其中1种即可.这里我使用第2种方式PowerShell安装。

在windows开始菜单，找到PowerShell以管理员方式打开，粘贴并执行下面命令：

```shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

![KUGatcqZKF](/images/posts/KUGatcqZKF.png)

不知道PowerShell是什么的，可以在windows的开始菜单里面搜这个，如上图，找到之后以管理员权限打开。然后安装chocolatey。安装的时候最好是开启全局帆樯。因为有可能某些资源是国外的，如果被墙了，就会导致安装失败。如果你的电脑没有PowerShell，那就要先安装PowerShell，具体安装方法很简单，百度搜索就可以。

等chocolatey安装好之后，输入choco，回车，如下图，如果看到没有报错，即表示安装成功。

![powershell_5G3YUqCTT8](/images/posts/powershell_5G3YUqCTT8.png)

### 2.安装mpv

然后是安装mpv播放器，以管理员权限运行powershell，执行下面命令：

```shell
choco install mpv
```

### 3.安装youtube-dl

然后是安装youtube-dl，同样是powershell管理员权限，执行下面命令：

```shell
choco install youtube-dl
```


### 4.安装ffmpeg

最后安装ffmpeg,也是通过powershell管理员权限，执行下面指令：

```shell
choco install ffmpeg
```

### 5.安装anki插件

最后是安装插件，这个插件才是关键中的关键。

如果你熟悉anki的话，直接安装这个插件就可以，插件的地址是：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)
插件安装完成之后，重启anki，使用快捷键Ctrl + O直接打开这个插件的菜单界面，然后剩下的工作就是对这个插件进行一些设置，步骤是:1.选择卡片模板，2.配置卡片模板，3.打开视频,4.制卡。

![srwyGARJZS](/images/posts/srwyGARJZS.png)

先下载模板，这个模板是跟这个插件配套使用的，是插件作者提供的一个模板，模板文件通过这个地址[https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b](https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b)下载。先把这个模板用熟，等到对anki非常熟悉之后，以后可以根据自己的需要修改这个模板。

模板下载完，你会得到下面这个文件，双击模板运行就自动导入anki了。

![Typora_elu2qwxCnN](/images/posts/Typora_elu2qwxCnN.png)

模板导入到anki后进行下一步设置。

在anki主界面，我们通过按快捷键`Ctrl + O`打开插件配置界面. 插件配置的首界面，有个叫做Type的选项，点击打开Type选择下拉框，弹出来Choose Note Type这个界面，如下图所示。在下拉框中我们选择“`Harry Potter and the Sorcerer's Stone（light theme）`"这个模板。如果你在上一步中没有安装那个模板，这里是看不到这个`Harry Potter and the Sorcerer's Stone（light theme）`模板的。

![F8VkgIxs8z](/images/posts/F8VkgIxs8z.png)

模板选中之后，设置一个Deck，一般我会新建一个Deck专门用来保存美剧卡片，根据你自己的需要选择。我这里是保存到`Just Added`这个Deck里面。字段的配置全部按照我下图②中的配置设置就可以了，这个字段是我经过了摸索和试错得出来的，直接参考我下面字段设置即可。

![6MWzXM7j8v](/images/posts/6MWzXM7j8v.png)

这些配置全部完成之后，点击ok按钮，然后回到下面那层窗口界面，点击那个界面中的`Open File`，会弹出窗口，要你去选择一个视频文件，去磁盘上面找到一个下载好的NetFlix美剧(带有英文台词的)视频，它就会用mpv自动打开那个视频进行播放了，播放的时候，按下键盘B键，就会触发自动制卡，anki的这个制卡插件就会往你的anki里面插入视频卡片了。w, e ,b 依次按下，可以截取指定区间的视频和字幕。具体查看使用文档说明。

### 6.美剧视频和字幕下载

我使用的方法是通过[FlixGrab+](https://www.flixgrab.com/)付费软件下载NetFlix的视频。

FlixGrab是可以批量下载整个美剧的，如果一个美剧有8季，你只需要粘贴其中任何一季的任何一集的URL就可以，等FlixGrab解析出来视频的缩略图之后，缩略图上面会出现齿轮样的设置按钮，上面有个`Paste Espisodes`

选项，会把所有季的所有集的URL全部粘贴生成出来缩略图，你可以单独对这些缩略图进行设置，分别设置它们的分辨率为720P。默认是最低分辨率。推荐全部设置为720P。FlixGrab+使用的时候要登录NetFlix账号，NetFlix账号登录的时候需要选择一个`Family Member`成员，即:登录的时候你需要选择家庭成员子账号图标进入，如果发现有异常搞不定的，可以发消息给我caianhua110#163.com(邮箱地址)，因为我踩了一些坑，可以分享一些经验。如果你觉得这个方法可以，也可以分享给你自己的朋友。

![POdvvjX7Wc](/images/posts/POdvvjX7Wc.png)



![PotPlayerMini64_ygvqCRi5Yo](/images/posts/PotPlayerMini64_ygvqCRi5Yo.png)

![56754546](/images/posts/56754546.gif)

Flixgrab+是付费版本，去官方网站选择季度付费，通过paypal支付即可，paypal在国内可以绑定借记银行卡。一个季度是50RMB左右费用，可以绑定3台电脑。

#### 6.1 NetFlix字幕插件

看美剧我之前一直是用[Language Reactor](https://chrome.google.com/webstore/detail/language-reactor/hoombieeljmmljlkjmnheibnpciblicm)插件，搜索一下chrome插件市场就能找到这个插件，然后它有个导出字幕功能，打印 Html即可，中英文双语字幕，设置如下，如果出现回退现象，只需要点击旁边的“小扳手”图标即可恢复到你之前的设置，目前Language Reactor会有回退到默认设置的Bug，如果出现了字幕设置回退，它旁边会出现一个“小扳手"图标，直接点击就可以恢复到你之前的设置。

![dX719tRHQU](/images/posts/dX719tRHQU.png)

​                                                                       (正常的双语字幕设置如上图)

![vJyfcBxca8](/images/posts/vJyfcBxca8.png)

​                                                                             (导出字幕)

![chrome_JRG5W5ERzj](/images/posts/chrome_JRG5W5ERzj.png)

​                                                               （字幕出现故障，点击"小扳手"恢复即可）

通过打印Html方式，中英文台词会直接显示在页面中，根据整句英文台词，可以快速搜索到中文人工翻译。配合英英词典或者中英双语词典，完善你的卡片笔记。

Language Reactor导出来的Html字幕如下：

![chrome_0NhkCqN32N](/images/posts/chrome_0NhkCqN32N.png)

查单词制卡10来秒钟搞定一个知识点。这样子做笔记的速度其实也是蛮快的。有声书/外刊 ，美剧，涉及到: 阅读，听力，口语。基本都覆盖到了。

#### 6.2 下载youtube视频

如果是看youtube，推荐IDM.全称是Internet Download Manager。工具下载地址:[Internet Download Manager](https://www.internetdownloadmanager.com/), 这个工具是付费的，大概120RMB左右，一次性永久使用。

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

![chrome_P42WUXjCil](/images/posts/chrome_P42WUXjCil.png)

IDM对应的chrome插件是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek)。

![oZmNzWrGq3](/images/posts/oZmNzWrGq3.png)

### 7.MPV播放器设置

#### 7.1 mpv 播放器的OSC配置

搞定了上面的所有设置后，我们需要优化下mpv播放器的工具条，防止工具条遮挡到字幕，方便欧陆词典或者有道词典鼠标屏幕取词，查生词。要实现的最终效果如下：

![mpv_HYntJYf4ib](/images/posts/mpv_HYntJYf4ib.png)

要把这个工具条置顶，具体操作如下：

去c盘找到mpv播放器的配置文件夹，这个配置文件夹地址类似这样子：C:\Users\47664\AppData\Roaming\mpv找到这个路径之后，快速进入这个路径，可以使用：

```shell
%appdata%\mpv
```

使用方式是，快捷键Ctrl + R直接输入上面的内容回车即可

，进入这个文件夹之后创建一个新文件夹，名字叫做`lua-settings`，再在这个`lua-settings`文件夹里面创建一个`osc.conf`文件，这个`osc.conf`里面写上如下配置,,然后保存即可。

```shell
hidetimeout=1000
fadeduration=500
seekbarstyle=bar
layout=topbar
valign=1
deadzonesize=1
```

我windows10上面的路径是这样子: 47664是我电脑用户名，你自己的电脑用户名跟这个肯定不同，我这里只是拿我自己的电脑举例。

```shell
C:\Users\47664\AppData\Roaming\mpv
```

按照我电脑上的配置为例，最终`osc.conf`这个配置文件要放到如下路径：

![explorer_ZghV2KICTX](/images/posts/explorer_ZghV2KICTX.png)

配置文件弄好之后，启动mpv播放器，控制条就移动到播放器的顶部了。修改和编辑配置文件，建议使用[notepad++](https://notepad-plus-plus.org/downloads/)这种编辑工具来进行配置的修改。我的做法是创建一个txt文件，然后把txt文件重命名为osc.conf即可，这样就创建了`osc.conf`这个文件。

mpv快捷键参考：[https://cheatography.com/someone/cheat-sheets/mpv-media-player/](https://cheatography.com/someone/cheat-sheets/mpv-media-player/)

这个快捷键的PDF文件，可以在上面这个网址可以下载到。



### 8.美剧制卡的建议

这个anki插件制作视频卡片的快捷键是`键盘B键`，默认是自动分析台词截取视频和音频。如果你自定义截取起始位置和截止位置，就需要按 W键 、E键，分别表示截取的起始位置和截止位置，然后再按B键制卡，它就会根据你指定的起始位置和截止位置来截取视频和音频，包括台词。更多的操作，请自行阅读插件文档：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)，如果具备二次开发能力的话，甚至还可以在这个插件的基础上，自行修改Lua脚本，实现一些自定义的功能。由于篇幅受限，这里不作细究，总之这里的想象空间还是很大的。

![NDSUprculn](/images/posts/NDSUprculn.png)





Enjoy it！

### 9.总结

把一个方法用成自己的习惯，持续积累，可能就是最适合自己的方法。根据统计来看，成年人自学语言，学到比较熟练的地步，大概需要5年时间。比如:`Matt vs Japan`精通日语花了5年时间，Giovanni Smith通过汉语HSK6考试花了5年时间------新汉语水平考试*HSK*（6级),也就是外国人汉语考试的最高等级。这2个人是把外语学到了考试最高等级的，用的都是anki.如果要借鉴anki这块的经验，可以参考这两位的在youtube的视频分享。

![chrome_pngaBEAaeS](/images/posts/chrome_pngaBEAaeS.png)

![chrome_Z5D3bg0Ir0](/images/posts/chrome_Z5D3bg0Ir0.png)



### 10.参考资料

[http://www.randomhacks.net/substudy/](http://www.randomhacks.net/substudy/) 这篇文章里面的作者，讲到了自己通过看剧学语言的心得体会，值得一看。

[https://learnanylanguage.fandom.com/wiki/Subs2srs](https://learnanylanguage.fandom.com/wiki/Subs2srs)这里提到的方式，是另外一种看剧挂载字幕的制卡方式，只支持低版本的anki，`Matt vs japan`曾经使用的方法就是这个方法，跟我本文讲解的方法是差不多的，插件都是同一个作者。

[https://mp.weixin.qq.com/s/nJUpWAN42fy0D1NsPewgrg](https://mp.weixin.qq.com/s/nJUpWAN42fy0D1NsPewgrg) 这篇文章来至于微信公众号，是某位IT算法大牛建立的公众号文章，关于如何寻找简单易懂的学习资料的，其中谈论了英语学习的一些观点，我个人觉得比较有意思，所以推荐下这篇文章，特别是程序员应该看看。

其他mpv播放器配置，参考Github：[https://github.com/minikui/mpv/tree/mpv/lua-settings](https://github.com/minikui/mpv/tree/mpv/lua-settings)

配置文件说明来源于这篇博客文章：[https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/](https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/)

