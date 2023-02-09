---
layout: post
title: Anki基础设置和操作(3)
categories: English
description: 
keywords: 记单词
typora-root-url: ../
---
Anki所有的参数信息比较多也比较复杂，如果要详细了解的，可以看看下面推荐的youtube视频介绍。参数非常重要，如果设置不当会导致很多严重的问题。

### Anki的参数原理

Anki参数详细讲解的，第一个视频是Matt的视频，地址是：[https://youtu.be/lz60qTP2Gx0](https://youtu.be/lz60qTP2Gx0)。

第二个讲解Anki参数的视频:[https://youtu.be/1XaJjbCSXT0](https://youtu.be/1XaJjbCSXT0)，这个可能讲解得更好。

<img src="https://cs-cn.top/images/posts/anki_parameter_means807.png"/>

<img src="https://cs-cn.top/images/posts/learning_Phase521.png"/>

<img src="https://cs-cn.top/images/posts/spance_repetition_seystem08.png"/>

简而言之，Anki在复习单词的时候，以答题的形式选择“Again，Hard，Good，Easy”这四个按钮，影响到的是每个单词的复习间隔。4个按钮的权重是不一样的，当点击不同的按钮的时候，对单词复习间隔的**百分比加成**是不同的。越是不熟悉的单词，间隔周期越短，越熟悉的单词，间隔周期越长。而且Anki设置中的有些参数还是互相制衡的，不是所有参数都可一直往上调的，达到临界值就调不动了。对于不熟悉的单词不建议点击 Again而建议点击Hard，因为点击Again次数太多会导致Ease Hell情况的发生，如果发生了Ease Hell问题，解决办法请参考这篇文章：[https://cs-cn.top/2019/08/12/Anki_Interval_Modifier/](https://cs-cn.top/2019/08/12/Anki_Interval_Modifier/)

### 0.我的anki参数设置

![anki_Eyp9ONnD8V](/images/posts/anki_Eyp9ONnD8V.png)

![anki_6xG2XY6FJa](/images/posts/anki_6xG2XY6FJa.png)

![anki_EqJkyO3es4](/images/posts/anki_EqJkyO3es4.png)



如果是看美剧或者youtube的制卡视频，最好是采用这个FSRS4Anki插件。这个插件的使用在我的博客中有文章专门介绍了。

### 1.Anki统计图的查看

统计图里面的饼图，条形图，柱状图都是可以点击的，点击之后，会跳转到Anki的浏览窗口去。比如Ease统计这里，随便点击一根柱状：

<img src="https://cs-cn.top/images/posts/ease_1201.png"/>

浏览窗口的input栏，会出现 `  "prop:ease>=2.3" AND "prop:ease<2.4"`

因为我们的鼠标点击的是230%这根柱子，所以查看到的是单词难度在230%   ~ 240% 之间的数据。因为这根柱子右侧紧挨着的是240%这根柱子。我们可以分析出大概还有多少单词，我们是比较陌生的，还有多少单词我们是比较熟悉的。也就能看出自己的学习效果，通过这段时间学习大概提升了多少词汇量。学习者是懒了，还是勤快，通过数据就能看到，更好了解自己。

<img src="https://cs-cn.top/images/posts/search_reasult2231.png"/>

### 2.筛选特定颜色的单词

比如Flag 1代表的是红色旗子，筛选的方法就是直接在过滤器种输入:`Flag:1`，然后回车，所有被标记过红色旗子的单词都会被筛选出来(如图，筛选出来164个红色标记的单词)。输入的参数它会自动给加上双引号：

<img src="https://cs-cn.top/images/posts/red_Flag829.png"/>

其他的类似：

`Flag:2`橘黄色

`Flag:3`绿色

`Flag:4 `蓝色

`Flag:5` 紫色

........

输入`Flag:2`,过滤出来橘黄色的单词：

<img src="https://cs-cn.top/images/posts/orange_704.png"/>



一般我常用的就是前面这几种旗子，用来做标记的。难的单词一般都是标记为红色旗子。或者有些单词，复习的时候发现单词释义需补充才能更好理解那个词，可以标记为蓝色，等到有空的时候抽空对那些单词进行整理，就跟我们平时整理笔记内容一样，把难点进行重点攻克，插上记号是为了找起来方便。手机端和PC端，安卓苹果端都是有这些旗子标记功能的。



另外筛选牌组学习计划的时候，也是支持这种筛选的语法的，多个筛选条件之间用`ADN`连接：

<img src="https://cs-cn.top/images/posts/flag_filters844.png"/>

比如，在地铁刷单词的时候，突然发现有个单词的解释给弄错了，想要在电脑上进行编辑，但是人又在外面不方便，怎么办，那就可以先在手机上标记这个单词，比如给它一个紫色的标记，等有空的时候，回到电脑上把紫色的单词筛出来，编辑好之后，再去掉紫色标记。

对被标记过颜色的单词，再进行一次相同颜色的标记，就会把这个颜色标签去掉。

<img src="https://cs-cn.top/images/posts/re_flag33.png"/>

### 3.Anki左侧栏菜单

左栏菜单也是非常有用的。包括**旗子**这种标记，还有对卡片的**状态**归类，以及对卡片被处理的**时段**划分，卡片所处的时间有“即将要被复习的”，“最近添加的”，“最近被编辑过的”，“最近学习过的”，“最近被点击Again”这些按照时间划分的，这些条件都可以组合起来，最终去筛选需要的单词。

 卡片的状态主要有“挂起状态”的Suspended；“学习中”的状态Learning；“复习中”的状态Review；Buried这个状态是“埋藏”的一种状态，经常用来搁置一个单词的复习，比如说今天我不想复习这个单词，留到明天去复习，可以Buried掉这个单词，第二天还会再次出现。而Suspended是挂起一个单词，下次再也不会出现这个单词了。这是需要注意区分的地方。其实总体而言，anki的东西就这么多。本博客里面3篇文章应该全部覆盖到了，有的是提供了Anki其他学习资料，比如老外的油管的教学视频，可以帮助进一步了解anki这种间隔复习，每次点击一个按钮的时候，复习的时间到底是怎么计算得出来的，可以做到非常清楚。

<img src="https://cs-cn.top/images/posts/anki_left_bar916.png"/>

每次点击左侧的菜单的时候，浏览器的input框就会出现双引号的指令，比如：

`"prop:due=0" `表示：今天需要复习的单词；

`"added:1"` 表示：最近一天被添加进anki的单词

`"edited:1" `表示：最近一天被编辑修改过的单词

`"flag:1" ` 表示：被标记为红色旗子的单词

而且这些条件的数字都是可以修改的，然后各种条件可以通过  `AND` 组合在一起，形成新的搜索命令。

比如，我想搜索今天将要复习的单词中，被标记为红色旗子的单词，搜索指令就是：`"flag:1" AND "prop:due=0"`,搜索出来的结果如下：

<img src="https://cs-cn.top/images/posts/search_result420.png"/>

绝大部分的搜索指令，我们只需要鼠标点击几下侧边栏，然后看看input框出现的对应的这些指令，就能学会。

其他的侧边栏菜单，相对就比较好理解了，Decks这个其实就是表示的单词本，把单词按照不同的名字存储在不同的分类里面，anki里面翻译过来叫做“词牌组”。不太好理解，我直接把它理解为**单词本**。另外Note Types其实就是表示的单词卡所使用的**模板文件**。而Tags这个是给单词卡添加额外标签的。这个没有旗子标记那么好用。

<img src="https://cs-cn.top/images/posts/left_bar5619.png"/>

Tags这个东西用得非常少，几乎没用，而且它是可以直接删除的，会影响到所有的单词卡片。被标记过`ODH`标签名的单词，这个标记都会被清空。

<img src="https://cs-cn.top/images/posts/tags058.png"/>

### 4.IOS手机端按钮设置

IOS苹果手机端的Anki，这些快捷按钮都是可以拖拽，顺序可以根据自己需要摆放的。我最常用的按钮就是Undo，还有Suspend Note，Flag 4， Flag 1 . 因为一般在地铁上，放在这个位置方便右手单手操作。

<img src="https://cs-cn.top/images/posts/short_cut4237.png"/>

### 5.如何解决冲突 恢复数据

如果同步数据的时候，发现手机端和PC端发生了冲突，那么就会弹出如下的对话框：

<img src="https://cs-cn.top/images/posts/conflits0131.png"/>

偶尔会发生这种情况：比如当天要复习200个单词。由于一会儿在PC端操作，一会儿又在手机端操作。PC端你操作了35个单词，手机端操作了200个单词，同时都操作了就会发生同步不一致。就需要用到还原功能。

<img src="https://cs-cn.top/images/posts/backups137.png"/>

由于anki的手机端和PC都会每隔1小时进行一次备份。所以，可以把手机端的数据恢复到1小时之前的状态。然后强制用手机端的数据去覆盖AnkiWeb云服务器中的数据。以手机端为准就还原手机端1小时之前的数据，并同步覆盖，如果以PC端为准就还原PC端一小时前的备份，同步覆盖。

刚开始使用Anki没多久的新手，经常发生数据冲突的问题。建议把数据备份的间隔设置为1小时备份一次。保留50份备份。手机端和PC端都可以设置。

### 6.新的一天开始于凌晨4点

建议手机端和PC端都设置，新的一天的开始时间为凌晨4点。这样设置，那么每天需要复习的单词，会在凌晨4点的时候弹出提醒。而不是在凌晨0点的时候弹出提醒，设置如下：

<img src="https://cs-cn.top/images/posts/new_day_begin859.png"/>

### 7.搜索非空字段

在anki搜索栏中，搜索空字段我们都会操作，但是搜索非空字段的语法是啥呢，如下：

```shel
added:2 Meaning:_*
```

上面这个搜索语法，是搜索最近2天添加的，Meaning字段不为空的卡片。

![anki_1hmQYDcYDx](/images/posts/anki_1hmQYDcYDx.png)

