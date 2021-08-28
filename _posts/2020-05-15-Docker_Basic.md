---

layout: post
title: Docker的常用指令
categories: .net
description: Docker使用技巧
keywords: .net
---
Docker在很多微软的开源项目使用得比较多，特别是windows WSL2系统结合DockerDeskTop，安装一些开源数据库，包括微软自家的SQLServer，OrchardCoreCMS，EshopOnDotNet，还有一些DotNetCore微服务相关的开源项目，RabbitMQ，Redis中间件，使用Docker安装到Local本机都非常方便。以下对于Docker常用指令做一些整理。

### 1.Docker常见指令

`docker -a, --all   #显示所有镜像，包括历史记录。`

`docker images   #列出本机所有镜像`

`docker search mysql #搜索docker hub里面所有相关的镜像，列出来镜像版本号`

`docker pull mysql  #拉取最新镜像，如果要指定版本号，使用冒号，后面加版本号`

`docker rmi -f     #删除镜像，如果要删除多个镜像，使用逗号隔开`

`docker rmi -f $(docker images -aq)  #递归删除所有镜像，删除的时候如果有容器引用了该镜像，则添加-f强制删除该镜像`

`如果是要找指定版本号的mysql，则最好是去到docker hub上面找到指定版本号的mysql安装`

`docker镜像的下载，是分层原理下载的，跟git的commit类似，一层一层的`

### 2.容器命令

`docker run -d --name nginx01 -p 3344:80 nginx   # -p 指定容器的端口，前面3344为宿主机端口，80为容器端口`

`docker run -p -d nginx:1.21.0 # 比如 -p 8080:8080  ,前面端口为宿主机端口，后面端口为docker容器端口`

`docker run -ir centos /bin/bash #交互模式运行centos,并指定控制台为bash`

`docker ps - a  #列出来曾经运行过的容器，包括正在运行的容器`

`docker ps -a -n=1 #显示最近使用过的容器`

`docker ps  -q #只显示容器编号`

`docker ps -aq #显示所有容器编号`

`ctrl + p + q  #容器不停止，退出， 一般使用exit 退出容器`

`docker rm -f $(docker ps -aq)  #递归方式删除所有容器`

`docker ps -a -q | xargs docker rm #通过管道符号删除，管道符号前面的值会传递到管道符合后面的命令中执行`

#### 启停容器

`docker start #启动容器`

`docker restart #重启容器`

`docker stop #停止容器`

`docker kill #强制杀掉容器进程`

#### docker容器后台运行

docker容器后台运行的时候需要有个前台进程。

docker run -d centos

### 进入Docker容器

`docker exec -it dec7686171bf  /bin/bash   #以交互模式进入到docker容器，并且开启了bash`

`ps -ef  #进入docker容器之后显示正在运行所有进程，以完整格式输出`

`docker exec -it nginx01 /bin/bash # 进入容器的时候，可以是容器ID，也可以指定容器名`


要查看某个镜像是否支持/bin/bash，可以通过inspect指令查看镜像中元数据，看元数据Json节点中的CMD节点是否有/bin/bash


`docker inspect dce768617bf   #查看镜像中的元数据`

`docker logs -tf --tail 10 dce7b86171bf #查看10条日志，每隔1秒钟打印一个日志`

### 从容器中拷贝文件到宿主机

`docker attach b7845302511b # 进入到image为centos的容器中`

`cd home #进入home目录`

`ls   #首先可以看到home目录是没有任何文件的`

`touch test.json  #新建一个文件`

`exit    # 退出容器`

`docker ps -a  #列出最近运行的容器，这个时候文件还在容器中，容器不销毁，文件就一直存在容器中`

`docker cp b78453025116:/home/test.json /home   #把文件从容器中拷贝到外面宿主机指定目录中`

`cd  home  #进入到宿主机的home目录`

`ls    #进入home目录，即可看到我们从容器中拷贝到宿主机的test.json文件`

实际使用中，一般是把容器的目录和宿主机的目录打通，使用 -V 参数映射容器目录到宿主机目录，volume技术其实就是卷技术，使用卷技术使容器和宿主机的数据同步







