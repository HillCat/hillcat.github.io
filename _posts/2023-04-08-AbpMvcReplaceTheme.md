---
layout: post
title: AbpVnextMvc默认Theme替换
categories: DotNetCore
description: AbpVnext笔记
keywords: AbpVnext
typora-root-url: ../
---
ABP最新版本来到了.net core 7.0.默认的mvc版本的皮肤是官方皮肤。可以替换为我们自己熟悉的theme.

利用abp控制台面板初始化一个demo,然后安装basicTheme模块。

```shell
abp add-module Volo.BasicTheme --with-source-code --add-to-solution-file
```

如果是需要自定义theme的话，安装最小版本的abp vnext即可：

```shell
abp new English.Tools -t app-nolayers -dbms SQLite --theme basic -csf 
```

进入项目根目录，cmd打开命令行，执行如下：

```shell
dotnet run --migrate-database
```

