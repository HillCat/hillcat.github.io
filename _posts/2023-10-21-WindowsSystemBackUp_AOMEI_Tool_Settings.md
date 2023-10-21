---
layout: post
title: Windows_System_Backup_Settings
categories: windows
description: 傲梅WINPE制作
keywords: windows系统备份
typora-root-url: ../

---

傲梅WINPE工具，官方说明在此[https://www.diskpart.com/help/make-bootable-cd-wizard.html](https://www.diskpart.com/help/make-bootable-cd-wizard.html)。作为一个有着N多年DIY电脑PC经验的人而言，我觉得傲梅备份工具是目前为止我用过的最为安全和稳定的系统备份还原工具，特别是作为IT开发人员，如果自己的电脑重装系统需要配置大量的软件环境，代价还是非常巨大的。因此掌握一手稳定可靠的电脑备份方案还是很有必要的。我使用Ghost有15+年来年经验。从我的第一台电脑开始就一直用Ghost，但是最近遇到了兼容问题和不稳定，给我重装系统带来了相当的麻烦。所以绝对自己这个技能升级一下，最近研究对比了各种备份还原方案，最终觉得傲梅是最佳方案。

![image-20231021183010529](/images/posts/image-20231021183010529.png)

### 1.背景回顾

首先，说下我用过的电脑系统备份工具，SymenTec Ghost，也就是国内山寨版本的“微PE”，“firpe”，“老毛桃”，“一键Ghost硬盘版”，“大白菜WINPE装机工具”，还有那个Gsms++工具。这些都用过。要么是这些工具会嵌入一些“私货”，要么就是对win11兼容不好，还有就是无法对整个分区的扇区和引导文件进行备份。

总之，傲梅这个老外开发的工具是我用过的最给力的一个。免费POJIE版本在某宝上面有，安装7.3.2版本的即可，exe文件大小是：175MB左右。

![image-20231021183907730](/images/posts/image-20231021183907730.png)

### 2.工具地址

下载地址为： https://www.aliyundrive.com/s/gENVy5xAdYr 

```shell
key: 3p1p 
```

这个已经是POJIE好了的工具，安装到windows上面就可以使用。我这里设置的是全英文界面。软件安装完毕之后，使用如下菜单路径，对现有的windows系统C盘进行备份：

![image-20231021184636757](/images/posts/image-20231021184636757.png)

进入之后，如下界面：

![image-20231021184706781](/images/posts/image-20231021184706781.png)

它会默认检测你的电脑系统，你可以根据自己的需要修改备份文件名。如上图，备份整个C盘的时候，会自动检测到C盘的引导扇区和隐藏分区。设置好备份文件的存放路径即可，这里仅仅需要设置一个路径即可，不需要设置文件名，它会根据你的Task名字，自动生成备份文件。备份完毕之后，文件如下：

![image-20231021184919420](/images/posts/image-20231021184919420.png)



### 3.还原系统

为了验证这个工具是可以使用的，我在备份完系统之后就对其进行了还原功能的测试，它自带了Boot Menu的植入功能，会在你的windows启动的时候，显示要你选择进入windows还是“傲梅WINPE”，但是这个功能是植入到了你系统的C盘引导扇区程序里面，每次开机都会出现。我不想要它把WINPE植入到系统C盘。那么我想让它刻录进入优盘中，做成优盘WINPE启动盘，并且我还想把这个WINPE导出为IOS，以方便随时刻录WINPE到优盘中。

所以按照傲梅官方文档的提示，需要到微软的官方网站下载 ADK工具包和Add On组件，然后再配合傲梅工具往优盘写入WINPE。

[https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install#download-the-adk-for-windows-11-version-22h2-updated-september-2023](https://learn.microsoft.com/en-us/windows-hardware/get-started/adk-install#download-the-adk-for-windows-11-version-22h2-updated-september-2023)

把下面的2个文件下载安装到自己windows11系统上面。

![image-20231021185724855](/images/posts/image-20231021185724855.png)

安装好之后，使用傲梅工具，刻录winpe到优盘中。具体的傲梅菜单如下：

![image-20231021185811226](/images/posts/image-20231021185811226.png)



![image-20231021185918796](/images/posts/image-20231021185918796.png)

后面就是根据提示信息，插入你的优盘，点击“下一步”“下一步”操作即可。优盘上面的WINPE就刻录好了。

### 4.去掉开机3秒等待

由于之前使用傲梅设置过开机启动Backupper工具，它这个是植入了C盘里面，每次开机都会停留3秒钟，要你选择是进入windows还是进入傲梅WINPE，关掉这个开机3秒等待，然后把下面这个"Enter into AOMEI Backupper(\windows)"干掉即可。

![image-20231021190354142](/images/posts/image-20231021190354142.png)

参考来至于这个帖子：[https://www.aomeitech.com/forum/discussion/2030/aomei-boot-messages-still-appear-after-unistalliation](https://www.aomeitech.com/forum/discussion/2030/aomei-boot-messages-still-appear-after-unistalliation)

亲测有效。
