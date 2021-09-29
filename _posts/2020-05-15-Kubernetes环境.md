---

layout: post
title: Kubernetes环境
categories: Docker
description: Docker使用技巧
keywords: .net
typora-root-url: ../
---
安装Kubernetes环境，一般是用Kubeadm，或者使用公有云的Kubernetes.

安装集群要求：

Linux操作系统，内存要求2GB，CPU要求双核，机器相互之间要求可以通信，可以访问外网拉取镜像，禁止swap分区。

### 准备工作

centos7.0系统镜像虚拟机若干台，然后关闭虚拟机防火墙：这里使用[centos7.0 Minimal](http://ftp.tku.edu.tw/Linux/CentOS/7.7.1908/isos/x86_64/CentOS-7-x86_64-Minimal-1908.torrent)版本，[直接下载地址](http://ftp.tku.edu.tw/Linux/CentOS/7.7.1908/isos/x86_64/CentOS-7-x86_64-Minimal-1908.iso)。

````shell
systemctl stop firewalld
systemctl disable firewalld
````

#### 关闭selinux

````shell
sed - i 's/enforcing/disable/' /etc/selinux/config #永久
setenforce 0 #临时
````

#### 关闭swap（K8S禁止虚拟机内存以提高行呢个）

永久关闭，需要重启Linux

````shell
swapoff -a #临时
sed -ri 's/.*wap.*/#&/' /etc/fstab #永久
````

#### 在master添加hosts

可以通过下面追加，也可以使用vim直接编辑

````shell
/etc/hosts << EOF
192.168.172.131 k8smaster
192.168.172.132 k8snode
EOF
````

#### 设置网桥参数

往文件中写入配置项信息

````shell
/etc/sysctl.d/k8s.conf << EOF
net.bridge.bridge-nf-call-ip6tables =1
net.bridge.bridge-nf-call-iptables=1
EOF
sysctl --system  #生效
````

#### 时间同步

保证各个虚拟机的时间同步

````shel
yum install ntpdate -y
ntpdate time.windows.com
````



