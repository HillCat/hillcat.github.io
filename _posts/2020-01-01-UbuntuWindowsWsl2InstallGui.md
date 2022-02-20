---

layout: post
title: 安装WSL2+Docker开发环境
categories: DotNetCore
description: Linux相关笔记
keywords: Linux
typora-root-url: ../
---
本篇是windows10安装wsl2 + windows terminal +ubuntu + docker desktop 环境的一篇合集。每次重装系统之后，需要安装这些环境还是比较繁琐的，容易漏掉一些设置，用此文做个笔记，方便以后参考。

### 安装WSL2+Docker开发环境

参考文章：[intalling-docker-desktop-for-windows](https://andrewlock.net/installing-docker-desktop-for-windows/)

根据步骤，先安装WSL1,开启这个功能：

```shell
dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart
```

安装成功之后，会看到如下信息：

```tex
Deployment Image Servicing and Management tool
Version: 10.0.19041.746

Image Version: 10.0.19042.804

Enabling feature(s)
[==========================100.0%==========================]
The operation completed successfully.
```



2.开启虚拟机

```tex
dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart
```



3.重启电脑



4.安装WSL2更新

Download [the WSL2 Linux kernel update package for x64 machines](https://wslstorestorage.blob.core.windows.net/wslblob/wsl_update_x64.msi) and install it.



5.设置WSL2为默认版本

This is an easy step, just run `wsl --set-default-version 2` in any PowerShell window:

```powershell
>wsl --set-default-version 2
For information on key differences with WSL 2 please visit https://aka.ms/wsl2
```

6.安装Ubuntu20.0.0LTS版本

We actually don't need to install a Linux distribution to use Docker Desktop, but if you want to shell into Linux directly, you'll need to install one. You can install a distribution directly from the [Microsoft Store](https://aka.ms/wslstore).



7.安装windows terminal

If you're using [Windows Terminal](https://docs.microsoft.com/en-us/windows/terminal/get-started) (you should be!) you can configure it to open your WSL distribution. The easiest way to do this is to open up the *settings.json* file and reset it. You can do this by deleting the contents of the file—Terminal will automatically repopulate it with the defaults, which will include a tab for WSL.



### 给WSL2的Ubunt安装GUI

没有必要就不要安装GUI，这个仅供参考：

1.执行Sudo apt install xrdp

2.执行sudo apt install -y xfce4

执行这一步骤的时候控制台中途命令行会暂停，如果没有弹出下面这个界面，记得动一下键盘任意键，会出现这个界面：默认选择之后回车，控制台程序会接着往下执行。

<img src="https://cs-cn.top/images/posts/linux_gui25.png"/>



3.执行sudo apt install -y xfce4-goodies

4.执行 sudo cp /etc/xrdp/xrdp.ini  /etc/xrdp/xrdp.ini.bak

这一步备份下xrdp配置文件。

5.修改xrdp配置

执行： sudo sed -i 's/3389/3390/g' /etc/xrdp/xrdp.ini

6.修改xrdp配置

执行： sudo sed -i 's/max_bpp=32/#max_bpp=32\nmax_bpp=128/g' /etc/xrdp/xrdp.ini

7.修改xrdp配置

执行：sudo sed -i 's/xserverbpp=24/#xserverbpp=24\nxserverbpp=128/g' /etc/xrdp/xrdp.ini

8.执行如下：

echo xfce4-session > ~/.xsession

9.编辑xrdp启动配置文件

执行：sudo nano /etc/xrdp/startwm.sh

<img src="https://cs-cn.top/images/posts/edit_configure_file836.png"/>

注释掉原本自带的配置文件最后两行，增加一行配置信息，让它从xfce4启动。修改完成之后保存，退出nano界面。

**10.开启xrdp服务**

执行：sudo /etc/init.d/xrdp start

<img src="https://cs-cn.top/images/posts/start_xrdp153.png"/>



11.使用remote desktop连接localhost:3390

<img src="https://cs-cn.top/images/posts/localhost3390_12.png"/>



12.使用Ubuntu账号登录

<img src="https://cs-cn.top/images/posts/Linux_Remote_Login817.png"/>

最终看到的ubuntu的界面：

<img src="https://cs-cn.top/images/posts/remote_LinuxGui343.png"/>



13.查看自己的ubuntu系统的版本号

执行：lsb_release -a

<img src="https://cs-cn.top/images/posts/ubuntu_release_926.png"/>



14.查看Ubuntu的ip地址

 ip addr

<img src="https://cs-cn.top/images/posts/view_ubuntu_ipAdress35.png"/>

172.19.255.21/20 就是ubuntu的ip地址。

15.给Ubuntu安装firefox浏览器

默认情况下FireFox是没有安装的，会提示：

<img src="https://cs-cn.top/images/posts/firefox_noInstall513.png"/>

执行：sudo apt install firefox 就可以给Ubuntu安装FireFox浏览器，不过这种方法只是给WSL2里面的Ubuntu使用桌面端提供方便，更好的办法还是使用Oracle公司的VisualBox虚拟机来创建完整版的Ubuntu，因为微软win10系统内置的这个Ubuntu是个阉割版本，而且对于一些基于Linux开发环境比较严格的开发语言和编译环境，还是推荐使用VisualBox，它和win10上面的DockerDeskTop软件不会发生冲突，而Vmware这个虚拟机和win10上面的WSL2有冲突问题。VisualBox搭建Ubuntu开发环境参考这篇：[Golang_Ubuntu环境](https://cs-cn.top/2020/01/01/WindowSetUPGolang/)





### Ubuntu安装破解版本宝塔

强烈建议安装 ：https://github.com/leitbogioro/Crack_BT_Panel   破解版宝塔，不要安装那些来源不明的破解版本，会可能导致有后门。



参考资料 [https://www.vlwx.com/362.html](https://www.vlwx.com/362.html)



