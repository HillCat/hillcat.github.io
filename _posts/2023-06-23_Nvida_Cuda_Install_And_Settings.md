---
layout: post
title: Nvidia_Cuda_AI_ccelerate
categories: english
description: AI学英文
keywords: AI生成提速
typora-root-url: ../
---

在使用C# Unsafe代码调用C++的AI库进行生成字幕的时候，会遇到卡顿和效率慢的问题，这个时候可以利用cuBLAS通过Nvidia显卡的GPU核心进行加速。前提是你需要一块Nvidia的显卡，然后还需要安装cuda，cuda的下载地址如下(win10操作系统)：

https://developer.nvidia.com/cuda-downloads?target_os=Windows&target_arch=x86_64&target_version=10&target_type=exe_local

文件大小超过3GB，下载完成之后，安装到系统中：

![Typora_oJzk8hkSqb](/images/posts/Typora_oJzk8hkSqb.png)



另外，对应的C++的dll需要编译为支持cuBLAS即可。显卡驱动最好是升级到Nvidia官方最新的驱动。

![chrome_odLufj15Fz](/images/posts/chrome_odLufj15Fz.png)

![image-20230623214217584](/images/posts/image-20230623214217584.png)

如果Cuda的版本和你显卡的版本不匹配，那么会出现如下报错：

`CUDA driver version is insufficient for CUDA runtime version`

仔细检查你电脑上面安装的Cuda版本和你NVidia显卡驱动的版本进行比较：

![image-20230623232725873](/images/posts/image-20230623232725873.png)

比如我的GPU版本是七彩虹的显卡，比较老的版本，Nvidia Gforce GT730系列的，从Nvidia官方下载到的最新的驱动 gt700系列中找到GT730,安装到win10上面显示这个版本是474.30,而我安装的Cuda是12.X版本，按照官方的解释，我这里应该安装Cuda11.X才行。所以卸载掉最新的CUDA12.X， 安装CUDA11.X即可。

![image-20230623233050774](/images/posts/image-20230623233050774.png)
