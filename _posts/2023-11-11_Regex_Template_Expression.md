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



#### 坑1：

在https://regex101.com/ 调试的正则会有匹配结果，但是实际放到csharp中执行，或者Linqpad中执行是不行的，不会匹配到任何的字符串。

以数字开头+n个字符串(带有换行)+以1~10数字开头+空格+|+1个数字+.+2个数字

```shell
^\d[\s\S]*?^\d{1,10} \| \d{1}.\d{2}
```

总结：匹配多行的任意字符[\s\S]*? ， 对于有特殊字符开头的一定要带上^ ，如果是以特殊字符结尾的一定带上$，这样子可以提升正则的匹配兼容性和精度，如果是单个space空格这种，直接用空格占位即可。

![image-20231111172614796](/images/posts/image-20231111172614796.png)

#### 坑2：

有些正则表达式即便是在RegexBuddy中调试是OK，但是放到Linqpad中和csharp代码中，也是不行的。如果是按照JavaScript的语法，这种语法都是正确的，可以匹配到正确结果。

![image-20231111141425071](/images/posts/image-20231111141425071.png)

#### 避坑1：

字符串匹配的时候严格限定起始字符串的类型，使用^限定起始位置的字符类型，在不换行的情况下，如果从当前位置匹配到当前行末尾，使用[\s\S].+，这个是匹配任意字符串直到本行的结尾，.号是匹配1个字符，+是多个字符(1到多个)

````shell
^\d{1,12} [\s\S].+
````

遇到有换行的多行任意字符，使用[\s\S]*？，这里的星号是（0到多个字符），问好是1个到多个匹配，这个能匹配换行符的原因是\s匹配了空白字符。用中括号是为了匹配任意个数的字符。



#### 避免2：

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

