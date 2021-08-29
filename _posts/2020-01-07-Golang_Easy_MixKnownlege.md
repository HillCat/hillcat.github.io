---

layout: post
title: Go容易混肴的知识点
categories: Go
description: Golang相关笔记
keywords: Golang
---
### 重复声明和重复赋值

看下面的一段代码：

````go
f, err := os.Open(name)
if err != nil {
    return err
}
d, err := f.Stat()
if err != nil {
    f.Close()
    return err
}
codeUsing(f, d)
````

在同一个方法里面，err这个变量被声明了两次。`:=`这个运算符在go语言中是声明和赋值一起的“简短运算符”。那么在上面这个例子中，按照其他语言，如果是C # 语言的规范，这个err在这里等于是重复声明了2次。这个在go语言中是合法的，

