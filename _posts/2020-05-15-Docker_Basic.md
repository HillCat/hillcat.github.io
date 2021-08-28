---

layout: post
title: Docker的常用指令
categories: .net
description: Docker使用技巧
keywords: .net
---
Docker在很多微软的开源项目使用得比较多，特别是windows WSL2系统结合DockerDeskTop工具，安装一些开源数据库，包括微软自家的SQLServer，OrchardCoreCMS，EshopOnDotNet，还有一些DotNetCore微服务相关的开源项目，RabbitMQ，Redis中间件，使用Docker安装到Local本机都非常方便。

### 1.Docker常见指令

docker -a, --all   #显示所有镜像，包括历史记录。

docker images   #列出本机所有镜像

docker search mysql #搜索docker hub里面所有相关的镜像，列出来镜像版本号

docker pull mysql  #拉取最新镜像，如果要指定版本号，使用冒号，后面加版本号

docker rmi -f     #删除镜像，如果要删除多个镜像，使用逗号隔开

docker rmi -f $(docker images -aq)  #递归删除所有镜像，删除的时候如果有容器引用了该镜像，则添加-f强制删除该镜像

`如果是要找指定版本号的mysql，则最好是去到docker hub上面找到指定版本号的mysql安装`

`docker镜像的下载，是分层原理下载的，跟git的commit类似，一层一层的`

### 2.容器命令

docker run -d --name nginx01 -p 3344:80 nginx   # -p 指定容器的端口，前面3344为宿主机端口，80为容器端口

docker run -p -d nginx:1.21.0 # 比如 -p 8080:8080  ,前面端口为宿主机端口，后面端口为docker容器端口

docker run -ir centos /bin/bash #交互模式运行centos,并指定控制台为bash

docker ps - a  #列出来曾经运行过的容器，包括正在运行的容器

docker ps -a -n=1 #显示最近使用过的容器

docker ps  -q #只显示容器编号

docker ps -aq #显示所有容器编号

ctrl + p + q  #容器不停止，退出， 一般使用exit 退出容器

docker rm -f $(docker ps -aq)  #递归方式删除所有容器

docker ps -a -q | xargs docker rm #通过管道符号删除，管道符号前面的值会传递到管道符合后面的命令中执行

#### 启停容器

docker start #启动容器

docker restart #重启容器

docker stop #停止容器

docker kill #强制杀掉容器进程

#### docker容器后台运行

docker容器后台运行的时候需要有个前台进程。

docker run -d centos



