---

layout: post
title: Ubuntu的VisualBox设置
categories: Go
description: Golang相关笔记
keywords: Golang
---
Golang的开发环境大部分的情况是使用Linux居多。下面对于VisualBox在windows10系统中安装配置Ubuntu桌面版20.0.X LTS版本整理如下：刚开始安装Ubuntu的时候，**务必保证分配到45G左右的空间**，如果分配空间太少的话，会遇到System Root空间不足的告警，后期再去修改磁盘空间大小会遇到很多坑。

### 网络桥接模式

<img src="https://cs-cn.top/images/posts/bridge_connection4214.png"/>

VisualBox网络桥接模式，防止虚拟机安装之后无法更新。

### 修改Ubuntu镜像源

因为国内网速的问题，Ubuntu的镜像源需要设置为国内的阿里巴巴或者其他镜像。这个对于Ubuntu而是非常简单的，可以参考：[https://blog.csdn.net/laoluobo76/article/details/108302191](https://blog.csdn.net/laoluobo76/article/details/108302191)

<img src="https://cs-cn.top/images/posts/set_aliyun_mirror314.png"/>

因为Ubuntu可以直接在图像界面下修改镜像源地址为国内的，所以它比Centos和苹果的IOS其实更加适合程序员用来做为Linux开发环境。



### 调整自适应分辨率

更新了各种包之后，开始设置Ubuntu分辨率。现在一般台式机的显示器都是23寸的。而VisualBox虚拟机安装完Ubuntu之后，还需把桌面分辨率调节一下，并且如果是做为开发环境的话，显卡的显存分配，刷新率这些都需要调整到最佳状态。

在执行了：apt-get install update && apt-get install upgrade 之后，执行如下代码：

```sudo apt install virtualbox-guest-dkms```

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

它会弹出来一个验证框，要求你输入Ubuntu权限的密码，输入之后，Terminal开始执行命令行，开始安装：

<img src="https://cs-cn.top/images/posts/install_sh928.png"/>

安装完毕之后重启Ubuntu虚拟机。只要设置正确，那么VisualBox窗体顶部工具栏View菜单栏中的VisualBoxResize功能就可以被选中了，如下：

<img src="https://cs-cn.top/images/posts/auto_resize840.png"/>

当你拖放窗口大小的时候，分辨率会随着窗口的变化而变化的，对于程序员在Window上面搞开发而言非常方便了。

### 设置Ubuntu显卡

让ubuntu基于我们的硬件的显卡，设置到最高的分辨率，这里进入到display设置界面，选择我们的显示器最大的分辨率，比如我的是23寸，就选择1920 X 1440 （4:3），得到一个最舒适的分辨率，方便我们长期使用虚拟机得到最好的显示效果，保护我们的视力。

<img src="https://cs-cn.top/images/posts/setting_display4144.png"/>

<img src="https://cs-cn.top/images/posts/1920X1440_606.png"/>

如果不太习惯那种全屏模式的话，还是喜欢那种自适应模式的分辨率，那么可以View中选择Auto-Resize Guest  display 就是自动缩放的分辨率。全部设置完成之后，执行：sudo apt update ,更新一下配置信息。

**注意**：设置Ubuntu虚拟机窗口自适应的时候会遇到一些坑：调节VisualBox窗口大小和分辨率的时候，如果VisualBox窗体不小心进入了Scale Model，则会看不到VisualBox顶部的工具栏，只需要按住**键盘右边的Ctrl **+ Home键找回工具条，重新点击Scale Model就可以回到工具栏模式，对我们的窗口分辨率进行进一步设置。而点击**键盘右边的Ctrl **+C可以切换到缩略窗口模式。

### 修改MachineName

虚拟机在安装的时候，由于没有太注意，给定义的机器的名字非常长，先把机器名字修改简短一些，可以直接如下：

sudo nano /etc/hostname

进入到nano编辑器界面，修改了机器名之后，Ctrl + O 保存，然后Ctrl +X 退出机器，重启即可。



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



### 安装Golang

把Golang的压缩包文件放到Ubuntu的Dowloads路径下面，

执行解压缩：

`tar -xvf go1.17.linux-amd64.tar.gz`

设置权限：

`sudo chown -R root:root ./go`

移动位置到/usr/lcoal:

`sudo mv go /usr/local`

使用nano打开profile文件,配置golang的PATH路径：

`nano ~/.profile`

在文件底部加入：

```  #add go to the path 
export PATH=$PATH:/usr/local/go/bin
```

执行：

`source ~/.profile`

以上golang的环境变量就配置好了，接下来是配置golang的国内镜像和开启Module管理

#### 启动Go Modules功能

`go env -w GO111MODULE=on`



#### 配置golang七牛云镜像

`go env -w GOPROXY=https://goproxy.cn,direct`

验证镜像：go env | grep GOPROXY

测试代理: ``time go get golang.org/x/tour``



把它配置到环境变量中：

```echo "export GO111MODULE=on" >> ~/.profile
echo "export GO111MODULE=on" >> ~/.profile
```

```
echo "export GOPROXY=https://goproxy.cn" >> ~/.profile
```

```
source ~/.profile
```

搞定镜像代理之后，vscode命令行安装go的模块才能成功:

<img src="https://cs-cn.top/images/posts/already_togo36.png"/>



#### 私有模块和公有模块设置

如果你使用的 Go 版本 >=1.13, 你可以通过设置 `GOPRIVATE` 环境变量来控制哪些私有仓库和依赖 (公司内部仓库) 不通过 proxy 来拉取，直接走本地，设置如下：

```
go env -w GOPROXY=https://goproxy.cn,direct
```

设置不走 proxy 的私有仓库，多个用逗号相隔

```
go env -w GOPRIVATE=*.corp.example.com
```



### Ubuntu安装vs code

Vs code安装到ubuntu上面做为golang的主要开发工具。首先是firefox浏览器进入到vs code 官方，下载ubuntu版本的安装包。

<img src="https://cs-cn.top/images/posts/vs_code_file224.png"/>

ubuntu 20.0.X版本安装的时候，右键选择install的时候会发现没有任何反应，可以换一个安装方法：

<img src="https://cs-cn.top/images/posts/open_with_install0253.png"/>

`sudo apt update`

`sudo apt install gdebi`

鼠标右键，改用另外的软件来打开vs code安装包：

<img src="https://cs-cn.top/images/posts/Gdebi_install24.png"/>

<img src="https://cs-cn.top/images/posts/installation_message337.png"/>



### 移除Vs Code

Ubuntu下面执行如下指令：

`sudo apt purge code`

### 提升Ubuntu系统硬盘的大小

一开不建议中途去提升虚拟机硬盘大小，我这里初次安装的时候给虚拟机是45GB硬盘。如果实在不行，分配少了空间，后期再来提升UBUNTU硬盘，不过这里我的尝试遇到很多坑，还是建议一开始就设置到容量。

首先是分配更多的空间给到visualBox的虚拟机。然后进入到Ubuntu种对磁盘进行再分配。

<img src="https://cs-cn.top/images/posts/visual_disk_size5.png"/>

然后是进入到Ubuntu镜像光盘里面的GPart工具里面：

<img src="https://cs-cn.top/images/posts/GPart_tools607.png"/>

加载到光盘之后，进入到Try Ubuntu里面。

篇幅有限，这里推荐更加详细的地址：[How to increase the Disk Size of a Dynamically Allocated Disk in VirtualBox](https://ourcodeworld.com/articles/read/1434/how-to-increase-the-disk-size-of-a-dynamically-allocated-disk-in-virtualbox)











