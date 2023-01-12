---
layout: post
title: 通过美剧学英语_anki如何制卡(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

本文介绍的这种anki制卡方法，最早可以追溯到2020年，来至于[youtube](https://www.youtube.com/watch?v=bbg6ztWecbU)播主`Matt vs japan`，我以前有提到过`Matt vs japan`，国内有人把他的方法搬运到B站，去B站搜索`subs2srs`还能看到这个插件的教程，去B站搜索其他关键字:"anki制作影音卡"，"anki制作视频卡","MPV + anki"，都可以找到与本文类似的方法，不过那些教程的方法subs2srs这个插件比较老了，文本使用的是该插件作者开发的另外的一个插件。使用anki这么多年，一个很重要的心得就是：学英语的效果并不在于你的学习技巧多牛逼，重要的是如何把一个方法用成自己的习惯，找到`英文输入和英文复习`之间的兼顾和平衡点，并且能够维持2年、3年、5年稳定持续积累才是核心。就是说要找到自己的节奏，而不被外界干扰，持续进行英文的输入和复习。

视频卡片效果如下，为了直接进入正题，我把不需要的文字内容删掉了一些，直接说重点。

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

这些配置全部完成之后，点击ok按钮，然后回到下面那层窗口界面，点击那个界面中的`Open File`，会弹出窗口，要你去选择一个视频文件，去磁盘上面找到一个下载好的NetFlix美剧(带有英文台词的)视频，它就会用mpv自动打开那个视频进行播放了，播放的时候，按下键盘B键，就会触发自动制卡，anki的这个制卡插件就会往你的anki里面插入视频卡片了。

### 6.美剧视频和字幕下载

我使用的方法是通过[FlixGrab+](https://www.flixgrab.com/)付费软件下载NetFlix的视频。

FlixGrab是可以批量下载整个美剧的，如果一个美剧有8季，你只需要粘贴其中任何一季的任何一集的URL就可以，等FlixGrab解析出来视频的缩略图之后，缩略图上面会出现齿轮样的设置按钮，上面有个`Paste Espisodes`

选项，会把所有季的所有集的URL全部粘贴生成出来缩略图，你可以单独对这些缩略图进行设置，分别设置它们的分辨率为720P。默认是最低分辨率。推荐全部设置为720P。FlixGrab+使用的时候要登录NetFlix账号，NetFlix账号登录的时候需要选择一个`Family Member`成员，即:登录的时候你需要选择家庭成员子账号图标进入，如果发现有异常搞不定的，可以发消息给我caianhua110#163.com(邮箱地址)，因为我踩了一些坑，可以分享一些经验。如果你觉得这个方法可以，也可以分享给你自己的朋友。

![POdvvjX7Wc](/images/posts/POdvvjX7Wc.png)



![PotPlayerMini64_ygvqCRi5Yo](/images/posts/PotPlayerMini64_ygvqCRi5Yo.png)

![56754546](/images/posts/56754546.gif)

flixgrab+是付费版本，去官方网站选择季度付费，通过paypal支付即可，paypal在国内可以绑定借记银行卡。一个季度是50RMB左右费用，可以绑定3台电脑。支付成功之后，它会往你指定的邮箱发送序列号，如下：

![nQmIpqX0TC](/images/posts/nQmIpqX0TC.png)

![chrome_vueAJb2RC8](/images/posts/chrome_vueAJb2RC8.png)

目前我只注册了1台电脑。其实还有2个名额，有需要的朋友可以共用序列号。或者你也可以找几个朋友一起学美剧，共用账号。NetFlix账号也是可以租用的，一个NetFlix账号可以共用3~5个人，电报群Telegram App或者淘宝找人去租用NetFlix账号也可以，不贵，一个季度45RMB左右。如果你长期没有找到合适的学美剧的方法，不妨试试这个方法。

看美剧必装的Chrome插件：Language Reactor插件，推荐一定安装。开启双语字幕非他莫属。

![SdFBfGLJSd](/images/posts/SdFBfGLJSd.png)

![chrome_TWtorDcc79](/images/posts/chrome_TWtorDcc79.png)

这个插件还有很多其他功能，比如单词分级`Set Vocabulary Level`。可以让你提前预览到生词分布情况，用来判断一个剧的难度。有声书可以分级阅读，美剧也有类似的由简单到难的一个方法论在里面。

![chrome_nvV5g42HPi](/images/posts/chrome_nvV5g42HPi.png)

除了NetFlix美剧，还可以看youtueb上面的视频，下载youtube视频和英文字幕，我一般采用这个IDM工具下载:[Internet Download Manager](https://www.internetdownloadmanager.com/), 这个工具也是付费的，比较便宜，大概120RMB左右，永久使用，用过的人都说好。

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

![chrome_P42WUXjCil](/images/posts/chrome_P42WUXjCil.png)

IDM对应的chrome插件是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek),不要搞错了插件，很多人第一次使用的时候经常搞错IDM对应的chrome插件。这个IDM插件，可以下载英文字幕，分辨率这些都是可选的，非常方便。

![oZmNzWrGq3](/images/posts/oZmNzWrGq3.png)

### 7.MPV播放器设置

#### 7.1 mpv 播放器的OSC配置

搞定了上面的所有设置后，我们需要优化下mpv播放器的工具条，防止工具条遮挡到字幕，方便欧陆词典或者有道词典鼠标屏幕取词，查生词。要实现的最终效果如下：

![mpv_HYntJYf4ib](/images/posts/mpv_HYntJYf4ib.png)

要把这个工具条置顶，具体操作如下：

去c盘找到mpv播放器的配置文件夹，这个配置文件夹地址类似这样子：C:\Users\47664\AppData\Roaming\mpv找到这个路径之后，创建一个新文件夹，名字叫做`lua-settings`，再在这个`lua-settings`文件夹里面创建一个`osc.conf`文件，这个`osc.conf`里面写上如下配置,,然后保存:

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

其他mpv播放器配置，参考Github：[https://github.com/minikui/mpv/tree/mpv/lua-settings](https://github.com/minikui/mpv/tree/mpv/lua-settings)

配置文件说明来源于这篇博客文章：[https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/](https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/)

其他mpv设置，除了参考上面Github别人配置之外，估计只能去看官方的英文文档去研究了，中文资料真的很少。但是这样子设置后，学英语已经够用了。

### 8.美剧制卡的建议

这个anki插件制作视频卡片的快捷键是`键盘B键`，默认是自动分析台词截取视频和音频。如果你自定义截取起始位置和截止位置，就需要按 W键 、E键，分别表示截取的起始位置和截止位置，然后再按B键制卡，它就会根据你指定的起始位置和截止位置来截取视频和音频，包括台词。更多的操作，请自行阅读插件文档：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)，如果具备二次开发能力的话，甚至还可以在这个插件的基础上，自行修改Lua脚本，实现一些自定义的功能。由于篇幅受限，这里不作细究，总之这里的想象空间还是很大的。

![NDSUprculn](/images/posts/NDSUprculn.png)

这种视频制卡的方法，其实跟国外大神们使用的方法基本上一样了，缺点是，还是需要手工查词典。要精确把握台词的中文意思，还得chrome浏览器打开NetFlix官网，登录你的奈飞账号，搜索到这一集，配合Language Reactor插件开启中英文双语字幕，去核对这个句子的中文人工翻译的意思。不要觉得这个过程繁琐，老外制作视频卡也是一样的繁琐。

![Typora_mBBtvdNjUT](/images/posts/Typora_mBBtvdNjUT.png)

![chrome_ggspGiQeqH](/images/posts/chrome_ggspGiQeqH.png)

我这里随便举个例子：

![anki_ziUaGliLMq](/images/posts/anki_ziUaGliLMq.png)

上面这句台词用的是google机器翻译，其实翻译出来的结果是直译的，跟剧情上下文有差距。那些百度网盘分享的美剧，野生字幕组翻译的，来路不明，容易出错。NetFlix这种是人工翻译的，很多不是直译，而是意译，至少是准确把握了剧情上下文，你查字典之后对某些单词进行直译标注也要省力很多。

![chrome_nBOS16mBij](/images/posts/chrome_nBOS16mBij.png)

![chrome_OHCpuhFXTe](/images/posts/chrome_OHCpuhFXTe.png)



刚开始看美剧会遇到很多生词和短语，听不懂，经过大量这种训练和制卡的复习，听力会大幅提升，等到大部分美剧不看字幕都能听懂的时候，口语听力应该就差不多了。随着输入量增加，对各种口语台词越来越熟悉，也就会具备一定的口语输出能力。相信很多看美剧学英语的都有这个成长的经历。Enjoy it！

### 9.参考资料

[http://www.randomhacks.net/substudy/](http://www.randomhacks.net/substudy/) 这篇文章里面的作者，讲到了自己通过看剧学语言的心得体会，值得一看。

[https://learnanylanguage.fandom.com/wiki/Subs2srs](https://learnanylanguage.fandom.com/wiki/Subs2srs)这里提到的方式，是另外一种看剧，挂载字幕的制卡方式，只支持低版本的anki，`Matt vs japan`曾经使用的方法就是这个方法，跟我本文讲解的方法是差不多的，插件都是同一个作者。

[https://mp.weixin.qq.com/s/nJUpWAN42fy0D1NsPewgrg](https://mp.weixin.qq.com/s/nJUpWAN42fy0D1NsPewgrg) 这篇文章来至于微信公众号，是某位IT算法大牛建立的公众号文章，关于如何寻找简单易懂的学习资料的，其中谈论了英语学习的一些观点，我个人觉得比较有意思，所以推荐下这篇文章。
