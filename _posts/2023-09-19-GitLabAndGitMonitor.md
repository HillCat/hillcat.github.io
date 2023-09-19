---
layout: post
title: 提升团队工作效率工具GitLab监控
categories: dotnetcore
description: dotnetcore
keywords: 团队管理
typora-root-url: ../
---

在团队开发中，git使用频率很高，而且很多公司都是使用Gitlab作为版本管理，团队组长经常会负责master分支合并，而团队中的其他成员往往无法及时知晓master分支的变更，导致自己开发的分支落后于master分支而没有及时rebase；往往发现自己的分支开发完之后，要rebase的时候出现很多冲突，这个时候再解决冲突会很耗时间。特别是在即将临近发版的时候，各种合并，和版本操作搞得鸡飞狗跳，其实合并版本这些事情，经常由于沟通不及时，或者团队协作问题，导致把同事的代码给直接覆盖了，或者是合并的时候搞错了分支，导致代码回滚，这些都是不必要的内耗。

那么有没有一个好的办法，让团队成员及时发现自己文件夹下面的分支落后于master分支，做到及时rebase呢，特别是我们同时开发好几个迭代分支，要在不同的分支之间切换来切换去，经常容易忘记rebase操作。为了解决这个问题，其实Gitlab和git都有提供dotnetcore版本的nuget包提供了api。并且我们很多时候都需要使用gitlab的网页端创建code review的新分支，并且发起merge branch的操作。而且发起这些之后我们还需要把开发分支url和code review分支url以及merge request请求的url告知开发组长。这些操作都是非常繁琐的操作。如果能够用代码自动实现，或者能够减轻程序员自己的工作量是最好不过的了。因此本文尝试自己开发一个这样子的工具，使得自己日常在公司的开发中提升工作效率和团队协作效率，减少因为合并版本，解决git冲突导致的鸡飞狗跳各种不必要的时间浪费。

首先要开发这样子的一个工具，需要一个测试环境，在自己的电脑docker desktop下面安装gitlab集成环境，如下,Ubuntu 的wsl命令下面：参考官方[gitlab文档](https://docs.gitlab.com/ee/install/docker.html)

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



