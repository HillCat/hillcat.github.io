---
layout: post
title: charles抓取安卓手机https包设置
categories: .net
description: 抓包
keywords: 安卓手机抓包
typora-root-url: ../

---

抓安卓手机包，使用charles这个工具比较方便。由于升级了系统从win10到win11，很多之前配置的东西都要重新配置，比如charles抓安卓手机包，发现全部是乱码，这个是由于windows没有配置https解包证书导致的，先要在windows安装charles的https证书，然后还要给安卓手机端配置这个证书。尤其是这个安卓模拟器配置证书比较麻烦。因此记录下做个备忘。

![image-20231014164534387](/images/posts/image-20231014164534387.png)



下面是配置charles为安卓系统代理上网的配置过程，首先是搞定一个Charles软件，激活一下，这个比较简单，网上搜索pojie办法一大堆，搞定之后，Charles可以正常使用了，然后就是配置https证书：

### 1.初始化Charles证书

首先是安装https证书，如下：

![image-20231014164100408](/images/posts/image-20231014164100408.png)

由于重新安装了windows系统，因此Charles证书要重新安装到系统的C盘，如下

![image-20231014164115579](/images/posts/image-20231014164115579.png)

![image-20231014164315299](/images/posts/image-20231014164315299.png)

安装到收信任的根证书文件夹下面，如上图。

![image-20231014164910804](/images/posts/image-20231014164910804.png)

设置代理地址和端口，这里使用星号，匹配所有的域名和端口，也就是要抓取安卓模拟器所有的请求域名和端口，如下：

![image-20231014165138433](/images/posts/image-20231014165138433.png)

![image-20231014165157055](/images/posts/image-20231014165157055.png)

开启8888代理上网端口。Charles默认是有守护进程，开启监听8888本地端口的，先把Charles这个本地监听端口服务给开启了，如下：

![image-20231014165402520](/images/posts/image-20231014165402520.png)

![image-20231014165415660](/images/posts/image-20231014165415660.png)

如上图，当开启Charles本地监听端口服务的时候，这里它用英文提示你如何去设置IOS的代理以及http代理，要你访问http://chls.pro/ssl 就可以下载到Charles在本地8888端口的证书。

然后在电脑端的安卓模拟器先设置访问代理Charles这个8888端口：192.168.1.104：8888.

### 2.Charles监听安卓模拟器

雷电安卓模拟器按图索骥，如下依次点击进入，找到设置代理的地方：

![image-20231014170028849](/images/posts/image-20231014170028849.png)

![image-20231014170045347](/images/posts/image-20231014170045347.png)

![image-20231014170058817](/images/posts/image-20231014170058817.png)

![image-20231014170112827](/images/posts/image-20231014170112827.png)

![image-20231014170124487](/images/posts/image-20231014170124487.png)



点击编辑图标，代理模式设置为“手动”：



![image-20231014165555355](/images/posts/image-20231014165555355.png)

安卓模拟器浏览器直接访问http://chls.pro/ssl，其实这个访问的是本地电脑上面的Charles监听端口8888，会自动下载https证书，但是这个证书需要手动设置到安卓系统目录里面去。

![image-20231014170503317](/images/posts/image-20231014170503317.png)

由于安卓模拟器是Linux类似系统，因此最为麻烦的地方，就是要把Charles生成的这个证书添加到安卓系统里面去。这样子才能解密安卓端https数据包为明文。

### 3.Charles证书添加到安卓模拟器

前置条件推荐：win11系统安装choco作为控制台工具，前提是你已经安装好了choco工具，并且最好是把powershell升级到powershell7.

如果安装了chocolaty工具，使用下面的命令可以直接安装powershell7

![image-20231014181258523](/images/posts/image-20231014181258523.png)

#### 3.1 安装OpenSSl

[https://community.chocolatey.org/packages/openssl](https://community.chocolatey.org/packages/openssl)

打开powershell，执行下面命令行，安装openssl,(所有的命令行的操作建议都以Administrator超级管理员权限运行)

````shell
choco install openssl
````

![image-20231014181801299](/images/posts/image-20231014181801299.png)

![image-20231014182021305](/images/posts/image-20231014182021305.png)

运行起来之后，效果如下：

![image-20231014182043238](/images/posts/image-20231014182043238.png)

![image-20231014182225721](/images/posts/image-20231014182225721.png)

电脑上面安装了openssl之后，就可以把诸如Charles和Fiddler的证书安装到安卓模拟器里面去了。

#### 3.2 Fiddler证书安装到模拟器









