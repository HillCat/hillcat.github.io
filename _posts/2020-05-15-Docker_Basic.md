---

layout: post
title: Docker的常用指令
categories: Docker
description: Docker使用技巧
keywords: .net
---
Docker在很多微软的开源项目使用得比较多，特别是windows WSL2系统结合DockerDeskTop，安装一些开源数据库，包括微软自家的SQLServer，OrchardCoreCMS，EshopOnDotNet，还有一些DotNetCore微服务相关的开源项目，RabbitMQ，Redis中间件，使用Docker安装到Local本机都非常方便。以下对于Docker常用指令做一些整理。Docker容器在Linux上面都是以进程隔离级别运行的，比较轻量级，结合K8s可以做到动态伸缩扩容。

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

docker容器后台运行的时候需要有个前台进程,如果docker发现没有前台应用则会自动停止。

docker run -d centos

`docker run -d centos /bin/sh -c "while true; do echo HelloWordMessage; sleep 1 ; done" #这里是开启一个前台无限循环执行一段shell脚本，不让后台centos停止`

### 进入Docker容器

`docker exec -it dec7686171bf  /bin/bash   #以交互模式进入到docker容器，并且开启了bash`

`ps -ef  #进入docker容器之后显示正在运行所有进程，以完整格式输出`

`docker exec -it nginx01 /bin/bash # 进入容器的时候，可以是容器ID，也可以指定容器名`


要查看某个镜像是否支持/bin/bash，可以通过inspect指令查看镜像中元数据，看元数据Json节点中的CMD节点是否有/bin/bash


`docker inspect dce768617bf   #查看镜像中的元数据`

`docker logs -tf --tail 10 dce7b86171bf #查看10条日志，每隔1秒钟打印一个日志`

#### exec和attach区别

有两种方式进入容器种，exec --it /bin/bash 方式和 attach方式。前面这种方式比较常见，是进入容器之后开启一个终端,后面这种方式是进入“正在运行的”终端。

docker attach 5bc0fd0f208b   #进入指定ID的容器

cd /home  #进入容器的home目录

cat test.json   #查看文件内容变化



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



### 容器部署tomcat

docker pull tomcat 

docker run -d -p 3355:8080 --name tomcat01 tomcat 

docker exec -it tomcat01 /bin/bash 

cd /usr/local/tomcat

cp -r webapps.dist | * webapps #拷贝网站文件到webapps目录,-r 递归拷贝

### 容器部署ElasticSearch

`docker run -d --name elasticsearch -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" elasticsearch:7.6.2  #直接这样子开启es内存占用会非常巨大`

`docker run -d --name elasticsearch02 -p 9200:9200 -p 9300:9300 -e "discovery.type = single-node" -e ES_JAVA_OPTS=“-xms64m -xmx512m”  elasticsearch:7.6.2 #通过配置文件指定内存大小`



### 可视化管理Docker

`docker run -d -p 8088:9000 --restart =always -v /var/run/docker.sock:/var/run/docker.sock --privileged=true portainer/portainer `

访问8088端口即可打开portainer面板，这是一个简易面板，可以管理images,containers,volumes,操作简单。

### docker为何启动这么快

docker的镜像容器使用的是unionFiles 联合文件系统，类似于git的push记录，文件是分层的。Linux系统启动的时候一般需要10秒钟左右，而docker容器启动只有几百个ms，是因为物理机Boot启动引导扇区这个步骤被省略掉了，docker容器通过分层之后，直接屏蔽掉了底层boot启动那块的代码，直接复用了宿主的Boot启动，也就是直接省略掉了Boot底层的启动，是直接开启的镜像层代码。启动速度是很快的。常规Linux启动Boot引导的时候，会到加载Boot FileSystem，加载完之后还得加载Root FileSystem，所以启动会慢。而docker镜像通过分层之后，启动的镜像层直接是置于Boot FileSystem和RootFileSystem层之上。启动速度非常快，而且还能屏蔽掉Linux各种发行版本底层的差异。

### 生成自己的镜像

`docker  commit -a="zhangsan" -m="ass webapps app" 7e119b82cff6  tomcat02:1.0`



### docker数据卷

`docker run -d -p --name nginx01 -v /etc/nginx nginx  #匿名挂载`

`docker volume ls #查看本地卷`

`docker run -d -p --name nginx02 -v juming-nginx:/etc/nginx nginx #具名挂载, v后面提供了名字`

#### 指定路径挂载

`docker run -it -v /home/ceshi:/home centos /bin/bash #这个就是把容器内的路径，指定挂载到宿主机的某个目录`

启动容器之后，可以通过inspcet指令查看容器元数据信息，可以看到类似的节点数据：

```c#
"mounts": {

"Srouce":"/home/ceshi", #这个是宿主机路径

"Destination":"/home"  #这个是docker容器的路径

}
```





#### 查看挂载目录



`docker volume inspect juming-nginx #查看具名挂载之后的容器元数据`

通过inspect命令可以查看到容器的元数据信息，在json格式的数据节点中，可以看到：

```c#
"mountpoint":"/var/lib/docker/volumes/juming-nginx/_data",

"Name":"juming-nginx"
```



容器卷有3种挂载形式：

-v 容器内路径    # 匿名挂载

-v 卷名:容器内路径  #具名挂载

-v  /宿主机路径：容器内路径 #指定路径挂载

举例：

docker run -d -p --name nginx02 -v juming-nginx:/etc/nginx:ro nginx #这里授权的是只读权限，容器只读，宿主机可读可写

docker run -d -p --name nginx02 -v juming-nginx:/etc/nginx:rw nginx #这里授权的是读写权限 ，容器和宿主机都可读可写



### DockerFile常用命令

FROM  #指定基础镜像  ，比如centos

MAINTAINER #镜像作者，姓名+ 邮箱

RUN #镜像构建时需要运行的命令

ADD #向镜像中添加内容，具有自动解压缩功能

WORKDIR #镜像工作目录

VOLUME #挂载目录

EXPOSE #指定对外端口

CMD #指定容器启动时该执行命令，只有最后一个会生效，可被替代

ENTRYPOINT #指定容器启动的时候要运行的命令，可以追加命令

ONBUILD #触发指令

COPY # 将文件拷贝到镜像中

ENV #构建的时候设置环境变量





