---
layout: post
title: 通过美剧学英语_anki如何制卡(13)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

这个美剧制卡的方法，其实在很久之前我尝试过，失败了，但是直到最近尝试和摸索成功之后，我发现，美剧学英语的效果确实非常好，只是长期以来美剧制卡一直是个难题。根据我自己实践体验，这种的复习效率很高，更加容易坚持。

![66667777](/images/posts/66667777.gif)

这种制卡方式使用的是anki结合mpv，离线的美剧，在线的youtube都能搞定，这给英语提升带来了极大的希望。

从我几年来的观察分析看，这个方法是国外很多语言习得大神们普遍采用的，也是为何我一直推荐使用anki的原因,anki使用群体遍布世界各地，生态非常强大，工具特别多，有的东西甚至超出了我的想象。

youtube有几个博主大神就是用这个方法，比如:`Matt vs japan`，`Giovanni Smith`也都是用这种方法。我很久以来没有用这个方法的主要原因，是我电脑安装mpv播放器失败，导致了我放弃了这种美剧制卡的方式，主要是因为我比较粗心，没有仔细阅读英文材料来研究这个方法。因为这个方法涉及到的资料大部分都是英文的。

![chrome_UpKqYv6fnw](/images/posts/chrome_UpKqYv6fnw.png)

![chrome_nJQ9JlTXYt](/images/posts/chrome_nJQ9JlTXYt.png)

Giovanni Smith我在几年前关注过他，他在使用anki的过程中也走了很多弯路，其实跟我一样，我也走了很多弯路。包括Matt vs Japan他很多年前的这个方法我尝试过，也怪自己当时尝试失败就放弃了。这里强烈建议，windows电脑一定要使用[chocolatey](https://chocolatey.org/)这个工具来管理软件包，特别特别重要，另外电脑还要开启帆樯功能，搞英语，如果你无法帆樯，基本会给英语学习造成无限障碍。

Giovanni Smith用这个方法通过了HSK6的考试，根据百度百科的解释：`6级是新汉语水平考试HSK的最高等级，通过HSK 6级的考生可以轻松地理解听到或读到的汉语信息，以口头或书面的形式用汉语流利地表达自己的见解`，对于一个美国黑人来说，学习中文3年，能够通过HSK6考试，我觉得已经很厉害了。但是据他自己说，即便通过了最高级别考试，还是无法流利进行中文口语输出，其实这个也在我意料中，因为考试能力并不等于真实的语言能力。去年的时候，他录制过一个视频，说的是他自己使用了1年的anki，用法上的错误，曾经导致想要放弃，那个时候我还留言给他，要他防止陷入复习陷阱中。后来过了几个月我再看他的发的视频，他最终还是承认了anki的间隔复习是有效的，之所以无效，是因为很多人无法长期坚持。又过了很久，我再看这个小伙子，他居然考过了HSK6。他最近的视频心得，展示了他这几年使用anki学中文的数据，复习单词的次数是50万次，而我使用anki的复习的次数是17万次左右。我分析了自己跟Giovanni Smith之间的差距的原因，一方面他是从零开始学汉语，制卡量巨大。而我长期以来都是阅读有声书的方式制卡，而Giovanni Smith有很大一部分卡片是看剧制卡。从卡片复习难度和可坚持程度而言，看剧制卡要比有声书制卡更容易坚持，Giovanni Smith是每天复习500多张卡片，雷打不动。而我是每天是复习300长卡片。这就是我跟他之间的区别。我上面只是举了Giovanni Smith的例子，其实Matt vs Japan他学日语也有类似经历，他后来创建的会员群里面大部分的学员，都是使用"看剧"的方式学语言。看剧我一直没有找到比较好的制卡方式，血的经验也再次证明了看剧的重要性。看剧制卡配置方法写篇文章记录下，其他有需要的朋友作为参考。细节部分的操作，就仁者见仁智者见智了。这里只讲安装和配置部分。



## mpv anki视频制卡

### 1，安装chocolatey

因为安装mpv播放器和youtube-dl和ffmpeg都需要通过chocolatey安装，所以最先要安装的是chocolatey：

这里提及到的所有软件的安装，都是在管理员权限之下进行。

chocolatey官方文档强烈建议用户采用离线安装的方式,如果你发现你电脑windows安装chocolatey失败，或者无法联网的报错，一般都是因为没有开启全局帆樯导致的，所以一定要能够帆樯才行。如果你已经是在国外，没有网络访问限制，那么安装这些软件的速度都应该是飞快的。

chocolatey官方文档，安装说明：一定要仔细看这个官方安装说明，安装代码和命令都在这个文档中：

[https://docs.chocolatey.org/en-us/choco/setup](https://docs.chocolatey.org/en-us/choco/setup)

按照上面地址的文档说明，chocolate安装方式有2种，一种是通过cmd安装，一种是powershell方式安装。选择其中1种即可.

第一种方式：Install with cmd.exe，指的是使用Command Prompt来执行命令：

```shell
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "[System.Net.ServicePointManager]::SecurityProtocol = 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"
```

Command Prompt打开方式如下：打开之后，粘贴上面的所有命令，之后回车运行即可。

![Typora_yozA6jxQns](/images/posts/Typora_yozA6jxQns.png)

第二种方式：Install with PowerShell.exe,指的是运行PowerShell命令行来执行命令：

```shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

PowerShell打开方式如下：打开之后，粘贴上面的所有命令，之后回车运行即可。

![KUGatcqZKF](/images/posts/KUGatcqZKF.png)



我个人倾向于使用第二种方式PowerShell来安装chocolatey，最好是开启全局帆樯，切记。国内这些坑爹的网络环境，有可能造成依赖项安装失败。

可能会发现，我发的这些地址都是英文的，有时候即便是研究英文自学方法，本身对于英文的阅读能力也有要求，还得懂一些电脑软件原理。很多资料看不懂，几乎没法研究这些工具,我懂编程，搞这些玩意，有时候都搞得奔溃。使用这种方法的人非常少主要是配置繁琐，对于小白基本可以直接劝退99%的人。chocolatey安装好之后，下面直接安装其他软件包，一定要按顺序操作。检测chocolatey是否安装成功的方法，就是打开PowerShel，输入choco，回车，如下图，如果看到没有报错，即表示安装成功。

![powershell_5G3YUqCTT8](/images/posts/powershell_5G3YUqCTT8.png)

## 2.安装mpv

我这里使用choco方式安装，以管理员权限运行powershell，执行下面命令：

```shell
choco install mpv
```

![Obsidian_Ctvz3ykLcj](/images/posts/Obsidian_Ctvz3ykLcj.png)

![Obsidian_JAZ4lroQx7](/images/posts/Obsidian_JAZ4lroQx7.png)

mpv播放器需要播放youtube的url视频，需要电脑默认安装youtube-dl这个插件。
这里尝试也使用choco来安装。

### 3.安装youtube-dl

同样也是通过choco安装，powershell管理员权限，执行下面命令：

```shell
choco install youtube-dl
```
使用choco安装的好处是，自动脚本安装好，避免自己手动安装出现错误，这一点极为重要，这也是我1年前，探索美剧制卡失败的关键原因，就是因为我没有使用choco方式安装软件包。

![Obsidian_Bb0W9OWsXH](/images/posts/Obsidian_Bb0W9OWsXH.png)

只有在使用choco完整安装了mpv和youtube-dl之后，url链接从浏览器直接鼠标拖拽到mpv播放器，才能直接播放youtube频道的视频。这种革命性的工具，让我们学习地道英文，去贴近真实环境又更进一步了。类似下面的效果:这是直接播放的一个url地址，在我电脑硬盘中并没有这个视频。它是实时拉取url网页自动分析视频地址然后加载到播放器种，这样子即便不需要下载youtube视频离线，在线的方式我们就可以制作youtube的anki视频卡。

![Obsidian_UgSM0jbUMG](/images/posts/Obsidian_UgSM0jbUMG.png)

你知道有了这个东西之后，看美剧Netflix和youtube制卡，这个复习上的“容易坚持的程度”将是其他方法不可比拟的。并且，这个播放器这么设置之后，直接拖拽B站URL地址是可以直接播放的，要播放油管视频，也是直接拖拽URL地址即可。油管里面又太多的真人秀，谈话节目，都可以这么操作了。

### 4.安装ffmpeg

这个插件是用来截取mp4和mp3的，程序自动分析台词之后，根据台词的音轨来断句，截取视频片段和音频片段。淘宝上面售卖的很多anki牌卡，其实都是用这种方式制卡的。手工精修。当然，这些人应该是anki的熟手二道贩子了。这些方法一方面是繁琐的配置，另一方面，有些人其实并不想公开。说真的，制作一个教程，要花费的精力太多，很多人不想录制教程。

![chrome_7ZGD4UqfqG](/images/posts/chrome_7ZGD4UqfqG.png)

![chrome_TICTai6Q6c](/images/posts/chrome_TICTai6Q6c.png)



安装ffmpeg也通过choco安装，参考：
[https://community.chocolatey.org/packages/ffmpeg](https://community.chocolatey.org/packages/ffmpeg)

也是通过powershell管理员权限，执行下面指令：

```shell
choco install ffmpeg
```

![Obsidian_y1M27hyg3I](/images/posts/Obsidian_y1M27hyg3I.png)



### 5.安装anki插件

[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)
这里使用mpv制卡，需要anki上面这个插件来配合，具体插件的说明文档也在这个地址中有说明。

插件配置，整体的界面如下：

先确认你已经安装了这个Crete subs2srs cards with mpv video player插件。

![anki_0YCtWRQvHD](/images/posts/anki_0YCtWRQvHD.png)

![Typora_xjtHQPxqCr](/images/posts/Typora_xjtHQPxqCr.png)



我相信，一般的anki小白或者中等用户，可能不知道如何使用这个插件进行美剧制卡，因为这个插件的使用人数貌似不多。通过Open Video..这个打开之后，界面如下：通常我使用快捷键 Ctrl + O 打开这个界面。

![anki_u4jnIEfEfI](/images/posts/anki_u4jnIEfEfI.png)

上面是我已经设置好的界面，Type这个里面需要选择一个模板，官方插件种提供了模板的下载地址。

![Typora_KDrVELN6GA](/images/posts/Typora_KDrVELN6GA.png)



通过这个地址[https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b](https://gistpreview.github.io/?d515535b80a3d8f0775989e0d83c8a3b)下载Deck模板，

![Typora_BYfm7FbVsW](/images/posts/Typora_BYfm7FbVsW.png)

注意看我选择的是哈利波特魔法石，高亮 ，这个模板：

![F8VkgIxs8z](/images/posts/F8VkgIxs8z.png)

这个Deck模板来源于上面链接提到的apkg：

![image-20230107140244548](/images/posts/image-20230107140244548.png)

如果你操作一切正常，是可以下载到这个`Harry Potter and the Sorcerer's Stone (2001).apkg`的。

![6MWzXM7j8v](/images/posts/6MWzXM7j8v.png)

这些配置全部完成之后，点击上面那个界面种的`Open File`就可以直接通过这个插件打开本地电脑磁盘上的美剧来观看了，mpv播放器会直接播放美剧，前提是你的美剧需要有英文字幕才行。目前这种制卡，抽取出来的都是英文字幕，如果你是使用网络上百度网盘别人售卖的《绝望主妇》那种有中英双字幕的，是可以抽取到中英文字幕的，但是，是那种间隔抽取的，就是一个中文，一个英文，间隔这种。实际操作体验非常差，主要是这些流行的口水剧都是野生字幕组瞎翻译的，很多台词的中文根本就是错的，所以，亲们，选择美剧，还是选择油管的视频或者NetFlix里面的吧，好歹NetFlix里面的台词中文和英文都是人工校准过的，比这种野生字幕组的靠谱。关键是我们自己用工具下载的，我们可以控制视频的清晰度，而百度网盘别人售卖的那些美剧，体积都是1GB大小，自己下载NetFlix这种剧，体积只有几十MB，小了100多倍，可以用来多学习很多剧了。

唯一缺点是：NetFlix的中文字幕格式是zip压缩包的，要想中英文字幕同步，还做不到，我的建议是，使用英文字幕即可，不懂的单词和语块自己分析写上标记和备注。另外不太建议去看那些口水剧，像《摩登家庭》《绝望主妇》《老友记》这些学院派的口水剧，令人费解的台词非常多，现实生活中的老外可能根本不会按照那么说话，演绎成分太多。

### 6.美剧视频和字幕下载

我使用的方法是通过[FlixGrab+](https://www.flixgrab.com/)付费软件下载NetFlix的视频。

选择一些比较真实的美剧和视频，越是真实的越好，不太建议去使用口水剧，特别过度设计的台词美剧，其实和真实的生活中的英文环境有差别的，真实的老外怎么沟通讲话，就弄真实的即可。这种方式制卡的速度是非常快的，制卡的时候mpv播放器开打，直接按键盘B键即可制卡，而且会自动断句，制卡之后，自己查下词典，把语块和生词标记到anki卡片中即可。不需要太多投入，一天20个卡，差不多了。一个星期下来非常容易坚持，而且这种视频单词卡，复习起来的难度比有声书的要低很多很多，同时也能够复习了听力。这也是那些大佬，坚持几年美剧下来，英文变得非常牛逼的主要原因。真正的美剧打开方式，我觉得就是这样。

![PotPlayerMini64_ygvqCRi5Yo](/images/posts/PotPlayerMini64_ygvqCRi5Yo.png)

![56754546](/images/posts/56754546.gif)

flixgrab这个工具，付费之后，会发送一封邮件到你的邮箱里面，会带上序列号和邮箱名，

 [https://www.flixgrab.com/](https://www.flixgrab.com/) 激活的时候，填写邮箱和序列号即可。一般我使用的是季度付费的方式，按照现在的汇率来算，一个季度是50元RMB左右，通过paypal关联国内的借记银行卡即可完成支付。

这个工具是可以批量下载一个系列的美剧，可以设置要下载的美剧的清晰度分辨率，一般默认最低画质即可，第一遍是通过浏览器chorme 配合Language Reactor插件，打开中英文字幕，看一遍了解所有剧情，

![SdFBfGLJSd](/images/posts/SdFBfGLJSd.png)

![chrome_TWtorDcc79](/images/posts/chrome_TWtorDcc79.png)

这个插件用来看剧，扫清一遍之后，可以大致评估到一个剧的难度，因为这个插件会有生词统计，你把生词难度等级进行调节，就可以看到大概的生词量，具体的插件使用参数自己摸索即可，免费的功能足够使用，这个插件还支持youtube视频。如果是要下载youtube视频，我一般使用也是付费软件[Internet Download Manager](https://www.internetdownloadmanager.com/)

![IDMan_SMKbr3Tn26](/images/posts/IDMan_SMKbr3Tn26.png)

![chrome_P42WUXjCil](/images/posts/chrome_P42WUXjCil.png)

这个软件配合的chrome插件是[IDM Integration Module](https://chrome.google.com/webstore/detail/idm-integration-module/ngpampappnmepgilojfohadhhmbhlaek),我主要是用来作为下载油管视频的主力工具，这个工具可以下载视频的英文台词，配合我们这个anki mpv制卡，是绝配，特别是油管上面有很多真实的谈话类节目，TED演讲，还有一些你喜欢的博主的英文视频都可以下载回来制卡。

### 7.美剧制卡的不足和优点

这种方式制作的卡片，都是没有中文标注的，需要自己再快速的查词典进行一下备注，做一些笔记。

![NDSUprculn](/images/posts/NDSUprculn.png)

这种方法，其实跟国外大神们使用的方法基本上一样了，缺点是，还是需要手工查词典，或者借助人工智能AI翻译，来搞定整个台词的翻译。因为有了Language Reactor我们结合翻译已经看过一遍美剧了，所以，制卡的时候，记录一下重点句型和单词也非常简单。

这种方式最大的优点是，彻底解决了，YouTube视频和Netflix美剧，长期以来没办法作为“高效”英语学习材料的弊端。很多大神都说看美剧对于听力和口语提升很大，但是从操作层面来讲，是非常难于下手的，特别是对于台词的整理和复习，这是个难点。本身看美剧就非常消耗时间和精力，还要去整理生词和台词，耗费的时间更多，这是有声书比美剧要好操作的地方。但是有声书的缺点是，里面的很多场景和真实生活相去甚远，而且有声书无法把整句进行真人朗读，复习的时候我们大都是复习的单个单词，对于整句的听力提升其实没有美剧效果好，还有就是，有声书制卡或者新闻报刊制卡，整个句子是不发音的，虽然很多人阅读词汇量很大，但是到了真实英文环境，听力还是非常差，其实还是因为两种学习方式导致的训练结果不一样导致。

美剧训练的是听力和口语表达，以及真实生活中场景语料的熟悉。有声书，更多是泛听训练和书面表达词汇阅读积累。本文说的这种美剧制卡，是用来弥补有声书缺点的一种补充。等于是填补了英语自学方法的一块空白。

此方法对操作要求较高，安装chocolatey之后，再通过chocolatey去安装mpv播放器，youtube-dl,ffmpeg。以及要求操作者懂anki使用，字段映射模板设置。还有后期要去阅读这个anki插件[https://ankiweb.net/shared/info/1213145732](https://ankiweb.net/shared/info/1213145732)的文档，以及MPV播放器还有一些快捷键的设置，怎么保存播放列表，快进，快退等等。

个人觉得，能够自动切取mp4和mp3音频，并且提取台词，这个已经非常好了，关键是mp4的分辨率可以自己设置截取的大小，有了视频片段，这对于可理解输入和降低复习压力都是大大的提升。

### 8.参考资料

[http://www.randomhacks.net/substudy/](http://www.randomhacks.net/substudy/) 这篇文章里面的作者，讲到了自己通过看剧学语言的心得体会，值得一看。

[https://learnanylanguage.fandom.com/wiki/Subs2srs](https://learnanylanguage.fandom.com/wiki/Subs2srs)这里提到的方式，是另外一种看剧，挂载字幕的制卡方式，只支持低版本的anki，`Matt vs japan`曾经使用的方法就是这个方法，跟我本文讲解的方法是差不多的，插件都是同一个作者。

