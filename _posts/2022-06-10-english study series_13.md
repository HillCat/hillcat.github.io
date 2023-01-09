---
layout: post
title: 通过美剧学英语_anki如何制卡(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

本文主要介绍看美剧制作单词卡片。尝试过看美剧学英语的人应该有一些挫折感。那就是美剧，整理知识点和复习，是一个很难落地实施的东西。大部分人看剧的时候，看过了基本就忘记了。如果要他反复看一个剧很多遍，他又感觉太枯燥太浪费时间，见效也很慢。如果你把一个美剧里面的重点地方全部做成视频卡片，就能够克服这些问题，并且很多剧只需要看2~3遍就差不多了，剩下的就是拿着手机刷这些知识点即可。如果你有使用anki单词卡的大幅度提升单词量的过往经历，就一定能体会到这其中的妙处。

看美剧制作单词卡片的目的是为了做笔记增强记忆，把经典的句子摘抄下来，把重要内容记录到卡片上，使用零碎时间在手机上复习这些重点内容，因为这种卡片会带上视频和语音，复习这些美剧卡片的时候，可以模拟雅思托福考试场景，只听一遍，要能过够完整反应出整个台词大意，通过这样来锻炼我们对于英语口语的敏感度和注意力。这是有声书、外刊这种平面载体无法做到的。很多词不接美剧，靠书面载体学不来。书面阅读词汇都好克服，最难改变的是英语思维，特别是口语思维，如果能够掌握美国人的说话习惯和思维，用美国人的口语思维去组织语言，那么口语输出和听力就有了可以模仿的对象。包括做跟读训练，我们复习这些卡片的时候都可以做跟读训练。其中的好处，这里就不赘述了，有anki制卡经验的自然懂我说的是什么意思。

下面是一张我制作好的美剧卡片。美剧卡我之前有用Sharex制作过，由于制作效率太低，这类卡片在我的卡片库中数量不多，有了这个插件之后，就可以大规模看剧了。选剧的2个标准是：1.大量人物对话，2.题材生活化。

![66667777](/images/posts/66667777.gif)

我的环境：window10 pro Version 22H2 (中文界面改为了英文界面)；Anki Version ⁨2.1.55 QT5(英文界面)。

在操作之前，**强烈建议**把文件夹视图调整为：显示文件后缀。

如何显示文件名后缀？

进行如下设置，打上勾即可。任意进入一个文件夹，在顶部菜单就能找到这个，视图，把文件名后缀，这个勾选上即可。因为我系统是设置成了英文，如果是中文，应该是显示的中文菜单。

![QQ_k87NMkPdKG](/images/posts/QQ_k87NMkPdKG.png)



## mpv anki视频制卡

### 1.安装chocolatey

因为安装mpv播放器和youtube-dl和ffmpeg都需要通过chocolatey安装，所以最先要安装的是chocolatey：

这里提及到的所有软件的安装，都是在管理员权限之下进行。

chocolatey官方文档强烈建议用户采用离线安装的方式,如果你发现你电脑windows安装chocolatey失败，或者无法联网的报错，一般都是因为没有开启全局帆樯导致的，所以一定要能够帆樯才行。如果你已经是在国外，没有网络访问限制，那么安装这些软件的速度都应该是飞快的。

chocolatey如何安装，文档如下：

[https://docs.chocolatey.org/en-us/choco/setup](https://docs.chocolatey.org/en-us/choco/setup)

按照上面地址的文档说明，chocolate安装方式有2种，一种是通过cmd安装，一种是powershell方式安装。选择其中1种即可.这里我使用第二种方式PowerShell安装Chocolatey：

在windows开始菜单，找到PowerShell以管理员方式打开，粘贴并执行下面命令：

```shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

![KUGatcqZKF](/images/posts/KUGatcqZKF.png)



chocolatey安装好之后，输入choco，回车，如下图，如果看到没有报错，即表示安装成功。

![powershell_5G3YUqCTT8](/images/posts/powershell_5G3YUqCTT8.png)

### 2.安装mpv

我这里使用choco方式安装，以管理员权限运行powershell，执行下面命令：

```shell
choco install mpv
```

### 3.安装youtube-dl

同样也是通过choco安装，powershell管理员权限，执行下面命令：

```shell
choco install youtube-dl
```


### 4.安装ffmpeg

也是通过powershell管理员权限，执行下面指令：

```shell
choco install ffmpeg
```

### 5.安装anki插件

如果你熟悉anki的话，直接安装这个插件就可以，随便摸索一下，就能搞定美剧制卡了。如果不太熟悉anki，会写那么继续看我下面的配置步骤。

先去这里拿到这个插件的ID，把插件安装上：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)
插件安装完成之后，重启anki，使用快捷键Ctrl + O可以直接打开这个插件的菜单界面，然后剩下的工作就是对这个插件的界面进行一些设置，总的思路是:先选定一个卡片模板，然后对这个卡片模板的字段进行设置，跟我们以前划词制卡差不多的套路。

![srwyGARJZS](/images/posts/srwyGARJZS.png)

在进行设置之前，我们需要下载一个模板，这个模板是跟这个插件配套使用的，是插件作者提供的一个模板，模板文件通过这个地址[https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b](https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b)下载。先把这个模板用熟，等到对anki非常熟悉之后，以后可以根据自己的需要，修改这个模板。暂时为了熟悉美剧制卡，先用这个插件的配套模板熟悉下套路。

模板下载完，你会得到下面这个文件，双击模板运行就自动导入anki了。

![Typora_elu2qwxCnN](/images/posts/Typora_elu2qwxCnN.png)

模板导入到anki后进行下一步设置。

在anki主界面，我们通过按快捷键`Ctrl + O`打开插件配置界面. 插件配置的首界面，有个叫做Type的选项，点击打开Type选择下拉框，弹出来Choose Note Type这个界面，如下图所示。在下拉框中我们选择“`Harry Potter and the Sorcerer's Stone（light theme）`"这个模板。如果你在上一步中没有安装那个模板，这里是看不到这个`Harry Potter and the Sorcerer's Stone（light theme）`模板的。

![F8VkgIxs8z](/images/posts/F8VkgIxs8z.png)

模板选中之后，设置一个Deck，意思就是生成的美剧卡片，你想把它保存到哪个Deck里面，一般我会新建一个Deck专门用来保存美剧卡片，根据你自己的需要选择。我这里是保存到`Just Added`这个里面。字段的配置全部按照我下图②中的配置设置就可以了。

![6MWzXM7j8v](/images/posts/6MWzXM7j8v.png)

这些配置全部完成之后，点击ok按钮，然后回到下面那层窗口界面，点击那个界面中的`Open File`，会弹出窗口，要你去选择一个视频文件，去磁盘上面找到一个下载好的NetFlix美剧(带有英文台词的)视频，它就会用mpv自动打开那个视频进行播放了，播放的时候，按下键盘B键，就会触发自动制卡，anki的这个制卡插件就会往你的anki里面插入视频卡片了。

### 6.美剧视频和字幕下载

我使用的方法是通过[FlixGrab+](https://www.flixgrab.com/)付费软件下载NetFlix的视频。

FlixGrab是可以批量下载整个美剧的，如果一个美剧有8季，你只需要粘贴其中任何一季的任何一集的URL就可以，等FlixGrab解析出来视频的缩略图之后，缩略图上面会出现齿轮样的设置按钮，上面有个`Paste Espisodes`

选项，会把所有季的所有集的URL全部粘贴生成出来，你可以对单独的这些集进行设置，分别设置它们的分辨率为720P。默认是最低分辨率。推荐全部设置为720P。FlixGrab+使用的时候会有些坑，登录的时候需要使用NetFlix账号登录，登录的时候你需要选择家庭成员子账号图标进入，如果发现有异常搞不定的，可以发消息给我，因为我踩了一些坑，可以分享一些经验。

![POdvvjX7Wc](/images/posts/POdvvjX7Wc.png)



![PotPlayerMini64_ygvqCRi5Yo](/images/posts/PotPlayerMini64_ygvqCRi5Yo.png)

![56754546](/images/posts/56754546.gif)

flixgrab+是付费版本，去官方网站选择季度付费，通过paypal支付即可，paypal在国内可以绑定借记银行卡。一个季度是50RMB左右费用，可以绑定3台电脑。支付成功之后，它会往你指定的邮箱发送序列号，如下：

![nQmIpqX0TC](/images/posts/nQmIpqX0TC.png)

![chrome_vueAJb2RC8](/images/posts/chrome_vueAJb2RC8.png)

目前我只注册了1台电脑。其实还有2个名额，有需要的朋友可以共用序列号。或者你也可以找几个朋友一起学美剧，共用账号。NetFlix账号也是可以租用共用的，一个NetFlix账号可以共用3~5个人，电报群或者淘宝找人去租用NetFlix账号即可。通过美剧训练自己的听力，训练到不需要开字幕能听懂大部分美剧，基本上听力这块也就差不多了。

看NetFlix的神器插件：chrome浏览器的Language Reactor插件，推荐一定安装。开启双语字幕的方法如下：

![SdFBfGLJSd](/images/posts/SdFBfGLJSd.png)

![chrome_TWtorDcc79](/images/posts/chrome_TWtorDcc79.png)

这个Language Reactor插件还有很多其他功能，比如单词分级`Set Vocabulary Level`。可以让你提前预览到这个剧的生词分布情况，用来判断一个剧的难度。有声书分级阅读的策略，同样也可以用到美剧这里。

![chrome_nvV5g42HPi](/images/posts/chrome_nvV5g42HPi.png)

除了NetFlix美剧，还可以看youtueb上面的视频，下载youtube视频和英文字幕，我一般采用这个IDM工具下载:[Internet Download Manager](https://www.internetdownloadmanager.com/), 这个工具也是付费的，比较便宜，大概120RMB左右，永久使用，用过的人都说好。

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

![chrome_P42WUXjCil](/images/posts/chrome_P42WUXjCil.png)

IDM对应的chrome插件是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek),不要搞错了插件，很多人第一次使用的时候经常搞错IDM对应的chrome插件。这个IDM插件，可以下载英文字幕，分辨率这些都是可选的，非常方便。

![oZmNzWrGq3](/images/posts/oZmNzWrGq3.png)

### 7.MPV播放器设置

#### 7.1 mpv 播放器的OSC配置

搞定了上面的所有设置hi后，我们需要优化下mpv播放器的工具条，让它置顶，这样子学美剧的时候，屏幕取词，就不会让工具条遮挡到字幕。要实现的最终效果如下：

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

美剧学英语的方法并不适合那些英语基础很差的人，因为看美剧，我这里都是没有中文字幕的，我都是直接开英文字幕来看，遇到不懂的单词就按键盘B键，录入到anki里面，屏幕取词，搞懂生词，之后整个台词的翻译，要去Netflix网页中查这个剧集的中文台词。简而言之就是，本地播放这一集的时候，网页中也开着这一集暂停。具体设置在接下来的部分有讲到。

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
