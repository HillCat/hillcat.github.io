---
layout: post
title: 提升团队工作效率工具GitLab监控
categories: dotnetcore
description: dotnetcore
keywords: 团队管理
typora-root-url: ../
---

在团队开发中，git使用频率很高，而且很多公司都是使用Gitlab作为版本管理，团队组长经常会负责master分支合并，而团队中的其他成员往往无法及时知晓master分支的变更，导致自己开发的分支落后于master分支而没有及时rebase；往往发现自己的分支开发完之后，要rebase的时候出现很多冲突，这个时候再解决冲突会很耗时间。特别是在即将临近发版的时候，各种合并，和版本操作搞得鸡飞狗跳，其实合并版本这些事情，经常由于沟通不及时，或者团队协作问题，导致把同事的代码给直接覆盖了，或者是合并的时候搞错了分支，导致代码回滚，这些都是不必要的内耗。

那么有没有一个好的办法，让团队成员及时发现自己文件夹下面的分支落后于master分支，做到及时rebase呢，特别是我们同时开发好几个迭代分支，要在不同的分支之间切换来切换去，经常容易忘记rebase操作。为了解决这个问题，其实Gitlab和git都有提供api。为了调试Gitlab的一些API，在docker desktop搭建开发环境：参考官方[文档](https://docs.gitlab.com/ee/install/docker.html)，docker脚本直接在win10的Ubuntu wsl下执行。

```shel
docker run --detach \
  --hostname localhost \
  --publish 443:443 --publish 80:80 --publish 22:22 \
  --name gitlab \
  --restart always \
  --volume gitlab-config:/etc/gitlab \
  --volume gitlab-logs:/var/log/gitlab \
  --volume gitlab-data:/var/opt/gitlab \
  --shm-size 256m \
  gitlab/gitlab-ee:latest

```

![image-20230920005234025](/images/posts/image-20230920005234025.png)



初始化成功，进入gitlab首页，刚开始的时候会是报错，原因是分配给docker desktop的内存太低，我这里分配了4GB，还是不够，直接给虚拟机分配8GB内存。

![image-20230920005628850](/images/posts/image-20230920005628850.png)

输入登录地址：http://localhost/users/sign_in

继续在Ubuntu wsl命令中运行如下命令，获取GitLab初始化之后的超级管理员root的登录密码，得到一个AES形式的密码明文，粘贴密码到登录框。

```shell
sudo docker exec -it gitlab grep 'Password:' /etc/gitlab/initial_root_password
```

![image-20230920010005357](/images/posts/image-20230920010005357.png)

![image-20230920010036399](/images/posts/image-20230920010036399.png)

![image-20230920010208525](/images/posts/image-20230920010208525.png)

docker环境很方便，就是有点费内存。

![image-20230920011238861](/images/posts/image-20230920011238861.png)

