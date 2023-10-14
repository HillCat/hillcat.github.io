---
layout: post
title: charles抓取安卓手机https包设置
categories: dotnet
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

注意阅读上面的提示信息，使用方法都在上面英文说得很清楚了。记录下两个地址。第一个是：http://chls.pro/ssl 第二个是：192.168.1.104：8888. 前者是Charles的证书，后者是我们需要设置的安卓模拟器代理地址，如果是IOS手机抓包，也可以设置iphone手机的代理地址为上面这个地址，就可以抓你IOS手机上面APP的https包了。

### 2.Charles安卓模拟器代理

雷电安卓模拟器代理设置，依次“下一步，下一步”：

![image-20231014170028849](/images/posts/image-20231014170028849.png)

![image-20231014170045347](/images/posts/image-20231014170045347.png)

![image-20231014170058817](/images/posts/image-20231014170058817.png)

![image-20231014170112827](/images/posts/image-20231014170112827.png)

![image-20231014170124487](/images/posts/image-20231014170124487.png)



设置代理模式为“手动”，如下:



![image-20231014165555355](/images/posts/image-20231014165555355.png)

安卓模拟器访问http://chls.pro/ssl，能够下载到ssl.charles证书，表明Charles已经代理了安卓模拟器上网流量了。

![image-20231014170503317](/images/posts/image-20231014170503317.png)

之后是安装openssl命令行工具，转换charles证书为安装适配版本。同样的方法可以转换findller的证书给到安卓端。

### 3.OpenSSL命令行安装

#### 3.0 Chcolaty安装

win11系统安装了chocolaty作为控制台工具，安装chocolaty工具，参考官方文档：[https://chocolatey.org/install](https://chocolatey.org/install)。使用powershell 以超级管理员权限安装即可。建议开启全局vpn。因为可能某些依赖项会被墙。

````shell
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
````

安装了chocolaty工具，使用下面的命令可以直接安装powershell7，顺带把powershell也升级下。

![image-20231014181258523](/images/posts/image-20231014181258523.png)

#### 3.1 Chocolaty安装OpenSSl

上面的前置条件OK之后，开始安装OpenSsl这个工具，使用choco安装的好处是，我们不需要像B站某些UP主演示的那样子进行全局路径和变量的设置，只需要choco自动全部给我们设置好即可。

安装openssl步骤：打开powershell，执行下面命令行：

````shell
choco install openssl
````

完整的执行过程如下图，choco会自动搜索openssl安装包，然后安装的时候是通过sp脚本全自动安装的，询问“Do you want to run the script”的时候，选择“A”回车即可，如下图：

![image-20231014181801299](/images/posts/image-20231014181801299.png)

装好Openssl工具之后，win11系统搜索OpenSSl，会看到这个已经安装好的App如下：直接点击打开。

![image-20231014182021305](/images/posts/image-20231014182021305.png)

运行起来之后，效果如下：

![image-20231014182043238](/images/posts/image-20231014182043238.png)

输入openssl version，检测下openssl功能是否正常：

![image-20231014182225721](/images/posts/image-20231014182225721.png)

接下来的操作可以参考B站这个视频：[https://www.bilibili.com/video/BV1it4y1p7yK/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d](https://www.bilibili.com/video/BV1it4y1p7yK/?share_source=copy_web&vd_source=074fc12dff24eb02318a300ccc48526d)

#### 3.2 OpenSSL转换Charles证书

首先，介绍下OpenSSL这个命令工具的作用，如下：我们这里用到的是把PC端的https证书转为安卓端使用的https证书。

![image-20231014192656968](/images/posts/image-20231014192656968.png)

首先是导出Charles证书，这里导出到桌面的"/Desktop/Charles Certificate/"文件夹中:

![image-20231014192145164](/images/posts/image-20231014192145164.png)

![image-20231014192044134](/images/posts/image-20231014192044134.png)

注意：这里有个坑，就是你如果不给这个文件夹下面输入一个文件名，导出的时候会发现文件夹里面是空。所以这里要给一个文件名字，这里给它命名为“charles.pem":



![image-20231014193947618](/images/posts/image-20231014193947618.png)

![image-20231014194120176](/images/posts/image-20231014194120176.png)

成功导出了charles的证书文件。

使用下面的命令开始转换：

```shell
openssl x509 -subject_hash_old -in charles.pem
```



![image-20231014194230316](/images/posts/image-20231014194230316.png)

![image-20231014194416450](/images/posts/image-20231014194416450.png)

执行成功之后，出来一堆hash字符。拷贝BEGIN CERIFICATE注释信息上面那8个字符串,也就是下面这8个字符：

```shell
15c8ce77
```

然后用这个8个字符直接重命名charles.pem为
```
15c8ce77.0
```
注意：连同后缀也要一起改，后缀.pem改为.0，注意这里的操作细节，别搞错了。

![image-20231014194843541](/images/posts/image-20231014194843541.png)

之所以要记录笔记，是因为这里的操作真的比较麻烦！记录下来以备不时之需。

#### 3.3 雷电模拟器安装Charles证书

首先是定位到雷电模拟器的安装路径，如下：

![image-20231014195537778](/images/posts/image-20231014195537778.png)

找到adb.exe这个工具：

![image-20231014195611330](/images/posts/image-20231014195611330.png)

使用超级管理员权限，运行command命令行，执行如下：这个命令的目的是为了把Charles证书推送到雷电安卓模拟器里面去。

```shell
adb.exe push "C:\Users\caianhua\Desktop\Charles Certificate\15c8ce77.0" /system/etc/security/cacert
s/
```

##### 3.3.0 遇到的坑

推送证书到安卓模拟器，会遇到路径不对，安卓模拟器没有写入权限的问题，如下：

![image-20231014200610446](/images/posts/image-20231014200610446.png)

看回安卓模拟器的设置：开启了Root权限，也有了ADB调试权限，但是无法写入，那么在网上搜索下解决方案，把写入权限开启。

![image-20231014200717602](/images/posts/image-20231014200717602.png)

##### 3.3.1 填坑

让abd以root权限运行，如下：

```shell
adb root
```



![image-20231014201119946](/images/posts/image-20231014201119946.png)



```shell
adb shell
```

![image-20231014202329011](/images/posts/image-20231014202329011.png)

进入之后,执行：

```shell
mount
```

![image-20231014202819294](/images/posts/image-20231014202819294.png)

最后退出shell，使用exit推出，再windows command指令：

```shell
adb.exe push "C:\Users\caianhua\Desktop\Charles Certificate\15c8ce77.0" /system/etc/security/cacerts/
```

最终是成功了。



总之上面命令的目的是把Charles证书复制一份到安卓系统的如下路径，如果复制失败，那么就手动进入安卓模拟器复制即可，下面我们去这个路径下面找这个证书文件，看看是否成功上传了：

```shell
/system/etc/security/cacerts/
```

进入雷电安卓模拟器的文件夹管理器中，依次打开对应的`/system/etc/security/cacerts/`路径，如下图，证明上面的操作是成功了：

![image-20231014203100802](/images/posts/image-20231014203100802.png)

通过adb shell命令，进入安卓的linux系统目录也是可以看到的，使用Linux shell命令更方便：

![image-20231014203348975](/images/posts/image-20231014203348975.png)

