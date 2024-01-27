---
layout: post
title: VisualStudio设置Mono字体和CodeSnippet，ListDoing
categories: DotNetCore
description: VisualStudio常用技巧
keywords: trpora
typora-root-url: ../
---

此文不定期整理VisualStudio使用的一些技巧。包括快捷键，还有插件的使用，一些重构代码的一些快捷方法。新版本的visual sutido特性的更新等。有些常用的快捷方式，熟悉之后对提高生产力很有帮助。

### 1.创建code snippets

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

### 2.Task List

除了使用code snippet可以加快开发速度和便捷度，常用的代码段和经典的demo也可以做成code snippet。另外还可以结合Task List 进一步管理代码开发进度，使得自己正在进行中的代码任务可以清晰可见，

参考：[https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list?view=vs-2022](https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list?view=vs-2022)

在visual studio 2019中 view菜单中打开task list，可以查看到我们平时标记的TODO列表，而这个地方还可以自定义BUG等自己的标记，打开Task List的时候就可以看到一些代码的位置，提升我们对于待办项的管理能力，防止漏掉TODO或者BUG。

![image-20211125183343042](/images/posts/image-20211125183343042.png)

![image-20211125183432426](/images/posts/image-20211125183432426.png)

![image-20220116131500195](/images/posts/image-20220116131500195.png)

其实Todo是对于将要做的任务进行标记，如果团队中其他人也喜欢使用Todo的话，会干扰到你自己的工作，Task List中会列出来一堆Todo，都不知道现在正在做的代码是哪些，其实可以自定义一个doing标记，并且Priority为High，高优先级用感叹号表示，并且标记为doing.那么在开发的时候，就可以把自己正在开发的代码标记为doing，后面一定要加空格，那么在开发的时候就一目了然，不需要到处去找代码。CodeSnippet 结合 TaskList可以避免到处翻页查找代码的尴尬，可以避免visual studio少开几个页面，减少电脑内存占用，提升vs响应速度。

### 3.设置Monokai字体

首先可以通过chocolatey安装Monokai字体

````shell
choco install jetbrainsmono
````

安装完成之后，visual studio 2022找到tools，font位置直接设置即可。整个代码编辑器内部的字体就都变为Mono字体了

![image-20240127135459223](/images/posts/image-20240127135459223.png)
