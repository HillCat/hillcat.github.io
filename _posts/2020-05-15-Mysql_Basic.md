---

layout: post
title: 开发环境Mysql安装和使用
categories: DotNetCore
description: DotNetCore
keywords: .net
typora-root-url: ../
---
Mysql安装之后远程客户端是无法通过root连接道数据库的，需要给与root账号远程登录授权。

### 授权

有的电脑需要做下面设置：

```sql
CREATE USER 'root'@'%' IDENTIFIED BY 'yourpassword';    
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%'  WITH GRANT OPTION;
FLUSH PRIVILEGES;
```

大部分情况下，mysql ,5.7.X版本可以尝试执行下面的指令(yourpassword记得改为自己的密码)：

```tex
mysql -uroot -p;
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED BY 'yourpassword' with grant option;
FLUSH PRIVILEGES;
```

一般经过上面的处理就可以登陆到本机localhost或docker中的mysql了。

![connet_mysql_success_2726.png](/images/posts/connet_mysql_success_2726.png)

**注意**：如果是Docker，启动容器的时候一定要指定好端口，-p 3306:3306   前面的端口号为宿主机win10的端口，后面的为ubuntu镜像中mysql的端口。



