---
layout: post
title: Anki降低复习压力/最重要的两个参数(4)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---
使用Anki已经有2~3年经验的人，可能遇到过单词留存率和“复习”噩梦的问题，anki让人诟病的地方主要是复习压力太大，随着积累的词汇量越来越大，搞得人精神崩溃，只要一段时间不去维持，词汇量马上掉下来打回原形(特别是纯靠阅读提升的被动词汇，很容易掉)，而疯狂的复习压力又反过来会给人一种焦虑感。

国内关于anki讨论最多的大部分是如何制卡，对于anki参数讨论比较少，很多anki初学者在中文世界里寻找anki资料，没有主动用英文去寻找过，看看别人老外是怎么用anki的。其实anki的很多技巧存在于英文世界里。在Youtube有来至世界各地的anki分享者，他们的经验非常值得借鉴。如果是Google和YouTube的重度使用者(翻Qiang的重度使用者)，用英文搜索资料是一项必备技能，可以解决很多资讯上的短板。

有人用anki觉得效果不好就去更换其他工具，比如更换supermemory，比如B站这个帖子：[https://www.bilibili.com/read/cv11512889](https://www.bilibili.com/read/cv11512889)，如果觉得一个工具不好用，我的办法一般是会去搜索英文资料来进行补充改进。

从长期使用anki来看，我积累的单词卡数量和我测试到的词汇量基本是一致的。也就是说anki的单词数量跟学习者的被动词汇量是一致的。有了这些数据，就可以量化自己的目标：什么时候可以词汇量过万，什么时候需要切换材料和难度，通过数据是可以预测的。

顺便说下supermemory和anki的区别，主要是下图这个区别。前者更加适合多科学习，如果是管理和学习英文单词，anki仍然是地表最强APP，没有之一！

本文要解决的就是：Anki卡片太多**可能变成英语学习者的噩梦**，这个问题怎么去解决。这个问题，在我频繁制卡的过程中遇到过，曾经导致我停止了英文自学有半年的时间。但是这停止的半年，并没有对我的单词量下降造成任何伤害。反而，由于现在驾驭anki越来越熟练，制卡几乎成为了我的生活习惯。未来当我单词量达到1.7万，我都不会再担心anki会成为噩梦。

![supermemory_anki](/images/posts/supermemory_anki.png)

### 如何调整留存率

什么是留存率？留存率就是Anki中的单词卡片，学习者最终能够记住的有多少。比如：7000个单词卡片，我想记住90%，也就是记住6300个单词，单词的留存率就是90%。如果设置留存率呢？参考原文：[https://readbroca.com/anki/what-is-anki-interval-modifier/](https://readbroca.com/anki/what-is-anki-interval-modifier/)。具体的操作，我把它翻译为中文，配上我的演示：

先安装这个插件[True Retention](https://ankiweb.net/shared/info/613684242) ，点击Stats的同时按住Shift键，否则进入的是默认的统计页面，一定要按住Shift键的同时点击鼠标左键，才能进入到下面这个界面：

<img src="https://cs-cn.top/images/posts/retention_914.png"/>

我这个单词本AudioBook里面存储的主要是平时看有声书的生词，这里面是运行了1.5年的数据，所以数据不是空白的，初学者刚开始使用，可能anki中还没有产生这么多数据。这里我查看到最近一个月，我的单词留存率是90.3%，我想把它调低一些，不想记住这么多单词。比如调低到85%就可以了。其实维持在80%~90%都是可以的。

调低到85%，计算公式如下：

*Interval Modifier = log(desired retention%) / log(current retention%)*

也就是： log(85%) / log(90.3%)=159% 

用计算机计算一下，如下：

<img src="https://cs-cn.top/images/posts/liucunlv_544.png"/>

调整Interval modifier，设置如下即可：

<img src="https://cs-cn.top/images/posts/intervar279.png"/>

降低留存率就是降低我们的复习压力。如果觉得复习压力太大，可以适当把这个降低。

短时间要复习大量的生词，比如一下子复习500个生词，但是没有那么时间，可以只挑选其中200个最为重要的单词来复习，Anki是支持这种方式的，详细的设置：[点击这里，查看文章](https://cs-cn.top/2019/06/10/english-study-tools-anki/#%E4%BD%BF%E7%94%A8anki%E8%BF%87%E6%BB%A4%E5%99%A8%E5%87%8F%E8%BD%BB%E5%A4%8D%E4%B9%A0%E5%8E%8B%E5%8A%9B)，这是Anki的高级玩法，就是使用Anki的过滤器，把优先级最高的单词优先复习了，不太紧急的单词顺延到后面复习。遵循”紧急优先的事情“先处理的原则。另外要谈到的是也是最最重要的问题，就是Anki的轮回地狱的问题，英文翻译过来叫做Ease Hell。这个问题困扰过我1年多的时间，导致我几乎放弃使用anki。本着”用英语促进英语“的原则，我开始主动使用英语来解决我生活中各种问题，搜索到了一些国外帖子经验，成功解决了这个Ease Hell问题。

### Anki的Ease Hell问题

关于“低间隔复习地狱”的问题，可以参考这篇文章：[Ease Hell](https://readbroca.com/anki/ease-hell/) 

“低间隔地狱”，我个人认为大部分是由于使用Anki的习惯不当导致的。在对一个单词不熟悉的时候，大多数人会很容易去点击”Again“，也就是告诉Anki，这个单词我记不住，没印象，请给我再复习一次的机会。那么今天某个时间段它会再次出现。建议，使用anki的时候，不要大量使用Again按钮，这是导致Ease Hell出现的主要原因。哪怕一个单词根本没有印象，也建议点击”Hard“，都不要频繁点击”Again“。如果点击了Again，那么会导致Ease Factor的数值降低到最小值130%，Anki就会频繁弹出提示复习这个单词，并且降低到130%之后的单词，会一直纠缠着你不放，很难摆脱这些单词，这就陷入死循环，复习压力暴增，而且降不下去，这是Anki算法的一个弊端，也是很多人遇到的噩梦。这里，为了降低anki的影响，建议把生活环境和工作环境切换到英文，看电影用英文字幕，看新闻也英文，看技术材料也英文，达到”心流“状态，两者结合起来，会加快单词的熟悉，而不是完全对anki产生依赖。

***Ease Factor***的设置的位置如下图：

<img src="https://cs-cn.top/images/posts/easy_factor_950.png"/>

Ease Factor为130%的单词我这里有1157个。我需要把这批单词的Ease Factor数值批量修改为250%。

<img src="https://cs-cn.top/images/posts/easy_factor023.png"/>





批量降低Easy Factor，需要安装这个插件：[Reset Ease，鼠标右键，新窗口页打开这个链接](https://ankiweb.net/shared/info/947935257)，获得安装code,安装完这个插件。进行如下的设置即可：

<img src="https://cs-cn.top/images/posts/change_ease_factor3508.png"/>

130%提升到250%，点击OK。这个就可以在很大程度上避免陷入噩梦。

修改了之后，效果图如下。Ease Factor百分比整体提升了19%。这么批量修改之后，会发现自己单词复习压力瞬间减少了很多。

<img src="https://cs-cn.top/images/posts/easy_value13.png"/>

为了更进一步降低单词复习难度，还可以修改New interval这个值，把它改为20%。这是一个补偿值，目的是为了防止点击Again的时候，单词出现过度“退化”现象，本来一个单词你复习了很多次了，由于你点击了一次Again，结果这个单词一夜回到解放前，退化到原始状态，变为了一个新单词，要从零开始复习，这个肯定是不对的。毕竟你已经复习过很多次这个单词了，不可能由于你点击了一个Again就把它打回原形。所以这个20%的补偿值是很必要的。

<img src="https://cs-cn.top/images/posts/newinterval910.png"/>

最后总结一句话：非常庆幸我自己是anki的深度用户，从自学英语一开始就采用anki。

这些数据会在以后的口语和写作中将发挥巨大的作用。从一开始就这么做积累，其实是非常明智的。
