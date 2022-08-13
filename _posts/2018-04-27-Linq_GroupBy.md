---
layout: post
title: Linq笔记_GourpBy
categories: DotNetCore
description: Linq笔记整理
keywords: Linq笔记
typora-root-url: ../
---
工作内容的临时备忘，Linq代码片段。



### 分组查询取每组中最小的值或最大值

参考：[https://stackoverflow.com/questions/1704821/linq-to-sql-groupby-and-max-to-get-the-object-with-latest-date](https://stackoverflow.com/questions/1704821/linq-to-sql-groupby-and-max-to-get-the-object-with-latest-date)

````c#
var bridgeCongnizaceAssessSource =await _bridgeCognizanceAssessRepository
                .Where(x => x.IsDeleted == 0 && x.TableName == BridgeServiceConstValue.Table_thematic_evaluation)
                .GroupBy(d => d.ComeFromId).Select(grp=>new DangerousBridgeCognizanceAssessEntity(){ComeFromId = grp.Key, DangerousBridgeLv = grp.Min(x=>x.DangerousBridgeLv)}).ToListAsync();

            
````

````c#
  var bridgeMainLineIdList = bgeLineInfoRepository.GroupBy(d => d.Bge_Id).Select(grp => grp.Min(x => x.Id))
                .ToListAsync();
````

分组取最小值。



![image-20211229005439581](/images/posts/image-20211229005439581.png)

![image-20211229005819943](/images/posts/image-20211229005819943.png)

[参考](https://docs.microsoft.com/en-us/dotnet/csharp/linq/group-query-results)

![image-20211229011525603](/images/posts/image-20211229011525603.png)

![image-20211229012041294](/images/posts/image-20211229012041294.png)



### 参考资料

[https://www.pluralsight.com/guides/grouping-aggregating-data-linq](https://www.pluralsight.com/guides/grouping-aggregating-data-linq)

### linq比较两个list是否相等

![image-20220518180210367](/images/posts/image-20220518180210367.png)![image-20220518185403773](/images/posts/image-20220518185403773.png)

参考：[https://www.techiedelight.com/compare-two-lists-for-equality-csharp/](https://www.techiedelight.com/compare-two-lists-for-equality-csharp/)
