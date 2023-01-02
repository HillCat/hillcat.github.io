---
layout: post
title: 最后一击_背诵COCA20000单词(12)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

COCA20000词汇库比较适合用来查漏补缺。

### 1.COCA20000百度网盘下载

下面是COCA20000词汇的词牌：

链接：[https://pan.baidu.com/s/1BQ4d7ErXVkgVs4rpXOAPSw?pwd=g0e1](https://pan.baidu.com/s/1BQ4d7ErXVkgVs4rpXOAPSw?pwd=g0e1) 
提取码：g0e1 

### 2.词牌来源和使用方法

这个anki词牌资源来至于网络，参考：

自己制作-COCA20000+雅思词汇(语音)记忆库-分享-更新
[https://www.pdawiki.com/forum/forum.php?mod=viewthread&tid=25114](https://www.pdawiki.com/forum/forum.php?mod=viewthread&tid=25114)
(出处: 掌上百科 - PDAWIKI)

论坛中的帖子提供了一些修改词牌模板的方法，具体还得根据自己的需要自行修改。

### 3.anki插件推荐

anki这个FSRS4Anki插件的使用，参考：

【怎么复习单词最科学:使用Anki FSRS4Anki Helper优化我们的复习策略】[ https://www.bilibili.com/video/BV1RM41127kZ/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d](https://www.bilibili.com/video/BV1RM41127kZ/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d)

在以往的anki版本中，我是不会去刻意尝试背诵单词的，为何现在我会使用背诵的方式呢？

### 4.vocabulary释义

到了后期为何还是需要背单词？笼统来说是因为时机已经成熟了，背单词之前我尝试了一段时间的英英词典vocabulary这个网站。感觉这个网站对于单词的释义真的非常精准，强力推荐。特别是已经有了一定的词汇量基础情况下，阅读英英释义难度不大。

![chrome_KqkAuSfBJl](/images/posts/chrome_KqkAuSfBJl.png)

采用vocabulary释义的coca20000词库和anki，原因主要有3点：

1.vocabulary这个网站的释义确实让我体会到更加容易记住一个单词；并且恰好有人已经制作了具备vocabulary释义的COCA20000的ANKI词牌。

2.anki的最新版本大幅改良了复习算法，在V3算法基础上结合FSRS4Anki  Helper插件，我们可以优化COCA20000单词的复习频率。如果要针对于雅思考试，前期高频词通过阅读提升很快，到了后期，再通过泛读提升词汇会发现效率有所下降，这个时候还是需要通过COCA词库查漏补缺。

3.最近我在研究雅思备考的过程中发现，很多雅思参考资料中提到的策略都是要先扫清生词障碍，再进行应考训练，生词障碍越早扫除越好。雅思这块有专门的听力训练，阅读训练，写作，口语这些，无论是哪一种训练，前提都是扫清词汇障碍。词汇没有堆起来，训练其他能力的时候精力容易分散，取不得太好效果。

后期采用背单词的策略，这个在漏屋那本书《词霸天下》中也有讲到，起初我是不太同意背单词的，但是经过长期的实践还是发现，背单词如果讲究方法得当，效率是比阅读要好，如果是为了应试，还是需要快速搞定所有单词然后再进入有针对性的备考训练，扫清单词障碍不能拖太久。

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
