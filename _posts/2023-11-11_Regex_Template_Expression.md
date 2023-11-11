---
layout: post
title: 正则表达式常见使用范式
categories: DotNetCore
description: 正则表达常见模板
keywords: 正则表达式
typora-root-url: ../

---

正则表达式常见的使用范式，调试正则表达式的工具有很多，https://regex101.com/ ，或者是Linqpad的这个正则调试工具 ctrl shif F1打开，但是最专业的还是RegexBuddy这个工具。前2个工具会有一些bug，跟你自己预估的匹配结果会有出入。

#### 场景1：找出coca60000文档中词语常见搭配的block块

比如，coca20000的pdf文件中，有常见的20000单词搭配用法，需要找出如下所示的文本区域，需要用到精准匹配多行，根据如下文本的特征，

![image-20231111141446050](/images/posts/image-20231111141446050.png)

正确的表达式如下：这里的|符号需要特殊转义，换行这里使用[\s\S]*?，其他的字符串的数量使用{1,5}动态调节即可。

````shell
\d \w{1,5} \w[\s\S]*?\d{1,9} \| \d+\.\d+
````



![image-20231111141425071](/images/posts/image-20231111141425071.png)
