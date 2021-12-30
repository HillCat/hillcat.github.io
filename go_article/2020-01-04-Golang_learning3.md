---

layout: post
title: Go语言快速入门：map数据结构for循环(3)
categories: Go
description: Golang相关笔记
keywords: Golang
typora-root-url: ../
---
这篇文章是接着上面Go语言快速入门(2)，给greetings.go增加新的函数方法Hellos，传递多个参数，返回多个参数。这个章节涉及到map的初始化，以及for  range对于数组的遍历，空白符_这几个概念。还有go里面的for也是一个比较重要的话题。

### module兼容处理

在Go语言快速入门(2)中，greetings.go文件中有一个方法Hello是传入一个人名之后返回一个随机的问候语，这次需要修改这个module，使其能够传入多个人名，然后返回多个问候语，考虑到直接修改Hello方法把其由单个形参改为多个形参，会破坏module的封装。只能是在这个module里面增加一个新的函数满足需求。保留了旧功能，以向后兼容。更多兼容性处理，参考官方文档:[Keeping Your Modules Compatible](https://go.dev/blog/module-compatibility)(使模块更具兼容性)。

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

返回的是一个map类型的数据结构，这个数据结构类似于其他语言里面得字典类型。

从这个官方demo中引出来一系列golang的语法结构：比如map数据结构,for循环，range运算符，空白符号_ 等概念，跟着官方文档学习，速度是最快的。下面对这些东西做了一些整理：

### Maps数据结构

这一节的代码中使用到了Map这个数据结构，大体上来说有点类似于C # 里面的泛型字典。但是略有一些不同。

这是官网地址：[https://golang.org/doc/effective_go#maps](https://golang.org/doc/effective_go#maps)

如果尝试向map中获取一个不存在的key，则map会返回什么值呢？go这里会返回“零值”。

```go
attended := map[string]bool{
    "Ann": true,
    "Joe": true,
    ...
}
```

如果map的key是string类型，value是bool类型，当请求了一个不存在的key的时候，返回的就是false.map不像其他语言一样获取不到的时候会报错，在go语言这里map如果获取一个不存在的数据，会直接返回那个类型对象的零值，比如：如果是布尔值则返回false，如果是数字则返回0，如果是字符串则返回""

#### 1.map的初始化

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



#### 2.map中添加元素和修改元素

map中添加元素和修改元素都是使用下面这种类似的语法，如果key对应有值，就会是修改，而如果没有key则是往字典里面增加内容。

````go
m["abc"] = 4
````



#### 3.map中删除元素

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

#### 4.map的遍历

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

#### 5.map中查找元素

如果map中不存在对应key的值，那么它不会抛异常，如果key不存在则会返回bool值表示有没有查找到。

#### 6.如何判断map中是否存在某个值

````go
if val, ok := dict["foo"]; ok {
    //do something here
}
````



### For循环

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
#### 4.for循环中的_空白符号

下面这个空白符 _，正常情况是应该是变量 i, 但是这里使用一个空白符表示了。因为变量 i 在循环体中并没有使用到，在go语言中会引起编译错误。这是go中强行规定的一个原则。range迭代始终会返回两个值，第一个值是当前循环迭代所在的索引，第二个是该索引处的值。从第一次第迭代开始，索引是`0`，依次递增，会返回并赋值给到for语句这里的 空白符 _ ,而这个索引值，是没有使用到的，需要直接忽略。空白符的解释，在官方文档 [The blank identifier](https://golang.org/doc/effective_go#blank)章节非常详细。

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

在golang中，那些“**在程序中定义了但是又不使用**的变量”编译时会引发报错。这个特性跟其他语言不同，如果是在C # 中，定义了一个变量不使用，编译器是不会报错的，visual studio编译器会自动优化掉这个变量。但是在golang中如果定义了一个变量又不用，就会报错。这个是golang强制规定的，目的是为了保证代码的可读性和简洁性。

使用空白符主要是为了避免编译报错，告诉编译器，这是一个特例，编译的时候不要报错。

如果for循环的i变量被使用了，就不会有这个问题，比如下面这个：

````go
package main

import "fmt"

func main() {
    sharks := []string{"hammerhead", "great white", "dogfish", "frilled", "bullhead", "requiem"}

    for i, shark := range sharks {
        fmt.Println(i, shark)
    }
}

//Output,打印出每一个切片元素
hammerhead
great white
dogfish
frilled
bullhead
requiem
````



但是如果把上面的代码修改一下，变为如下就会报错：

````go
package main

import "fmt"

func main() {
    sharks := []string{"hammerhead", "great white", "dogfish", "frilled", "bullhead", "requiem"}

    for i, shark := range sharks {
        fmt.Println(shark)
    }
}

//Output
src/range-error.go:8:6: i declared and not used
````

因为range在每次循环的时候都会返回i值，而这个值又没有使用到，所以用一个空白符接收这个值，编译器会自动忽略这个i索引值，改为空白符接收，就没有问题：

````go
package main

import "fmt"

func main() {
    sharks := []string{"hammerhead", "great white", "dogfish", "frilled", "bullhead", "requiem"}

    for _, shark := range sharks {
        fmt.Println(shark)
    }
}

//Output
hammerhead
great white
dogfish
frilled
bullhead
requiem
````

#### 5.range运算符

range运算符还可以用来遍历字符串：

````go
package main

import "fmt"

func main() {
    sammy := "Sammy"

    for _, letter := range sammy {
        fmt.Printf("%c\n", letter)
    }
}
````

#### 6.map遍历_返回值是随机的

需要注意的一个问题是map在遍历的时候返回的值是随机的。

````go
package main

import "fmt"

func main() {
    sammyShark := map[string]string{"name": "Sammy", "animal": "shark", "color": "blue", "location": "ocean"}

    for key, value := range sammyShark {
        fmt.Println(key + ": " + value)
    }
}

//Output
color: blue
location: ocean
name: Sammy
animal: shark
````



#### 7.嵌套循环

````go
package main

import "fmt"

func main() {
    numList := []int{1, 2, 3}
    alphaList := []string{"a", "b", "c"}

    for _, i := range numList {
        fmt.Println(i)
        for _, letter := range alphaList {
            fmt.Println(letter)
        }
    }
}

//Output
1
a
b
c
2
a
b
c
3
a
b
c
````

#### 8.循环语句中使用break,continue

[循环语句中使用break,continue](https://www.digitalocean.com/community/tutorials/using-break-and-continue-statements-when-working-with-loops-in-go)

### If语句

go中的if语句跟 C # 中的很大的不同，它这个if初始化赋值和条件判断通过分号隔开，一行搞定：

```go
if err := file.Chmod(0664); err != nil {
    log.Print(err)
    return err
}
```

上面这个代码，首先是`err := file.Chmod(0664);`对变量进行了赋值运算，然后紧接着对这个变量进行非空判断`err != nil`。





