---
layout: post
title: Nvida_Cuda_AI_ccelerate
categories: english
description: AI学英文
keywords: AI生成提速
typora-root-url: ../
---

在使用C# Unsafe代码调用C++的AI库进行生成字幕的时候，会遇到卡顿和效率慢的问题，这个时候可以利用cuBLAS通过Nvidia显卡的GPU核心进行加速。前提是你需要一块Nvida的显卡，然后还需要安装cuda，cuda的下载地址如下(win10操作系统)：

https://developer.nvidia.com/cuda-downloads?target_os=Windows&target_arch=x86_64&target_version=10&target_type=exe_local

文件大小超过3GB，下载完成之后，安装到系统中：

![Typora_oJzk8hkSqb](/images/posts/Typora_oJzk8hkSqb.png)



另外，对应的C++的dll需要编译为支持cuBLAS即可。

![chrome_odLufj15Fz](/images/posts/chrome_odLufj15Fz.png)
