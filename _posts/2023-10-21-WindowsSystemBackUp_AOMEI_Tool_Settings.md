---
layout: post
title: Windows_System_Backup_Settings
categories: windows
description: 傲梅WINPE制作
keywords: windows系统备份
typora-root-url: ../

---

利用傲梅工具制作自己的WINPE备份还原工具，官方说明在此[https://www.diskpart.com/help/make-bootable-cd-wizard.html](https://www.diskpart.com/help/make-bootable-cd-wizard.html)。作为一个有着N多年DIY电脑PC经验的人而言，我觉得傲梅备份工具是目前为止我用过的最稳定可靠的电脑C盘备份工具，我使用Ghost有15+年。从我的第一台电脑开始就一直用Ghost备份系统，但是最近遇到了GHOST在win11系统(机械硬盘和SSD Vme2.0)拷贝数据的兼容问题，导致我从win10升级到win11之后花了很多时间重装系统。程序员的电脑要安装很多开发工具，配置很多环境，有些还是购买的正版软件，绑定了机器序列号的，所以重装系统浪费的时间可能是1~2天。电脑装机工具领域，Ghost越来越有被AOMEI取代的趋势。傲梅是付费工具，网络上有POJIE版本，或者Tao宝有POJIE版。安装好之后，接下来的思路是利用AOMEI这个工具刻录自己的WINPE系统.WINPE镜像使用微软官方正版镜像，没有任何的篡改，安全无毒。

![image-20231021183010529](/images/posts/image-20231021183010529.png)

### 1.AOMEI下载

使用AOMEI自制WINPE之后，下面这些工具就都没有必要了：SymanTec Ghost(赛门特克Ghost)，“微PE”，“firpe”，“老毛桃”，“一键Ghost硬盘版”，“大白菜WINPE”。唯一可能还会用到的就只有diskgenius分区工具；但是在硬盘分区合理的情况下，一般几十年都不会再去重新分区，除非是你买了新硬件。

傲梅7.3.2版本exe文件大小是：175MB左右。下载地址为： https://www.aliyundrive.com/s/gENVy5xAdYr 

```shell
提取码: 3p1p 
```

下载好之后直接安装，已经是POJIE好了的(买来至Tao宝5元店(*^_^*))，安装之后不需要做任何的其他操作就可以直接用了。

![image-20231021183907730](/images/posts/image-20231021183907730.png)

### 2.AOMEI备份

AOMEI全英文界面(傲梅的绝大部分用户其实都是海外用户)。国内有很多山寨魔改的各种傲梅备份分区工具，如果不看官方文档，还真的不知道如何制作属于自己的WINPE，它的备份界面如下：

![image-20231021184636757](/images/posts/image-20231021184636757.png)

点击进入，如下，会自动检测硬盘中的系统：

![image-20231021184706781](/images/posts/image-20231021184706781.png)

备份成功之后，会生成后缀是adi格式的文件，如下：

![image-20231021184919420](/images/posts/image-20231021184919420.png)



### 3.制作WINPE

拜托第三方制作的WINPE，自己也可以免费制作正版的WINPE。直接使用微软官方最新的winPE 11官方镜像。然后通过AOMEI工具刻录。

按照傲梅官方文档的制作文档提示，需要到微软的官方网站下载 ADK工具包和Add On组件，直接打开微软官方网站，下载安装ADK和ADD ON:

[https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install#download-the-adk-for-windows-11-version-22h2-updated-september-2023](https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install#download-the-adk-for-windows-11-version-22h2-updated-september-2023)

![image-20231021185724855](/images/posts/image-20231021185724855.png)

所谓的WINPE，其实就是利用微软的官方ADK工具，把最小化的系统刻录到优盘里面，刻录过程中会用到你C盘系统的某些文件，比如你的C盘系统是win10，那么就去下载win10对应的ADK，微软的这个ADK是专门针对不同的系统来安装的。AOMEI工具会利用已经安装好的ADK工具，来进行优盘WINPE的刻录。所以ADK是一切操作的前提。

按照微软官方文档的说明，选择"Download the Widdows ADK for Windows 11"，然后“Download the Windows PE add-on for the Windsow ADK”。

按顺序安装ADK和add-on for ADK，然后使用傲梅工具，创建启动媒介，Tools-->Create Bootable Media,选择Bootable Disc Type，选择windows PE:

![image-20231021185811226](/images/posts/image-20231021185811226.png)



![image-20231021185918796](/images/posts/image-20231021185918796.png)

后面就是根据提示信息，插入你的优盘，点击“下一步”“下一步”操作即可。优盘上面的WINPE就刻录好了。

### 4.去掉开机3秒等待

由于之前使用傲梅设置过开机启动Backupper工具，现在这个Backupper工具已经被我刻录到优盘里面做成了WINPE，所以这个植入了C盘每次开机都会停留3秒的设置就不需要了。Win + R 快捷键，输入： `msconfig`,打开Sytem Configuration,进入Boot选项：

![image-20231021190354142](/images/posts/image-20231021190354142.png)

删掉“Enter into AOMEI Backupper(\windows)”启动项，开机停留3秒的情况会自动取消。

具体参考AOMEI论坛的这个帖子：[https://www.aomeitech.com/forum/discussion/2030/aomei-boot-messages-still-appear-after-unistalliation](https://www.aomeitech.com/forum/discussion/2030/aomei-boot-messages-still-appear-after-unistalliation)

### 5.优盘WINPE使用

根据傲梅官方文档和微软的文档指引，成功刻录了微软官方最新的WINPE 11到优盘。开机按下Del键，进入主板BIOS设置从优盘启动。进入之后界面如下：

如果之前有备份过，这个首屏界面会列出来你硬盘上面备份的所有文件名字：下面图片从第一张开始，都是拍摄于电脑显示器界面

![image-20231021203100594](/images/posts/image-20231021203100594.png)

选择其中一个备份还原系统即可，非常方便，没有花里胡哨的垃圾功能，从界面可以看出来，我这个WINPE是win11最新的：

![image-20231021205551727](/images/posts/image-20231021205551727.png)

这个优盘工具还可以进行系统备份：

![image-20231021205610395](/images/posts/image-20231021205610395.png)

这是利用WINPE备份系统C盘的截图:

![image-20231021205627748](/images/posts/image-20231021205627748.png)

尝试备份C盘之后，首屏界面这里会显示多出来一个备份文件，并且在这个界面可以直接删除掉你不想要的备份。真的是没有任何多余的垃圾功能，非常的干净。

![image-20231021205643898](/images/posts/image-20231021205643898.png)

要还原系统C盘也是非常简单的，直接选中其中一个备份好的镜像，右键点击还原即可：

![image-20231021210235162](/images/posts/image-20231021210235162.png)







