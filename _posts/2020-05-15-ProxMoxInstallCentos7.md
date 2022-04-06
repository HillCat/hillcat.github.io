---

layout: post
title: ProxMoxInstallCentos7
categories: DotNetCore
description: DotNetCore
keywords: .net
typora-root-url: ../
---
ProxMoxInstallCentos7过程中记录。

![image-20220404232201767](/images/posts/image-20220404232201767.png)

首先是从阿里云镜像上面download Centos7,[http://mirrors.aliyun.com/centos/](http://mirrors.aliyun.com/centos/)

然后上传到本地机器地proxmox文件夹中。

然后安装centos7的时候记得修改镜像源为阿里云的。

### 虚拟机中安装Docker

Centos7安装完docker之后是不会随着开机自动启动的，需要手动设置为开机自动启动。

参考docker官方文档：[https://docs.docker.com/engine/install/linux-postinstall/#configure-docker-to-start-on-boot](https://docs.docker.com/engine/install/linux-postinstall/#configure-docker-to-start-on-boot)![image-20220405122815283](/images/posts/image-20220405122815283.png)

开机自动启动：

````c#
 sudo systemctl enable docker.service
 sudo systemctl enable containerd.service
````

关闭开机自动启动：

````c#
 sudo systemctl disable docker.service
 sudo systemctl disable containerd.service
````

