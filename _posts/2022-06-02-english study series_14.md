---
layout: post
title: 如何解决youtube字幕不兼容anki的问题(14)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

在我本博客英文专栏第13篇文章里面，介绍了anki用来学习美剧的方法。其中有个问题，就是美剧无法解决20分钟这种不间歇口语表达的问题，一般的解决思路就是去youtube寻找一个母语者去模仿。但是在我们模仿这个母语者的过程中，我们如果要做笔记，制作视频卡片，要放到手机上面复习，有点难实现。主要的困难在于youtube采用了Google自己的字幕标准，导出来的字幕格式和NetFlix那种不一样，导致我们使用mpv2anki制作视频卡片的时候，是没办法针对youtube的视频的。如果生成机器字幕再转换，这个过程太过于复杂。如果我们能找到一种方法，通过AI自动生成youtube英文字幕，这个字幕格式和NetFlix兼容，那么我们就可以搞定youtube里面所有英文视频了。

### Automatic YouTube subtitle generation

在github中存在一个python项目，就是专门针对youtube视频生成AI字幕的。

[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)

使用这个工具如果能够生成兼容性更好的字幕，那么问题就迎刃而解了。

