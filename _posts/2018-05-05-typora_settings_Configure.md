---
layout: post
title: typora常用快捷键
categories: Blog
description: typora常用快捷键和技巧。
keywords: trpora
typora-root-url: ../
---

typora编辑器的一些常用快捷键：

### 1.**标题H1~H6**

   标题这块主要是通过快捷键ctrl + 数字键快速实现标题分割。

### 2.**加粗，倾斜，下划线**

   Ctrl+B/I/U进入加粗/倾斜/下划线模式。

### 3.**插入代码**

   在Typora中插入程

   

   序代码的方式有两种：使用反引号 `（~ 键）。行内代码使用~键，如果是多行代码使用3个~符号，敲入对应的编程语言符号就是表示当前要贴入的代码。比如：

   这个是行内代码`hello word`,使用的就是反引号`去包裹。

   多行代码，并且选定开发语言为C#,比如:

   ```c#
   public class Book 
       {
           public Guid AuthorId { get; set; }
   
           public string Name { get; set; }
   
           public BookType Type { get; set; }
   
           public DateTime PublishDate { get; set; }
   
           public float Price { get; set; }
       }
   ```


### 4.***插入超文本***

   - 插入带有文字的超链接，使用快捷键ctrl + k，出现方括号和圆括号 `[]()`

       [百度](https://www.baidu.com) 方括号中填写文本，圆括号中填写带有http或者https打头的url形式，其他形式的插入超文本，因为在gfm的markdown支持不是很好，所以这里没有列出来。

### 5.***插入图片***

   这里使用的是picgo这个工具让github作为图床使用。具体的设置方法，网络上面有这里不再赘述。总之就是先把图片通过图床的形式上传到github,带有自己域名指向的img地址，直接以\<img>标签的形式粘贴到博客正文。比如：下面这个就是一张采用github作为托管的图床图片：

   <br/>

### 6.插入删除线



使用两个波浪线 包围文字就是删除线效果：

~~我是被删除的文本~~

   

###    7.偏好设置

1.设置为自动保存，以免编写的博客来不及保存出现丢失

![auto_save_23423.png](/images/posts/auto_save_23423.png)

   

   2.复制图片到指定目录，并且使用相对路径，如下图所示设置。

![image_settings_2352.png](/images/posts/image_settings_2352.png)

为了让本地图片实时显示出来，可以脱机编写博客，这里yaml格式要添加一行配置:

`typora-root-url: ../`

指明图片的相对路径位置。



![relative_path_837.png](/images/posts/relative_path_837.png)



