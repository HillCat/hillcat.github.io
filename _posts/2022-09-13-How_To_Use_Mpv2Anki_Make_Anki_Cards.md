---
layout: post
title: mpv2anki_make_english_video_card(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

配置之前的准备工作:首先说明下我的电脑环境: 系统是`window10 pro Version 22H2` (英文界面)；安装的anki版本是`Anki Version ⁨2.1.56 QT5`(英文界面)，chrome浏览器Version 109.0.5414.75 (Official Build) (64-bit)。

在操作之前，**强烈建议**把文件夹视图调整为：显示文件名后缀；

文件视图，把文件名后缀这个勾选上即可(英文界面)。

![QQ_k87NMkPdKG](/images/posts/QQ_k87NMkPdKG.png)



## 安装配置

### 1.安装chocolatey

最先要安装的是chocolatey。在windows开始菜单，找到PowerShell，鼠标右键点击**以管理员身份运行**

![chrome_AAa51Nll5h](/images/posts/chrome_AAa51Nll5h.png)

```shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

粘贴并运行上面这一整行代码，即可完成chocolatey的安装。

chocolatey装好之后，输入choco，回车，如下图，看到chocolatey的版本号，即表示安装成功。

![powershell_5G3YUqCTT8](/images/posts/powershell_5G3YUqCTT8.png)

### 2.安装mpv

然后是安装mpv播放器，以管理员权限运行powershell，执行下面命令：

```shell
choco install mpv
```

整个安装过程，它会询问你`是否运行所有脚本`，选择A，回车，运行所有脚本。后面的其他安装都是类似，都会询问你，一般你选A，回车即可。

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

### 5.安装Mpv2Anki插件

插件的地址是：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)，安装Code是：1213145732，直接拿着Code码安装即可。
插件安装完成之后，重启anki。

#### 5.1 模板设置

##### 1.下载和配置模板

对应的模板![explorer_bIIPBr4p5A](/images/posts/explorer_bIIPBr4p5A.png)，下载地址：

链接：https://pan.baidu.com/s/1L_uUocPyQ11932PPbiTnfg?pwd=jzri 
提取码：jzri 

mpv2anki插件字段映射如下

![h5rbR8A0Xb](/images/posts/h5rbR8A0Xb.png)

anki的模板里面最好是预留一些看似没用的字段，比如下面这个Webm_quote和Mp4_quote字段，实际上没有用到，但是为何还是需要放到这里，是因为anki的卡片在播放视频文件的时候，目前iphone端是不支持webm格式的，因为anki使用的是safari浏览器，这个是iphone端还没有开放支持webm导致的，所以必须要在iphone端支持视频播放只能使用mp4。当你导出卡片数据的时候，如果你的模板中没有[sound:something.mp4]这种格式的引用，那么这个something.mp4视频就不会被打包进入apkg包，我们经常会遇到，打包的时候我们的卡片里面的视频文件没有连同一起打包，导致别人引用你的卡片牌组的时候只看到了卡片里面的图片和文字，视频区域是空白的没有得到渲染，而且有时候还无端的会丢失视频，现实白色区域。这个时候就要检查是否是没有引用这个视频导致的。这里说的引用，是指的提供一个冗余的字段，里面写上[sound:something.mp4]或者[sound:something.webm]这种格式内容,那么something.mp4和something.webm在卡片数据打包为apkg包的时候就会连同一起被打包导出来。要不然anki是不认这2个视频文件的。

![zlSOQCwg3Q](/images/posts/zlSOQCwg3Q.png)

##### 2. 视频无法播放问题解决

请修改视频文件名重新制卡，比如："apple.mp4"改为"orange.mp4"再制卡，之前无法播放的卡片删掉重新制作即可。

##### 3. 双字幕映射

双字幕映射，需要英文视频同时有1个英文字幕(en.srt)1个中文字幕(zh.srt)，分开独立的文件。具体的双字幕方法，看官方文档。

![chrome_ewjCGpNFeo](/images/posts/chrome_ewjCGpNFeo.png)

双字幕映射，在看美剧的时候比较有用，比如《绝望主妇》，刷这个剧的时候，默认的字幕是eng.srt和.srt两种，其中.srt里面同时包含了中文和英文，默认播放的时候，mpv和potplayer都会加载这个.srt的字幕。如果是mpv2anki制卡，插件会分开识别en.srt和zh.srt后缀的字幕文件，en.srt中只能有英文，zh.srt中只能有中文。



![explorer_S42dVulphK](/images/posts/explorer_S42dVulphK.png)

实际使用，把eng.srt重命名为en.srt，把.srt重命名为zh.srt并去掉里面的英文字幕即可。《绝望主妇》双字幕的设置如下：

![anki_eIG93lzBJD](/images/posts/anki_eIG93lzBJD.png)

![pTdYdFc0vb](/images/posts/pTdYdFc0vb.png)

这样子最终得到的就是我们需要的效果，我们还可以根据《绝望主妇》量身为它设计一个模板，用来保存前后上下文台词。

![stTpbqlm6g](/images/posts/stTpbqlm6g.png)

#### 5.2 视频压缩为高密度mp3音频

mpv2anki插件作者开发了2款插件。高密度mp3音频的概念是来至于国外这篇视频：“[Optimizing Passive Immersion: Condensed Audio](https://youtu.be/QOLTeO-uCYU)”，本来一集美剧30分钟，可以压缩为一个10分钟的语音mp3，专门用来在通勤路上复习用，这种复习的方式主要是锻炼听力，培养对`人物对话`的敏感度。插件地址：[https://ankiweb.net/shared/info/939347702](https://ankiweb.net/shared/info/939347702)，这个插件提供的方法可以用来把视频转为mp3音频，适合精听精学，搭配anki的视频卡，同时可以训练到听力，口语，阅读。写作部分交给Grammarly和OpenAi的ChartGPT帮助我们批改作文和提升作文的水平。而写作和口语的语料库来源于我们平时制卡积累的卡片，并且这些卡片全文都是可以直接掏出手机搜索或者在电脑上的anki中搜索的。

### 6.美剧视频和字幕下载

下载奈飞视频的工具[FlixGrab+](https://www.flixgrab.com/)，通过季度付费的方法购买即可，一个序列号可以使用3个月，绑定3台电脑。奈飞账号虽然区分国家和地区，但是如果你使用的vpn是可以切换多个国家和地区的话，那么是可以下载到《老友记》，Suits---《金装律师》，Brooklyn Nine-Nine---《神烦警探》,这些剧的原版的，并且字幕也是中文原版和英文原版。中文和英文字幕可以通过Language Reactor插件在developer tools请求的url数据中扒下来，可以批量弄成zh.srt  en.srt文件，基本上中英文双语全自动制卡就搞定了，具体查看本文`6.1.1 提取NetFlix中英文字幕`。

#### 6.0 FlixGrab+

FlixGrab使用大概如下：

![POdvvjX7Wc](/images/posts/POdvvjX7Wc.png)



##### 6.0.1 FlixGrab+无法下载

**第一种原因**是未分配运行权限/网络访问权限导致。

初次打开软件，windows10系统会询问你给与这个软件的网络访问权限和执行权限，如果你没给，那么就会下载超时：

![fxFiovnxAY](/images/posts/fxFiovnxAY.png)



**第二种原因**是NetFlix Cookie冲突导致。

如果在FlixGrab中频繁登录或者退出NetFlix账号/更换了NetFlix账号，可能会导致一些问题。先排除是网络原因。重新粘贴New Paste试试看。如果一直无法下载，请考虑卸载FlixGrab。卸载之后，还需要彻底删除FlixGrab的残留文件，这特别特别特别重要，这里强调3次(我之前就踩过这个坑)。卸载之后，通过使用[Everything工具](https://www.voidtools.com/)搜索电脑硬盘中所有跟FlixGrab相关的文件，全部删除干净之后再重装FlixGrab，然后再把之前的注册FlixGrab，登录NetFlix的步骤都重新操作一遍。



**第三种原因**是FlixGrab出了新版本。

去官方下载新版本，覆盖安装就可以了。原则上NetFlix官方是禁止第三方App下载它们的视频的，会不定期更新这块的漏洞，爬虫和反爬虫之间的较量，会导致双方频繁升级算法。如果突然无法下载视频了，请检查是否官方出了新版本。



#### 6.2 下载youtube视频

IDM全称是Internet Download Manager。下载地址:[Internet Download Manager](https://www.internetdownloadmanager.com/), 这个工具是付费的，终身授权很便宜，推荐人手一份。

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

使用代理帆樯的时候，IDM如果无法下载，请注意IDM的代理设置:

![IDMan_1aZQPEgESz](/images/posts/IDMan_1aZQPEgESz.png)



IDM的chrome插件安装地址是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek)，不要搞错了，因为市面上假冒插件太多。

##### 6.2.1 chrome去广告插件

另外，观看youtube视频，必备的去广告插件:[Adblock](https://chrome.google.com/webstore/detail/adblock-%E2%80%94-best-ad-blocker/gighmmpiobklfepjocnamgkkbiglidom)。

##### 6.2.2 chrome九宫格插件

九宫格插件：[G App Launcher (Customizer for Google™)](https://chrome.google.com/webstore/detail/g-app-launcher-customizer/ponjkmladgjfjgllmhnkhgbgocdigcjm)。

#### 6.3 在线播放youtube视频

如果肉身再国外，可以使用mpv直接播放url链接视频，如果肉身在墙内，还是别用这个了，它是边下载边看的模式，会很卡。

#### 6.4 卡片字体颜色

插件地址：[Quick Colour Changing](https://ankiweb.net/shared/info/2491935955)使用这个anki插件，编辑卡片的时候能快速标记文字颜色，突出学习重点。配置如下：

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
    ],
    [
      "#00aa7f",
      "Alt+8"
    ]
  ]
}
```

![XBarzyeZt4](/images/posts/XBarzyeZt4.png)

​                                                                               (↑苹果手机anki测试效果↑)

插件[Quick Colour Changing](https://ankiweb.net/shared/info/2491935955)自定义的3种颜色标记, 效果如上图。



### 7.MPV播放器设置

#### 7.1 mpv 播放器的OSC配置

搞定了上面的所有设置后，我们需要优化下mpv播放器的工具条，防止工具条遮挡到字幕，其实，当我们把Potplayer播放器的书签功能和mpv整合的时候，大部分的看剧的时间都是使用potplayer而不是使用mpv了，我们使用mpv的唯一的地方就是制作视频单词卡的时候需要mpv播放器。注意：平时大量观看英文节目和电视节目包括美剧的时候，推荐只带英文，不要带中文。看不懂的单词就使用

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

另外：mpv.conf这个文件，基本上没太多作用。我虽然创建了这个文件，但是这个文件里面一般都是留空。在英语刷剧的时候，这个文件用不到。



#### 7.2 播放器字体放大和缩小

快捷键 win + R ，输入如下指令，快速进入mpv配置文件夹

```shell
%appdata%\mpv
```

进入到mpv播放器配置文件夹，创建input.conf文件，写入内容：

```shell
# increase subtitle font size
ALT+k add sub-scale +0.1

# decrease subtitle font size
ALT+j add sub-scale -0.1
```

保存之后，退出mpv播放器，重新打开mpv播放器，即可使用快捷键Alt + j减小字幕，Alt + K 增大字幕。

![explorer_IQgamd3KWJ](/images/posts/explorer_IQgamd3KWJ.png)

#### 7.3 自定义mpv字体颜色和大小

和上面一样，先进入mpv配置文件夹，在mpv.conf文件中输入下面配置：

```powershell
sub-color='#FFFF00' #subtitle color in rgb
sub-shadow-color='#000000' #shadow color 
sub-font='Noto Sans' #set font
sub-bold=yes
sub-font-size=60
sub-pos=95 #subtitle position 5 percent above the bottom of the screen
```

保存即可，退出mpv，重新打开mpv。播放视频的时候，字幕就是黄色了。比较突出显眼，更容易屏幕取词。



#### 7.4 我的mpv配置

如果不想手动配置的麻烦，可以直接使用我已经配置好的配置。

快捷键 win + R ，输入如下指令，快速进入mpv配置文件夹

```shell
%appdata%\mpv
```

进入到mpv播放器配置文件夹，把我提供的这个mpv文件内的所有文件，拷贝到你的mpv文件夹即可。重启mpv播放器就可以生效。

链接：https://pan.baidu.com/s/1VCJNZ1T9g9Od7IlMnpkWMA?pwd=gmzb 
提取码：gmzb 

### 8.mpv快捷键

mpv快捷键参考：[https://cheatography.com/someone/cheat-sheets/mpv-media-player/](https://cheatography.com/someone/cheat-sheets/mpv-media-player/)

这个快捷键的PDF文件，可以在上面这个网址可以下载到。

这个anki插件制作视频卡片的快捷键是`B键`，默认是自动分析台词截取视频和音频。如果你自定义截取起始位置和截止位置，就需要按 W键 、E键，分别表示截取的起始位置和截止位置，然后再按B键制卡，它就会根据你指定的起始位置和截止位置来截取视频和音频，包括台词。更多的操作，请自行阅读插件文档：[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)，如果具备二次开发能力的话，甚至还可以在这个插件的基础上，自行修改Lua脚本，实现一些自定义的功能。由于篇幅受限，这里不作细究，总之这里的想象空间还是很大的。

#### 8.1 游戏手柄

甚至你觉得这样子用快捷键不爽，可以使用游戏手柄(北通牌的手柄，把震动马达的排线拆掉使用，因为`北通手柄`开机的时候都会震动,我都是用螺丝刀拆开手柄，把震动马达的排线拔掉的)，手柄键映射到键盘组合键上，这样子就不需要那么累。游戏手柄采用USB那种，映射软件使用:[https://github.com/AntiMicroX/antimicrox](https://github.com/AntiMicroX/antimicrox)，之前阅读有声书和原版书的时候，我复习anki卡片就是使用游戏手柄，这个映射软件可以把2个组合键，映射手柄上的1个键。还是比较省力的。超过1000张卡要复习，用手柄会很快。当你遇到这个问题的时候，希望可以想到还有这么个方法。

Enjoy it！

### 9.Anki窗体置顶

在编辑Anki卡片的时候，由于我们已经采用了非常快速的视频卡片制作方式，在编辑的时候我们一般希望讲卡片的预览部分置顶，同时也不影响编辑。那么可以使用Ctrl + Space 空格的方式选中一个窗口，让其置顶，然后我们在编辑Anki视频卡片的同时，还不影响我们预览每一张卡片。

![33KIbtpgAm](/../../hillcat.github.io/images/posts/33KIbtpgAm.png)

默认情况下左侧这个预览窗口会隐藏(当我们编辑右侧的时候)。置顶的方法

参考：
https://www.minitool.com/news/chrome-always-on-top.html

![Obsidian_bgTA7HNFnN](/../../hillcat.github.io/images/posts/Obsidian_bgTA7HNFnN.png)
安装AutoHotKey之后，在桌面创建一个Always on Top的AutoHotKey脚本文件，里面写入如下内容：

```shell
#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.
^SPACE::  Winset, Alwaysontop, , A
```
保存之后，双击运行，电脑的托盘中就会出现AutoHotKey正在运行的图标(H标志)，这个时候，选中Chrome窗口，ctrl + space   就能把chrome窗体置顶，ctrl + space再按下，取消置顶。这个脚本可以控制任何窗口置顶。我们利用这个脚本就可以置顶Anki的窗口，在编辑和整理视频英文笔记的时候进入一种全屏的沉浸式编辑体验中。
![Obsidian_cZkRHXJkAU](/../../hillcat.github.io/images/posts/Obsidian_cZkRHXJkAU.png)

### 10.总结

把一个方法用成自己的习惯，持续积累，可能就是最适合自己的方法。成年人业余自学语言，学到比较高水平，大概需要5年时间，全职学也要2年时间。比如:`Matt vs Japan`精通日语花了5年时间，他以前学中文的时候的视频:[https://youtu.be/670q5RXp26w](https://youtu.be/670q5RXp26w)，`Giovanni Smith`通过汉语HSK6考试也花了接近5年时间------新汉语水平考试*HSK*（6级),也就是外国人汉语考试的最高水平。这2个人是把外语学到了应考的高等级，相当于雅思8~9分。我不确定anki是不是好工具，但至少几年用下来，没有更换过其他工具(直到我听力能够听懂70%油管的英文视频的时候，这个时候我的主力单词复习工具才转为[Reverso](https://context.reverso.net/translation/))。初级阶段到初级到中级阶段使用Anki可以较为快速积累单词，但是到了中后期听力慢慢提升上来之后，不再是以阅读积累单词了，这个时候变为以看国外英文视频不带中文字幕的方式来学习英语，这个时候就要慢慢换为Reverso，因为anki的复杂度以及太过于重量级，和你已经强大的听力能力不匹配，就像一个强大的发动机引擎需要一个强大的变速箱一样，当听力变得强大之后，Reverso的效率会更大，并且这个时候慢慢开始会不自主进行写作和口语输出了。增加Reverso这个工具的原因，来至于这个Zoe的视频：[在语言学习过程中如何高效做笔记?](https://www.youtube.com/watch?v=h3PQM_WS5eA&ab_channel=Zoe.languages)，当然这个视频里面我是可以裸听不看字幕听懂，因为没有生词。特别是听力提升之后，其实，学习方法和配套工具自然会发生变化和调整。主要是参考国外高手们的经验和方法分享。

关于Anki，其实又很多高手介绍过使用体验，Matt在他的二语习得过程中总结过anki的角色定位，视频地址:[The Role of the SRS](https://youtu.be/wrBFhsnBQ2k)。本篇主要是介绍美剧的辅助工具。网络上也有类似的方案，但是比较零散，本篇融合了我自己的经验在其中，希望刷剧的群友参考。以后实践过程中总结的心得体会，我会继续发布在本网站的English板块中。

![chrome_pngaBEAaeS](/images/posts/chrome_pngaBEAaeS.png)

![chrome_Z5D3bg0Ir0](/images/posts/chrome_Z5D3bg0Ir0.png)



备注：youtube上面绝大部分二语习得者的视频我都看过，还有很多没有在这里列出来。但是从这些人的经验来看，有些人是本身在目标语言所在国待过半年以上的，有些是跟母语者接触过，有些是请了母语者为老师，完全没有接触母语者自学成才的很少，屈指可数。但无法否认，自身的努力还是起到决定性作用的。

<span id="jump">------------</span>

### 10.Anki插件列表

下面这里为了方便，这是我安装的插件的Code，可以直接拿过去使用：

1.`Adjust Sound Volume` 2123044452

2.`Advanced Browser` 874215009

3.`Always On Top` 1760080335

4.`Anki Zoom` 538879081

5.`AnkiConnect` 2055492159

6.`Batch Editing` 291119185

7.`BetterSearch` 1052724801

8.`Customize Keyboard Shortcuts` 24411424

9.`Duplicate and Reorder` 1114271285

10.`Google Translate` 1536291224

11.`link Cards Notes and Preview them in extra window` 1423933177

12.`Set Font Size` 651521808

13.`True Retention` 613684242

14.`FSRS4Anki Helper` 759844606

15.`AnkiWebView Inspector` 31746032

16.`Create subs2srs cards with mpv video player`  1213145732

17.`Quick Colour Changing`  2491935955

18.`AwesomeTTS - Add speech to your flashcards`  1436550454

19.`paste plain/unformatted text`  107041104

20.`Review Heatmap` 1771074083

21.`Advanced copy fields`1898445115

这些插件的官方链接地址，需要去ankiweb addons页面去寻找，[https://ankiweb.net/shared/addons/2.1](https://ankiweb.net/shared/addons/2.1), Ctrl + F，搜索插件名即可，插件的使用方法基本都在插件页面有详细介绍。大部分插件从名字就能知道它的功能。

paste plain/unformatted text:这个插件主要场景是，当你从网络中复制粘贴文字的时候，那些文字带有特殊的颜色或者超级连接，你需要格式化这些文本的时候，可以使用这个插件，这个插件是有快捷键的，需要自己config配置修改快捷键，常规情况下anki格式化粘贴用到的快捷键是ctrl shift v,很多时候这个功能没用，使用这个插件之后，比如，设置快捷键为ctrl p， 那么当你复制了一个带有颜色标记的文本，粘贴到anki里面，或者是从anki卡片的字段之间挪动文本的时候，希望文本不要带有颜色，那么复制了文本之后使用ctrl p粘贴即可，粘贴到输入框中的文本就是不带颜色的，这种文本，英文里面叫做raw text。

### 11.插件初始化

Anki的很多插件的配置都是通过config菜单配置的，有部分的插件需要自己研究进行设置。最常见的就是Asometts插件，这些插件的使用建议都尽量使用英文的材料来学习使用。因为anki本身的模板机制多，需要js,html,css知识，另外还需要掌握anki这么多插件的使用方法，所以不是短期之内可以全部搞定的，况且这个东西需要有一定的研究能力。研究材料很多都是英文的，所以无形中又给anki初级使用者造成门槛，而使用anki的初级者本身英语就不是很高段位，所以这就造成恶性循环，使用anki的人无法普及。

![EbZSNPwe9n](/images/posts/EbZSNPwe9n.png)

### 12.参考资料

[http://www.randomhacks.net/substudy/](http://www.randomhacks.net/substudy/) (英文文章)这篇文章里面的作者，讲到了自己通过看剧学语言的心得体会，值得一看。

[https://learnanylanguage.fandom.com/wiki/Subs2srs](https://learnanylanguage.fandom.com/wiki/Subs2srs)(英文文章)这里提到的方式，是另外一种看剧挂载字幕的制卡方式，只支持低版本的anki，`Matt vs japan`曾经使用的方法就是这个方法，跟我本文讲解的方法是差不多的，插件都是同一个作者。

其他mpv播放器配置，参考Github：[https://github.com/minikui/mpv/tree/mpv/lua-settings](https://github.com/minikui/mpv/tree/mpv/lua-settings)

配置文件说明来源于这篇博客文章：[https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/](https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/)

