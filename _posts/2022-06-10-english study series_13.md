---
layout: post
title: 通过美剧学英语_anki如何制卡(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

美剧卡片的制作，我在2020年从youtube看到过，最早来至于[youtube](https://www.youtube.com/watch?v=bbg6ztWecbU)播主`Matt vs japan`，使用mpv+anki制卡，那个时候他是使用日剧动画学日语，他的日语就是依靠刷剧学起来的，我几乎看了他所有视频分享。后来`二语习得理论`的克拉申教授还到过他的youtube频道参加播主的访谈，他是美国人，母语是英语，但是把日语学到了接近日本母语者的水平，他学习日语的5年期间，就待在美国，并没有生活在日语环境中，从这一点上也看得出来，刷剧是营造语言环境的最佳办法(如果你没有待在目标语言国的条件的话)。美剧卡随身携带，随时复习看过的美剧。

mpv+anki添加卡片只需要按下一个快捷键即可搞定，制卡的主要时间是花在“整理知识点”和“完善卡片笔记”上面，这个时间花得也不多，15秒左右一张卡。所以，用anki+mpv工具配合美剧学英语实际成本不高，卡片和笔记整理完之后，平时每天用来刷手机抖音/刷朋友圈的时间,用来复习这些卡片即可。

美剧卡片的复习步骤:复习的时候，卡片的正面是播放美剧片段视频而不显示字幕和做过的笔记，这个时候盲听，看自己是否能够听出来剧中人物的对白，可以帮助锻炼听力。点击卡片之后，显示卡片背面答案，这一面有英文字幕和中文释义/单词笔记，可以起到复习的作用。点击播放按钮，把没有听出来的再听一遍，巩固你的听力。第三遍，跟着单词卡做影子跟读，起到锻炼口语的作用。美剧被这么操作过一波之后，卡片都沉淀到了手机上，打开手机复习即可，不用反复跑回电脑或ipad上去刷剧，用刷卡的方法替代刷剧即可。零碎时间在手机上复习，更节约时间。有整块时间的时候，就在PC电脑或者笔记本上面看新剧制卡，整理笔记。长此以往，你的听力就能够听懂大部分美剧的讲话了，接触不同的材料不断拓展英语的边界。

![66667777](/images/posts/66667777.gif)

有人可能会觉得制卡很枯燥，难于坚持，那可能是没有正反馈导致的。正反馈，就是你能够感觉到你的英语正在进步。而这种进步，是需要建立在循序渐进这个体系上的，也即是如果基础太差，词汇量太低，强行`越级打怪`，反而是痛苦的，无法坚持。还一个就是，要去找那种自己`比较共情`的剧，而不是“别人觉得适合”就合适。刷美剧建议词汇量大于5000，有一定听力基础再进行(可以通过有声书先打基础)。

## 准备工作

配置之前的准备工作:首先说明下我的电脑环境: 我的电脑系统是`window10 pro Version 22H2` (中文界面改为了英文界面)；安装的anki版本是`Anki Version ⁨2.1.56 QT5`(英文界面)，chrome浏览器Version 109.0.5414.75 (Official Build) (64-bit)。

在操作之前，**强烈建议**把文件夹视图调整为：显示文件名后缀；并且电脑开启全局帆樯(或者通过软路由智能分流帆樯)。

如何显示文件名后缀？

进行如下设置，打上勾即可。文件视图，把文件名后缀这个勾选上即可(我的系统设置的是英文界面)。

![QQ_k87NMkPdKG](/images/posts/QQ_k87NMkPdKG.png)



### 1.安装失败的可能原因

如果`chocolatey/mpv/youtube-dl/ffmpeg`某些软件安装失败，请排查是否下面原因。如果一切顺利，请忽略下面所有原因。

1.樯的问题(肉身在樯内，时刻享受着Great Fire Wall特殊照顾的这群人)。大部分人使用的是windows端开启代理app方式帆樯，这种模式可能无法完全代理PowerShell或cmd的这种命令行工具，它们可能还是会走国内线路，导致安装失败。如果遇到这种情况，可能需要设置chocolatey的国内镜像源，这个需要自行百度/google解决。如果你是用软路由方式帆樯(强烈推荐用这种方式)，基本就不存在这个问题，因为软路由如果配置了自动分流规则，会自动接管powershell和cmd这种命令行的国外流量，以及IDM下载的时候，都不需要对代理进行额外设置，家里所有设备只要连接wifi的都可以直接访问google，比较省事，不需要每台设备都去配置帆樯app。想要打造稳定的英文学习环境，推荐用这种方式。

2.系统完整性导致的问题。如果系统是Ghost版本电脑城快速装机的那种，可能会存在某些组件缺失，需要重装系统。(尽量安装[微软官方镜像iso文件](https://www.microsoft.com/zh-cn/software-download/windows10)刻录的windows系统，激活码在[淘宝10元店](https://s.taobao.com/search?q=windows%E6%BF%80%E6%B4%BB&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&spm=a21bo.jianhua.201856-taobao-item.2&ie=utf8&initiative_id=tbindexz_20170306)有售)。

## 安装配置

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

这个ffmpeg安装的时候，可能会被樯，安装的时间较长，请注意。如果肉身在樯外，请忽略。

### 5.安装anki插件

最后是安装插件，这个插件才是关键中的关键。

如果你熟悉anki的话，直接安装这个插件就可以，插件的地址是：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)
插件安装完成之后，重启anki，使用快捷键Ctrl + O直接打开这个插件的菜单界面，然后剩下的工作就是对这个插件进行一些设置，步骤是:1.选择卡片模板，2.配置卡片模板。配置完成之后就可以正常使用了。

![srwyGARJZS](/images/posts/srwyGARJZS.png)

先下载模板，这个模板是跟这个插件配套使用的，是插件作者提供的一个模板，模板文件通过这个地址[https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b](https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b)下载。先把这个模板用熟，等到对anki非常熟悉之后，以后可以根据自己的需要修改这个模板。

模板下载完，你会得到下面这个文件，双击模板运行就自动导入anki了。

![Typora_elu2qwxCnN](/images/posts/Typora_elu2qwxCnN.png)

模板导入到anki后进行下一步设置。

在anki主界面，我们通过按快捷键`Ctrl + O`打开插件配置界面. 插件配置的首界面，有个叫做Type的选项，点击打开Type选择下拉框，弹出来Choose Note Type这个界面，如下图所示。在下拉框中我们选择“`Harry Potter and the Sorcerer's Stone（light theme）`"这个模板。如果你在上一步中没有安装那个模板，这里是看不到这个`Harry Potter and the Sorcerer's Stone（light theme）`模板的。

![F8VkgIxs8z](/images/posts/F8VkgIxs8z.png)

模板选中之后，设置一个Deck，一般我会新建一个Deck专门用来保存美剧卡片，根据你自己的需要选择。我这里是保存到`Just Added`这个Deck里面。字段的配置全部按照我下图②中的配置设置就可以了，这个字段是我经过了摸索和试错得出来的，直接参考我下面字段设置即可，(右边这里的很多字段其实都是无效的)。

![6MWzXM7j8v](/images/posts/6MWzXM7j8v.png)

这些配置全部完成之后，点击ok按钮，然后回到下面那层窗口界面，点击那个界面中的`Open File`，会弹出窗口，要你去选择一个视频文件，去磁盘上面找到一个下载好的NetFlix美剧(要带有srt英文台词的)视频，它就会用mpv自动打开那个视频进行播放了，播放的时候，按下键盘B键，就会触发自动制卡，插件会往你的anki里面插入视频卡片了。w, e ,b 依次按下，可以截取指定区间的视频和字幕。具体查看使用文档说明。我猜测，它的原理大致是这样: open窗口打开一个本地视频的时候，会通过anki插件来调用mpv播放器(因为播放视频是从插件这里发起的)，顺带会把插件中含有的lua脚本装载并初始化到mpv播放器中，播放过程中当你按下B键的时候，mpv播放器跟anki发生交互，自动截取视频卡片/上下文字幕发送到anki。

说明：等所有设置完成了之后，模板自带的Deck可以删掉，删的时候，apkg包导入进来的1000多张卡会被清空(删Deck，不会影响Note Type，因为Note Type只能通过Note Type菜单删除)。

### 6.美剧视频和字幕下载

我使用的方法是通过[FlixGrab+](https://www.flixgrab.com/)付费软件下载NetFlix的视频。

FlixGrab是可以批量下载整个美剧的，如果一个美剧有8季，你只需要粘贴其中任何一集的URL就可以，等FlixGrab解析出来视频的缩略图之后，缩略图上面会出现齿轮样的设置按钮，上面有个`Paste Espisodes`

选项，会把所有集的URL全部粘贴生成出来缩略图，你可以单独对这些缩略图进行设置，分别设置它们的分辨率为720P。默认是最低分辨率432P。推荐全部设置为720P。FlixGrab使用的时候要登录NetFlix Family Member成员，即:登录的时候你需要选择家庭成员子账号图标进入。如果你觉得这个方法可以，也可以分享给你自己的朋友们。如果在FlixGrab中频繁登录或者退出NetFlix账号，可能会导致一些问题，登录缓存cookie可能会存在冲突，导致无法下载视频，请重新删掉FlixGrab，重新安装。一定要彻底删除干净，具体办法是:使用[Everything工具](https://www.voidtools.com/)搜索电脑硬盘中所有跟FlixGrab相关的文件，全部删除干净之后再重装FlixGrab一般都能解决问题。

![POdvvjX7Wc](/images/posts/POdvvjX7Wc.png)



![PotPlayerMini64_ygvqCRi5Yo](/images/posts/PotPlayerMini64_ygvqCRi5Yo.png)

![56754546](/images/posts/56754546.gif)

Flixgrab+是付费版本，去官方网站选择季度付费(50RMB左右)，通过paypal支付即可，也可以选择去淘宝找人代购，接收序列号的邮箱填写你自己的就可以，一个序列号可以绑3台电脑。多人共用更划算。

#### 6.1 NetFlix字幕插件

NetFlix看剧的神器插件，我一直是用[Language Reactor](https://chrome.google.com/webstore/detail/language-reactor/hoombieeljmmljlkjmnheibnpciblicm)，搜索一下chrome插件市场就能找到这个插件，然后它有个导出字幕功能，导出的时候，选择"打印HTML"即可，中英双语字幕会在浏览器页面中完整显示出来。它的功能和Anki美剧制卡可谓是完美结合，也不枉以前持续投入英语自学的研究，该插件有几个关键的地方设置需要注意，详情参考下图:

![dX719tRHQU](/images/posts/dX719tRHQU.png)

​                                                                       (↑双语设置↑)

![vJyfcBxca8](/images/posts/vJyfcBxca8.png)

​                                                                             (↑导出字幕↑)

![chrome_JRG5W5ERzj](/images/posts/chrome_JRG5W5ERzj.png)

​                  （↑如果字幕设置被还原，这里会出现"小扳手"图标，点击之后，会自动恢复到之前的设置↑）

打开的字幕页面，会以`about:blank`地址展示，排版相当工整，体验真的非常棒。展开一个剧集的字幕，搜索和核对字幕都非常方便。由于字幕出自官方校准，所以准确性和质量都有保证。这也是我强烈推荐用NetFlix学美剧的原因。

![chrome_0NhkCqN32N](/images/posts/chrome_0NhkCqN32N.png)



#### 6.2 下载youtube视频

下载youtube英文视频，推荐用IDM工具，IDM全称是Internet Download Manager。下载地址:[Internet Download Manager](https://www.internetdownloadmanager.com/), 这个工具是付费的，性价比特别高，120RMB左右永久版权。

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

使用代理帆樯的时候，IDM如果无法下载，请注意IDM的代理设置:

![IDMan_1aZQPEgESz](/images/posts/IDMan_1aZQPEgESz.png)

![chrome_P42WUXjCil](/images/posts/chrome_P42WUXjCil.png)

IDM的chrome插件安装地址是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek)，不要搞错了，因为市面上有些冒牌插件，也是打着IDM的旗号，容易搞错，这里特别注意下。

![oZmNzWrGq3](/images/posts/oZmNzWrGq3.png)

#### 6.3 快速标记字体颜色

编辑卡片的时候，不同的生词标记不同的颜色，使用[Quick Colour Changing](https://ankiweb.net/shared/info/2491935955)这个anki插件，能快速标记文字颜色。我的Quick Colour Changing插件设置如下:  Alt+4 是标记蓝色，Alt+5是标记橘黄色，Alt+6是标记橙红色。它这个插件的配置文本是Json格式，如果要增加其他快捷键和颜色，增加keys的数组项即可。

```shell
{
    "keys": [
        [
            "#ff557f",
            "Alt+6"
        ],
        [
            "#ffaa00",
            "Alt+5"
        ],
        [
            "#0000ff",
            "Alt+4"
        ]
    ]
}
```

![anki_Pex5ak3DKQ](/images/posts/anki_Pex5ak3DKQ.png)

区分字体颜色之后，做出来的卡片一目了然。也能够更加突出重点。实际使用来看，美剧制作的卡片，难度要比有声书/外刊/新闻这些题材来源的卡片简单太多，而且也更加符合口语习惯，总之一句话: 刷美剧，用它，真香!

### 7.MPV播放器设置

#### 7.1 mpv 播放器的OSC配置

搞定了上面的所有设置后，我们需要优化下mpv播放器的工具条，防止工具条遮挡到字幕，方便欧陆词典或者有道词典鼠标屏幕取词。要实现的最终效果如下：

![mpv_HYntJYf4ib](/images/posts/mpv_HYntJYf4ib.png)

要把这个工具条置顶，具体操作如下：

去c盘找到mpv播放器的配置文件夹，这个配置文件夹地址类似这样子：C:\Users\47664\AppData\Roaming\mpv。快速进入这个路径，可以使用：

![explorer_tQhLY6AveB](/images/posts/explorer_tQhLY6AveB.png)

```shell
%appdata%\mpv
```

使用方式是，快捷键:`win + R`，打开windows的运行窗口，直接输入上面的命令回车即可，进入这个文件夹之后创建一个新文件夹，名字叫做`lua-settings`，再在这个`lua-settings`文件夹里面创建一个`osc.conf`文件，这个`osc.conf`里面写上如下配置,,然后保存即可。

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



### 8.mpv快捷键

这个anki插件制作视频卡片的快捷键是`键盘B键`，默认是自动分析台词截取视频和音频。如果你自定义截取起始位置和截止位置，就需要按 W键 、E键，分别表示截取的起始位置和截止位置，然后再按B键制卡，它就会根据你指定的起始位置和截止位置来截取视频和音频，包括台词。更多的操作，请自行阅读插件文档：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)，如果具备二次开发能力的话，甚至还可以在这个插件的基础上，自行修改Lua脚本，实现一些自定义的功能。由于篇幅受限，这里不作细究，总之这里的想象空间还是很大的。Enjoy it！

### 9.总结

把一个方法用成自己的习惯，持续积累，可能就是最适合自己的方法。成年人业余自学语言，学到比较高水平，大概需要5年时间，全职学也要2年时间。比如:`Matt vs Japan`精通日语花了5年时间，Giovanni Smith通过汉语HSK6考试也花了接近5年时间------新汉语水平考试*HSK*（6级),也就是外国人汉语考试的最高水平。这2个人是把外语学到了应考的最高等级，如果对于我们学英语而言，他们相当于学到了雅思8~9分水准，用的都是anki。如果要借鉴anki这块的经验，他们2位其实都算是成功案例，其在youtube分享的视频，非常值得研究。Anki的DIY能力前所未有的强大，划词制卡和美剧制卡结合，既可以用来看原版英文书，又可以用来刷美剧。而且不用一直换方法，因为方法全在其中了。一套方法贯穿几年都没问题。从有声书到美剧的平滑过渡，几乎没有竞品可以替代anki。体验到英语日渐提升的快感之后，再也不容易被一些英语机构或者培训班或者个人忽悠了。因为，很多培训机构或者个人的方法可能还不如你自己的方法。

![chrome_pngaBEAaeS](/images/posts/chrome_pngaBEAaeS.png)

![chrome_Z5D3bg0Ir0](/images/posts/chrome_Z5D3bg0Ir0.png)



### 10.参考资料

[http://www.randomhacks.net/substudy/](http://www.randomhacks.net/substudy/) (英文文章)这篇文章里面的作者，讲到了自己通过看剧学语言的心得体会，值得一看。

[https://learnanylanguage.fandom.com/wiki/Subs2srs](https://learnanylanguage.fandom.com/wiki/Subs2srs)(英文文章)这里提到的方式，是另外一种看剧挂载字幕的制卡方式，只支持低版本的anki，`Matt vs japan`曾经使用的方法就是这个方法，跟我本文讲解的方法是差不多的，插件都是同一个作者。

[https://mp.weixin.qq.com/s/nJUpWAN42fy0D1NsPewgrg](https://mp.weixin.qq.com/s/nJUpWAN42fy0D1NsPewgrg) 这篇是某位程序员大神写的微信公众号文章。该文章主要以程序员的视角，谈了学习英语的意义。其实它阐述的观点用一句话就可以概括，那就是"天下武功为快不破"。在计算机IT技术层出不穷的当下，如果仅仅是做应用开发，每隔一段时间都要学习很多新技术和新框架/中间件，决定职业竞争力的就是学习速度，`英语足够好，自学速度将超过90%程序员，甚至超过99.99%程序员`这句话是这个程序大神在文中的原话，我也比较认可这句话，并且也实际体会到这句话的意义，因为我大部分技术资料几乎都是通过直接看原版，这给我带来了极高的效率。这就是修炼英语内功对于程序员的意义-----天下武功唯快不破，拼的就是速度。包括自己研究英语自学，也都是看英文视频和原版。其实这个英文的意义，在那本魏剑峰的书的序言有讨论过，书名是《英语高效学习法》(2022年10月出版)，由`恶魔奶爸`作序，序言的标题是`推荐序：学习英语的真正效用`，有兴趣的可以拿来看看这本书。

其他mpv播放器配置，参考Github：[https://github.com/minikui/mpv/tree/mpv/lua-settings](https://github.com/minikui/mpv/tree/mpv/lua-settings)

配置文件说明来源于这篇博客文章：[https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/](https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/)

