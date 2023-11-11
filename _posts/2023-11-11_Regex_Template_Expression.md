---
layout: post
title: 正则表达式常用范式
categories: DotNetCore
description: 正则表达式使用
keywords: 正则表达式
typora-root-url: ../

---

正则表达式常见的使用范式，调试正则表达式的工具有很多，https://regex101.com/ ，或者是Linqpad的这个正则调试工具 ctrl shif F1打开，还有RegexBuddy.......等等。如果是.net csharp调试正则，推荐还是linqpad.

#### 场景1：找出coca60000文档中词语常见搭配的block块

比如，coca20000的pdf文件中，有常见的20000单词搭配用法，需要找出如下所示的文本区域，需要用到精准匹配多行，根据如下文本的特征，抽取一部分出来做正则匹配调试。

![image-20231111141911500](/images/posts/image-20231111141911500.png)

正确的表达式如下：这里的|符号需要特殊转义，换行这里使用[\s\S]*?，其他的字符串的数量使用{1,5}动态调节即可。

````shell
\d \w{1,5} \w[\s\S]*?\d{1,9} \| \d+\.\d+
````

正则2

```shell
\d{1,6} [\w\W]{1,12} \w\n[\s\S]*?\d{1,9} \| \d{1}\.\d{2}
```

正则3

```shell
^\d{1,12}[\s\S]*?\| 0.\d{1,2}
```

兼容上面场景的，和csharp匹配最好的正则是上面这个“正则3”. 不需要过多的对中间部分的字符进行描述，采用3段法，掐头去尾，干掉中间的多行，基本就可以了。头部：^\d{1,12} 以数字开头，并且1~12个数字，中间：[\s\S]*? 匹配多行，1~多个任意字符，包括换行；结尾：`\| 0.\d{1,2}`  以逻辑“或”符号加上空格再加上数字0.再加上1~2个数字结尾。这个就比较完整描述了每个区块的特征，过度解读和描述，会导致匹配的兼容性产生问题。

与之对应的csharp代码如下：

````cshap
Regex.Matches (input, @"^\d{1,12}[\s\S]*?\| 0.\d{1,2}", RegexOptions.Multiline)
````



#### 坑1：

在https://regex101.com/ 调试的正则会有匹配结果，但是实际放到csharp中执行，或者Linqpad中执行是不行的，不会匹配到任何的字符串。

以数字开头+n个字符串(带有换行)+以1~10数字开头+空格+|+1个数字+.+2个数字

```shell
^\d[\s\S]*?^\d{1,10} \| \d{1}.\d{2}
```

总结：网页版本的正则调试，最终在网页是OK，但是放到csharp是无法使用的。针对开发的语言和平台，最好是使用兼容你那个语言最近的调试工具。

![image-20231111172614796](/images/posts/image-20231111172614796.png)

#### 坑2：

有些正则表达式即便是在RegexBuddy中调试是OK，但是放到Linqpad中和csharp代码中，也是不行的。如果是按照JavaScript的语法，这种语法都是正确的，可以匹配到正确结果。建议如果是.net调试正则，推荐使用linqpad。linqpad4.0版本是绿色版本。

![image-20231111141425071](/images/posts/image-20231111141425071.png)

#### 避坑1：

字符串匹配的时候严格限定起始字符串的类型，使用^限定起始位置的字符类型，在不换行的情况下，如果从当前位置匹配到当前行末尾，使用[\s\S].+，这个是匹配任意字符串直到本行的结尾，.号是匹配1个字符，+是多个字符(1到多个)

````shell
^\d{1,12} [\s\S].+
````

遇到有换行的多行任意字符，使用[\s\S]*？，这里的星号是（0到多个字符），问好是1个到多个匹配，这个能匹配换行符的原因是\s匹配了空白字符。用中括号是为了匹配任意个数的字符。



#### 避坑2：

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

#### 避坑3：

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
