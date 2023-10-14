---
layout: post
title: charles抓取安卓手机https包设置
categories: .net
description: 抓包
keywords: 安卓手机抓包
typora-root-url: ../

---

抓安卓手机包，使用charles这个工具比较方便。由于升级了系统从win10到win11，很多之前配置的东西都要重新配置，比如charles抓安卓手机包，发现全部是乱码，这个是由于windows没有配置https解包证书导致的，先要在windows安装charles的https证书，然后还要给安卓手机端配置这个证书。尤其是这个安卓模拟器配置证书比较麻烦。因此记录下做个备忘。

### 0.安卓App抓包常见问题

想要通过Charles或者Findler抓包工具抓取安卓手机App里面的https请求，结合postman来开发模拟某些App的请求应用，如果开发环境没有配置好，会出现一些奇怪的问题，比如Charles抓包的时候抓到的都是乱码，还有安卓模拟器里面访问网站也会提示访问的https链接不是私密链接。解决这些问题，我们需要重新配置安卓模拟器的https证书。

![image-20231014164534387](/images/posts/image-20231014164534387.png)

![image-20231014184937891](/images/posts/image-20231014184937891.png)



前提是准备一个pojie好的Charles软件，激活一下，这个比较简单，网上搜索办法一大堆，搞定之后，Charles可以正常使用了，然后就是配置https证书：

### 1.初始化Charles证书

首先是安装https证书，如下：

![image-20231014164100408](/images/posts/image-20231014164100408.png)

由于重新安装了windows系统，因此Charles证书要重新安装到系统的C盘，如下

![image-20231014164115579](/images/posts/image-20231014164115579.png)

![image-20231014164315299](/images/posts/image-20231014164315299.png)

安装到受信任的根证书文件夹下面。

![image-20231014164910804](/images/posts/image-20231014164910804.png)

设置代理地址和端口，这里使用星号，匹配所有的域名和端口：

![image-20231014165138433](/images/posts/image-20231014165138433.png)

![image-20231014165157055](/images/posts/image-20231014165157055.png)

Charles开启监听8888本地端口如下：

![image-20231014165402520](/images/posts/image-20231014165402520.png)

![image-20231014165415660](/images/posts/image-20231014165415660.png)

注意阅读上面的提示信息，使用方法都在上面英文说得很清楚了。记录下两个地址。第一个是：http://chls.pro/ssl 第二个是：192.168.1.104：8888. 前者是Charles的证书，后者是我们需要设置的安卓模拟器代理地址，如果是IOS手机抓包，也可以设置iphone手机的代理地址为上面这个地址，就可以抓你IOS手机上面APP的https包了。这里主要是重点讨论安卓模拟器抓包的设置，相对而言有些复杂。继续下面的设置：

### 2.Charles监听安卓模拟器

雷电安卓模拟器按图索骥，如下依次点击进入，找到设置代理的地方：

![image-20231014170028849](/images/posts/image-20231014170028849.png)

![image-20231014170045347](/images/posts/image-20231014170045347.png)

![image-20231014170058817](/images/posts/image-20231014170058817.png)

![image-20231014170112827](/images/posts/image-20231014170112827.png)

![image-20231014170124487](/images/posts/image-20231014170124487.png)



设置代理模式为“手动”，上面记录好的Charles弹窗监听信息地址，设置为安卓的代理地址，默认端口号8888如下:



![image-20231014165555355](/images/posts/image-20231014165555355.png)

安卓模拟器浏览器直接访问http://chls.pro/ssl，能够下载到ssl.charles证书，表明我们的代理设置都是正确的，安卓模拟器能够和电脑端的Charles进行通讯了。

![image-20231014170503317](/images/posts/image-20231014170503317.png)

最麻烦的就是给安卓模拟器安装Charles的证书，同样的方法也可以安装Findller的证书，Fillder抓包和Charles抓包都会用到下面说到的方法。

### 3.Charles证书添加到安卓模拟器

前置条件：win11系统安装了chocolaty作为控制台工具，安装chocolaty工具，参考官方文档：[https://chocolatey.org/install](https://chocolatey.org/install)。使用powershell 以超级管理员权限安装即可。建议开启全局vpn。因为可能某些依赖项会被墙。

````shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
````

安装了chocolaty工具，使用下面的命令可以直接安装powershell7，顺带把powershell也升级下。

![image-20231014181258523](/images/posts/image-20231014181258523.png)

#### 3.1 安装OpenSSl

上面的前置条件OK之后，开始安装OpenSsl这个工具，使用choco安装的好处是，我们不需要像B站某些UP主演示的那样子进行全局路径和变量的设置，只需要choco自动全部给我们设置好即可。

安装openssl步骤：打开powershell，执行下面命令行：

````shell
choco install openssl
````

完整的执行过程如下图，choco会自动搜索openssl安装包，然后安装的时候是通过sp脚本全自动安装的，询问“Do you wan to run the script”的时候，选择“A”回车即可，如下图：

![image-20231014181801299](/images/posts/image-20231014181801299.png)

装好Openssl工具之后，win11系统搜索OpenSSl，会看到这个已经安装好的App如下：直接点击打开。

![image-20231014182021305](/images/posts/image-20231014182021305.png)

运行起来之后，效果如下：

![image-20231014182043238](/images/posts/image-20231014182043238.png)

输入openssl version，检测下openssl功能是否正常：

![image-20231014182225721](/images/posts/image-20231014182225721.png)

电脑上面安装了openssl之后，就可以把诸如Charles和Fiddler的证书安装到安卓模拟器里面去了。可以参考B站这个视频：[https://www.bilibili.com/video/BV1it4y1p7yK/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d](https://www.bilibili.com/video/BV1it4y1p7yK/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d)

#### 3.2 Fiddler证书安装到模拟器









