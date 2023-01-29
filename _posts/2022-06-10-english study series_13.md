---
layout: post
title: mpv2anki插件的使用(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

配置之前的准备工作:首先说明下我的电脑环境: 系统是`window10 pro Version 22H2` (英文界面)；安装的anki版本是`Anki Version ⁨2.1.56 QT5`(英文界面)，chrome浏览器Version 109.0.5414.75 (Official Build) (64-bit)。

在操作之前，**强烈建议**把文件夹视图调整为：显示文件名后缀；

如何显示文件名后缀？

进行如下设置，打上勾即可。文件视图，把文件名后缀这个勾选上即可(我的是英文界面)。

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

![G7muSzi8rG](/images/posts/G7muSzi8rG.png)

##### 2. 视频无法播放问题解决

请修改视频文件名重新制卡，比如："apple.mp4"改为"orange.mp4"再制卡，之前无法播放的卡片删掉重新制作即可。

##### 3. 双字幕映射

双字幕映射，需要英文视频同时有1个英文字幕1个中文字幕，分开独立的文件。具体的双字幕方法，看官方文档。

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

下载奈飞视频的工具[FlixGrab+](https://www.flixgrab.com/)，通过季度付费的方法购买即可，一个序列号可以使用3个月，绑定3台电脑。奈飞账号虽然区分国家和地区，但是如果你使用的vpn是可以切换多个国家和地区的话，那么是可以下载到《老友记》，Suits---《金装律师》，Brooklyn Nine-Nine---《神烦警探》,这些剧的原版的，并且字幕也是中文原版和英文原版。就完全不需要去taobao或者百度网盘找那些野生字幕组了。奈飞的中文字幕提取需要经过格式化处理，通过Language Reactor插件打印html格式复制到剪切板的Raw Text经过自己编写的脚本处理格式化之后，可以批量弄成zh.srt文件，基本上中英文双语全自动制卡就搞定了。

#### 6.0 FlixGrab+

FlixGrab使用大概如下：

![POdvvjX7Wc](/images/posts/POdvvjX7Wc.png)



##### 6.0.1 FlixGrab+无法下载

**第一种原因**是未分配运行权限/网络访问权限导致。

初次打开软件，windows10系统会询问你给与这个软件的网络访问权限和执行权限，如果你没给，那么就会下载超时：

![fxFiovnxAY](/images/posts/fxFiovnxAY.png)



**第二种原因**是NetFlix Cookie冲突导致。

如果在FlixGrab中频繁登录或者退出NetFlix账号，可能会导致一些问题。先排除是网络原因。重新粘贴New Paste试试看。如果一直无法下载，请考虑卸载FlixGrab。卸载之后，还需要彻底删除FlixGrab的残留文件，这特别特别特别重要，这里强调3次(我之前就踩过这个坑)。卸载之后，通过使用[Everything工具](https://www.voidtools.com/)搜索电脑硬盘中所有跟FlixGrab相关的文件，全部删除干净之后再重装FlixGrab，然后再把之前的注册FlixGrab，登录NetFlix的步骤都重新操作一遍。



**第三种原因**是FlixGrab出了新版本。

去官方下载新版本，覆盖安装就可以了。原则上NetFlix官方是禁止第三方App下载它们的视频的，会不定期更新这块的漏洞，爬虫和反爬虫之间的较量，会导致双方频繁升级算法。如果突然无法下载视频了，请检查是否官方出了新版本。

#### 6.1 NetFlix字幕插件

NetFlix看剧的神器插件，我一直是用[Language Reactor](https://chrome.google.com/webstore/detail/language-reactor/hoombieeljmmljlkjmnheibnpciblicm)，搜索一下chrome插件市场就能找到这个插件，然后它有个导出字幕功能，导出的时候，选择"打印HTML"即可，中英双语字幕会在浏览器页面中完整显示出来，即便下载不到srt格式的中文人工字幕，也可以使用这个打印的字幕，用工具生成中文的str字幕。从而制作中英文双语卡片。

![dX719tRHQU](/images/posts/dX719tRHQU.png)

​                                                                       (↑双语设置↑)

![vJyfcBxca8](/images/posts/vJyfcBxca8.png)

​                                                                             (↑导出字幕↑)

![chrome_JRG5W5ERzj](/images/posts/chrome_JRG5W5ERzj.png)

​                  （↑如果字幕设置被还原，这里会出现"小扳手"图标，点击之后，会自动恢复到之前的设置↑）

打开的字幕页面，会以`about:blank`地址展示，排版相当工整，体验真的非常棒。展开一个剧集的字幕，搜索和核对字幕都非常方便。由于字幕出自官方校准，所以准确性和质量都有保证。

![chrome_0NhkCqN32N](/images/posts/chrome_0NhkCqN32N.png)



#### 6.2 下载youtube视频

IDM全称是Internet Download Manager。下载地址:[Internet Download Manager](https://www.internetdownloadmanager.com/), 这个工具是付费的，终身授权很便宜，推荐人手一份。

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

使用代理帆樯的时候，IDM如果无法下载，请注意IDM的代理设置:

![IDMan_1aZQPEgESz](/images/posts/IDMan_1aZQPEgESz.png)



IDM的chrome插件安装地址是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek)，不要搞错了，因为市面上假冒插件太多。

##### 6.2.1 去广告插件

另外，观看youtube视频，必备的去广告插件:[Adblock](https://chrome.google.com/webstore/detail/adblock-%E2%80%94-best-ad-blocker/gighmmpiobklfepjocnamgkkbiglidom)。

##### 6.2.2 九宫格插件

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

搞定了上面的所有设置后，我们需要优化下mpv播放器的工具条，防止工具条遮挡到字幕，方便欧陆词典或者有道词典鼠标屏幕取词。注意：看剧只带英文，不要带中文。

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

### 9.总结

把一个方法用成自己的习惯，持续积累，可能就是最适合自己的方法。成年人业余自学语言，学到比较高水平，大概需要5年时间，全职学也要2年时间。比如:`Matt vs Japan`精通日语花了5年时间，他以前学中文的时候的视频:[https://youtu.be/670q5RXp26w](https://youtu.be/670q5RXp26w)，`Giovanni Smith`通过汉语HSK6考试也花了接近5年时间------新汉语水平考试*HSK*（6级),也就是外国人汉语考试的最高水平。这2个人是把外语学到了应考的高等级，相当于雅思8~9分。我不确定anki是不是好工具，但至少几年用下来，没有更换过其他工具，学习的连贯性和一致性得到了延续。Matt在他的二语习得过程中总结过anki的角色定位，视频地址:[The Role of the SRS](https://youtu.be/wrBFhsnBQ2k)。本篇主要是介绍美剧的辅助工具。网络上也有类似的方案，但是比较零散，本篇融合了我自己的经验在其中，希望刷剧的群友参考。以后实践过程中总结的心得体会，我会继续发布在本网站的English板块中。

![chrome_pngaBEAaeS](/images/posts/chrome_pngaBEAaeS.png)

![chrome_Z5D3bg0Ir0](/images/posts/chrome_Z5D3bg0Ir0.png)



备注：youtube上面绝大部分二语习得者的视频我都看过，还有很多没有在这里列出来。但是从这些人的经验来看，有些人是本身在目标语言所在国待过半年以上的，有些是跟母语者接触过，有些是请了母语者为老师，完全没有接触母语者自学成才的很少，屈指可数。但无法否认，自身的努力还是起到决定性作用的。

<span id="jump">------------</span>

### 10.我安装的插件

下面这里为了方便，我已经准备好了19个插件的Code，可以直接拿过去使用：

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

这些插件的官方链接地址，需要去ankiweb addons页面去寻找，[https://ankiweb.net/shared/addons/2.1](https://ankiweb.net/shared/addons/2.1), Ctrl + F，搜索插件名即可，插件的使用方法基本都在插件页面有详细介绍。大部分插件从名字就能知道它的功能。

paste plain/unformatted text:这个插件主要场景是，当你从网络中复制粘贴文字的时候，那些文字带有特殊的颜色或者超级连接，你需要格式化这些文本的时候，可以使用这个插件，这个插件是有快捷键的，需要自己config配置修改快捷键，常规情况下anki格式化粘贴用到的快捷键是ctrl shift v,很多时候这个功能没用，使用这个插件之后，比如，设置快捷键为ctrl p， 那么当你复制了一个带有颜色标记的文本，粘贴到anki里面，或者是从anki卡片的字段之间挪动文本的时候，希望文本不要带有颜色，那么复制了文本之后使用ctrl p粘贴即可，粘贴到输入框中的文本就是不带颜色的，这种文本，英文里面叫做raw text。

### 11.参考资料

[http://www.randomhacks.net/substudy/](http://www.randomhacks.net/substudy/) (英文文章)这篇文章里面的作者，讲到了自己通过看剧学语言的心得体会，值得一看。

[https://learnanylanguage.fandom.com/wiki/Subs2srs](https://learnanylanguage.fandom.com/wiki/Subs2srs)(英文文章)这里提到的方式，是另外一种看剧挂载字幕的制卡方式，只支持低版本的anki，`Matt vs japan`曾经使用的方法就是这个方法，跟我本文讲解的方法是差不多的，插件都是同一个作者。

其他mpv播放器配置，参考Github：[https://github.com/minikui/mpv/tree/mpv/lua-settings](https://github.com/minikui/mpv/tree/mpv/lua-settings)

配置文件说明来源于这篇博客文章：[https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/](https://bigdata404.wordpress.com/2017/07/09/mac%E7%9C%8B%E7%89%87%E7%BB%88%E6%9E%81%E5%A7%BF%E5%8A%BF%EF%BC%8Dmpv/)

