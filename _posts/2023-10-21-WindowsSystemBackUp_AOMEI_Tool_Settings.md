---
layout: post
title: Windows_System_Backup_Settings
categories: windows
description: 傲梅WINPE制作
keywords: windows系统备份
typora-root-url: ../

---

利用傲梅工具制作自己的WINPE备份还原工具，官方说明在此[https://www.diskpart.com/help/make-bootable-cd-wizard.html](https://www.diskpart.com/help/make-bootable-cd-wizard.html)。作为一个有着N多年DIY电脑PC经验的人而言，我觉得傲梅备份工具是目前为止我用过的最稳定可靠的电脑C盘备份工具，我使用Ghost有15+年。从我的第一台电脑开始就一直用Ghost备份系统，但是最近遇到了GHOST在win11系统(机械硬盘和SSD Vme2.0)拷贝数据的兼容问题，导致我从win10升级到win11之后花了很多时间重装系统。程序员的电脑要安装很多开发工具，配置很多环境，有些还是购买的正版软件，绑定了机器序列号的，所以重装系统带来的阵痛期很长。既然Ghost不稳定了，那么就换个更好的方法。傲梅是付费工具，网络上有POJIE版本，利用POJIE好的傲梅，刻录属于自己的纯净WINPE系统可以一劳永逸。此文正是为了此目的而写.

![image-20231021183010529](/images/posts/image-20231021183010529.png)

### 1.背景回顾

首先，说下我用过的电脑系统备份工具：SymanTec Ghost，也就是国内各大电脑城装机用得最多的各种WINPE会自带的工具，比较知名的，比如：“微PE”，“firpe”(这个工具我还捐赠过作者35RMB)，“老毛桃”，“一键Ghost硬盘版”，“大白菜WINPE”，还有，这些工具都会自带分区工具，DOS工具，还有自带dism++工具。这些都用过。最大的问题是，这些工具都会在系统C盘植入“私货”，平时看着人畜无害，没有到双十一不会给你弹窗，到了双十一电商促销的时候，这些幺蛾子和牛鬼蛇神就都出来了。或多或少都会在WINPE里面植入广告弹窗。最好的办法就是下载微软官方的WINPE制作优盘工具，最为纯净也最为稳定。

总之，傲梅这个工具越来越有取代Ghost的趋势。傲梅免费POJIE版本在某宝上面有，安装7.3.2版本的即可，exe文件大小是：175MB左右。

![image-20231021183907730](/images/posts/image-20231021183907730.png)

### 2.工具地址

下载地址为： https://www.aliyundrive.com/s/gENVy5xAdYr 

```shell
key: 3p1p 
```

这个已经是POJIE好了的工具，安装到windows上面就可以使用。我这里设置的是全英文界面(傲梅的绝大部分用户其实都是海外用户)。备份界面如下：

![image-20231021184636757](/images/posts/image-20231021184636757.png)

点击备份进入之后，如下界面：

![image-20231021184706781](/images/posts/image-20231021184706781.png)

备份完之后，文件后缀是adi格式的，如下：

![image-20231021184919420](/images/posts/image-20231021184919420.png)



### 3.还原系统

为了验证这个工具是可以使用的，我在备份完系统之后就对其进行了还原功能的测试，它自带了Boot Menu的植入功能，会在你的windows启动的时候，显示要你选择进入windows还是“傲梅WINPE”，但是这个功能是植入到了你系统的C盘引导扇区程序里面，每次开机都会出现。我不想要它把WINPE植入到系统C盘。那么我想让它刻录进入优盘中，做成优盘WINPE启动盘，并且我还想把这个WINPE导出为IOS，以方便随时刻录WINPE到优盘中。

所以按照傲梅官方文档的提示，需要到微软的官方网站下载 ADK工具包和Add On组件，然后再配合傲梅工具往优盘写入WINPE。

[https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install#download-the-adk-for-windows-11-version-22h2-updated-september-2023](https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install#download-the-adk-for-windows-11-version-22h2-updated-september-2023)

把下面的2个文件下载安装到自己windows11系统上面。

![image-20231021185724855](/images/posts/image-20231021185724855.png)

微软官方为刻录各种版本的WinPE提供了专门的工具，针对你的系统来安装，这里我系统是win11，所以选择："Download the Widdows ADK for Windows 11"，然后还要安装“Download the Windows PE add-on for the Windsow ADK”, 刻录WINPE 11的时候，会默认安装上与你电脑匹配的网卡驱动和显卡驱动。

安装好之后，使用傲梅工具，刻录winpe到优盘中。具体的傲梅菜单如下：

![image-20231021185811226](/images/posts/image-20231021185811226.png)



![image-20231021185918796](/images/posts/image-20231021185918796.png)

后面就是根据提示信息，插入你的优盘，点击“下一步”“下一步”操作即可。优盘上面的WINPE就刻录好了。

### 4.去掉开机3秒等待

由于之前使用傲梅设置过开机启动Backupper工具，它这个是植入了C盘里面，每次开机都会停留3秒钟，要你选择是进入windows还是进入傲梅WINPE，关掉这个开机3秒等待，然后把下面这个"Enter into AOMEI Backupper(\windows)"干掉即可。

Win + R 快捷键，输入： `msconfig`,打开如下界面：

![image-20231021190354142](/images/posts/image-20231021190354142.png)

删掉傲梅启动项即可。

参考来至于这个帖子：[https://www.aomeitech.com/forum/discussion/2030/aomei-boot-messages-still-appear-after-unistalliation](https://www.aomeitech.com/forum/discussion/2030/aomei-boot-messages-still-appear-after-unistalliation)

亲测有效。

### 5.优盘WINPE使用

根据傲梅官方文档和微软的文档指引，成功刻录了微软官方最新的WINPE 11到优盘。开机按下Del键，进入主板BIOS设置从优盘启动。进入之后界面如下：

如果之前有备份过，这个首屏界面会列出来你硬盘上面备份的所有文件名字：

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







