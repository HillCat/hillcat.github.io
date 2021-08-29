---

layout: post
title: Go语言快速入门(3)
categories: Go
description: Golang相关笔记
keywords: Golang
---
### Module兼容处理

在Go语言快速入门(2)中，greetings.go文件中有一个方法Hello是传入一个人名之后返回一个随机的问候语，这次需要修改这个module，使其能够传入多个人名，然后返回多个问候语，考虑到直接修改Hello方法把其由单个形参改为多个形参，会破坏module的封装。只能是在这个module里面增加一个新的函数满足需求。保留了旧功能，以向后兼容。更多兼容性处理，参考官方文档:[Keeping Your Modules Compatible](https://go.dev/blog/module-compatibility)(让你的模块更具兼容性)。

1.修改greeting.go代码如下：

````go
package greetings

import (
    "errors"
    "fmt"
    "math/rand"
    "time"
)

// Hello returns a greeting for the named person.
func Hello(name string) (string, error) {
    // If no name was given, return an error with a message.
    if name == "" {
        return name, errors.New("empty name")
    }
    // Create a message using a random format.
    message := fmt.Sprintf(randomFormat(), name)
    return message, nil
}

// Hellos returns a map that associates each of the named people
// with a greeting message.
func Hellos(names []string) (map[string]string, error) {
    // A map to associate names with messages.
    messages := make(map[string]string)
    // Loop through the received slice of names, calling
    // the Hello function to get a message for each name.
    for _, name := range names {
        message, err := Hello(name)
        if err != nil {
            return nil, err
        }
        // In the map, associate the retrieved message with
        // the name.
        messages[name] = message
    }
    return messages, nil
}

// Init sets initial values for variables used in the function.
func init() {
    rand.Seed(time.Now().UnixNano())
}

// randomFormat returns one of a set of greeting messages. The returned
// message is selected at random.
func randomFormat() string {
    // A slice of message formats.
    formats := []string{
        "Hi, %v. Welcome!",
        "Great to see you, %v!",
        "Hail, %v! Well met!",
    }

    // Return one of the message formats selected at random.
    return formats[rand.Intn(len(formats))]
}
````

2.修改hello.go的代码如下：

````go
package main

import (
    "fmt"
    "log"

    "example.com/greetings"
)

func main() {
    // Set properties of the predefined Logger, including
    // the log entry prefix and a flag to disable printing
    // the time, source file, and line number.
    log.SetPrefix("greetings: ")
    log.SetFlags(0)

    // A slice of names.
    names := []string{"Gladys", "Samantha", "Darrin"}

    // Request greeting messages for the names.
    messages, err := greetings.Hellos(names)
    if err != nil {
        log.Fatal(err)
    }
    // If no error was returned, print the returned map of
    // messages to the console.
    fmt.Println(messages)
}
````

最终执行结果如下：

```go
➜  hello go run .
map[Darrin:Hail, Darrin! Well met! Gladys:Hail, Gladys! Well met! Samantha:Hi, Samantha. Welcome!]

```

返回的是一个map类型的数据结构，这个数据结构类似于字典，但是又不完全跟字典相同。在默认key不存在的情况下，

### Maps数据结构

这一节的代码中使用到了Map这个数据结构，大体上来说这个数据结构有点类似于C # 里面的泛型字典。但是略有一些不同。

这是官网地址：[https://golang.org/doc/effective_go#maps](https://golang.org/doc/effective_go#maps)

如果尝试向map中获取一个不存在的key，则map会返回什么值呢？

```go
attended := map[string]bool{
    "Ann": true,
    "Joe": true,
    ...
}
```

如果map的key是string类型，value是bool类型，当请求了一个不存在的key的时候，返回的就是false.

#### map的初始化

map的初始化使用make方法，里面声明key,value的类型。

````go
m = make(map[string] int)

// map的大小在初始化的时候可以指定大小
m = make(map[string] int, 100)
````

下面这种 声明方式得到的是一个空的map,它的零值是nil,相当于C #里面的空指针，直接在go里面操作空指针会抛出panic类型错误，这种异常是go里面严重异常。跟C # 里面抛空指针异常有点类似。

````go
var m map[string] int
````



#### map中添加元素和修改元素

map中添加元素和修改元素都是使用下面这种类似的语法，如果key对应有值，就会是修改，而如果没有key则是往字典里面增加内容。

````go
m["abc"] = 4
````



#### map中删除元素

跟其他语言不同，go中如果要删除一个元素，不需要提前判断它是否存在，如果这个值不存在，而调用了delete操作，什么也不会发生。如果对map为nil的对象进行delete操作也是会抛出panic异常的。所以删除map的时候要对map进行非空判断。

````go
delete(m, "abc")
````

使用内置的delete方法进行删除

```go
func test5() {
	var a map[string]int
	a = make(map[string]int, 16)
	fmt.Printf("a = %#v \n", a)
	a["stu01"] = 1000
	a["stu02"] = 2000
	a["stu03"] = 3000
	fmt.Printf("a = %#v \n", a)
	delete(a, "stu02")
	fmt.Printf("DEL after a = %#v \n", a)
}
```

删除所有的，需要用for循环，挨个删除

#### map的遍历

使用for ... range 的方法进行遍历，获取当中的值

```go
func test4() {
	rand.Seed(time.Now().UnixNano())

	var a map[string]int
	a = make(map[string]int, 1024)
	for i := 0; i < 128; i++ {
		key := fmt.Sprintf("stu%d", i)
		value := rand.Intn(1000)
		a[key] = value
	}
	for key, value := range a {
		fmt.Printf("map[%s]=%d\n", key, value)
	}
}
```

#### map中查找元素

如果map中不存在对应key的值，那么它不会抛异常，如果key不存在则会返回bool值表示有没有查找到。

### For语句

for 一般配合range一起使用。
#### 1.自增型for循环：

```go
for i := 0; i < 5; i++ {
    fmt.Println(i)
}
```



#### 2.带有步距的自增for循环：

````go
for i := 0; i < 15; i += 3 {
    fmt.Println(i)
}

//Output
0
3
6
9
12
````

#### 3.自减型for循环：

````go
for i := 100; i > 0; i -= 10 {
    fmt.Println(i)
}

//Output
100
90
80
70
60
50
40
30
20
10
````

4.跳出循环

````go
for {
    if someCondition {
        break
    }
    // do action here
}
````



### If语句

go中的if语句跟 C # 中的很大的不同，它这个if语句里面是可以对变量进行初始化之后，再对变量进行bool运算,全部在一行搞定，中间隔一个分号隔开：

```go
if err := file.Chmod(0664); err != nil {
    log.Print(err)
    return err
}
```

上面这个代码，首先是`err := file.Chmod(0664);`对变量进行了赋值运算，然后紧接着对这个变量进行非空判断`err != nil`。






### _空白符号

````go
 for _, name := range names {
        message, err := Hello(name)
        if err != nil {
            return nil, err
        }
        // In the map, associate the retrieved message with
        // the name.
        messages[name] = message
    }
````

下划线在golang语言中被认为是空白标识符，它在golang中主要是用来接收那些“在程序中已经定义了的变量，但是又不使用的变量”，如果是在C # 中，定义了一个变量不使用，编译器是不会报错的。但是在golang中如果定义了一个变量又不使用，那么编译的时候就会报错。这个是golang强制规定的，目的是为了保证代码的可读性和简洁性。但是也有特殊情况，

在上面这个for循环中空白符_原本应该是声明的 for语句中的 变量i ,也就是name数组中的下标i变量，因为这个变量在for循环体内没有使用到，就会造成编译的时候报错，为了避免编译报错，使用空白符告诉go编译器忽略这个语法检查。

比如下面这种for循环，就使用到了i 变量：

````go
ackage main

import "fmt"

func main() {
    sharks := []string{"hammerhead", "great white", "dogfish", "frilled", "bullhead", "requiem"}

    for i := 0; i < len(sharks); i++ {
        fmt.Println(sharks[i])
    }
}
````

