---
layout: post
title: Anki制卡配套工具推荐
categories: English
description: 英文自学
keywords: English
---

本篇文章主要是补充一下anki周边的一些配套工具，最常用的就是在线词典助手，还有ShareX，以及欧陆词典+牛津高阶双解9 ；其实还有很多anki的插件配置这里没有给出来，只能等有空的时候再完整本篇文章。
### 欧陆词典+牛津9

首选要保证你的电脑里面是安装了欧陆词典的，并且安装了mdx词典“牛津高阶双解词典9”这个版本，如果没有这个资源的，可以去这个[掌上百科](https://www.pdawiki.com/forum/)网站，各种开源词典都有，比较推荐`牛津高阶9`这个版本。加载到欧陆里面，就是下面红色那本的样子：

<img src="https://cs-cn.top/images/posts/niujin_4404.png"/>

<img src="https://cs-cn.top/images/posts/niujin914552.png"/>

因为我使用过非常多的开源词典，有各种版本的都有，其中使用效果最好的还是这个牛津9.这个是从“[海明没有威](https://youtu.be/kl-i2to1zvw)”这个油管的博主群内分享出来的资源。“[掌上百科](https://www.pdawiki.com/forum/)”那个网站里面也是有下载的。因为国内大部分的开源英文词典都是从那个论坛流传出来的。

### ShareX

其次就是你需要配置好ShareX这个软件的截图功能，现在我的很多生词的操作都是在windows电脑上面进行的。使用快捷键F3，按一下，把图片粘贴到anki里面去的，做到“快”，“准”，“稳”。效果如下：

<img src="https://cs-cn.top/images/posts/myanki115246.gif"/>

为什么要用图片，而不是文字插入呢？之前我用过很多不同排版格式的词典，而anki从词典里面复制粘贴的文字的时候,css的样式是会有变形的，要保留样式可以使用`shift + ctrl +V `快捷键,即便是使用这个快捷键，也会有文字样式的丢失，无法做到100%还原排版样式。因为有些单词会出现一词多义，并不是`牛津9`一本词典就可以搞定的，有时候还要借助其他的词典，复制粘贴的时候总会丢css样式,因为很多样式都是行内样式，anki为了节省服务器硬盘资源，在你粘贴文本到anki编辑框的时候，它会故意去掉样式，去掉部分样式之后，文本变得奇丑无比，影响复习效果。而且如果分散更多精力在排版和编辑上，又会造成“没有太多的时间去阅读输入和进行听力训练“。因为这套方法是平民方法，所以对于时间成本和效率十分在乎。尽量不要在制卡的时候花费太多时间。

直接用ShareX截图，圈住词典的图片释义之后，直接粘贴到Anki编辑框里面，剪切板内图片的复制是Sharex自动帮你完成的。

<img src="https://cs-cn.top/images/posts/pc_show115623.png"/>



欧陆词典的配置如下：

<img src="https://cs-cn.top/images/posts/oulu_559.png"/>

<img src="https://cs-cn.top/images/posts/jianqieban_853.png"/>



手机端IOS的效果：

<img src="https://cs-cn.top/images/posts/iphone_15918.png"/>

对于某些单词，有多个意思的，容易混淆的，可以用sharex自带的编辑功能，把精确的意思进行圈红处理，复习的时候节省时间。或者当一个单词意思在牛津9这本词典查不准的时候，可以多查一下其他词典。找到准确的解释。避免一开始录入anki中的是错误的释义，导致后面要想纠正就很难。因为每复习一次都是一错再错。不要一开始就领会了错误的释义，手头上一定要有好点的词典。

例如：Dink immediately recognized Wallis Wallace's signature, scrawled in big **loopy** letters.  loopy这个词。有道翻译出来的意思是“`丁克立刻认出了沃利斯·华莱士的签名，那是潦草的大字。` ”。**loopy** 它翻译成了`潦草`。因为`牛津9`查出来的意思只有2个，导致我误以为是loopy在这里是“奇怪”的意思，翻译为`奇怪的字体，怪怪的字体`好像也说得通,于是我圈红了这个意思，录入到anki中。每次复习的时候，都这么记，越错越深。好在我手里有2本词典，记了好几次，发现不对劲，loop有`环`的意思，但是它跟“奇怪”的字体有啥关系呢？带着这个疑问，于是多查了几下其他词典。韦氏词典中查到的意思是：**表示带圆圈的字体**，这就很好理解了，瞬间就记住了，而手头这本牛津9压根查不出来这层意思，所以，手上要多备几本词典，只有1本词典是不足以应付母语国家这种分级读物的。手里要至少准备2本电子词典。我以前刚开始学有声书的时候，多达6本词典。但是最终留下来的好词典真的不多。

<img src="https://cs-cn.top/images/posts/sharex_edit6220015.gif"/>



<img src="https://cs-cn.top/images/posts/loopy_10109.png"/>



另外推荐我手里这本韦氏V3：

百度网盘链接：[https://pan.baidu.com/s/1pzctTidgkqVa4pc6JCME0A](https://pan.baidu.com/s/1pzctTidgkqVa4pc6JCME0A ) 
提取码：wki2

像博文中提到的这些复杂的工具，它们的配置，其实可以制作成[autoit脚本](https://www.autoitscript.com/site/)，我这边配置好之后，直接让自动化脚本给你们搞定所有安装。不过要写autoit脚本实现自动化安装，比较耗时。所以只能是录制视频或者写文章的形式告知网友自己去摸索。等哪天有空，我会把这些手动配置的繁琐过程，全部做成脚本形式。以免难倒很多电脑小白。

autoit这个自动化工具我以前使用过，不难，很简单，但是写脚本需要有一定的代码能力。等有空再写这种脚本，到时候写好了更新到博客中。



ShareX的配置这个涉及到比较复杂的操作，需要**导入我给的那个[ShareX的配置](https://cs-cn.top/assets/doc/ShareX-13.5.0-backup.sxb)**，然后稍微按照
[https://animecards.site/setupsharex/#hotkey-for-audio](https://animecards.site/setupsharex/#hotkey-for-audio) 这个文档安装完ffmpeg 这个插件，在ShareX安装目录创建Screenshots文件夹,就可以使用快捷键F2，和快捷键F3了。F2是截声音，F3是截图。

ShareX官网：[https://getsharex.com/](https://getsharex.com/)



<img src="https://cs-cn.top/images/posts/sharex_import_config214256.gif"/>

如下图，我是把ShareX安装在D盘，D盘目录下面有个ShareX目录，在这个里面自己还创建了一个Screenshots文件夹用来保存截图。

如果你是直接导入的我的配置文件，请也按照此路径安装，并且创建一个自定义文件夹Screenshots。

<img src="https://cs-cn.top/images/posts/sharex12923.png"/>

<img src="https://cs-cn.top/images/posts/path_212853.png"/>

ShareX配置导入之后，还需要进行一些配置，如下：(鼠标右键，新标签页中打开此图片)

<img src="https://cs-cn.top/images/posts/sharex_allconfig2326.png"/>



### Anki工具

关于Anki，下载地址是官网:[https://apps.ankiweb.net/](https://apps.ankiweb.net/)

Anki插件首页：[https://ankiweb.net/shared/addons/](https://ankiweb.net/shared/addons/)

Anki常用插件：

Advanced Browser,

AnkiConnect,

AwesomeTTS,

Fast Word Query,

Set Font Size,

Batch Editing。

主要是以上6个插件。可以去到Anki插件首页，Ctrl + F  (搜索对应插件名)，找到插件对应code安装到anki中即可。需要注意的是AwesomeTTS会有两个版本，建议选择官方版本：[https://ankiweb.net/shared/info/1436550454](https://ankiweb.net/shared/info/1436550454)。

anki插件的安装，是通过插件对应的安装code来安装的，示范如下：

<img src="https://cs-cn.top/images/posts/install_anki_plugin159.gif"/>



### 在线词典助手

如果无法访问外网的，可以直接下载离线安装包：[在线词典助手离线安装包](https://www.laohuang.net/20190523/odh-offline-package/)

如果可以上外网的朋友，直接去谷歌浏览器插件市场搜索了安装即可

anki的模板，在上面的百度网盘里面资料中已经给出。

<img src="https://cs-cn.top/images/posts/anki_assists145452.png"/>

