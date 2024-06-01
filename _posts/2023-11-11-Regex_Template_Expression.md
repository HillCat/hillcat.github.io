---
layout: post
title: 正则表达式常见用法
categories: DotNetCore
description: 正则表达式
keywords: 正则表达式
typora-root-url: ../

---

正则表达式常见的使用范式，调试正则表达式的工具有很多，https://regex101.com/ ，或者是Linqpad的这个正则调试工具 ctrl shif F1打开，还有RegexBuddy.......等等。如果是.net csharp调试正则，推荐还是[linqpad](https://www.linqpad.net/).

#### 场景1：找出coca20000文档中词语常见搭配的block块

在这个基础上，利用特殊符号分割这些字符串，小圆点和大圆点的Unicode分割问题，这里也会是一个坑。

比如，coca20000的pdf文件中，有常见的20000单词搭配用法，需要找出如下所示的文本区域，需要用到精准匹配多行，根据如下文本的特征，抽取一部分出来做正则匹配调试。

![image-20231111141911500](/images/posts/image-20231111141911500.png)

正确的表达式如下：这里的`|`符号需要特殊转义，换行这里使用`[\s\S]*?`，其他的字符串的数量使用{1,5}动态调节即可。

失败案例1：

````shell
\d \w{1,5} \w[\s\S]*?\d{1,9} \| \d+\.\d+
````

失败案例2：

```shell
\d{1,6} [\w\W]{1,12} \w\n[\s\S]*?\d{1,9} \| \d{1}\.\d{2}
```

**成功案例**：

```shell
^\d{1,12}[\s\S]*?\| 0.\d{1,2}
```

匹配的过程需要不断调试，最终得到兼容性和准确率最高的正则。在处理多行匹配截止符的时候，需要注意正则的贪婪匹配和非贪婪匹配问题，多行匹配中一定要使用`?`号，采用非贪婪匹配的模式。

#### 关于贪婪匹配和非贪婪匹配

比如：`[\s\S]*?^\d{1,10} `，它是可以让多行匹配可以截止的，而不是无限的匹配下去。而如果是改为`[\s\S]*^\d{1,10}` ，他们的区别仅仅是多一个和少一个`?`的区别,后者是少了`?`,导致多行匹配无法截止，而是无限匹配下去，原因如下：

在正则表达式中，`"*" `和 `"?" `分别表示贪婪匹配和非贪婪匹配。

- 贪婪匹配：使用 `"*" `表示贪婪匹配，它会尽可能多地匹配字符。例如，正则表达式 `"[\s\S]*" `会匹配尽可能多的字符，直到无法再匹配为止。
- 非贪婪匹配：使用 `"*?"` 表示非贪婪匹配，它会尽可能少地匹配字符。例如，正则表达式` "[\s\S]*?" `会匹配尽可能少的字符，以满足后续的匹配条件。

在上面的例子中，正则表达式` "[\s\S]*?" `匹配尽可能少的字符，直到下一个条件` "^\d{1,10}" `可以匹配为止，从而截止多行匹配。这是因为非贪婪匹配会尽量减少匹配字符的数量，以满足后续匹配条件。

而在正则表达式` "[\s\S]*^\d{1,10}" `中，`"^\d{1,10}" `是从行的开头开始匹配一个数字，但由于前面的 "*" 是贪婪匹配，它会尽可能多地匹配字符，包括行的开头，所以多行匹配无法截止，会一直匹配下去。

经验总结：正则本质上是对具有某些特征的文本进行“特征描述”，在编写正则的时候不需过多的对文本中间部分的字符进行“描述”。优先采用3步骤：1.先确定头部和尾部的特征，2.然后利用非贪婪匹配解决中间部分多行文本截止的问题，3.最后是找准结尾部分的特征。对于大文本中的匹配大致如上规则。如果是一些特定的文本类型匹配，这里也可以进行一些总结举例，后续有待补充。

与正则3对应的csharp代码如下：大文本筛选一般这里要设置RegexOptions.Multiline。

````cshap
Regex.Matches (input, @"^\d{1,12}[\s\S]*?\| 0.\d{1,2}", RegexOptions.Multiline)
````

##### 关于中括号

中括号 `"[]" `在正则表达式中表示一个字符集合，用来匹配方括号中包含的任何一个字符。例如，正则表达式` "[abc]" `匹配字符 "a"、"b" 或 "c" 中的任何一个。"[\s\S]" 实际上会匹配任何字符，包括空白字符和非空白字符。这通常用于匹配整个文本，因为它包括了所有可能的字符，不会漏掉任何字符。这种技巧主要是在正则表达式中用来匹配多行文本，因为默认情况下，正则表达式通常只匹配一行文本。通过使用 "[\s\S]"，可以匹配包括换行符在内的整个文本内容。但是这个多行匹配一定要结合`?`非贪婪匹配进行。

#### 坑1：regex101网站不兼容

在https://regex101.com/ 网页版本的调试器不兼容csharp，或者说这个网站本身存在bug。

```shell
^\d[\s\S]*?^\d{1,10} \| \d{1}.\d{2}
```

调试正则的时候尽量使用兼容开发语言的成熟的工具。

![image-20231111172614796](/images/posts/image-20231111172614796.png)

#### 坑2：RegexBuddy不兼容

RegexBuddy调试正则也存在兼容的问题。

![image-20231111141425071](/images/posts/image-20231111141425071.png)

#### 避坑2：多行匹配截止问题

遇到多行匹配，从调试经验来看，比较好用的还是[\s\S]*?配合使用，因为它支持截止符号，比如这里用`\|`进行多行匹配的截止符，实际匹配的多行会以第一个遇到的|截止。因为问号，当遇到特殊的符号的时候会停止。

![image-20231111181330887](/images/posts/image-20231111181330887.png)

如果使用csharp进行正则匹配，尽量使用linqpad作为调试工具，对于.net的regex正则兼容是最好的，另外，linqpad自带的正则调试，一定要勾选多次匹配，正则匹配到多个结果的时候会实时显示在Linqpad结果下面。

![image-20231111180955221](/images/posts/image-20231111180955221.png)



csharp中循环遍历匹配项：

```csharp

//正则表达式匹配
foreach (var item in finalUrl)
{
    var newStr = item.FullPathUrl;
    var bb = Regex.Matches(newStr, @"\d \w{1,5} \w[\s\S]*?\d{1,9} \| \d+\.\d+", RegexOptions.None);
    var dd = bb[0];
    if (dd.Groups.Count > 1)
    {
        item.FullPathUrl = dd.Groups[1].ToString();
    }

}
foreach (var item in bridgeLogoKeyList)
{
    item.real_url = finalUrl.Where(d => d.Url == item.logo_url).Select(d => d.FullPathUrl)
        .FirstOrDefault();
}
```

要进行抽取一些模板变量，使用(.*?)把需要抽取的子匹配项用这个双括号匹配。

```csharp
private static MatchCollection GetMatches(string text)
{
    if (string.IsNullOrEmpty(text)) text = "";
    Regex regex = new Regex("[#|\\$]([a-zA-Z0-9_.]+?)[#|\\$]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    return regex.Matches(text);
}
```

#### 避坑3：Unicode特殊编码匹配问题

在正则匹配的时候，字符串里面会出现一些特殊的符号，使用一般的匹配模式是没办法做到的，需要匹配他们的unicode码才可以，要查找一个特殊的字符串的unicode码，可以直接从维基百科或者其他的专门查询unicode码的页面，先复制粘贴自己的符号，然后直接在目标页面整个Ctrl + F 搜索即可。

比如 大号的实心圆点：这个文本里面有小实心圆点，也有大的实心圆点，如果要以大实心圆点进行分割文本，直接用●  Split，或者string.Contains操作是不行的。

````shell
adj good, late, dark, previous, sleepless, starry, rainy,
Arabian, drunk, lonely noun day, room•, middle•,
•sky, hour, bed, •week, dinner, sleep, air verb spend•,
stay•, wake, pray, awake, wander, sneak
● hours of darkness, dark, darkness, nighttime ||
early hours, small hours, middle of the night,
evening
````

正确的操作方法如下：

```csharp
    using var uowcocaPdf =
        _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true, timeout: 15000);

var cocaPdfEntity = await cocaPdfDbSet.Where(d => (d.isFinished == false) && d.pdfResult.Contains("\u25CF"))
        .FirstOrDefaultAsync();
    if (cocaPdfEntity != null)
    {
        //实心圆点之后的近义词舍弃
        if (cocaPdfEntity.pdfResult != null && cocaPdfEntity.pdfResult.Contains("\u25CF"))
        {
            string[] parts = cocaPdfEntity.pdfResult.Split("\u25CF");
            if (parts.Length > 1)
            {
                cocaPdfEntity.pdfResult = parts[0];
                cocaPdfEntity.isFinished = true;
              await  _cocaPdfRepository.UpdateAsync(cocaPdfEntity);
            }
        }
    }
    else
    {
        loop=false;
        continue;
    }
    await uowcocaPdf.CompleteAsync();
```

直接的做法是直接去unicode页面复制粘贴这个符号去搜索对应的Unicode码，因为是U字幕开头，所以最终赋值到csharp代码的时候都会带上`\u`字样，后面跟随unicode对应的字母编码。

![image-20231112000555311](/images/posts/image-20231112000555311.png)
