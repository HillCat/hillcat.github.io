---
layout: post
title: OpenAI生成youtube字幕(12)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

这个AI生成youtube英文字幕是基于OpenAi公司的Whisper库。OpenAI公司的Whisper库更新很快，但是yt-whisper脚本的更新相对滞后，yt-whisper官方的setup.py执行的时候由于依赖包的名字还是whisper，而官方库改名为openai-whisper了，所以需要修改下这个名字。fork并修改脚本之后，使用自己github的地址安装即可解决yt-whisper装不上去的问题。

Whisper这个AI库生成的youtube字幕非常精准，可以针对任何youtube的视频，自动生成字幕。这样就省得我们去手工下载youtube的机器字幕了。唯一缺点是压缩视频都是利用的ffmpeg这个中间件，特别耗CPU资源，对于字幕的生成耗时比较久，最好是 i7 CPU左右比较好，配置低真的会很慢。当然，最好是自己能够写脚本**批量挂机执行**也行。

## fork并修改脚本

首先用你自己的github账号fork这个仓库：https://github.com/m1guelpf/yt-whisper
要从下面这个地址安装，改为使用你自己的github地址即可。

```SHELL
https://github.com/m1guelpf/yt-whisper.git
```



## yt-whisper安装过程

首先确保你的windows10电脑已经安装了chocolatey这个软件包管理工具。

### 1.安装chocolatey

chocolatey如何安装，文档如下：

[https://docs.chocolatey.org/en-us/choco/setup](https://docs.chocolatey.org/en-us/choco/setup)

在windows开始菜单，找到PowerShell，鼠标右键点击**以管理员身份运行**，粘贴并执行下面框框中的命令(复制整行)：

![chrome_AAa51Nll5h](/images/posts/chrome_AAa51Nll5h.png)

```shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

等chocolatey安装好之后，输入choco，回车，如下图，看到显示了chocolatey的版本号v1.1.0，即表示安装成功。

![powershell_5G3YUqCTT8](/images/posts/powershell_5G3YUqCTT8.png)

### 2.安装python环境

我们需要给windows10安装python3.执行下面语句：不要使用默认指令`choco install python`，默认指令会安装python3的最新版本，后面安装whisper会提示版本过高安装不了。这里安装python3.9版本即可。

```shell
choco install python39
```

然后安装pip, 因为python3自带了pip，所以这里只是升级一下pip：

```shell
python -m pip install -U pip
```

然后是安装yt-dlp：

```shell
python -m pip install yt-dlp
```

### 3.创建Python虚拟环境

python虚拟环境是为了让pyhon能够调用除标准库之外的库而发明的，关于Python虚拟环境更多信息可以参考官方说明：[https://docs.python.org/3/tutorial/venv.html](https://docs.python.org/3/tutorial/venv.html)

创建python虚拟环境可以参考视频：[https://www.youtube.com/watch?v=HSVjz4FPKzM&t=67s&ab_channel=cmoorelabs](https://www.youtube.com/watch?v=HSVjz4FPKzM&t=67s&ab_channel=cmoorelabs)



创建虚拟机环境之前，先要知道你自己的当前账户名，如果你是Administrator登录的，那么在C盘，找到用户目录，再进去用户目录下面，会看到你当前登录用户名的文件，进入之后，创建一个venv文件夹。比如我当前电脑的用户账户是47664.我会在这个路径下面先创建一个venv文件夹，如下：

![OelKR2H5xT](/images/posts/OelKR2H5xT.png)

然后根据我电脑账户路径，执行下面的指令，它会往我的这个文件夹下面写入很多python文件：

```shell
python -m venv C:\Users\47664\venv
```

执行上面这个指令的时候，记得把47664替换为你自己的电脑登录账户。执行完上面指令，会发现这个文件夹多了很多文件：

![explorer_8zuIuHD57x](/images/posts/explorer_8zuIuHD57x.png)

### 4.安装git环境

如果你电脑已经安装了git，就不需要做这一步了。如果没有安装git，那么就按照下面方式安装git.

git安装分为2种方式，第一种使用choco安装，最省事,但是需要开启全局帆樯；第二种，去git官方下载exe文件安装(耗时且容易出错)。

#### 4.1第一种方式

```shell
choco install git.install
```

choco这种方式安装git非常方便简单，直接一条指令搞定。如果你遇到下面这种操作超时的问题，那么请开启帆樯v-p~n搞定。

![chrome_wXkhDsMbCN](/images/posts/chrome_wXkhDsMbCN.png)

开启帆樯之后，git安装就可以很顺利了：安装成功之后，在电脑的最近添加这里就可以看到Git一系列的东西了。安装完成git之后，需要重新关闭控制面板cmd，重新打开。让git生效。

![chrome_fzc38M5kIe](/images/posts/chrome_fzc38M5kIe.png)

![xXrgtx9Ems](/images/posts/xXrgtx9Ems.png)

#### 4.2第二种方式

下载git安装文件exe：去到git官网：[https://git-scm.com/](https://git-scm.com/)，在首页的右边有个下载的位置，点击那个Download for Windows，下载git的安装文件。选择64位版本的Setup文件下载下来，就跟我们以前安装exe文件一样，直接下一步，下一步，下一步，直到安装完成。安装完成git之后，需要重新关闭控制面板cmd，重新打开。让git生效。

### 5.启动python虚拟环境

python的虚拟环境启动，是通过执行activate.bat启动的，activate.bat程序是一个批处理程序，找到这个文件所在位置，在命令行直接运行这个文件就能启动python虚拟环境，

![swv9F06BMY](/images/posts/swv9F06BMY.png)

以管理身份运行cmd，然后通过 cd 命名切换到activate.bat所在目录，如下(就是你当前登录用户所在的venv\Scripts目录)

``` cd C:\Users\47664\venv\Scripts```



![cmd_INHW2y2cj1](/images/posts/cmd_INHW2y2cj1.png)

切换目录后，直接输入：

```shell
activate.bat
```

回车执行，执行会一闪而过，然后地址前面会出现 (venv)，这个就代表已经启动python虚拟环境了，如下：前面带了这个(venv),就表示你进入了python虚拟机环境:

![cmd_cGtW04Fz9Y](/images/posts/cmd_cGtW04Fz9Y.png)

已经进入python虚拟环境了，黑框cmd不要退出，我们这个时候先去安装一个git环境，



### 6.安装whisper

我们关闭黑框cmd，再重新打开黑框cmd环境，执行上面那个activate.bat文件进入python虚拟机环境。

python虚拟环境开启之后，看到这个(venv)，一定要确保你已经进入了python虚拟环境才能下面操作。

![cmd_cGtW04Fz9Y](/images/posts/cmd_cGtW04Fz9Y.png)

我们安装OpenAi公司的whisper库：

```shell
pip install git+https://github.com/openai/whisper.git
```

这个库的安装需要耗费些时间，耐心等待安装完成。安装完成之后，接着安装yt-whisper。

### 7.安装yt-whisper

如果是电脑上面之前已经安装过yt-whisper，则需要彻底删除干净，Everything工具查找硬盘上所有涉及到whisper的python Library完全清除干净。再安装。如果使用wrap cli工具批量调用python这个库的时候可能发生错误。

安装moviepy：

```shel
pip install moviepy
```

安装yt-whisper。执行：

```shell
pip install git+https://github.com/HillCat/redis_sentry_main
```



安装完成。就可以使用去生成youtube视频的字幕了。

### 8.测试yt_whisper

执行下面指令，测试yt_whisper功能：

```shell
yt_whisper "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
```

转换的时候，时间会有点长，5分钟到10分钟左右。如果是要批量进行大量的url转换压缩，我一般会自己写脚本批量搞定。

![cmd_f02JOb0vMR](/images/posts/cmd_f02JOb0vMR.png)

转换过程CPU会100%拉满，是因为ffmpeg这个中间件压缩视频的时候耗资源，像HandBrake这种视频格式转换工具基本都是使用这个ffmpeg，批量压缩视频的时候也是很耗CPU。

以后我们就可以正常使用yt_whisper指令了。更多指令参考：[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)

### 9.CMD使用yt_whisper

最好的方式是使用powershell高版本的控制面板来执行这些脚本，这里为了只是以cmd控制面板来演示下：

通过上面步骤，成功安装了yt-whisper。重启电脑之后，再要使用这个工具生成youtube字幕，只需要以下几个步骤：

第一步:进入到`venv\Scripts`目录下面，这个文件夹有activate.bat这个文件，如下：

![88TWZswyfY](/images/posts/88TWZswyfY.png)

第二步：在当前Script目录，地址栏中输入cmd直接回车，可以快速打开cmd控制面板会自动停留在当前路径中，然后直接输入activate.bat启动python虚拟环境。



第三步：如下图，输入yt_whisper 空格 加上双引号，带上youtube视频URL地址回车即可开始生成AI字幕文件。

![cmd_AcxT2WrrE5](/images/posts/cmd_AcxT2WrrE5.png)

以上就是日常使用yt_whisper生成youtube AI字幕的常规操作。如果不指定目录位置，输出的字幕文件会生成到Scripts目录中。

#### 9.1 指定字幕保存路径

```shell
yt_whisper "https://www.youtube.com/watch?v=9NqthBLHBDg&ab_channel=IAmTimCorey" --output_dir C:\Users\47664\Downloads\video
```

因为IDM工具下载youtube视频默认会保存到windows系统的C盘的Downloads下面的video文件夹，所以使用yt_whisper生成字幕的时候，建议按照上面的例子，指定一个`output_dir`参数带上目标地址。我这里是把输出的字幕指定到了`C:\Users\47664\Downloads\video`文件里。你可以保存这个例子，修改对应的路径和url，每次下载的时候使用这个保存的模板即可。

### 10.PowerShell使用yt_whisper

windows10默认自带的Powershell是5.1版本的，我们这里需要额外追加一个Powershell7的版本。安装Powershell7不会影响到系统默认的Powershell5.1的使用。

PowerShell7它有自动补全和智能提示功能，而Powershell5.1是没有这些功能的,Powershell 7是微软基于.net core开发的，而Powershell5.1是基于.net framework老版本的(已经不再维护)，微软目前把主要精力放到Powershell 7上面，并且这个shell是跨平台的。Powershell7的版本下载地址：

[https://github.com/PowerShell/PowerShell/releases/download/v7.3.1/PowerShell-7.3.1-win-x64.msi](https://github.com/PowerShell/PowerShell/releases/download/v7.3.1/PowerShell-7.3.1-win-x64.msi)

安装完成之后，我们在开始菜单里面。或者搜索找到powershell会看到powershell7的图标，如下,鼠标右键，以管理员身份运行：

![chrome_qEfIpCNCqE](/images/posts/chrome_qEfIpCNCqE.png)

![chrome_AAa51Nll5h](/images/posts/chrome_AAa51Nll5h.png)

最终使用Powershell7下载youtube字幕如下效果：

![pwsh_HcvYfZeZCR](/images/posts/pwsh_HcvYfZeZCR.png)

它会出现指令自动补全和提示，键盘方向键：上下↑↓翻历史记录， 敲代码的时候出现智能提示，利用右方向键 → 补全，省力省心。

![pwsh_hCZvJO56OI](/images/posts/pwsh_hCZvJO56OI.png)

```shell
 cd c:\users\47664\venv\Scripts   
```



![pwsh_eHeL9ZgWC3](/images/posts/pwsh_eHeL9ZgWC3.png)

```shell
 ./activate.bat   
```



![pwsh_F6At4odYys](/images/posts/pwsh_F6At4odYys.png)

```shell
 yt_whisper "https://www.youtube.com/watch?v=KPn637EfSOI&ab_channel=PBSNewsHour" --output_dir F:\Downloads\Video
```



### 12.翻译Youtube字幕

可以搭配安装`Deepl Translate`插件,插件安装Code是：`972129549`。在没有中文字幕的情况下，快速生成翻译中文。插件地址：https://ankiweb.net/shared/info/972129549，

这个插件需要API Key ，这个Key在淘宝上面有卖的，30RMB一个月，如果你是高密度刷youtube的视频来精学，精听，用这个插件会节省很多时间。因为它的翻译准确度要高于国内的有道的欧陆。另外这个DeepL有个Write服务是免费的，用来批改英文作文很有效，特别是它的同义词替换，语法错误检查，关键是它是免费的，而且同义词替换要比Gramarly好用。

![BeeCLnaGhT](/images/posts/BeeCLnaGhT.png)



![BvqJpgUT47](/images/posts/BvqJpgUT47.png)

![croZVJetH2](/images/posts/croZVJetH2.png)

![Typora_DAXQo33YSK](/images/posts/Typora_DAXQo33YSK.png)



### 13.卸载和重装yt-whisper

1.首先是通过控制面板卸载python

2.利用Everthing工具把残留的python文件删除

3.清空回收站

4.通过choco安装python39

5.重新创建python虚拟环境

6.pip安装whipser

### 14.注意事项

1.mkv格式的视频无法被anki的mpv2anki插件截取，推荐使用[HandBrake](https://handbrake.fr/)这个工具，转换视频为MP4格式。这是一个免费工具，比我们国产的“格式工厂”要好得多。而且性能和各种参数非常齐全。曾今用它来转换过《绝望主妇》这套视频，缩小体积，性能和专业度都是非常好的。

![HandBrake_v7cMLehYt6](/images/posts/HandBrake_v7cMLehYt6.png)

2.yt_whisper输出的字幕文件名和视频名不一致，使用的时候修改为一致即可。这里我使用了自己编写的脚本和工具批量跑这个字幕生成，并且结合potplayer的书签功能和anki结合一起使用快速制卡，效果一流。推荐使用anki经验在1年以上的人使用。具体工具和方法思路，可以找我交流。
