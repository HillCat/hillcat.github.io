---

layout: post
title: Linux常用命令整理
categories: Linux
description: Linux相关笔记
keywords: Linux
typora-root-url: ../
---
Linux常用的命令非常多。排名最靠前的就是解压缩功能。

### 解压缩文件夹

参考：[https://www.cyberciti.biz/faq/how-do-i-compress-a-whole-linux-or-unix-directory/](https://www.cyberciti.biz/faq/how-do-i-compress-a-whole-linux-or-unix-directory/)

Linux如何压缩一个文件夹：中间是压缩包格式，后面是文件夹路径位置

压缩指令如下：

~~~~c#
tar -zcvf archive-name.tar.gz source-directory-name
~~~~

- -z : Compress archive using gzip program in Linux or Unix
- -c : Create archive on Linux
- -v : Verbose i.e display progress while creating archive
- -f : Archive File name

解压指令如下：

~~~~c#
tar -zxvf prog-1-jan-2005.tar.gz -C /tmp
~~~~

