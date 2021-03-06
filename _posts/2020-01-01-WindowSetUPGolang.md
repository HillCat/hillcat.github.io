---

layout: post
title: Go语言快速入门：Go开发环境(1)
categories: Go
description: Golang相关笔记
keywords: Golang
typora-root-url: ../
---
Golang开发第一步，首先安装Golang开发环境，这里使用ubuntu作为golang开发环境。Go语言官方博客、文档中的所有golang代码基本都是在Linux环境演示的，如果有其他编程语言基础而又要快速自学，看老外的文档是最快的，而老外的操作基本是在mac linux进行，比如cat指令在很多博客文章中反复出现：比如：[go 模块的管理](https://go.dev/blog/migrating-to-go-modules) 。ubuntu相对于debian,centos这些系统，桌面端更加友好，而且安装ubuntu的时候大部分的配置都是在图形化界面操作完成，非常方便。对于国内镜像切换支持得非常好。安装得时候推荐给ubuntu分配30~45G左右的硬盘空间。默认10GB空间太少，会引发ubuntu system boot空间不足。

### 网络桥接模式

为了能够让虚拟机安装的时候可以连接网络，这里设置为桥接模式。防止虚拟机安装之后无法更新。

<img src="https://cs-cn.top/images/posts/bridge_connection4214.png"/>

### 修改Ubuntu镜像源

因为国内网速的问题，Ubuntu的镜像源需要设置为国内的阿里巴巴或者其他镜像。这个对于Ubuntu而是非常简单的，可以参考：[https://blog.csdn.net/laoluobo76/article/details/108302191](https://blog.csdn.net/laoluobo76/article/details/108302191)

<img src="https://cs-cn.top/images/posts/set_aliyun_mirror314.png"/>

因为Ubuntu可以直接在图像界面下修改镜像源地址为国内的，所以它比Centos和苹果的IOS其实更加适合程序员用来做为Linux开发环境。

上面这个界面默认会是chinese国家，但是Dwonload From这里选择other，从other里面会看到默认是美国，往上翻阅滚动找到China -> morros.aliyun.com。镜像源就设置为国内阿里云了。



### 调整自适应分辨率

更新了各种包之后，开始设置Ubuntu分辨率。现在一般台式机的显示器都是23寸的。而VisualBox虚拟机安装完Ubuntu之后，还需把桌面分辨率调节一下，并且如果是做为开发环境的话，显卡的显存分配，刷新率这些都需要调整到最佳状态。

在执行了：apt-get install update && apt-get install upgrade 之后，执行如下代码：

```csharp
sudo apt install virtualbox-guest-dkms
```

安装完上面这个dkms之后，需要关机，VisualBox中对虚拟机的显卡缓存拉到最大并且开启3D加速：

<img src="https://cs-cn.top/images/posts/view_card_settings53.png"/>

如果要使用Auto-resize Guest Display,则需要在我们的电脑中找到VisualBoxAdditional.ISO这个镜像，手动设置到Ubuntu的DVD光驱中，让Ubuntu开机的时候加载这个VisualBoxAdditional.ISO镜像：

<img src="https://cs-cn.top/images/posts/visualBoxAdditional1554.png"/>

然后找到了这个镜像文件之后，载入到Ubuntu的光盘里面中：

<img src="https://cs-cn.top/images/posts/LoadVisualBoxAdditional.ISO910.png"/>

经过上面这个设置之后，开机启动Ubuntu，Ubuntu的桌面就会显示出来DVD这个设备加载了一个光盘文件，会显示在桌面中，我们需要手动找到这个路径安装这个VisualBoxAdditional镜像里面的软件，

<img src="https://cs-cn.top/images/posts/file_box317.png"/>

进入到光盘文件中，右键鼠标，从Terminal中打开当前路径：

<img src="https://cs-cn.top/images/posts/open_teminal22537.png"/>

然后Terminal中敲入命令行 ./autorun.sh  ,执行光盘程序中的文件，安装相应的扩展：

<img src="https://cs-cn.top/images/posts/autorunsh2843.png"/>

它会弹出来一个验证框，要求输入Ubuntu权限的密码，输入之后，Terminal开始执行命令行，开始安装：

<img src="https://cs-cn.top/images/posts/install_sh928.png"/>

安装完毕之后重启Ubuntu虚拟机。只要设置正确，那么VisualBox窗体顶部工具栏View菜单栏中的VisualBoxResize功能就可以被选中了，如下：

<img src="https://cs-cn.top/images/posts/auto_resize840.png"/>

当拖放窗口大小的时候，分辨率会随着窗口的变化而变化的，对于程序员在Window上面搞开发而言非常方便了。

### 设置Ubuntu显卡

让ubuntu基于我们的硬件的显卡，设置到最高的分辨率，这里进入到display设置界面，选择我们的显示器最大的分辨率，比如我的是23寸，就选择1920 X 1440 （4:3），得到一个最舒适的分辨率，方便我们长期使用虚拟机得到最好的显示效果，保护我们的视力。

<img src="https://cs-cn.top/images/posts/setting_display4144.png"/>

<img src="https://cs-cn.top/images/posts/1920X1440_606.png"/>

如果不太习惯那种全屏模式的话，还是喜欢那种自适应模式的分辨率，那么可以View中选择Auto-Resize Guest  display 就是自动缩放的分辨率。全部设置完成之后，执行：sudo apt update ,更新一下配置信息。

**注意**：设置Ubuntu虚拟机窗口自适应的时候会遇到一些坑：调节VisualBox窗口大小和分辨率的时候，如果VisualBox窗体不小心进入了Scale Model，则会看不到VisualBox顶部的工具栏，只需要按住**键盘右边的Ctrl **+ Home键找回工具条，重新点击Scale Model就可以回到工具栏模式，对我们的窗口分辨率进行进一步设置。而点击**键盘右边的Ctrl **+C可以切换到缩略窗口模式。

### 缩短MachineName

虚拟机在安装的时候，由于没有太注意，给定义的机器的名字非常长，先把机器名字修改简短一些，可以直接如下：

sudo nano /etc/hostname

进入到nano编辑器界面，修改了机器名之后，Ctrl + O 保存，然后Ctrl +X 退出机器，重启即可。

如果是shell切换为zsh之后，这个MachineName就会自动变为一个“右箭头->光标”。

### 安装oh my zsh

在苹果笔记本上面很多人喜欢使用iterm2这个命令提示的shell，而之前我用过一段时间的zsh，这个[oh my zsh](https://github.com/ohmyzsh/ohmyzsh)是zsh的增强版本，带有智能提示，Github中的Star数量是132k，人气特别高的一个开源项目。特别是对于经常忘记Linux指令的人，非常有用。这里考虑用oh my zsh替换掉Ubuntu默认的bash shell。当然，这两个shell是可以互相切换的。不用担心，为了以防万一，操作之前对虚拟机进行快照备份。

1.首先是安装zsh：执行：sudo apt install zsh

2.把默认shell设置为zsh:  

````echo $SHELL````

`chsh -s $(which zsh)`

3.安装git,curl,wget这三个工具：

`sudo apt install curl wget git`

4.安装Oh My Zsh，通过如下命令行：

`sh -c "$(curl -fsSL https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"`

安装完oh my zsh之后，默认的shell就会是oh my zsh的。

其他更多扩展：oh my zsh安装插件，卸载oh myzsh ，参考：[How to Install OH-MY-ZSH in Ubuntu 20.04](https://www.tecmint.com/install-oh-my-zsh-in-ubuntu/)



如果是在Bash Shell情况下切换到zsh，直接敲入命令行：zsh  即可



#### shell命令自动提示

在安装了oh my zsh之后，我们使用git命令来测试下，这个shell命令工具是怎么提供提示信息的，比如我们敲入git，然后**按两下Tab键**，这个时候，下面会弹出来一堆提示信息，都是跟git指令相关的，而且这些提示补全指令，都是可以通过上下方向箭头去选择的，有了这个oh my zsh之后就非常方便。

<img src="https://cs-cn.top/images/posts/git_command_test12.png"/>



### Windows复制粘贴文件文本到Ubuntu

通过上面的“调整分辨率”那个章节，我们已经安装过VisualBoxAdditional.ISO这个光盘镜像了，那么VisualBox工具栏上面已经有了这个功能，可以把虚拟机中的剪切板内容分享给外面的windows宿主机，同时也可以把外面宿主机windows剪切板内容分享给虚拟机Ubuntu，可以是双向，也可以是windows -> Ubuntu，也可以是Ubuntu-> windows，这三种选项看自己需要来定。设置之后需要生效，要重启Ubuntu虚拟机。

<img src="https://cs-cn.top/images/posts/copy_paste026.png"/>

另外，拖动文件到Ubuntu里面都是可以的，也是在安装完VisualBoxAdditional之后才有的功能。

### 关掉Ubuntu自动锁屏

因为是在windows的VisualBox虚拟机环境使用Ubuntu，本身windows有锁屏功能，虚拟机Ubuntu的锁屏时间很短，只有5分钟，为了开发方便，直接关闭掉锁屏：

<img src="https://cs-cn.top/images/posts/auto_lock_screen04900.png"/>



### 给本地虚拟机Ubuntu提供科学上网能力

可以使用这个webUI项目解决国内服务器需要科学上网的问题，比如自己搭建的Ubuntu环境需要用来编译OpenWrt给R2S软路由使用，我这里给虚拟机Ubunut分配了45GB硬盘空间，而由于编译OpenWrt软路由固件需要长时间挂机，并且编译的时候很多的插件都是需要科学上网才行的，所以最好的办法就是使用这个VrayA项目：[https://github.com/v2rayA/v2rayA](https://github.com/v2rayA/v2rayA)

![image-20220213183226362](/images/posts/image-20220213183226362.png![image-20220213183321490](/images/posts/image-20220213183321490.png)

操作手册：[https://v2raya.org/docs/prologue/quick-start/](https://v2raya.org/docs/prologue/quick-start/)
