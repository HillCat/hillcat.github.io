---
layout: post
title: Anki_True_Retention_Easy_Hell(4)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---


使用Anki已经有2~3年经验的人，可能遇到过单词留存率和“复习”噩梦的问题，anki让人诟病的地方主要是复习压力太大，随着积累的词汇量越来越大，搞得人精神崩溃，只要一段时间不去维持，词汇量马上掉下来打回原形(特别是纯靠阅读提升的被动词汇，很容易掉)，而疯狂的复习压力又反过来会给人一种焦虑感。

国内关于anki讨论最多的大部分是如何制卡，对于anki参数讨论比较少，很多anki初学者在中文世界里寻找anki资料，没有主动用英文去寻找过，看看别人老外是怎么用anki的。其实anki的很多技巧存在于英文世界里，包括很多华人在国外分享anki使用经验，基本都只在youtube上面分享，很少有内容会流入到国内的B站，因为anki可能是比较小众化的一个东西，很多高阶玩法只在程序员群体中流行，或者说有很多东西并不为人所知。但是，如果你是一个程序员，我觉得学英语用anki会有很大的优势。

从长期使用anki来看，我积累的单词卡数量和我测试到的词汇量基本是一致的。也就是说anki的单词数量跟学习者的被动词汇量是一致的。有了这些数据，就可以量化自己的目标：什么时候可以词汇量过万，什么时候需要切换材料和难度，通过数据是可以预测的。

如果是管理和学习英文单词，anki仍然是地表最强APP，没有之一！但这个玩意确实只能在实战中积累使用经验，一开始要搞明白很多anki的概念，真的会吃不消。太追求完美主义的人，一般会花太多时间去研究如何制卡，如何设置参数上面。这里建议新手不要花太多时间研究anki，而是尽量最快速度的把这个工具用起来先，特别是用划词助手和anki配合制卡，把主要精力集中在去阅读英文阶梯读物上。抱着做实验的心态去使用anki。因为anki是需要数据支撑的，只有使用了才会产生数据，产生了数据之后才能依据已有的数据进行参数的调整。就比如下面一些参数的调整，都是需要建立在已有的数据之上的。如果你完全都没有用过anki，刚开始就去研究这些东西其实没有任何意义。

### 如何调整留存率

什么是留存率？留存率就是忘掉一部分之后，最终能记住(留下来的)单词有多少。比如：7000个单词卡片，我想记住90%，也就是记住6300个单词，单词的留存率就是90%。设置方法参考原文：[https://readbroca.com/anki/what-is-anki-interval-modifier/](https://readbroca.com/anki/what-is-anki-interval-modifier/)。具体的操作，我把它转述为中文，配上案例演示：

先安装这个插件[True Retention](https://ankiweb.net/shared/info/613684242) ，点击Stats的同时按住Shift键，否则进入的是默认的统计页面，一定要按住Shift键的同时点击鼠标左键，才能进入到下面这个界面：

<img src="https://cs-cn.top/images/posts/retention_914.png"/>

单词本AudioBook里面存储的主要是平时看有声书的生词，这里面是运行了1.5年的数据，所以数据不是空白的，初学者刚开始使用，可能anki中还没有产生这么多数据。这里我查看到最近一个月，单词留存率是90.3%，把它调低一些，不想记住这么多单词。比如调低到85%就可以了。其实维持在80%~90%都是可以的。

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

关于“低间隔**复习地狱**”的问题，可以参考这篇文章：[Ease Hell](https://readbroca.com/anki/ease-hell/) 

“低间隔地狱”，大部分是由于使用Anki的习惯不当导致的。在对一个单词不熟悉的时候，大多数人会很容易去点击”Again“，也就是告诉Anki，这个单词用户记不住，没印象，请给用户再复习一次的机会。那么今天某个时间段它会再次出现。建议，使用anki的时候，不要大量使用Again按钮，这是导致Ease Hell出现的主要原因。哪怕一个单词根本没有印象，也建议点击”Hard“，这并不是自欺欺人的做法，只是告诉anki不要太过于频繁的去“复习"。如果点击了Again，会导致Ease Factor的数值降低到最小值130%，值越小Anki复习就越频繁，降低到130%之后，很难翻身，久而久之陷入无限循环，雪球越滚越大，复习压力暴增，直到使用者崩溃。为了不过分依赖anki，建议把生活环境和工作环境切换到英文，看电影用英文，看新闻也英文，看技术材料也英文，anki是辅助维持单词，要记住单词主要是靠平时用英语接触各种各样的信息，在信息中熟悉单词，而不是完全靠anki记单词。我的很多单词都是在实践中记住的，极少有单词是靠硬刷anki记住的。为了防止anki反噬，产生副作用，要通过参数的设置来遏制它不好的一面。

***Ease Factor***的设置的位置如下图：

<img src="https://cs-cn.top/images/posts/easy_factor_950.png"/>

Ease Factor为130%的单词我这里有1157个。我需要把这批单词的Ease Factor数值批量修改为250%。要不然，这批单词的复习的频率太高了。

<img src="https://cs-cn.top/images/posts/easy_factor023.png"/>





批量降低Easy Factor，需要安装这个插件：[Reset Ease，鼠标右键，新窗口页打开这个链接](https://ankiweb.net/shared/info/947935257)，获得安装code,安装完这个插件。进行如下的设置即可：

<img src="https://cs-cn.top/images/posts/change_ease_factor3508.png"/>

130%提升到250%，点击OK。这个就可以在很大程度上避免陷入噩梦。

修改了之后，效果图如下。Ease Factor百分比整体提升了19%。这么批量修改之后，会发现自己单词复习压力瞬间减少了很多。

<img src="https://cs-cn.top/images/posts/easy_value13.png"/>

为了更进一步降低单词复习难度，还可以修改New interval这个值，把它改为20%。这是一个补偿值，目的是为了防止点击Again的时候，单词出现过度“退化”现象，本来一个单词复习了很多次了，由于点击了一次Again，结果这个单词一夜回到解放前，退化到原始状态，变为了一个新单词，要从零开始复习，这个肯定是不对的。毕竟已经复习过很多次了，不可能由于点击了一个Again就把它打回原形。所以这个20%的补偿值是很必要的。

<img src="https://cs-cn.top/images/posts/newinterval910.png"/>

### Anki的暂停和搁置功能

除了一些调整复习强度的参数可以灵活调整我们的复习策略，另外还有暂停和搁置功能是anki里面比较灵活的功能，很多人可能并不经常用到这两个功能，一般这两个功能是为了快速筛选出**适合我们复习**的一些单词，很多时候，我们制卡都是漫不经心，非常随意的扔到anki里面，并没有经过深度加工。判断一个生词是否易于复习的标准，就是我们是否易于理解这个单词。如果一个单词放到anki里面很久了，比如半年的时间了，我们遇到它的时候还是非常陌生，即便我们复习再多次，其实还是一样的会记不住。我们要经常使用搁置和暂停的功能，把我们很难理解的那些词过滤掉。然后集中在周末的时候我们搜索google或者是一些英文词典，来进行圈注一些自己的东西进去，帮助我们理解那些短句或者单词。要不然，anki始终还是一个囤积工具，并不会很高效的帮助我们规划复习。

搁置：anki里面的Bury Note，就是暂时隐藏掉这个单词卡，隔日再出现。

暂停：anki里面的Suspend Card，被暂停了之后，这个单词永远不会再出现，除非你取消暂停。一般我最常用的是这个暂停功能，被暂停的单词一般都是非常难的，或者我们还没有做好心理准备要去吸收记住它，或者它非常不好理解，这样子的单词我们需要定期筛选出来，多通过查词典，搜索google进行一系列的拓展，看看这个词在真实世界中是怎么使用的，比如我会复制一个词，去到Quera类似这种网站上面去搜索这个词，因为Quera网站上面大部分都是真实世界人们提问的一些地方。或者我搜索google，看看会出来什么结果，然后再结果中进一步去看看这个词，人们是怎么用的。如果遇到了比较好的例子，就会记录下来，这样子就加深了印象。难词就变得容易理解。

通过[游戏手柄](https://item.jd.com/100027491310.html)，配合Customize Keyboard Shortcuts插件，可以设置anki的快捷键，比如把suspend改为X键控制，可以把一些很难的单词直接给停掉，然后自己再去suspend标签里面去寻找那个单词，开启词典或者google或者维基百科去搜索相关的国外的母语者的释义，图片或者是词源网站，去拓展深挖了这个词。这样子能够提升我们的对于单词的理解。修改anki快捷键的插件来源地址：[https://ankiweb.net/shared/info/24411424](https://ankiweb.net/shared/info/24411424)，anki还有很多各种各样的插件，可以根据自己的学习进度和熟练度自己拓展，也可以看看老外们是怎么拓展anki功能的，可以参考：[https://youtu.be/9NUuw7DT4iM](https://youtu.be/9NUuw7DT4iM)

![FtyBVTFhdg](/images/posts/FtyBVTFhdg.png)

周末我们整理难词得时候，搜索 is:suspended就可以搜索出来暂停的单词，进行查词典，搜Google整理，完善这些笔记。搜索 is:buried 可以搜索出来被搁置的卡片。被取消暂停的卡片，将会被重新释放出来，然后anki会给你重新安排复习计划。

另外，anki的使用经验，不单单是可以向国外的人借鉴经验，同时国内可以多多向一些学霸借鉴经验，比如这位学霸的一些经验帖：[https://www.zhihu.com/column/ankigaokao](https://www.zhihu.com/column/ankigaokao)

![rZb8pLUNWW](/images/posts/rZb8pLUNWW.png)

另外，看看老外那些高手是怎么使用各种插件来拓展anki功能的，其实也可以拓展出来一堆的插件，在其中再挑选符合自己需要的。类似的插件还有一大堆，比如：

````c#
Accelerate Image Drag And Drop
Add Hyperlink
Anki Web Browser Selection searching
Batch Note Editing
Button Colours Good Again
Convert Subdecks to Tag Hierarchy
Create Filtered Deck from the Browser
Customize Sidebar
Edit Field During Review
Highlight Search reasults in the browser
ImageResizer
Night Mode
Progress bar
add-on window search bar
````

更多的anki插件，可以老外的这篇文章：[https://pawelcislo.com/2020/07/10/optimising-our-learning-retention-rate-with-srs-anki/](https://pawelcislo.com/2020/07/10/optimising-our-learning-retention-rate-with-srs-anki/)

![3TWLK39EtV](/images/posts/3TWLK39EtV.png)
