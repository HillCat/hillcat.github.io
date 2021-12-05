---
layout: post
title: VisualStudio设置codeSnippets
categories: DotNetCore
description: VisualStudio常用技巧
keywords: trpora
typora-root-url: ../
---

此文不定期整理VisualStudio使用的一些技巧。包括快捷键，还有插件的使用，一些重构代码的一些快捷方法。新版本的visual sutido特性的更新等。有些常用的快捷方式，熟悉之后对提高生产力很有帮助。

### 创建code snippets

创建code snippet可以加速我们代码的开发速度，避免每次都要重复敲击一些代码。

参考官方文档：[https://docs.microsoft.com/en-us/visualstudio/ide/code-snippets?view=vs-2022](https://docs.microsoft.com/en-us/visualstudio/ide/code-snippets?view=vs-2022)

创建code snippet快捷键是：**Ctrl**+**K**, **Ctrl**+**B** ；插入code snippet快捷键:**Ctrl**+**K**, **Ctrl**+**X** 

````c#
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
  <CodeSnippet Format="1.0.0">
    <Header>
      <Title>File Exists</Title>
      <Shortcut>exists</Shortcut>
    </Header>
    <Snippet>
      <Code Language="CSharp">
        <![CDATA[var exists = File.Exists("C:\\Temp\\Notes.txt");]]>
      </Code>
      <Imports>
        <Import>
          <Namespace>System.IO</Namespace>
        </Import>
      </Imports>
    </Snippet>
  </CodeSnippet>
</CodeSnippets>
````

制作一个xml文本，像如下格式，填写上Title，Shorcut，Snippet正文部分，并且指明是Csharp代码，那么这个code snippet文件就制作完成了。导入到visual studio 2019里面即可。上面这个代码顺带还会导入命名空间，如果不需要导入命名空间，则Imports这部分xml可以去掉。

```c#
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
  <CodeSnippet Format="1.0.0">
    <Header>
      <Title>File Exists</Title>
      <Shortcut>exists</Shortcut>
    </Header>
    <Snippet>
      <Code Language="CSharp">
        <![CDATA[var exists = File.Exists("C:\\Temp\\Notes.txt");]]>
      </Code>
    </Snippet>
  </CodeSnippet>
</CodeSnippets>
```

如下这个例子是把`Console.ReadLine()；`这个代码制作成快捷方式，快捷键是cr，敲击两下tab键即可快捷输入代码。

![image-20211205185359317](/images/posts/image-20211205185359317.png)

制作完成的文件，导入即可，

![image-20211205185633506](/images/posts/image-20211205185633506.png)

放到一个你想存放的文件夹里面即可。![image-20211205195626239](/images/posts/image-20211205195626239.png)

![image-20211205195712517](/images/posts/image-20211205195712517.png)

