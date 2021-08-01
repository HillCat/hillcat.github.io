---
layout: post
title: Anki最重要的参数Interval modifier
categories: English
description: 英文自学
keywords: English
---
这个Interval modifier参数是Anki使用过程中最重要的一个参数。留存率，其实就是表示的你经过一段时间的单词复习，最终能够维持住记忆的单词的百分比。比如我最近1个月学习效果如何，比如最近一个月我单词本有7000个单词在Anki中轮流滚动复习。



比如7000个单词，我想记住90%，也就是6300个单词维持在不遗忘的状态。

先安装这个插件[True Retention](https://ankiweb.net/shared/info/613684242) ，然后我们进入到一个单词本里面去，点击Statics的同时按住Shift键，

<img src="https://cs-cn.top/images/posts/retention_914.png"/>

我这个单词本AudioBook里面存储的主要是平时看有声书的生词，查看到最近一个月，我这批单词的留存率如上。90.3%，还算正常。其实Anki官方给出来的数字是建议留存率维持在90%。

但是这么高的留存率，我感觉每天的复习频率很高，投入的时间成本太多了。我想降低下留存率，比如只需要维持在85%即可。

那么这个Interval Modifier参数应该设置多少呢？

按照[这篇文章](https://readbroca.com/anki/what-is-anki-interval-modifier/)的解释，计算公式是：*Interval Modifier = log(desired retention%) / log(current retention%)*

也就是： log(85%) / log(90.3%)=159% 

也就是说，你觉得复习的频率太高了，而且压力很大，你可以适当降低一点留存率，减少每天花在Anki中的时间。

<img src="https://cs-cn.top/images/posts/liucunlv_544.png"/>





