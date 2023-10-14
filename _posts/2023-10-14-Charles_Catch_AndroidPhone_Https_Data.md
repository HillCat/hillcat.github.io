---
layout: post
title: charles抓取安卓手机https包设置
categories: .net
description: 抓包
keywords: 安卓手机抓包
typora-root-url: ../

---

抓安卓手机包，使用charles这个工具比较方便。由于升级了系统从win10到win11，很多之前配置的东西都要重新配置，比如charles抓安卓手机包，发现全部是乱码，这个是由于windows没有配置https解包证书导致的，先要在windows安装charles的https证书，然后还要给安卓手机端配置这个证书。

![image-20231014164534387](/images/posts/image-20231014164534387.png)



下面是配置charles为安卓系统代理上网的配置过程，记录下，配置过程有些细节，时间久了容易忘记，在此记录一下，以作备忘：

首先是安装https证书，如下：

![image-20231014164100408](/images/posts/image-20231014164100408.png)

![image-20231014164115579](/images/posts/image-20231014164115579.png)

![image-20231014164315299](/images/posts/image-20231014164315299.png)

![image-20231014164910804](/images/posts/image-20231014164910804.png)

![image-20231014165138433](/images/posts/image-20231014165138433.png)

![image-20231014165157055](/images/posts/image-20231014165157055.png)

开启8888代理上网端口：

![image-20231014165402520](/images/posts/image-20231014165402520.png)

![image-20231014165415660](/images/posts/image-20231014165415660.png)

然后在电脑端安卓模拟器，设置安卓模拟器使用这个ip地址和端口代理上网即可。

安卓模拟器如下设置：

![image-20231014170028849](/images/posts/image-20231014170028849.png)

![image-20231014170045347](/images/posts/image-20231014170045347.png)

![image-20231014170058817](/images/posts/image-20231014170058817.png)

![image-20231014170112827](/images/posts/image-20231014170112827.png)

![image-20231014170124487](/images/posts/image-20231014170124487.png)



按照如下设置手动代理，ip地址就是自己电脑的当前局域网ip地址。



![image-20231014165555355](/images/posts/image-20231014165555355.png)

根据Charles的证书安装提示，我们需要使用浏览器直接访问http://chls.pro/ssl这个地址，下载https证书，添加到安卓里面设置为信任。

![image-20231014170503317](/images/posts/image-20231014170503317.png)

