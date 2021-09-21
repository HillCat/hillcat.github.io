---
layout: post
title: Anki降低复习压力/最重要的两个参数(4)
categories: English
description: 英文自学
keywords: English
---
使用anki最容易犯错的地方就是使用不当，容易造成复习量爆炸，给学习者造成很大的复习压力。包括某些人使用Anki已经有2~3年经验的人，可能还是对Anki不太熟悉。转而去更换其他supermemory类似软件的例子，比如：[https://www.bilibili.com/read/cv11512889](https://www.bilibili.com/read/cv11512889)，这是放弃anki转而使用SuperMemo的一个例子。其实如果搞懂了anki的参数还有一些关键的坑，避开这些坑，调整和优化好自己的参数，anki还是非常不错的一个工具。本篇主要介绍anki中最重要的2个参数，防止掉坑。

什么是留存率？留存率就是Anki中的单词卡片，你最终能够记住的有多少，能记住百分之几的单词。比如：7000个单词卡片，我想记住90%，也就是记住6300个单词，单词的留存率就是90%。如果设置留存率呢？参考原文：[https://readbroca.com/anki/what-is-anki-interval-modifier/](https://readbroca.com/anki/what-is-anki-interval-modifier/)。具体的操作，我把它翻译为中文，配上我的演示：

先安装这个插件[True Retention](https://ankiweb.net/shared/info/613684242) ，点击Stats的同时按住Shift键，否则你进入的是默认的统计页面，一定要按住Shift键的同时点击鼠标左键，才能进入到下面这个界面：

<img src="https://cs-cn.top/images/posts/retention_914.png"/>

我这个单词本AudioBook里面存储的主要是平时看有声书的生词，这里面是运行了1.5年的数据，所以数据不是空白的，你们刚开始使用，可能anki中还没有产生这么多数据。这里我查看到最近一个月，我的单词留存率是90.3%，我想把它调低一些，不想记住这么多单词。比如调低到85%就可以了。其实维持在80%~90%都是可以的。

调低到85%，计算公式如下：

*Interval Modifier = log(desired retention%) / log(current retention%)*

也就是： log(85%) / log(90.3%)=159% 

用计算机计算一下，如下：

<img src="https://cs-cn.top/images/posts/liucunlv_544.png"/>

调整好的数据，设置如下即可：

<img src="https://cs-cn.top/images/posts/intervar279.png"/>

降低留存率就是降低我们的复习压力。如果你觉得复习压力太大，可以适当把这个降低。

短时间要复习大量的生词，比如一下子复习500个生词，但是你没有那么时间，可以只挑选其中200个最为重要的单词来复习，Anki是支持这种方式的，详细的设置：[点击这里，查看文章](https://cs-cn.top/2019/06/10/english-study-tools-anki/#%E4%BD%BF%E7%94%A8anki%E8%BF%87%E6%BB%A4%E5%99%A8%E5%87%8F%E8%BD%BB%E5%A4%8D%E4%B9%A0%E5%8E%8B%E5%8A%9B)，这是Anki的高级玩法，就是使用Anki的过滤器，把优先级最高的单词优先复习了，不太紧急的单词顺延到后面复习。遵循”紧急优先的事情“先处理的原则。另外要谈到的是也是很重要的问题，就是Anki的轮回地狱的问题，英文翻译过来叫做Ease Hell。这个问题困扰过我1年多的时间，是隐藏的一个巨坑，学Anki一定要避免这个坑。

### Anki的Ease Hell问题

关于“低间隔地狱”的问题，可以参考这篇文章：[Ease Hell](https://readbroca.com/anki/ease-hell/) 

“低间隔地狱”，我个人认为大部分是由于使用Anki的习惯不当导致的。在你觉得一个单词不熟悉的时候，你会很容易去点击”Again“，也就是告诉Anki，这个单词我记不住，没印象，请给我再复习一次的机会。那么今天某个时间段它会再次出现。建议，使用anki的时候，不要大量使用Again按钮，这是导致Ease Hell出现的主要原因。哪怕一个单词你根本没有印象，也建议你点击”Hard“，都不要频繁点击”Again“。如果点击了Again，那么会导致Ease Factor的数值降低到最小值130%，Anki就会频繁弹出提示要你复习这个单词，并且降低到130%之后的单词，会一直纠缠着你不放。你很难摆脱这些单词。这就陷入死循环，让你复习压力暴增，而且降不下去，这是Anki算法的一个弊端，目前无解。





***Ease Factor***的设置的位置是：这是初始值，如果要修改anki中已经存在的卡片的这个值，需要借助一个插件批量修改。

<img src="https://cs-cn.top/images/posts/easy_factor_950.png"/>

Ease Factor的单词，降低到130%的单词有多少，我这里有1157个。我需要把这批单词的Ease Factor数值批量修改为250%。

<img src="https://cs-cn.top/images/posts/easy_factor023.png"/>





给anki安装这个插件：[Reset Ease，鼠标右键，新窗口页打开这个链接](https://ankiweb.net/shared/info/947935257)，获得安装code,安装完这个插件，然后批量设置。

<img src="https://cs-cn.top/images/posts/change_ease_factor3508.png"/>

直接130%的这些卡片的系数提升到250%，点击OK。这个就可以在很大程度上避免你陷入“轮回”地狱。

修改了之后，效果图如下。Ease Factor百分比整体提升了19%。这么批量修改之后，你会发现自己单词复习压力瞬间减少了很多。

<img src="https://cs-cn.top/images/posts/easy_value13.png"/>

为了更进一步降低单词复习难度，还可以修改New interval这个值，把它改为20%。这是一个补偿值，目的是为了防止你点击Again的时候，单词出现过度“退化”现象，本来一个单词你复习了很多次了，由于你点击了一次Again，结果这个单词一夜回到解放前，退化到原始状态，变为了一个新单词，要它从零开始复习。这个肯定是不对的。毕竟你已经复习过很多次这个单词了，不肯能由于你点击了一个Again就把它打回原形。所以这个20%的补偿值是很必要的。

<img src="https://cs-cn.top/images/posts/newinterval910.png"/>

