---

layout: post
title: 开发环境Mysql安装和使用
categories: DotNetCore
description: DotNetCore
keywords: .net
typora-root-url: ../
---
Mysql安装之后远程客户端是无法通过root连接道数据库的，需要给与root账号远程登录授权。

### SQL导出表结构字段注释为excle

```c#
SELECT
COLUMN_NAME 字段名称,
COLUMN_TYPE 数据类型,
-- IF(IS_NULLABLE='NO','是','否') AS '必填',
COLUMN_COMMENT 注释
FROM
INFORMATION_SCHEMA.COLUMNS
where
-- Finance为数据库名称，到时候只需要修改成你要导出表结构的数据库即可
table_schema ='gdbs_shenzhen'
AND
-- user为表名，到时候换成你要导出的表的名称
-- 如果不写的话，默认会查询出所有表中的数据，这样可能就分不清到底哪些字段是哪张表中的了
table_name = 'bge_substructure_info'
```



### 导出表结构为Excle

使用下面的sql语句在navicat执行，然后使用navicat导出来，

````c#
SELECT
COLUMN_NAME 字段名称,
COLUMN_TYPE 数据类型,
IF(IS_NULLABLE='NO','是','否') AS '必填',
COLUMN_COMMENT 注释
FROM
INFORMATION_SCHEMA.COLUMNS
where
-- Finance为数据库名称，到时候只需要修改成你要导出表结构的数据库即可
table_schema ='gdbs_dev'
AND
-- user为表名，到时候换成你要导出的表的名称
-- 如果不写的话，默认会查询出所有表中的数据，这样可能就分不清到底哪些字段是哪张表中的了
table_name = 'bge_pier_info'
````

![image-20220426162559850](/images/posts/image-20220426162559850.png)

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

下面这个是修改root远程权限，使得远程的root可以访问。**特别注意**：'yourpassword' 改为自己密码**!！！！**

```tex
mysql -uroot -p;
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED BY 'yourpassword' with grant option;
FLUSH PRIVILEGES;
```

一般经过上面的处理，重启mysql进程服务，就可以登陆到本机localhost或docker中的mysql了。

![connet_mysql_success_2726.png](/images/posts/connet_mysql_success_2726.png)

**注意**：如果是Docker，启动容器的时候一定要指定好端口，-p 3306:3306   前面的端口号为宿主机win10的端口，后面的为ubuntu镜像中mysql的端口。

### Mysql8授权访问

https://www.cnblogs.com/withLevi/p/16005877.html

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

#### Ubunt18.04安装Mysql5.7

```c#
wget -c https://dev.mysql.com/get/mysql-apt-config_0.8.15-1_all.deb
sudo dpkg -i mysql-apt-config_0.8.15-1_all.deb
    
```

![image-20211109105815250](/images/posts/image-20211109105815250.png)

在第一项里面选择，mysql5.7安装。

更新源：

```c#
sudo apt-get update
```

执行安装程序：

```c#
sudo apt-get install mysql-server
```

设置mysql 远程访问:

```c#
sudo vim /etc/mysql/mysql.conf.d/mysqld.cnf
```

![image-20211109111756996](/images/posts/image-20211109111756996.png)

注释掉bind-address.

#### Ubuntu安装DotNetCore

参考：https://tecadmin.net/how-to-install-dotnet-core-on-ubuntu-18-04/



### Centos7.6安装宝塔面板

如果是在Linux环境下调试对接前端代码，最好的方式是使用轻量云主机来对接前端开发。

宝塔面板使用守护进程的方式启动控制台应用。



### HeiDiSql工具

开发过程中使用比较频繁的就是测试数据库和本地数据库进行同步，HeiDiSql这个工具有个比较好的功能，就是OutPut导出的时候，可以选择数据库对拷，或者同步某个数据库的某张表，支持非常多的形式，下面图例只是我日常使用比较常见的一种场景——把云端服务器的数据库导入到本地进行同步。这里面排除了一些体积比较大的日志数据表，一般只对业务数据相关的表进行同步操作。这种图形化的界面操作起来非常方便省事，特别是本地开发要建立数据库的时候。

![image-20220305105854579](/images/posts/image-20220305105854579.png)
