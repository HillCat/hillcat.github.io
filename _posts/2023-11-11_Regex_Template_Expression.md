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



正则3：以数字开头+n个字符串(带有换行)+以1~10数字开头+空格+|+1个数字+.+2个数字

```shell
^\d[\s\S]*?^\d{1,10} \| \d{1}.\d{2}
```

总结：匹配多行的任意字符[\s\S]*? ， 对于有特殊字符开头的一定要带上^ ，如果是以特殊字符结尾的一定带上$，这样子可以提升正则的匹配兼容性和精度，如果是单个space空格这种，直接用空格占位即可。

![image-20231111172614796](/images/posts/image-20231111172614796.png)



![image-20231111141425071](/images/posts/image-20231111141425071.png)

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

