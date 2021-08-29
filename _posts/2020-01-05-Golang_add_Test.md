---

layout: post
title: Go语言快速入门：测试Go(4)
categories: Go
description: Golang相关笔记
keywords: Golang
---
这篇文章主要是给go代码添加测试, go语言的单元测试是内置的。接着上篇文章，这篇文章是对我们的greetings.go文件进行测试，进入到greetings文件夹，创建greetings_test.go文件。测试文件的命名以下划线 _test这种方式结尾是告诉go的test command，这个greetings_test.go文件是包含了测试功能的。这个章节会涉及到go里面的正则表达式，测试函数，指针，。

1.在greetings_test.go里面粘贴如下代码：

````go
package greetings

import (
    "testing"
    "regexp"
)

// TestHelloName calls greetings.Hello with a name, checking
// for a valid return value.
func TestHelloName(t *testing.T) {
    name := "Gladys"
    want := regexp.MustCompile(`\b`+name+`\b`)
    msg, err := Hello("Gladys")
    if !want.MatchString(msg) || err != nil {
        t.Fatalf(`Hello("Gladys") = %q, %v, want match for %#q, nil`, msg, err, want)
    }
}

// TestHelloEmpty calls greetings.Hello with an empty string,
// checking for an error.
func TestHelloEmpty(t *testing.T) {
    msg, err := Hello("")
    if msg != "" || err == nil {
        t.Fatalf(`Hello("") = %q, %v, want "", error`, msg, err)
    }
}
````

上面这段代码，使用了testing库里面的testing.T这个类型作为一个参数，然后使用这个类型的方法来报告和记录测试得到的数据。代码中实现了两个测试，

TestHelloName这个测试方法是传递一个name值，正常情况下是返回响应值，如果返回的响应值是空或者内部有错误出现，则testing.T的Fatalf方法将消息打印的控制台并结束执行；

TestHelloEmpty这个测试方法是用空字符串调用Hello函数，该测试主要是验证程序对于错误处理是否正常。如果返回空字符或者没有错误，则testing.T的Fatalf方法会将消息打印到控制台。



### 执行测试

这里执行多次，结果都是测试ok。

````go
➜  greetings go test
PASS
ok  	example.com/greetings	0.011s
➜  greetings go test
PASS
ok  	example.com/greetings	0.008s
➜  greetings 


````

greetings目录下面有greetings.go   greetings_test.go两个文件。

在控制台执行go test的时候，命令会自动调用测试程序里面以Test开头的函数，并且是调用目录下面以_test.go结尾的文件里面的Test开头的函数。

可以加上 -v 参数，打印出来更加详细测试数据：

````go
➜  greetings go test -v
=== RUN   TestHelloName
--- PASS: TestHelloName (0.00s)
=== RUN   TestHelloEmpty
--- PASS: TestHelloEmpty (0.00s)
PASS
ok  	example.com/greetings	0.007s

````



### 测试失败

把greetings.go中的Hello函数，修改为如下：message := fmt.Sprint(randomFormat()),只返回了问候语，但是没有返回人名，会被测试函数中的  :

````go
want := regexp.MustCompile(`\b`+name+`\b`)  
````

这个正则匹配的时候，发现没有name，那么测试失败。下面这个正则表达式就是false,那么测试失败。

````go
want.MatchString(msg)
````



````go
// Hello returns a greeting for the named person.
func Hello(name string) (string, error) {
    // If no name was given, return an error with a message.
    if name == "" {
        return name, errors.New("empty name")
    }
    // Create a message using a random format.
    // message := fmt.Sprintf(randomFormat(), name)
    message := fmt.Sprint(randomFormat())
    return message, nil
}
````



````go
➜  greetings go test
--- FAIL: TestHelloName (0.00s)
    greetings_test.go:15: Hello("Gladys") = "Hail, %!v(MISSING)! Well met!", <nil>, want match for `\bGladys\b`, nil
FAIL
exit status 1
FAIL	example.com/greetings	0.015s
➜  greetings 


````

如果是测试失败，那么无需 -v参数，go的测试程序会告诉你第几行的代码测试失败了，特别是在测试文件特别多的情况下，这个很管用，方便快速定位到代码所在文件所在行。函数TestHelloName虽然是测试失败了，但是`TestHelloEmpty` 函数的测试是正常的。

### 正则表达式语法

