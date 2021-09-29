---

layout: post
title: Go容易混肴的知识点
categories: Go
description: Golang相关笔记
keywords: Golang
typora-root-url: ../
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

### 数字常量

````go
package main

import "fmt"

const (
	// Create a huge number by shifting a 1 bit left 100 places.
	// In other words, the binary number that is 1 followed by 100 zeroes.
	Big = 1 << 100
	// Shift it right again 99 places, so we end up with 1<<1, or 2.
	Small = Big >> 99
)

func needInt(x int) int { return x*10 + 1 }
func needFloat(x float64) float64 {
	return x * 0.1
}

func main() {
	fmt.Println(needInt(Small))
	fmt.Println(needFloat(Small))
	fmt.Println(needFloat(Big))
}

````

以上代码执行结果：

````go
21
0.2
1.2676506002282295e+29
````

