---
layout: post
title: 欧陆词典设置/Anki必装插件/ShareX配置
categories: English
description: 英文自学
keywords: English
---

本篇文章主要是补充一下anki周边的一些配套工具，最常用的就是在线词典助手，还有ShareX，以及欧陆词典+牛津高阶双解9 ；还有anki常用的[6个插件](https://cs-cn.top/2019/07/10/anki_pdf_js_study/#anki%E5%BF%85%E5%A4%87%E6%8F%92%E4%BB%B6)，建议都装上。
### 欧陆词典+牛津9

首选要保证你的电脑里面是安装了欧陆词典的，并且安装了mdx词典“牛津高阶双解词典9”这个版本，如果没有这个资源的，可以去这个[掌上百科](https://www.pdawiki.com/forum/)网站，各种开源词典都有，比较推荐`牛津高阶9`这个版本。加载到欧陆里面，它的版本信息如下：

<img src="https://cs-cn.top/images/posts/niujin9_351.png"/>

<img src="https://cs-cn.top/images/posts/niujin914552.png"/>

因为我使用过非常多的开源词典，有各种版本的都有，其中使用效果最好的还是这个牛津9.这个是从“[海明没有威](https://youtu.be/kl-i2to1zvw)”这个油管的博主群内分享出来的资源。“[掌上百科](https://www.pdawiki.com/forum/)”那个网站里面也是有下载的。因为国内大部分的开源英文词典都是从那个论坛流传出来的。

如果说还有什么更厉害的词典，那就是地表最强词典：英英原版的LEXICO词典：[LEXICO官方在线词典](https://www.lexico.com/)

<img src="https://cs-cn.top/images/posts/LEXICO_46.png"/>

我曾经看专业材料的时候，遇到很多的专业词汇，在牛津9和韦氏里面都查不到，包括去它们的官网都查不到，但是去到LEXICO就搞定了。收词量，LEXICO真的超级巨无霸。一般不是遇到特别特别超纲的词是不会祭出这个大杀器的，因为它的体积太大了。

#### ShareX配置

第一步：在D盘创建ShareX目录，再在这个目录新建文件夹Screenshots。

第二步：从[官网](https://getsharex.com/)下载ShareX，把ShareX安装到D盘的文件夹ShareX中，然后，**导入[ShareX的配置(点击这里直接下载配置文件)](https://cs-cn.top/assets/doc/ShareX-13.5.0-backup.sxb)**，如下图3 (gif动图).

<img src="https://cs-cn.top/images/posts/sharex12923.png"/>

<img src="https://cs-cn.top/images/posts/path_212853.png"/>

<img src="https://cs-cn.top/images/posts/sharex_import_config214256.gif"/>







第三步：按照 [https://animecards.site/setupsharex/#hotkey-for-audio](https://animecards.site/setupsharex/#hotkey-for-audio ) 这个文档安装完ffmpeg 这个插件。以下是配置顺序。基本都是点几下鼠标，直接下一步下一步。配置完之后，F2快捷键  ，F3快捷键就可以使用了。一个是截音频，一个是截图。美剧里面截取声音片段就靠这个功能。前提是不要有其他软件占着F2, F3快捷键。需要特别说明的是：由于最近Netflix还有Udemy这种国外的VIP收费类视频网站采用了加密技术，PC端截图工具截取视频内容的时候会显示黑屏。所以，推荐chrome[截图插件](https://chrome.google.com/webstore/detail/awesome-screenshot-screen/nlipoenfbbikpbjkfpfillcgkoblgpmj)截图来解决这个问题；而sharex的F2截图功能用来截欧陆词典释义。

<img src="https://cs-cn.top/images/posts/sharex_allconfig2326.png"/>

#### 欧陆词典配置

欧陆词典和ShareX配合使用如下：要做到这样，你的欧陆词典需要加载了牛津9，另外还得开启剪切板取词。下面第3幅图有具体的配置截图。

<img src="https://cs-cn.top/images/posts/myanki115246.gif"/>

用图片而不用文本复制粘贴，是因为anki会对粘贴的css html文本进行格式化，导致粘贴进去的排版格式和辞典中的不一致。

anki要精简css内容，是因为anki为了节省服务器硬盘资源，毕竟anki一直以来是免费为大家托管数据的，全球这么多人使用，数据量非常庞大，所以为了降低服务器硬件费用，它们官方就会对内容进行精简。

<img src="https://cs-cn.top/images/posts/pc_show115623.png"/>



如果遇到问题，请检查你的欧陆词典的配置，如下：

<img src="https://cs-cn.top/images/posts/oulu_559.png"/>

<img src="https://cs-cn.top/images/posts/jianqieban_853.png"/>



手机端IOS的效果：

<img src="https://cs-cn.top/images/posts/iphone_15918.png"/>

对于某些单词，有多个意思的，容易混淆的，可以用sharex自带的编辑功能，把精确的意思进行圈红处理，复习的时候节省时间。或者当一个单词意思在牛津9这本词典查不准的时候，可以多查一下其他词典。找到准确的解释。避免一开始录入anki中的是错误的释义，导致后面要想纠正就很难。因为每复习一次都是一错再错。不要一开始就领会了错误的释义，手头上一定要有好点的词典。

例如：Dink immediately recognized Wallis Wallace's signature, scrawled in big **loopy** letters.  loopy这个词。有道翻译出来的意思是“`丁克立刻认出了沃利斯·华莱士的签名，那是潦草的大字。` ”。scrawled 是马马虎虎，潦草地，作动词；big **loopy** letters 它翻译成了`大字`。loopy在这本牛津9查出来的意思只有2个：第1个意思是“失去理智的，疯狂的，奇怪的，怪异的”，第2个意思是“很生气，十分愤怒的”。在韦氏词典中查到的loopy的意思是：**表示带圆圈的字体**。其实这也体现了英式词典和美式词典的差距。而我们平时阅读的大部分材料其实都是美式的。市面上牛津这种英式词典资源比较多，大部分都是用牛津。而韦氏词典这个词典资源比较少，开源mdx词典收词量还是很有限。

词典资源还是要以中文词典为主，具体原因跟[海明没有威](https://youtu.be/kl-i2to1zvw)说的一样，这里不赘述。

<img src="https://cs-cn.top/images/posts/sharex_edit6220015.gif"/>



<img src="https://cs-cn.top/images/posts/loopy_10109.png"/>



这本偏美式的词典，韦氏2019下载地址：

百度网盘链接：[https://pan.baidu.com/s/1pzctTidgkqVa4pc6JCME0A](https://pan.baidu.com/s/1pzctTidgkqVa4pc6JCME0A ) 
提取码：wki2

类似的情况，牛津9搞不定的单词，韦氏可以搞定的还有：

“Sure, that’ll be fine,” said Lucky. He pretended to **zip his lips** closed. `他假装紧闭双唇`

这里的Zip有闭嘴的意思。一般常见的意思是“拉上拉链”。在牛津9这本词典里面，Zip这个词是查不到 “闭嘴”这层意思的。而在韦氏2019里面氏查到了“闭嘴”这个意思。不信，可以对照这两本词典试试。想象一下，这种看上去认识的词，并不一定就听得懂它的意思，听力问题，其实很多时候还是词汇问题。一词多义的情况在有声书里面实在是太多，口语里面大多是简单词，跟有声书里面类似。看上去都懂，实际上是熟词多义太多导致听不懂。如果是那种单纯的生词还好处理，记住就可以，但还有很多时候只能意译 而无法直译。像这种高频词一词多义的情况，只能通过场景偶遇，这种才是最难掌握的单词。四六级词汇`翻倍效应`就是这么来的。这里我依次截取了有道、韦氏、牛津作对比：其实也能够明显感受到，有声书大部分是偏美式的，有很多词在牛津这种英式词典中很难查到，需要去韦氏词典中找：

<img src="https://cs-cn.top/images/posts/dictionary_733.png"/>

所以，手里要准备两种类型的词典，一种是英式的一种是美式的。

### 美式词典和英式词典区别

牛津偏英式，韦氏偏美式。我们来看下`晾衣夹`这个单词，在美式词典和英式词典的区别，词典的质量好坏对于学习效果是有很大影响的！`clothespin` 这个词是美式用法，因为市面上大部分的原版书籍材料都是以**美式用法**居多。曾经有一段时间我也非常纠结是要美式还是英式，从纸质资源来看，美式的居多，还有美剧资源来看，也是美式的居多。这两者的区别，只有在查词典的时候能够感觉出来。从大的概率来讲，手头上得有一本英式词典、一本美式词典。不过，现在的牛津10这本词典对于英式和美式用法都有讲解。不必太纠结英式和美式。听力输入接近500小时，词汇量6000+那个时候做口语出书的时候，才决定自己是美式还是英式口音。前期学习阶段，英式和美式都是混合进行。看下`晾衣夹`这个单词先。

首先看下它的上下文场景：

`“Could Archie have opened his cage door himself?" Josh asked.`

`Mrs. Gwynn shook her head."We always keep a clothespin on his door to make sure he can't open it.`

`Mrs. Gwynn`的金丝雀从笼子里面跑出去了，`Josh`帮`Mrs. Gwynn`去寻找，在分析金丝雀丢失的原因的时候，上面是两个人的谈话，`Josh`问`Mrs. Gwynn`，是不是金丝雀自己把鸟笼打开了，自己飞出去的？而`Mrs. Gwynn`回答`Josh`说"我们总是在他的门上放一个晒衣夹，以确保它打不开  "； 这里，`Mrs. Gwynn`用晾衣夹来锁住鸟笼，防止金丝雀逃出鸟笼，非常接地气的一种生活场景。

以上例子原文出自有声书：《A to Z Mysteries》系列26本中的第3本书。并且牛津9这本词典还不一定可以查到这个词，牛津9这里对于clothespeg和clothespin的区别并没有做说明，当然大部分情况下我都是使用牛津，只是这里举例的都是一些特殊情况，想要传达的意思就是，随着你学习经验积累，使用很多种词典之后，就会发现英式词典和美式词典是有区别的，手里头两种词典都得有！

<img src="https://cs-cn.top/images/posts/niujin9_608.png"/>

<img src="https://cs-cn.top/images/posts/weishi_656.png"/>

相比之下，韦氏词典的这个解释，更匹配原著上下文的意思。

补充说明：这里牛津10效果会比牛津9的效果更好：

<img src="https://cs-cn.top/images/posts/niujin10_14.png"/>

可以看到，clothespin这个词，牛津10里面提到了clothespin是美式用法；而clothespeg是英式用法。需要牛津10的，在下面下载：

**牛津10**   **DownloadAddress**：

链接：[https://pan.baidu.com/s/1_GEFbeyeLeixTcgKd3xgIA](https://pan.baidu.com/s/1_GEFbeyeLeixTcgKd3xgIA ) 
提取码：kew8



### Anki必备插件

关于Anki，下载地址是官网:[https://apps.ankiweb.net/](https://apps.ankiweb.net/)

Anki插件市场首页：[https://ankiweb.net/shared/addons/](https://ankiweb.net/shared/addons/)，里面包含了所有anki常见的几百个插件：来至全世界各地。

<img src="https://cs-cn.top/images/posts/chajian_market4034.png"/>

推荐的Anki必备插件：

[Advanced Browser](https://ankiweb.net/shared/info/874215009),

[AnkiConnect](https://ankiweb.net/shared/info/2055492159),

[AwesomeTTS](https://ankiweb.net/shared/info/814349176),

[Fast Word Query](https://ankiweb.net/shared/info/1807206748),

[Set Font Size](https://ankiweb.net/shared/info/651521808),

[Batch Editing](https://ankiweb.net/shared/info/291119185)。

主要是以上6个插件。Anki插件一般的安装，都是去到[Add-ons for Anki](https://ankiweb.net/shared/addons/)首页，谷歌浏览器使用Ctrl + F  (搜索对应插件名)，进入插件详情页，在详情页找到插件对应code安装到anki中即可。需要注意的是AwesomeTTS会有两个版本，我用的是非官方版本，如果要官方版本的，到这里下载：[https://ankiweb.net/shared/info/1436550454](https://ankiweb.net/shared/info/1436550454)。

anki插件的安装，是通过插件对应的安装code来安装的，示范如下：

<img src="https://cs-cn.top/images/posts/install_anki_plugin159.gif"/>

示范的时候遇到了一个报错，因为anki无法在代理模式下工作，我当时开了代理上网。所以请无视那个报错信息，一般情况下只要你的网络畅通，都是可以正常安装这些插件的，如果你也使用了代理上网，请去掉代理之后重试一般都OK。



### 在线词典助手_Anki制卡模板

如果无法访问外网的，可以直接下载离线安装包：[在线词典助手离线安装包](https://www.laohuang.net/20190523/odh-offline-package/)

如果可以上外网的朋友，直接去[谷歌浏览器插件市场](https://chrome.google.com/webstore/detail/online-dictionary-helper/lppjdajkacanlmpbbcdkccjkdbpllajb)搜索了安装即可

**anki的模板(模板文件名为:NetFlix.apkg,  anki模板名称为:NetFlix-20210615)**，在上面的百度网盘里面资料中已经给出[NetFlix.apkg(也可以点击这里直接单独下载这个模板)](https://cs-cn.top/assets/doc/NetFlix.apkg),双击安装到Anki中即可。然后在线词典助手就可以按照下面的设置，之后就可以制卡了。

<img src="https://cs-cn.top/images/posts/netflix_plantform5541.png"/>



### 美剧制卡的多种方式

在开始进行美剧制卡之前，看下我这个百度网盘里面录制的这个视频，这里面说到了为啥我没有把这些方法大肆公开，是因为这些方法并不适合每一个学英语的人，而且里面涉及到法律，版权等问题。有很多方法是需要突破各种‘网络限制’的(而“翻(Q)iang"去上‘外网’是雷区，98%人没有这个条件，而且有些人对于anki不太认可，所以就没有太去宣传)，本博客提供的一切英语自学方法仅对有缘人有效，对于有决心学好英语的人提供有限的帮助，如果有疑问可以私下和我交流，这里提供的方法都没有对外公开，网络估计也搜索不到，仅供私下交流学习使用：

链接：[https://pan.baidu.com/s/1nMQDQ17XDVqLnZ6a-mhKDA](https://pan.baidu.com/s/1nMQDQ17XDVqLnZ6a-mhKDA ) 
提取码：0yg9

视频中提到的Anki制卡模板：[NetFlix.apkg(点击这里直接单独下载这个模板)](https://cs-cn.top/assets/doc/NetFlix.apkg)



如果是使用Potplayer播放器制卡的话，就是如下图2那样子：单词句子需要“Alt + E ” 打开字幕窗口，找到当前这一行的字幕，手动复制粘贴到anki的Browse窗口，使用Notes菜单 ----> Add Notes..菜单。手工添加单词卡片。ShareX负责截图和截取声音文件。(要查看大图，请**鼠标右键**从新页面打开图片)

<img src="https://cs-cn.top/images/posts/AddNotes328.gif"/>

<img src="https://cs-cn.top/images/posts/concernts422.gif"/>

