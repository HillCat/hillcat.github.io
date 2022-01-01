---

layout: post
title: Mysql被哪些IP访问过?
categories: DotNetCore
description: DotNetCore
keywords: .net
typora-root-url: ../
---
Mysql安全方面的策略。

在开发阶段，为了保证只能是指定的某个IP可以访问mysql，需要centos防火墙进行设置白名单。

### 1.查看哪些IP访问了mysql：

````sql
SELECT substring_index(host, ':',1) AS hostname,state,count(*) FROM information_schema.processlist GROUP BY state,hostname;
````

通过上面的命令可以看到哪些IP访问了mysql。这个是最为准确的访问数据。因为在某些情况下，我们获取到的IP地址可能不准确。

![image-20220101140838806](/images/posts/image-20220101140838806.png)

比如我们通过百度里面，敲入IP来查询我们的IP地址，其实是不准确的。

![image-20220101141023915](/images/posts/image-20220101141023915.png)



