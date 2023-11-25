---
layout: post
title: Git使用技巧
categories: 工具
description: Git工具使用技巧
keywords: Git使用技巧
typora-root-url: ../
---

Git工具使用。以下是Git回退到某个commit的版本。

### 1.基于本地分支创建新分支

说明：git checkout -b 新分支名 基于的分支名

```shell
git checkout -b newBranchName rebasedBranchName
```

或者直接在当前分支下面打开git控制台，直接创建分支，比如：git checkout -b dev-story-20231104-Subtitle_Logic_Optimum

![image-20231104225539317](/images/posts/image-20231104225539317.png)

### 2.找回自己被他人覆盖的代码

当别人的操作失误，导致自己之前的代码被覆盖的时候，需要找回自己的代码，这个时候就需要对代码的某个commit版本进行回滚操作，这个时候就会用到这个功能：

![image-20211230024243026](/images/posts/image-20211230024243026.png)

![image-20211230024809463](/images/posts/image-20211230024809463.png)

#### 2.2 直接回滚本地分支

场景：同事在没有告知的情况下，悄悄的修改并且提交了你的分支，而你事先并不知道，这个时候你修改了代码提交了push，发现提示报错，git提示信息告诉你，你当前的分支的进度落后于线上的版本，无法提交，于是你pull拉取了远程的分支，而这个时候你本地的变动已经提交在了本地，这个时候会出现merge合并冲突的情况，git会自动进行合并，这个时候会导致你的分支线出现凸起的隆起，并且在commit里面会留下一条merge合并的记录。

而这个时候如果你们团队的分支管理方式是rebase的模式，这个时候，团队的leader会要求你重新整一个分支。目的是要清理掉当前这个分支的merge记录。

那么直接的方法就是退回当前的分支到某个commit，回到merge之前的时间点。先备份好merge操作之后的commit部分的代码。然后把本地分支回退并且删除掉merge记录和merge commit。

![image-20231125171857335](/images/posts/image-20231125171857335.png)

在进行这个操作之前，一定要先记得把该处commit之后的那部分代码记得导出备份。

![image-20231125172027290](/images/posts/image-20231125172027290.png)

当导出备份和回退都做完之后，基于当前的回退的版本，新建一个新的分支。到git命令行，执行基于当前分支的新建一个分支，语法如下：

`newBranchName`就是新分支的名字，`rebaseBranchName`就是要基于哪个分支创建新分支。

```shell
git checkout -b newBranchName rebasedBranchName
```

建完之后，git会自动切换到新的分支。然后再把之前拷贝出来备份的那些改动追加到这个新分支上面。这样子就消除掉了分支上面出现突起隆起的问题了。

### 3.本地忽略文件

开发过程中，本地调试环境和线上公网的git正式环境配置是不一样的，我们提交代码的时候不希望把配置文件也提交上去了，开发团队中每个人的本地调试配置环境可能都不同，又不想影响到开发团队其他的成员或者

问题线索参考：[https://stackoverflow.com/questions/1753070/how-do-i-configure-git-to-ignore-some-files-locally](https://stackoverflow.com/questions/1753070/how-do-i-configure-git-to-ignore-some-files-locally)

![image-20220305135427196](/images/posts/image-20220305135427196.png)

![image-20220305135527486](/images/posts/image-20220305135527486.png)

TortoiseGit里面操作，参考:[https://tortoisegit.org/docs/tortoisegit/tgit-dug-ignore.html#:~:text=If%20you%20right%20click%20on,ignore%20type%20and%20ignore%20file.](https://tortoisegit.org/docs/tortoisegit/tgit-dug-ignore.html#:~:text=If%20you%20right%20click%20on,ignore%20type%20and%20ignore%20file.)



![image-20220305140941314](/images/posts/image-20220305140941314.png)

![image-20220305140750452](/images/posts/image-20220305140750452.png)

![image-20220305142746325](/images/posts/image-20220305142746325.png)

实际测试效果如下：

设置本地规则之后，visual Studio这里看到的Staged状态为删除状态，如果提交到公网上面，commit到公网可能会影响到团队其他成员：

![image-20220305143507794](/images/posts/image-20220305143507794.png)
