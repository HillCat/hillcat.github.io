---
layout: post
title: 最后一击_背诵COCA20000单词(12)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

如果是前期阶段基础比较弱的时候可以使用阅读阶梯书解决前面5K~8K左右的单词，到了后面阶段想要快速搞定一些外刊的阅读能力，这个时候可以尝试背诵COCA20000词库。结合阅读外刊的方式。因为这个时候的词汇量已经可以看懂英英词典的释义了。并且通过vocabulary网站的英英释义解释，可以更好的理解词汇之间的细微差别，实践中，我觉得vocabulary的英英释义确实可以让你更容易记住一个单词。

结合COCA20000词库，可以让我们把精力花在我们不熟悉的那些词上面。这里我推荐使用anki 2.1.55版本或高于这个版本的anki,结合插件FSRS4Anki  Helper来背诵COCA20000词汇。

### 1.COCA20000百度网盘下载

下面是COCA20000词汇的词牌：

链接：[https://pan.baidu.com/s/1BQ4d7ErXVkgVs4rpXOAPSw?pwd=g0e1](https://pan.baidu.com/s/1BQ4d7ErXVkgVs4rpXOAPSw?pwd=g0e1) 
提取码：g0e1 

### 2.词牌来源和使用方法

这个anki词牌资源来至于网络，参考：

自己制作-COCA20000+雅思词汇(语音)记忆库-分享-更新
[https://www.pdawiki.com/forum/forum.php?mod=viewthread&tid=25114](https://www.pdawiki.com/forum/forum.php?mod=viewthread&tid=25114)
(出处: 掌上百科 - PDAWIKI)

### 3.anki优化背词算法

anki这个FSRS4Anki插件的使用，参考：

【怎么复习单词最科学:使用Anki FSRS4Anki Helper优化我们的复习策略】[ https://www.bilibili.com/video/BV1RM41127kZ/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d](https://www.bilibili.com/video/BV1RM41127kZ/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d)

在以往的anki版本中，我是不会去刻意尝试背诵单词的，为何现在我会使用背诵的方式呢？

### 4.为何会突然背单词

笼统来说是因为时机已经成熟了，背单词之前我尝试了一段时间的英英词典vocabulary这个网站。感觉这个网站对于单词的释义真的非常精准，强力推荐。

![chrome_KqkAuSfBJl](/images/posts/chrome_KqkAuSfBJl.png)

采用vocabulary结合coca20000词库和anki，原因主要有3点：

1.vocabulary这个网站的释义确实让我体会到更加容易记住一个单词；并且恰好有人已经制作了具备vocabulary释义的COCA20000的ANKI词牌。

2.anki的最新版本大幅度改良的V3算法，结合FSRS4Anki  Helper插件，我们可以优化COCA20000单词的复习进度。在没有使用FSRS4Anki之前，大概通过阅读积累到1W左右单词的时候会感觉到复习压力倍增，使用这个插件的算法之后，压力得到极大的缓解，阅读积累词汇具有随意性，往往发现阅读了很多东西，有些高频词还是会有漏掉的情况，如果要针对于雅思考试，这种野生的阅读方法不太可取，有COCA词库可以更快速有针对性提升积累。

3.最近我在研究雅思备考的过程中发现，很多雅思参考资料中提到的策略就是，先要扫清生词障碍，越早越好。雅思这块有专门的听力训练，阅读训练，写作，口语这些，无论是哪一种教辅材料，在你做专项训练的时候，提到的一个前提就是要扫清词汇障碍。

有了anki优化算法的加持，并且自己也有了大量词汇积累，所以背完剩下的词汇难度应该不大。如果觉得英英释义有难度，可以借助某些工具把卡片中的vocabulary英英释义翻译为中文。如果基础较好，背诵单词可以作为一种扫盲和进阶方法。这个策略在漏屋那本书《词霸天下》中也有讲到。

具体操作方式：导入COCA20000词牌，把我们已经熟悉的单词剔除掉。再使用优化参数来背诵这些生词。结合阅读外刊巩固，还有大量的听力来映射为听力词汇。或者是在雅思听力训练的时候，也可以起到事半功倍的效果。



![image-33065](/images/posts/image-33065.png)



### 5.COCA20000词牌样式编辑

默认的词牌是含有大量的信息的，例句，同义词族，等等；有很多信息是背单词的时候不需要的，可以隐藏掉。懂html和css的话，可以自己结合inspector插件，编写css，通过inspector插件调试anki的词牌，隐藏掉我们不需要显示的部分即可.

![anki_cqDplLMUSN](/images/posts/anki_cqDplLMUSN.png)

通过批量处理英英注释部分，以及隐藏掉不需要的一些干扰信息，这样子背起来就相当方便了。而且还结合了anki最新的复习算法，相得益彰，如虎添翼。

![anki_N8aqEsLA3g](/images/posts/anki_N8aqEsLA3g.png)



在style中加入如下代码，保存即可

```css
.vocabulary #vUi {
    display: none;
}

.vocabulary span.b.c {
    display: none;
}

.vocabulary.a {
    display: none;
}

span.b.c+.a {
    display: none;
}

```

![Typora_HbxLuFmCf2](/images/posts/Typora_HbxLuFmCf2.png)
