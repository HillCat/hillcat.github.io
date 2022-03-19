---
layout: post
title: Git使用技巧
categories: 工具
description: Git工具使用技巧
keywords: Git使用技巧
typora-root-url: ..
---

Git工具使用。以下是Git回退到某个commit的版本。

### Git回退到之前版本

当别人的操作失误，导致自己之前的代码被覆盖的时候，需要找回自己的代码，这个时候就需要对代码的某个commit版本进行回滚操作，这个时候就会用到这个功能：

![image-20211230024243026](/images/posts/image-20211230024243026.png)

![image-20211230024809463](/images/posts/image-20211230024809463.png)



### 本地忽略文件

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
