---
layout: post
title: 如何解决youtube字幕不兼容anki的问题(14)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---



### 美剧卡片对口语输出的作用

这些卡片，之后可以用来做口语输出造句的时候用得上，比如，我记不起来“改天”这个词怎么造句了，可以掏出手机，打开anki，在视频卡片中搜索到“改天”这个中文，就会搜到之前制作过的卡片，查到这个卡片，就能查到视频场景，和以前做过的笔记。并且很快能够模仿出来。如果看过大量的美剧，或者youtube，积累了大量的口语句型或者短语，在要造句的时候想不起来，就可以通过中文来搜索。后期，我们写作或者口语输出训练的时候，就可以利用上这些笔记和卡片，查找起来也方便。慢慢的，这些卡片就会转化被我们吸收，成为输出语料。

![7778899555](/images/posts/7778899555.gif)

### youtube字幕问题

在我本博客English板块[第13篇文章](https://cs-cn.top/2022/06/10/english-study-series_13/)里面，介绍了anki用来学习美剧的方法。其中有个问题，就是美剧无法解决20分钟这种不间歇口语表达的问题，一般的解决思路就是去youtube寻找一个母语者去模仿。但是在我们模仿这个母语者的过程中，我们如果要做笔记，放到手机上面复习，有点难实现。主要的困难在于youtube采用了Google自己的字幕标准，导出来的字幕格式和NetFlix那种不一样，导致我们使用mpv2anki制作视频卡片的时候，是没办法针对youtube的视频的。在github中存在一个python项目，就是专门针对youtube生成字幕的。这个AI生成youtube英文字幕是基于OpenAi公司的Whisper库。不过Whisper库更新很快，yt-whisper一直有报错。

[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)

使用这个工具如果能够生成兼容性更好的字幕，那么问题就迎刃而解了。如果它生成出来的英文字幕，可以完美兼容mpv2anki插件，那么English板块[第13篇](https://cs-cn.top/2022/06/10/english-study-series_13/)介绍的那个方法就可以无缝用在youtube视频上面。



### yt-whisper在windows10安装过程

首先确保你的windows10电脑已经安装了chocolatey这个软件包管理工具。如果不清楚怎么安装的，可以看我English系列的第13篇文章，里面有详细介绍怎么安装chocolatey. 有了这个chocolatey之后，安装其他工具就会方便很多。

我们需要给windows10安装python3.执行下面语句：不要使用默认指令`choco install python`，默认指令会安装python3的最新版本，后面安装whisper会提示版本过高安装不了。这里安装python3.9版本即可。

```shell
choco install python39
```

然后安装pip, 因为python3自带了pip，所以这里只是升级一下pip：

```shell
python -m pip install -U pip
```

然后是安装yt-dlp：

```shell
python -m pip install -U yt-dlp
```



创建python虚拟环境：

创建python虚拟环境，参考视频：[https://www.youtube.com/watch?v=HSVjz4FPKzM&t=67s&ab_channel=cmoorelabs](https://www.youtube.com/watch?v=HSVjz4FPKzM&t=67s&ab_channel=cmoorelabs)

这个视频只是作为一个参考，我这里说明下，这里要创建python虚拟环境的原因，因为OpenAi这个whisper需要运行在python环境下面，要有个虚拟环境。

创建虚拟机环境之前，先要知道你自己的当前账户名，如果你是Administrator登录的，那么在C盘，找到用户目录，再进去用户目录下面，会看到你当前登录用户名的文件，进入之后，创建一个venv文件夹。比如我当前电脑的用户账户是47664.我会在这个路径下面先创建一个venv文件夹，如下：

![OelKR2H5xT](/images/posts/OelKR2H5xT.png)

然后根据我电脑账户路径，执行下面的指令，它会往我的这个文件夹下面写入很多python文件：

```shell
python -m venv C:\Users\47664\venv
```

执行上面这个指令的时候，记得把47664替换为你自己的电脑登录账户。执行完上面指令，会发现这个文件夹多了很多文件：

![explorer_8zuIuHD57x](/images/posts/explorer_8zuIuHD57x.png)

最为关键的一步来了，千万别弄错了：我们需要在命令行中去执行这个activate.bat程序,目的是为了开启python虚拟化环境，怎么做呢？

![swv9F06BMY](/images/posts/swv9F06BMY.png)

最好的办法就是先复制Scripts文件夹所在位置的路径：如下，复制这个Scripts所在位置的整个路径全部复制下来，`C:\Users\47664\venv\Scripts`,其实就是直接找你电脑里面C盘的那个Scripts目录复制即可，直接复制你自己的Scripts路径，你自己实际路径是什么就复制什么。Scripts目录如下：去找C盘下面的用户目录进入，然后找到自己当前登录的用户名，再进入那个venv文件夹，就能看到Scripts目录，复制整个这个路径。

![xIlXKqcgh9](/images/posts/xIlXKqcgh9.png)

然后把路径切换到这个Scripts目录:切记，这里不要用PowerShell, 用cmd黑框，以管理员方式打开cmd。切换目录的指令如下，cd 就是change direct改变路径的缩写，后面带上你复制的自己的Script整个路径，

```shell
cd C:\Users\47664\venv\Scripts
```

如下，这样子就切换目录到了Scripts下面了，这么切换目录的原因是我们的bat文件在这个目录里面，开启python虚拟环境要用这个。

![cmd_INHW2y2cj1](/images/posts/cmd_INHW2y2cj1.png)

直接输入：

```shell
activate.bat
```

回车执行，如果一次不行，同样输入activate.bat执行一次，直到看到有个(venv)的小括号出现，如下：前面带了这个(venv),就表示你进入了python虚拟机环境:

![cmd_cGtW04Fz9Y](/images/posts/cmd_cGtW04Fz9Y.png)

已经进入python虚拟环境了，黑框cmd不要退出，我们这个时候先去安装一个git环境，

下载git安装文件exe：去到git官网：[https://git-scm.com/](https://git-scm.com/)，如下图，点击那个Download for Windows，下载git的安装文件：

![fc6kv4lUYs](/images/posts/fc6kv4lUYs.png)

![YVTKOVsT3Q](/images/posts/YVTKOVsT3Q.png)

选择64位版本的Setup文件下载下来，就跟我们以前安装exe文件一样，直接下一步，下一步，下一步，直到安装完成。估计会要重启下电脑。重启电脑之后我们再以管理员方式启动cmd黑框。

我们回到黑框cmd环境，继续操作，安装whisper库之前还是要开启python虚拟环境，执行上面那个activate.bat文件。如果忘记了，请回到上面activate.bat那里。切换目录，执行activate.bat。

开启python虚拟环境。开启之后，看到这个(venv)

![cmd_cGtW04Fz9Y](/images/posts/cmd_cGtW04Fz9Y.png)

再执行下面，安装whisper库：

我们安装OpenAi公司的whisper库：

```shell
pip install git+https://github.com/openai/whisper.git
```

这个库的体积很大，安装文件可能达到2GB，耐心等待安装完成。安装完成whisper之后，

安装yt-whisper:

```shell
pip install git+https://github.com/m1guelpf/yt-whisper.git
```



全部安装完毕之后，就可以使用yt-whisper去生成youtube视频的字幕了，先不用急着去找youtube视频链接，这里的指令我们先执行，测试下yt_whisper指令是否正常能够生成字幕。

执行下面指令，测试yt_whisper功能：

```shell
yt_whisper "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
```

转换的时候，时间会有点长，5分钟到10分钟左右，看你要转化的视频mp4的时间长短决定。

![cmd_f02JOb0vMR](/images/posts/cmd_f02JOb0vMR.png)

转换过程CPU会100%拉满，期间就不要做其他事情了，静静等待即可，防止电脑卡死。AI在电脑生成字幕的时间和速度，除了跟你视频长度有关系，还有跟你电脑CPU配置也有关系。生成完成之后，这个控制台会显示，生成的vtt格式的字幕在你电脑硬盘的路径，根据路径过去拿这个字幕即可。



以后我们就可以正常使用yt_whisper指令了，使用方式，参考：[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)

找到你想要自动生成字幕的youtube链接地址，复制，使用yt-whisper 加上双引号，里面写上你要转AI字幕的视频的地址即可，如下格式：

```shell
yt_whisper "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
```

每次使用的时候，如果你电脑重启过，或者关闭过python虚拟环境，可能需要再次进入python虚拟机环境，才能执行这个AI程序，进入python虚拟环境的方式，参考上面的步骤即可。

