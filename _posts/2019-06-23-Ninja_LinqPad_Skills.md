---
layout: post
title: Ninja_LinqPad_Skills
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

LinqPad调试ABP Unit Of Work中的Repository。对于调试Linq语句，跟踪SQL，避免产生BUG具有重要意义。而且LinqPad这个工具非常强大方便，更多的内容会继续整理到本帖中。

### 背景

在使用ABP做项目的时候，由于ABP内部CURD大量采用[UOW模式(UnitOfWork)](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)，仓储的互操作使用Linq虽然加快了开发速度，Linq更加抽象，复杂的Linq使得我们很难看到底层SQL细节，导致产生BUG。这个时候如果采用LinqPad来调试，会提高我们的开发和调试效率。Linq可转为SQL和lambda，提升我们对于Linq细节的把控，写出高效且正确的代码。

![vynmFXyxBg](/images/posts/vynmFXyxBg.png)

### 解决方案

#### LinqPad +Abp

ABP项目中引入LinqPad结合ABP_Vnext的仓储对象Repository可以明显提升Linq的调试和开发效率。使用LinqPad调试ABP仓储，需要引入项目所在Entity dll文件。商业版LinqPad对Linq语法会有智能提示功能，并且支持引入EFcore DbContext上下文对象直接在LinqPad中调试代码。Linq生成lambda和原生sql，以便分析我们写的linq是否正确。甚至

#### 引入EFCore中的DbContext

![3XpyODva97](/images/posts/3XpyODva97.png)



![89WoZCudPX](/images/posts/89WoZCudPX.png)

引入*Service.EntityFrameworkCore.dll这个dll的时候,LinqPad会自动识别项目上下文DbContext，并且读取到项目中配置好的数据库ConnectString。

![PsntgnmBkH](/images/posts/PsntgnmBkH.png)

点击Test，就会发现这个assemblies被引入了就可以使用了。引入了项目中的EntityFrameWorkCore项目之后，LinqPad会自动检测dll中的DbContext对象，并且自动检测数据库配置连接是否有效。引入之后，就可以在Linq的调试过程中直接引入项目dll中的DbContext上下文对象了，可以进行一些高级调试。

#### 调试Mysql

默认情况下LinqPad是没有附带Mysql驱动的，需要自己安装相关驱动，Linq代码最终生成的SQL，会是Mysql语法的，方便我们写出正确的Linq代码，避免BUG。

![jznHivgrio](/images/posts/jznHivgrio.png)

点击Add connection，Choose Data Context界面，View more drivers...   如下，选择LINQ to DB driver for LINQPad 6，安装即可支持各种数据库。

![segbnozRrG](/images/posts/segbnozRrG.png)

### LinqPad官方示例

以下是linq官方的一些演示代码：参考地址：[Why LINQ beats SQL](https://www.linqpad.net/WhyLINQBeatsSQL.aspx)

```tex
from p in db.Purchases
where p.Customer.Address.State == "WA" || p.Customer == null
where p.PurchaseItems.Sum (pi => pi.SaleAmount) > 1000
select p
```

```te
from p in db.Purchases
where p.Customer.Address.State == "WA" || p.Customer == null
let purchaseValue = p.PurchaseItems.Sum (pi => pi.SaleAmount)
where purchaseValue > 1000
orderby purchaseValue descending
select new
{
   p.Description,
   p.Customer.SalesPerson.Name,
   PurchaseItemCount = p.PurchaseItems.Count()
}
```

### LinqPad做正则表达式调试

参考文章:[https://www.danclarke.com/linqpad-tips-and-tricks-part3](https://www.danclarke.com/linqpad-tips-and-tricks-part3)

上面这篇文章来至于国外微软mvp文章，LinqPad7有一个隐藏功能就是调试正则表达式。

**ctrl + shift +F1**  就可以调出正则表达式调试工具。

![image-20220124125520937](/images/posts/image-20220124125520937.png)

