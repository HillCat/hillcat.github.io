---
layout: post
title: TesseractOCRTrainning
categories: .net
description: TesseractOCR
keywords: Tesseract
typora-root-url: ../

---

TesseractOCR训练属于自己的OCR模型。参考官方文档地址，编译Tesseract 5.3.3版本，进入win11的Terminal控制面板，输入wsl进入到win的linux子系统。注意：不要使用Ubuntu的环境，会无法编译，下面所有的操作都是在wsl环境下。官方参考文档：[https://tesseract-ocr.github.io/tessdoc/Compiling.html#linux](https://tesseract-ocr.github.io/tessdoc/Compiling.html#linux)

其中遇到的坑，解决办法：

[https://github.com/tesseract-ocr/tesseract/issues/833](https://github.com/tesseract-ocr/tesseract/issues/833)

````shell
sudo apt-get install automake libtool
````

首先

```shel
sudo apt update
sudo apt upgrade
```

其次：

```shell
sudo apt install tesseract-ocr
sudo apt install libtesseract-dev

```

```shell
sudo apt-get install g++ # or clang++ (presumably)
sudo apt-get install autoconf automake libtool
sudo apt-get install pkg-config
sudo apt-get install libpng-dev
sudo apt-get install libjpeg8-dev
sudo apt-get install libtiff5-dev
sudo apt-get install zlib1g-dev
sudo apt-get install libwebpdemux2 libwebp-dev
sudo apt-get install libopenjp2-7-dev
sudo apt-get install libgif-dev
sudo apt-get install libarchive-dev libcurl4-openssl-dev

```

训练模块

````shell
sudo apt-get install libicu-dev
sudo apt-get install libpango1.0-dev
sudo apt-get install libcairo2-dev

````

Unbuntu下面编译Tesseract还需要：

```shell
sudo apt-get install libleptonica-dev
```

然后参考官方文档，编译Tesseract：

````shell
sudo apt install make
````



[https://github.com/tesseract-ocr/tesseract/blob/main/INSTALL.GIT.md](https://github.com/tesseract-ocr/tesseract/blob/main/INSTALL.GIT.md)

```shell
$ ./autogen.sh
$ ./configure --disable-debug 'CXXFLAGS=-g -03'
$ make -j16
$ sudo make install
$ sudo ldconfig
$ make training
$ sudo make training-install
```

安装成功之后：

![image-20240110002245102](/images/posts/image-20240110002245102.png)



