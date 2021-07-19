---
layout: post
title: AbpVnext添加迁移文件
categories: AbpVnext
description: 
keywords: AbpVnext
---

EasyAbp的使用，打开已经存在的AbpVnext项目，加载即可，添加需要的模块或者实体，

添加新的Entity之后，生成迁移文件，并且更新数据库。

`Add-Migration “Update_TablePrefix” `  

生成出来一个迁移文件：

20210718233032_Update_TablePrefix.cs

`Update-Database` 完成对数据表的操作

更多Efcore相关操作，具体查看官方文档：[文档链接地址](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs)

#### Migration冲突的解决办法

Update-Database -TargetMigration CreateBlog      #后面这里的CreateBlog是Migration指定的别名

1. 首先是通过上面的指令，把数据库回滚到冲突之前的位置
2. 然后是修改对方冲突的那条Migration指令的ID并且重命名
3. 补齐被冲突覆盖掉的，或者丢失掉的那部分Migation
4. 如果是模型新增了属性，则需要强制更新 -Force 参数强制重新检测模型改变

_MigrationHistory表中冲突的部分，就需要进行修改，具体的做法是把MigrationId时间戳的数字改动一下(最后一位数字)，迁移类里面的这个时间戳数字ID也别忘记修改了。修改完成之后，被重复覆盖掉的部分，需要通过追加一条最新的Migration记录来补上去。

#### Efcore迁移发生冲突解决办法

一般都是把Migration类重命名和更新时间戳

