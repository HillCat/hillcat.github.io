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

我们需要给windows10安装python3.执行下面语句：

```shell
choco install python
```

然后安装pip, 因为python3自带了pip，所以这里只是升级一下pip：

```shell
python -m pip install -U pip
```

然后是安装yt-dlp：

```shell
python -m pip install -U yt-dlp
```

然后安装whisper:

```shell
pip install git+https://github.com/openai/whisper.git -q
```

然后安装mmpeg:

```shell
choco install ffmpeg
```

最后安装yt-whisper:

```shell
pip install git+https://github.com/HillCat/yt-whisper.git
```

全部安装完毕之后，就可以使用yt-whisper去生成youtube视频的字幕了

使用方式，参考：[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)



找到你想要自动生成字幕的youtube链接地址，复制，使用yt-whisper 加上双引号，里面写上你要转AI字幕的视频的地址即可，如下格式：

```shell
yt_whisper "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
```

转换的时候，时间会有点长，5分钟到10分钟左右，看你要转化的视频mp4的时间长短决定。

![cmd_f02JOb0vMR](/images/posts/cmd_f02JOb0vMR.png)

转换过程CPU会100%拉满，期间就不要做其他事情了，静静等待即可，防止电脑卡死。AI在电脑生成字幕的时间和速度，除了跟你视频长度有关系，还有跟你电脑CPU配置也有关系。生成完成之后，这个控制台会显示，生成的vtt格式的字幕在你电脑硬盘的路径，根据路径过去拿这个字幕即可。
