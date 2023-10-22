---
layout: post
title: charles和fiddler手机App抓包设置
categories: .net
description: 抓包
keywords: 安卓手机抓包
typora-root-url: ../

---

安卓逆向，通过Charles或者Fiddler抓取手机APP请求数据包，对https进行解密。

### 0.安卓App抓包常见问题

charles破解序列号生成地址：[https://www.zzzmode.com/mytools/charles/](https://www.zzzmode.com/mytools/charles/)

没有设置之前，https都是加密的：

![image-20231014164534387](/images/posts/image-20231014164534387.png)

![image-20231014184937891](/images/posts/image-20231014184937891.png)



设置之后，https明文都可以解析出来。

![image-20231014204943025](/images/posts/image-20231014204943025.png)

### 1.初始化Charles证书

首先是安装https证书，如下：

![image-20231014164100408](/images/posts/image-20231014164100408.png)

由于重新安装了windows系统，因此Charles证书要重新安装到系统的C盘，通过向导安装，直接“下一步，下一步”即可：

![image-20231014164115579](/images/posts/image-20231014164115579.png)

![image-20231014164315299](/images/posts/image-20231014164315299.png)

如上图：安装到受信任的根证书颁发者路径下，即“Trusted Root Certification Authorites”文件夹下面，然后是开启Https代理，设置需要代理的端口和域名。

![image-20231014164910804](/images/posts/image-20231014164910804.png)

这里使用星号*，匹配所有的域名和端口：

![image-20231014165138433](/images/posts/image-20231014165138433.png)

![image-20231014165157055](/images/posts/image-20231014165157055.png)

上面设置完成之后，Charles对本地8888端口的监听进程就启动了。下面是测试雷电模拟器连接Charles端口，并下载https证书的能力：

![image-20231014165402520](/images/posts/image-20231014165402520.png)

![image-20231014165415660](/images/posts/image-20231014165415660.png)

第一个是证书地址：http://chls.pro/ssl 第二个是代理地址：192.168.1.104：8888. 这里的提示信息明确告知你，需要你配置移动设备代理，改为使用Charles的http代理地址。以安卓模拟器为例，我们把安卓模拟器的代理设置为“手动”并且代理地址设置为192.168.1.104:8888。这样设置之后，雷电模拟器每次开机之前，都需要开启Charles，雷电模拟器内部才能上网，要不然是无法联网的。雷电模拟器的代理上网，要么被Charles接管，要么被Fiddler 4接管，2者选择其一即可，选择Charles的时候就是Charles抓包，选择Fiddler的时候就是Fiddler抓包。

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

之后是安装openssl命令行工具，转换charles证书为安卓适配版本。同样的方法可以转换findller的证书给到安卓端。

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

首先，介绍下OpenSSL这个命令工具的作用，如下：

![image-20231014192656968](/images/posts/image-20231014192656968.png)

首先是导出Charles证书，这里导出到桌面的"/Desktop/Charles Certificate/"文件夹中:

![image-20231014192145164](/images/posts/image-20231014192145164.png)

![image-20231014192044134](/images/posts/image-20231014192044134.png)

注意：这里有个坑，就是你如果不给这个文件夹下面输入一个文件名，导出的时候会发现文件夹里面是空。所以要给一个文件名，这里给它命名为“charles.pem":



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

看回安卓模拟器的设置：开启了Root权限，也有了ADB调试权限，但是无法写入，首先确认安卓模拟器开启了root如下，然后进行后续操作。

![image-20231014200717602](/images/posts/image-20231014200717602.png)

![image-20231018003059646](/images/posts/image-20231018003059646.png)

##### 3.3.1 填坑

让abd以root权限运行需要remount一下，root权限才会生效，后面的push操作才会有写入权限，如下：

```shell
adb root
```

```shell
adb remount
```

![image-20231014232216721](/images/posts/image-20231014232216721.png)

```shell
adb.exe push "C:\Users\caianhua\Desktop\Charles Certificate\15c8ce77.0" /system/etc/security/cacerts/
```

下面我们去这个路径下面找这个证书文件，看看是否成功上传了：

```shell
/system/etc/security/cacerts/
```

进入雷电安卓模拟器的文件夹管理器中，依次打开对应的`/system/etc/security/cacerts/`路径，如下图，证明上面的操作是成功了：

![image-20231014203100802](/images/posts/image-20231014203100802.png)

通过adb shell命令，进入安卓的linux系统目录也是可以看到的，使用Linux shell命令更方便：

![image-20231014203348975](/images/posts/image-20231014203348975.png)

##### 3.3.2 验证

Charles的证书已经弄到安卓模拟器里面去了，那么现在重新开启Charles，会自动开启8888端口的代理，然后安卓模拟器应该就是使用这个Charles代理端口上网了，下面来试试，https请求包是不是都已经是能抓到明文了。验证下：

![image-20231014204553852](/images/posts/image-20231014204553852.png)



### 4.Fiddler证书设置

Fiddler抓包证书设置跟Charles类似，需要中途进行一下转换，步骤会稍微多一点。

Fiddler下载地址：[Fiddler_5.0.20192.25091.zip](https://cs-cn.top/assets/tools/Fiddler_5.0.20192.25091.zip)

![image-20231015021502125](/images/posts/image-20231015021502125.png)



#### 4.1 安装Fiddler证书到PC端

首先我这个版本是安装的Fiddler 4版本，需要.net运行时环境.net framework 4.6.1；新装的win11系统是没有安装Fiddler https证书的，进入Options菜单，

![image-20231014223251306](/images/posts/image-20231014223251306.png)

默认情况下Fiddler是没有开启https抓包，点击HTTPS选项卡下面的Decrypt HTTPS traffic选项。

![image-20231014223508497](/images/posts/image-20231014223508497.png)



![image-20231014223648200](/images/posts/image-20231014223648200.png)

这里会有一连串的风险警告提示，告知如果你把这个不受信任的证书颁发机构发布的证书添加到系统根证书文件夹，那么来至这个发布者的所有证书将被自动受信任。如果你点击Yes表示你已经知晓了这个风险。我们直接点击Yes。

![image-20231014223723021](/images/posts/image-20231014223723021.png)

继续弹出来警告提示，请你确认以便添加证书到证书根目录。继续点击Yes。

![image-20231014223758777](/images/posts/image-20231014223758777.png)

一连串的警告和确认操作之后，证书成功被安装到系统证书根目录。

![image-20231014224154732](/images/posts/image-20231014224154732.png)

在安装成功之后，我们可以打开windows系统的证书管理界面查看，

![image-20231014224453124](/images/posts/image-20231014224453124.png)

会看到Fiddler字样的证书被安装到Root目录了。建议不要进行多次安装，这里会显示2个“DO_NOT_TRUST_FiddlerRoot"；当把这个证书以同样的原理安装到安卓Linux的`/system/etc/security/cacerts/`目录的时候，也不要进行重复安装。

![image-20231014224549489](/images/posts/image-20231014224549489.png)

#### 4.2 安装Fiddler证书到安卓端

需要把PC端的证书，使用OpenSSl工具进行转换，才能把PC证书安装到安卓Linux里面去，导出这个PC端证书：

![image-20231014224643340](/images/posts/image-20231014224643340.png)

![image-20231014224705053](/images/posts/image-20231014224705053.png)

点击操作之后，Fiddler自动把证书导出到windows系统的desktop桌面路径上，从你的电脑桌面上，可以看到一个名字为"Fiddler..."字样开头的证书图标，如下：

![image-20231014224805408](/images/posts/image-20231014224805408.png)

为了便于操作，把这个证书丢到文件夹里面，文件夹取名”FiddlerCertificate“，Fiddler PC端的证书的整个样子如下：

![image-20231014224906155](/images/posts/image-20231014224906155.png)

CMD进入到这个路径下面开始转换证书。

#### 4.2 OpenSSL转换Fiddler证书

1.首先将cer证书转为pem后缀证书

```shell
openssl x509 -inform der -in FiddlerRoot.cer -out Fiddler.pem
```

![image-20231014225147814](/images/posts/image-20231014225147814.png)

读取pem证书hash头的8个字符串：

```shel
openssl x509 -subject_hash_old -in Fiddler.pem
```

![image-20231014225340998](/images/posts/image-20231014225340998.png)

copy这8个字符串，重命名pem文件。

![FiddlerCertificateConvert](/images/posts/FiddlerCertificateConvert.gif)

CMD定位到雷电模拟器根目录`D:\leidian\LDPlayer9`，把证书`269953fb.0`传送到雷电模拟器中，如下：

```shell
adb root
```

```shell
adb remount
```

````shell
adb.exe push "C:\Users\caianhua\Desktop\FiddlerCertificate\269953fb.0" /system/etc/security/cacerts/
````

![image-20231014231845288](/images/posts/image-20231014231845288.png)

成功把Fiddler证书拷贝到了雷电模拟器中。

![image-20231014232523635](/images/posts/image-20231014232523635.png)

#### 4.3 遇到的坑

Charles关掉之后，换成Fiddler 4来监听并且代理8888端口，会发现雷电安卓模拟器无法上网。

![image-20231014234700013](/images/posts/image-20231014234700013.png)

![image-20231014235644603](/images/posts/image-20231014235644603.png)

Fiddler代理的端口8888是可以被安卓模拟器端请求到的，证明Fiddler确实是代理了8888端口接管了安卓模拟器的代理。

结论：最终还是解决了Fiddler 4抓包安卓https的问题。

#### 4.4 解决办法

1.删除掉Fiddler 4之前生成的证书cer转pem再重命名为`269953fb.0`的那份文件,重新导出Fiddler 4的cer证书，按照上面的步骤重新生成，并且使用adb命令重新push到安卓模拟器内部。

2.win11系统开机的时候不要使用vpn代理，并且win11代理设置中不要夹杂vpn代理端口的设置，只要保留Fiddler代理的地址，如图：

![image-20231015020209821](/images/posts/image-20231015020209821.png)

```shell
http=127.0.0.1:8888;https=127.0.0.1:888
```

Fiddler抓包的时候，安卓模拟器无法上网，跟电脑端开启了其他代理端口设置有关。其他代理软件的配置信息要从这个Proxy IP address里面去掉。

Fiddler 4的设置如下：

![image-20231015020509595](/images/posts/image-20231015020509595.png)

允许雷电模拟器连接到Fiddler的代理端口：

![image-20231015020412761](/images/posts/image-20231015020412761.png)



Fiddler的过滤器可以抓特定进程的，特定域名的报文数据，这是比Charles强的地方。做逆向分析的时候这个功能很实用。

![image-20231015020837454](/images/posts/image-20231015020837454.png)

配置这些开发环境不容易，配置完，记得备份系统。
