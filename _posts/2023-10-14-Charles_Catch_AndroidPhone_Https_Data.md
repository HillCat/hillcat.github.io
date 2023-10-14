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

雷电安卓模拟器按图索骥，如下依次点击进入，直到找到设置代理的地方：

![image-20231014170028849](/images/posts/image-20231014170028849.png)

![image-20231014170045347](/images/posts/image-20231014170045347.png)

![image-20231014170058817](/images/posts/image-20231014170058817.png)

![image-20231014170112827](/images/posts/image-20231014170112827.png)

![image-20231014170124487](/images/posts/image-20231014170124487.png)



点击上面的编辑图标，设置安卓模拟器的wifi为手动代理，如下：填写上Charles给到我们的代理地址和端口：



![image-20231014165555355](/images/posts/image-20231014165555355.png)

根据Charles的证书安装提示信息，我们需要使用浏览器直接访问http://chls.pro/ssl这个地址，下载https证书，添加到安卓模拟器的系统里面。

![image-20231014170503317](/images/posts/image-20231014170503317.png)

由于这个不是真实的手机，因此这个模拟器添加Charles证书最难的部分需要手动搞定才行，直接访问http://chls.pro/ssl虽然能够下载到证书，但是无法直接安装。

