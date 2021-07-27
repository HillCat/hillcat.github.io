---
layout: post
title: 怎么设置Anki的各种参数
categories: English
description: 
keywords: 记单词
---
Anki所有的参数详细教程，在Matt的视频中有详细的讲解，地址是：[https://youtu.be/lz60qTP2Gx0](https://youtu.be/lz60qTP2Gx0)

讲解得非常详细，所以我就不赘述了。可以使用谷歌浏览器，开启 [Language Learning with Youtube](https://chrome.google.com/webstore/detail/language-learning-with-yo/jkhhdcaafjabenpmpcpgdjiffdpmmcjb)插件，并且把机器翻译开起来，字幕调节到英文，然后使用language Learning with Youtube开启对英文的翻译。

<img src="https://cs-cn.top/images/posts/anki_options0547.png"/>

### Anki背后的工作原理详解

安装好插件之后，需要开启机器翻译的英文字幕，然后对language Learning with Youtube进行设置，具体如下：

<img src="https://cs-cn.top/images/posts/learn_youtube_settings0952.gif"/>

开启右侧滚动字幕，只需要进行如下设置即可，点击图中箭头所指的位置，展开字幕即可，如果不明白的地方可以暂停视频，看英文字幕，查下单词理解他讲的东西，因为他还有做示范，所以应该是很容易理解的：

<img src="https://cs-cn.top/images/posts/right_bar_settings609.png"/>

Matt对于Anki的理解比较深刻，各种参数他都了如指掌，看完他这个视频，相信你会对于那些参数熟练掌握。

还有个视频教程也不错(人工英文字幕，不是机器翻译的)，他有PPT还列出来了详细的计算公式，视频地址：[https://youtu.be/uLfczzq9z_8](https://youtu.be/uLfczzq9z_8) 。Again，Hard，Good，Easy四个按钮。分别代表了不同的权重。权重值不同，对于一个单词的复习间隔**百分比加成**是不同的。越是不熟悉的单词，间隔周期越短，越熟悉的单词，间隔周期越长。一般个人建议，不要把间隔最大的周期超过半年，也就是说这些放入anki里面的单词，再怎么熟悉，间隔不要超过半年，半年之后仍然还是需要复习一下的。文末附上我的详细设置。

<img src="https://cs-cn.top/images/posts/parameters_caculator4716.png"/>



<img src="https://cs-cn.top/images/posts/anki_settings_01_413.png"/>

<img src="https://cs-cn.top/images/posts/anki_settings_02_447.png"/>

<img src="https://cs-cn.top/images/posts/anki_settings_03_528.png"/>

<img src="https://cs-cn.top/images/posts/anki_settings_04557.png"/>

如果你觉得一个单词太简单，不需要再复习了，那么直接suspend note按钮，挂起那个单词即可，如下图那样(安卓端也是有这个功能，PC端也有)。比如，你可以给一个单词打上Flag 4(Blue)标签。 旗子记号还有红色，橘色，绿色，紫色，宝石绿 ，7种颜色。而且被标记颜色的单词，是可以轻松筛选出来的。

<img src="https://cs-cn.top/images/posts/suspend_note048.png"/>

### 筛选特定颜色的单词

比如Flag 1代表的是红色旗子，筛选的方法就是直接在过滤器种输入:`Flag:1`，然后回车，所有被标记过红色旗子的单词都会被筛选出来(如图，筛选出来164个红色标记的单词)。输入的参数它会自动给你加上双引号：

<img src="https://cs-cn.top/images/posts/red_Flag829.png"/>

其他的类似：

`Flag:2`橘黄色

`Flag:3`绿色

`Flag:4 `蓝色

`Flag:5` 紫色

........

输入`Flag:2`,过滤出来橘黄色的单词：

<img src="https://cs-cn.top/images/posts/orange_704.png"/>



一般我常用的就是前面这几种旗子，用来做标记的。难的单词一般都是标记为红色旗子。或者有些单词，复习的时候你发现单词释义需补充你才能更好理解那个词，你可以标记为蓝色，等到有空的时候抽空对那些单词进行整理，就跟我们平时整理笔记内容一样，把难点进行重点攻克，插上记号是为了找起来方便。手机端和PC端，安卓苹果端都是有这些旗子标记功能的。



另外筛选牌组学习计划的时候，也是支持这种筛选的语法的，多个筛选条件之间用`ADN`连接：

<img src="https://cs-cn.top/images/posts/flag_filters844.png"/>

比如，在地铁刷单词的时候，突然发现有个单词的解释给弄错了，想要在电脑上进行编辑，但是人又在外面不方便，怎么办，那就可以先在手机上标记这个单词，比如给它一个紫色的标记，等有空的时候，回到电脑上把紫色的单词筛出来，编辑好之后，再去掉紫色标记。

对被标记过颜色的单词，再进行一次相同颜色的标记，就会把这个颜色去掉。

<img src="https://cs-cn.top/images/posts/re_flag33.png"/>

### IOS手机端按钮设置

IOS苹果手机端的Anki，这些快捷按钮都是可以拖拽，顺序可以根据你自己需要摆放的。我最常用的按钮就是Undo，还有Suspend Note，Flag 4， Flag 1 . 因为一般在地铁上，放在这个位置方便右手单手操作。

<img src="https://cs-cn.top/images/posts/short_cut4237.png"/>

### 如何解决冲突 恢复数据

如果同步数据的时候，发现手机端和PC端发生了冲突，那么就会弹出如下的对话框：

<img src="https://cs-cn.top/images/posts/conflits0131.png"/>

偶尔会发生这种情况：比如你当天要复习200个单词。由于你一会儿在PC端操作，一会儿又在手机端操作。PC端你操作了35个单词，并且这35个单词的复习进度给同步上传到AnkiWeb，同时你也在手机端操作这200个单词，并且操作过程中你没有同步，而是等到把所有的200个单词操作完成之后再上传到AnkiWeb，这个时候你会发现，同步的时候，居然是用PC端的数据把你手机端的覆盖掉。

也就是说，本来你今天完成了这200个单词复习的，结果一同步，回到了解放前。怎么办呢，

<img src="https://cs-cn.top/images/posts/backups137.png"/>

由于anki的手机端和PC都会每隔1小时进行一次备份。所以，你可以把手机端的数据恢复到1小时之前的状态。然后强制用手机端的数据去覆盖AnkiWeb云服务器中的数据。这个时候，云端的数据和你手机的数据都是正确的了。再到PC端进行同步，它会提示你，PC端数据和云端AnkiWeb发生了冲突，问你是要用PC的去覆盖AnkiWeb云端的还是用云端AnkiWeb的数据覆盖你PC端的。那么你选择用AnkiWeb云端的覆盖PC的即可。 那么这样，三端的数据都是以手机端的为准了。

这种情况偶尔会发生，防止你复习的工作都白做了，建议你把数据备份的间隔设置为半小时备份一次。保留50份备份。手机端是可以设置备份间隔的。

### 新的一天开始于凌晨4点

建议你的手机端和PC端都设置，新的一天的开始时间为凌晨4点。这样设置，那么每天需要复习的单词数，会在凌晨4点的时候弹出提醒。而不是在凌晨0点的时候弹出提醒，因为有时候过了零点了，可能你还没有睡觉，发现今天的复习任务还没有完成。那么就可以在凌晨1~2点的时候，复习完当天还没有完成的任务。防止它到了零点的时候就把第二天的复习量给你弹出来。毕竟这种情况经常发生：到了快要睡觉的时候才想起今天还有任务没有完成。

<img src="https://cs-cn.top/images/posts/new_day_begin859.png"/>

