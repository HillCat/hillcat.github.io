---
layout: post
title: OpenAI人工智能生成youtube字幕(12)
categories: English
description: 英文自学
keywords: English
typora-root-url: ../
---

这个AI生成youtube英文字幕是基于OpenAi公司的Whisper库。OpenAI公司的Whisper库更新很快，但是yt-whisper脚本的更新相对滞后，yt-whisper官方的setup.py执行的时候由于依赖包的名字还是whisper，而官方库改名为openai-whisper了，所以需要修改下这个名字。fork并修改脚本之后，使用自己github的地址安装即可解决yt-whisper装不上去的问题。

Whisper这个AI库生成的youtube字幕非常精准，可以针对任何youtube的视频，自动生成字幕。这样就省得我们去手工下载youtube的机器字幕了。唯一缺点是这个yt-whisper脚本是python写的，性能有点低，比较吃CPU。

### fork并修改脚本

首先用你自己的github账号fork这个仓库：[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)

setup.py中的

```shell
whisper @ git+https://github.com/openai/whisper.git@main#egg=whisper
```

改为

```shell
openai-whisper @ git+https://github.com/openai/whisper.git@main#egg=openai-whisper
```

修改了这个setup.py之后，请使用你自己的github仓库地址安装yt_whisper.也就是说原本安装说明里面要从下面这个地址安装，改为使用你自己的github地址即可。

```shell
https://github.com/m1guelpf/yt-whisper.git
```

## yt-whisper安装过程

首先确保你的windows10电脑已经安装了chocolatey这个软件包管理工具。

### 1.安装chocolatey

最先要安装的是chocolatey。强烈推荐使用chocolatey这个软件包管理软件(血的教训)，虽然有很多方法可以安装mpv播放器，但是为了保险起见，请把所有安装过程交给choco自动处理。包括安装youtube-dl(播放url需要用到这个)，ffmpeg(视频音频自动截取需要这个)。choco类似于Mac上面的Homebrew,CentOS上面的Yum，Ubuntu上面的apt-get。

chocolatey如何安装，文档如下：

[https://docs.chocolatey.org/en-us/choco/setup](https://docs.chocolatey.org/en-us/choco/setup)

按照上面地址的文档说明，chocolate安装方式有2种，一种是通过cmd安装，一种是powershell方式安装。选择其中1种即可.这里我使用第2种方式PowerShell安装。

在windows开始菜单，找到PowerShell，鼠标右键点击**以管理员身份运行**，粘贴并执行下面框框中的命令(复制整行)：

![chrome_AAa51Nll5h](/images/posts/chrome_AAa51Nll5h.png)

```shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

很多人打开这个Windows PowerShell的时候不是以管理员权限打开的，会报下面错误：它会提示你 `default folder requires Administrative permissions`. 意思是说”默认文件夹需要管理员权限“。你需要按照我上面说的那样子，以管理员权限打开windows PowerShell。具体操作是，找到powershell，鼠标右键，会出现”以管理员方式运行“，点击，让它以管理员方式运行就可以了。期间有人出现过这个情况，这让我不得不把这个文章尽量详细写出来。可能对于一些程序员朋友觉得有点冗余，对于不太懂程序的，有些细节就会被难住。

![tACkzhrojS](/images/posts/tACkzhrojS.png)

管理员权限启动的Powershell，窗口上面会有`Administrator` 或者 `管理员`字样，如下：

![image-20230118034115752](/images/posts/image-20230118034115752.png)

![eWyxATtSbe](/images/posts/eWyxATtSbe.png)

如果没有这个字样，就不是管理员权限，你要检查你当前登录windows系统的账号，或者直接用windows系统默认的超级管理员账号Administrator登录。

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

创建python虚拟环境：

创建python虚拟环境，参考视频：[https://www.youtube.com/watch?v=HSVjz4FPKzM&t=67s&ab_channel=cmoorelabs](https://www.youtube.com/watch?v=HSVjz4FPKzM&t=67s&ab_channel=cmoorelabs)

这个视频只是作为一个参考，我这里说明下，这里要创建python虚拟环境的原因，因为OpenAi这个whisper需要运行在python环境下面，要有个虚拟环境。

创建虚拟机环境之前，先要知道你自己的当前账户名，如果你是Administrator登录的，那么在C盘，找到用户目录，再进去用户目录下面，会看到你当前登录用户名的文件，进入之后，创建一个venv文件夹。比如我当前电脑的用户账户是47664.我会在这个路径下面先创建一个venv文件夹，如下：

![OelKR2H5xT](/images/posts/OelKR2H5xT.png)

然后根据我电脑账户路径，执行下面的指令，它会往我的这个文件夹下面写入很多python文件：

```shell
python -m venv C:\Users\47664\venv
```

执行上面这个指令的时候，记得把47664替换为你自己的电脑登录账户。执行完上面指令，会发现这个文件夹多了很多文件：

![explorer_8zuIuHD57x](/images/posts/explorer_8zuIuHD57x.png)

### 4.启动python虚拟环境

最为关键的一步来了，千万别弄错了：我们需要在命令行中去执行这个activate.bat程序,目的是为了开启python虚拟化环境，怎么做呢？

![swv9F06BMY](/images/posts/swv9F06BMY.png)

最好的办法就是先复制Scripts文件夹所在位置的路径：如下，复制这个Scripts所在位置的整个路径全部复制下来，`C:\Users\47664\venv\Scripts`,其实就是直接找你电脑里面C盘的那个Scripts目录复制即可，直接复制你自己的Scripts路径，你自己实际路径是什么就复制什么。Scripts目录如下：去找C盘下面的用户目录进入，然后找到自己当前登录的用户名，再进入那个venv文件夹，就能看到Scripts目录，复制整个这个路径。

![xIlXKqcgh9](/images/posts/xIlXKqcgh9.png)

然后把路径切换到这个Scripts目录:切记，这里不要用PowerShell, 用cmd黑框，以管理员方式打开cmd。切换目录的指令如下，cd 就是change direct改变路径的缩写，后面带上你复制的自己的Script整个路径，

```shell
cd C:\Users\47664\venv\Scripts
```

如下，这样子就切换目录到了Scripts下面了，这么切换目录的原因是我们的bat文件在这个目录里面，开启python虚拟环境要用这个。

![cmd_INHW2y2cj1](/images/posts/cmd_INHW2y2cj1.png)

直接输入：

```shell
activate.bat
```

回车执行，如果一次不行，同样输入activate.bat执行一次，直到看到有个(venv)的小括号出现，如下：前面带了这个(venv),就表示你进入了python虚拟机环境:

![cmd_cGtW04Fz9Y](/images/posts/cmd_cGtW04Fz9Y.png)

已经进入python虚拟环境了，黑框cmd不要退出，我们这个时候先去安装一个git环境，

### 5.安装git环境

下载git安装文件exe：去到git官网：[https://git-scm.com/](https://git-scm.com/)，如下图，点击那个Download for Windows，下载git的安装文件：

![fc6kv4lUYs](/images/posts/fc6kv4lUYs.png)

![YVTKOVsT3Q](/images/posts/YVTKOVsT3Q.png)

选择64位版本的Setup文件下载下来，就跟我们以前安装exe文件一样，直接下一步，下一步，下一步，直到安装完成。估计会要重启下电脑。重启电脑之后我们再以管理员方式启动cmd黑框。

我们回到黑框cmd环境，继续操作，安装whisper库之前还是要开启python虚拟环境，执行上面那个activate.bat文件。如果忘记了，请回到上面activate.bat那里。切换目录，执行activate.bat。

开启python虚拟环境。开启之后，看到这个(venv)

![cmd_cGtW04Fz9Y](/images/posts/cmd_cGtW04Fz9Y.png)

### 6.安装whisper

我们安装OpenAi公司的whisper库：

```shell
pip install git+https://github.com/openai/whisper.git
```

这个库的体积很大，安装文件可能达到2GB，耐心等待安装完成。安装完成whisper之后，

### 7.安装yt-whisper

注意，这个脚本安装出错，建议你fork官方这个库之后，修改脚本setup.py里面的错误，并用你自己的github地址安装yt-whisper。参考文本开篇提到的方法。下面这个执行命令作为参考：

```shell
pip install git+https://github.com/m1guelpf/yt-whisper.git
```

安装完成。就可以使用yt-whisper去生成youtube视频的字幕了，先不用急着去找youtube视频链接，这里的指令我们先执行，测试下yt_whisper指令是否正常能够生成字幕。

### 8.测试yt_whisper

执行下面指令，测试yt_whisper功能：

```shell
yt_whisper "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
```

转换的时候，时间会有点长，5分钟到10分钟左右，看你要转化的视频mp4的时间长短决定。

![cmd_f02JOb0vMR](/images/posts/cmd_f02JOb0vMR.png)

转换过程CPU会100%拉满，期间就不要做其他事情了，静静等待即可，防止电脑卡死。AI在电脑生成字幕的时间和速度，除了跟你视频长度有关系，还有跟你电脑CPU配置也有关系。生成完成之后，这个控制台会显示，生成的vtt格式的字幕在你电脑硬盘的路径，根据路径过去拿这个字幕即可。



以后我们就可以正常使用yt_whisper指令了，使用方式，参考：[https://github.com/m1guelpf/yt-whisper](https://github.com/m1guelpf/yt-whisper)

以后的日常使用过程中，只需要找到你想要自动生成字幕的youtube链接地址，复制，使用yt-whisper 加上双引号，里面写上你要转AI字幕的视频的地址即可，如下格式：

```shell
yt_whisper "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
```

每次使用的时候，如果你电脑重启过，或者关闭过python虚拟环境，可能需要再次进入python虚拟机环境，才能执行这个AI程序，进入python虚拟环境的方式，参考上面的步骤即可。

### 9.CMD使用yt_whisper

通过上面步骤，成功安装了yt-whisper。重启电脑之后，再要使用这个工具生成youtube字幕，只需要以下几个步骤：

第一步:进入到`venv\Scripts`目录下面，这个文件夹有activate.bat这个文件，如下：

![88TWZswyfY](/images/posts/88TWZswyfY.png)

第二步：在当前Script目录，地址栏中输入cmd直接回车，可以快速打开cmd控制面板会自动停留在当前路径中，然后直接输入activate.bat启动python虚拟环境。

![95346dgfdgdg](/images/posts/95346dgfdgdg.gif)



第三步：如下图，输入yt_whisper 空格 加上双引号，带上youtube视频URL地址回车即可开始生成AI字幕文件。

![cmd_AcxT2WrrE5](/images/posts/cmd_AcxT2WrrE5.png)

以上就是日常使用yt_whisper生成youtube AI字幕的常规操作。如果不指定目录位置，输出的字幕文件会生成到Scripts目录中。

#### 9.1 指定字幕保存路径

```shell
yt_whisper "https://www.youtube.com/watch?v=9NqthBLHBDg&ab_channel=IAmTimCorey" --output_dir C:\Users\47664\Downloads\video
```

因为IDM工具下载youtube视频默认会保存到windows系统的C盘的Downloads下面的video文件夹，所以使用yt_whisper生成字幕的时候，建议按照上面的例子，指定一个`output_dir`参数带上目标地址。我这里是把输出的字幕指定到了`C:\Users\47664\Downloads\video`文件里。你可以保存这个例子，修改对应的路径和url，每次下载的时候使用这个保存的模板即可。

### 10.PowerShell使用yt_whisper

还有比较便利方式就是使用最新版本PowerShell7，它有自动补全着智能提示。Powershell7的版本下载地址：

[https://github.com/PowerShell/PowerShell/releases/download/v7.3.1/PowerShell-7.3.1-win-x64.msi](https://github.com/PowerShell/PowerShell/releases/download/v7.3.1/PowerShell-7.3.1-win-x64.msi)

安装完成之后，我们在开始菜单里面。就能够看到这个软件：

![chrome_qEfIpCNCqE](/images/posts/chrome_qEfIpCNCqE.png)

最终使用Powershell7下载youtube字幕如下效果：

![pwsh_HcvYfZeZCR](/images/posts/pwsh_HcvYfZeZCR.png)

它会出现指令自动补全和提示，我们打开Powershell7之后，通过键盘上下↑↓键盘翻阅我们使用过的历史记录，可以快速找到Python虚拟机环境开启的路径和指令，只需要键盘方向键箭头向右  → ，即可补全，不需要我们一个个敲代码。

![56435345sfhg24](/images/posts/56435345sfhg24.gif)

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



### 12.制作Youtube单词卡片

可以搭配安装`google translate`插件,插件安装Code是：`1536291224`。在没有中文字幕的情况下，快速生成翻译中文。

![afryitHXx9](/images/posts/afryitHXx9.png)

### 13.注意事项

1.mkv格式的视频无法被anki的mpv2anki插件截取，需要用格式工厂转换mkv为mp4格式，如果其他格式视频不是mp4的，建议都转为mp4。

![FormatFactory_l4jIIT6Xzx](/images/posts/FormatFactory_l4jIIT6Xzx.png)

2.yt_whisper输出的字幕文件名和视频名不一致，使用的时候修改为一致即可。
