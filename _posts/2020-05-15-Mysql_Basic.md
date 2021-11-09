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

```c#
ALTER USER 'root'@'localhost' IDENTIFIED BY 'NewPassword';
```

上面这个是修改root密码。

下面这个是修改root远程权限，使得远程的root可以访问。

```tex
mysql -uroot -p;
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED BY 'yourpassword' with grant option;
FLUSH PRIVILEGES;
```

一般经过上面的处理就可以登陆到本机localhost或docker中的mysql了。

![connet_mysql_success_2726.png](/images/posts/connet_mysql_success_2726.png)

**注意**：如果是Docker，启动容器的时候一定要指定好端口，-p 3306:3306   前面的端口号为宿主机win10的端口，后面的为ubuntu镜像中mysql的端口。



#### 彻底删除mysql

参考：[https://linuxscriptshub.com/uninstall-completely-remove-mysql-ubuntu-16-04/](https://linuxscriptshub.com/uninstall-completely-remove-mysql-ubuntu-16-04/)



#### ubuntu18.0LTS 开启root

sudo passwd root

sudo vi /etc/ssh/sshd_config

把配置文件中permission root yes 打开

然后允许通过密码登录：

![image-20211109105042869](/images/posts/image-20211109105042869.png)

![image-20211109105058145](/images/posts/image-20211109105058145.png)





sudo service ssh restart

