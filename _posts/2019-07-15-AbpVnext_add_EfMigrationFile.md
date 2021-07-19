---
layout: post
title: AbpVnext添加迁移文件
categories: AbpVnext
description: 
keywords: AbpVnext
---

EasyAbp的使用比较简单，打开已经存在的AbpVnext项目，加载即可，添加需要的模块或者实体，
<img src="https://cs-cn.top//images/posts/easy_abp_73615.png"/>

添加新的Entity之后，生成迁移文件，并且更新数据库。

`Add-Migration “Update_TablePrefix” `  

<img src="https://cs-cn.top//images/posts/efcore_migrationFile9073436.png"/>

生成出来一个迁移文件：

20210718233032_Update_TablePrefix.cs

`Update-Database` 完成对数据表的操作

更多Efcore相关操作，具体查看官方文档：[文档链接地址](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs)

#### Efcore回滚指定的Migrating

Update-Database -TargetMigration CreateBlog      #后面这里的CreateBlog是Migration指定的别名



