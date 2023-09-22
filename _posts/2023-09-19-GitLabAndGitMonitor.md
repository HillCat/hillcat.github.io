---
layout: post
title: 提升团队工作效率工具GitLab监控
categories: dotnetcore
description: dotnetcore
keywords: 团队管理
typora-root-url: ../
---

在团队开发中，团队组长经常会负责master分支合并，而团队中的其他成员往往无法及时知晓master分支的变更，导致某些人的开发分支远远落后于master分支，要rebase的时候出现很多冲突，这个时候再解决冲突会很耗时间。特别是在即将临近发版的时候，各种合并，搞得鸡飞狗跳。

有没有一个好办法，让团队成员及时发现自己分支落后于master分支？其实可以自己开发一个winform工具，使用Gitlab提供的API和git本身的API监控本地分支和master分支差异，然后创建code view分支和合并分支请求，都可以通过Gitlab的API解决。为了方便测试，在本地搭建一个gitlab最快的方式是直接使用docker：参考官方[文档](https://docs.gitlab.com/ee/install/docker.html)，docker脚本直接在win10的Ubuntu wsl下执行。

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



初始化成功，进入gitlab首页，刚开始的时候会是报错，原因是分配给docker desktop的内存太低，刚开始分配了4GB，网页打开速度很慢，提升到8GB之后速度恢复正常.

![image-20230920005628850](/images/posts/image-20230920005628850.png)

输入登录地址：http://localhost/users/sign_in

继续在Ubuntu wsl命令中运行如下命令,拿到password之后，使用root登录。

```shell
sudo docker exec -it gitlab grep 'Password:' /etc/gitlab/initial_root_password
```

![image-20230920010005357](/images/posts/image-20230920010005357.png)

![image-20230920010036399](/images/posts/image-20230920010036399.png)

![image-20230920010208525](/images/posts/image-20230920010208525.png)

成功搞定。

