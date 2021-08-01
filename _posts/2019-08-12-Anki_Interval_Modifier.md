---
layout: post
title: Anki降低复习压力/最重要的两个参数
categories: English
description: 英文自学
keywords: English
---
这个Interval modifier参数是Anki使用过程中最重要的一个参数。跟这个参数直接挂钩的就是“留存率”。

留存率，其实就是你能够最终维持记忆的单词的数量的百分比，很多时候，单词的记忆是需要靠维持的，时间久了不用的话就会遗忘。使用单词卡片，定期复习就是为了保证大部分单词不被遗忘。比如：最近一个月我单词本有7000个单词在Anki中轮流滚动复习。在这7000个单词中，我想记住90%，也就是维持6300个单词不被遗忘。那么该如何设置这个Interval modifier参数呢？复习旧的单词是需要花费时间的，而学习新单词也是需要时间的，如果投入太多时间都用来复习旧单词，那么就没有多余的时间去学新单词。在时间投入上就需要一个平衡点。所以就有了留存率的问题，以及Interval modifier参数设置的问题。参考：[https://readbroca.com/anki/what-is-anki-interval-modifier/](https://readbroca.com/anki/what-is-anki-interval-modifier/)

首先我们需要知道现有单词库真实的留存率。

先安装这个插件[True Retention](https://ankiweb.net/shared/info/613684242) ，然后我们进入到一个单词本里面去，点击Stats的同时按住Shift键，否则你进入的是默认的统计页面，要进入下面这个统计页面，需要鼠标点击的时候同时键盘按住Shift。

<img src="https://cs-cn.top/images/posts/engliword_remain104.png"/>

<img src="https://cs-cn.top/images/posts/retention_914.png"/>

我这个单词本AudioBook里面存储的主要是平时看有声书的生词，查看到最近一个月，我这批单词的留存率如上。90.3%，还算正常。其实Anki官方给出来的数字是建议留存率维持在90%。也有人建议维持到85%就可以了。还有调查的人认为维持到80%~90%都是可以的。

如果是维持到90%这么高的留存率，我感觉每天的复习频率会很高，投入的时间成本太多了。我想降低下留存率，比如只需要维持在85%即可。

那么这个Interval Modifier参数应该设置多少呢？

按照[这篇文章](https://readbroca.com/anki/what-is-anki-interval-modifier/)的解释，计算公式是：*Interval Modifier = log(desired retention%) / log(current retention%)*

也就是： log(85%) / log(90.3%)=159% 

也就是说，你觉得复习的频率太高了，会导致你复习压力很大，你可以适当降低一点留存率，减少每天花在Anki中的时间。

<img src="https://cs-cn.top/images/posts/liucunlv_544.png"/>





### Anki的Ease Hell问题



关于“低间隔地狱”的问题，可以参考这篇文章：[Ease Hell](https://readbroca.com/anki/ease-hell/) 

“低间隔地狱”，我个人认为大部分是由于使用Anki的习惯不当导致的，在短时间内，无限循环复习某些单词，但，就是记不住。好像有些单词永远记不住，永远在无限地刷，地狱轮回。

一般这些单词的Ease Factor值都是130%。如果你的单词卡中存在大量的这种单词，势必会加重你的复习负担，需要对这部分单词进行一定的处理，完善它们，要么提升它们的Ease Factor值。

还一个就是要分析下自己最近阅读的有声书或美剧，是不是不太实用，导致录入了大量的超纲词。要重点分析下这些Ease Factor为130%的生词。你可以去到Anki的统计面板里面，打开柱状图，点击柱条值为130%的那批单词。认真分析下原因，看看是什么问题导致的，以便于优化自己的学习习惯。

如果确实是自己阅读的材料太过于抽象，导致自己记不住，那么就要考虑更换一下材料或者可以换动画片或者美剧。如果确实是因为那些单词是不常用的超纲词，那么可以考虑删除掉一部分很难记的单词。因为它们不常用，频率很低。

***Ease Factor***的定义：**一张卡片的轻松系数代表了 Anki 认为这张卡片的难易程度。**

如果一张卡片很容易，那么Anki就会很少去展示这张卡，如果Anki认为卡片很难，它就会频繁出现，以便于你通过高频率的复习来记住它。

每张卡片初始轻松系数为250% .如下所示：

<img src="https://cs-cn.top/images/posts/easy_factor_950.png"/>

如果Ease Factor这个数值越低，Anki会认为这个卡越难，如果你在回答卡片的时候一直回答Again，那么这个卡片的Ease Factor这个值就会降到最低值130%。

<img src="https://cs-cn.top/images/posts/Easy_Factor435.png"/>

拿我这里的单词举例，我这里有6800多张卡片，其中有1157张卡片的Ease Factor是130%，也就是说这些卡片会非常频繁地每天出现在复习名单中，导致我的复习压力非常非常大。而且这种Ease Factor降低到130%的卡片，一般会被Anki认为是很难的单词，会让我一直不停的复习不停的复习，陷入恶性循环。而一张卡片一旦它的Ease Factor降低到130%之后，只要你回答单词卡的时候不点击Easy那个按钮，它的这个Ease Factor的值是很难涨上来的。

<img src="https://cs-cn.top/images/posts/easy_factor023.png"/>



为了避免出现“低间隔复习地狱“的发生。有三个办法：

第一个就是科学合理的使用上面的Interval modifier那个参数，平衡好你的留存率。

第二个就是修改那些130% Ease Factor的单词的简单系数为 250%.可以使用这个插件：[Reset Ease](https://ankiweb.net/shared/info/947935257)

<img src="https://cs-cn.top/images/posts/change_ease_factor3508.png"/>

安装好这个插件之后，到adds-on配置里面，查看这个插件的配置参数，默认情况下，这个插件会检测出你所有的单词卡片中Ease Factor的数值已经是130%的这批卡片，直接把他们的轻松系数提升到250%。这个就可以在很大程度上避免你陷入“低间隔重复”地狱，导致每天被复习压力压得喘不过气来。

下面这幅图是批量修改了Ease Factor之后，重新生成的柱状图：Ease Factor百分比整体提升了19%

<img src="https://cs-cn.top/images/posts/easy_value13.png"/>

第三个就是修改 New interval这个值，把它改为20%。因为Ease Factor之所以会降低到130%是因为你太频繁的回答了Again这个按钮，很多时候，你复习单词的时候，实在是想不起来这个单词了，你就会直接回答Again，而回答Again的次数太多的话，很容易把一个单词卡片的Ease Factor降低到130%，我就是因为使用了太多次的Again按钮，所以导致我有1000多个单词都是130%，导致我感觉每天复习压力很大，陷入了 ”低复习间隔地狱“的坑。所以如果你很喜欢点Again，那么最好是把New interval这个值给个20%。比如一个单词，原本的复习间隔是30天，而刚好你点击了Again，那么这个单词瞬间会打回原型，变为隔天复习。加个20% 就是 20%*30 ，也就是6天后复习，就不会直接打回原形，因为总有一些单词，由于复习者当时可能是注意力不集中，点击了Again按钮，或者是复习者的身体过于疲劳导致当时回忆不起来这个单词，而每次点击Again的时候，如果有些单词我已经复习过很多遍了，比如某些单词我通过大量的复习，3个月才会出现一次，而我点击Again之后就直接变为隔天复习，这种其实不太合理。可能你仅仅是偶尔忘记了这个词，不至于说点击了Again就要直接把一个3个月间隔的词直接变为隔天复习，那个惩罚代价也太大了。所以还是得给一个补偿值20%，以便减轻自己复习压力。

<img src="https://cs-cn.top/images/posts/newinterval910.png"/>

