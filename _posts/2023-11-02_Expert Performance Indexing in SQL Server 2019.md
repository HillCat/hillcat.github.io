---
layout: post
title: Expert Performance Indexing in SQL Server 2019: Toward Faster Results and  Lower Maintenance
categories: DotNetCore
description: sqlserver2019索引
keywords: sqlserver
typora-root-url: ../

---

数据库索引优化：《Expert Performance Indexing in SQL Server 2019: Toward Faster Results and  Lower Maintenance》

英文原版在Zlibrary有下载，摘抄一些笔记整理如下：

![image-20231102234513604](/images/posts/image-20231102234513604.png)

这是一本专门讲解sqlserver  2019数据库索引的书籍，包括600多页，都是讲解索引相关的内容；可以帮助理解各种索引的工作原理和常见优化方法；适用于微软sqlserver 各种版本，虽然这本书是基于比较新的版本讲解的，但是里面的一些章节比较通用。

下面是一些目录：

![image-20231102235232287](/images/posts/image-20231102235232287.png)

![image-20231102235322349](/images/posts/image-20231102235322349.png)

这本书还在阅读中，遇到一些重要的地方会记录在此......

多列索引命中的问题：

![image-20231103000620348](/images/posts/image-20231103000620348.png)

多列索引还有另外一个优点，它通过称为最左前缀（Leftmost Prefixing）的概念体现出来。继续考虑前面的例子，现在我们有一个firstname、lastname、age列上的多列索引，我们称这个索引为fname_lname_age。当搜索条件是以下各种列的组合时，数据库将使用fname_lname_age索引：
firstname，lastname，age
firstname，lastname
firstname
从另一方面理解，它相当于我们创建了(firstname，lastname，age)、(firstname，lastname)以及(firstname)这些列组合上的索引。下面这些查询都能够使用这个fname_lname_age索引：

```
SELECT peopleid FROM people WHERE firstname='Mike' AND lastname='Sullivan' AND age='17'; 
SELECT peopleid FROM people WHERE firstname='Mike' AND lastname='Sullivan'; 
SELECT peopleid FROM people WHERE firstname='Mike'; 
```

下面这些查询不能够使用这个fname_lname_age索引：

```
SELECT peopleid FROM people Where lastname='Sullivan'; 
SELECT peopleid FROM people Where age='17'; 
SELECT peopleid FROM people Where lastname='Sullivan' AND age='17';
```

 





