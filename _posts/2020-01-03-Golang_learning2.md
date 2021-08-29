---

layout: post
title: Go语言快速入门(2)
categories: Go
description: Golang相关笔记
keywords: Golang
---
### 安装Golang

把Golang的压缩包文件放到Ubuntu的Dowloads路径下面，

执行解压缩：

`tar -xvf go1.17.linux-amd64.tar.gz`

设置权限：

`sudo chown -R root:root ./go`

移动位置到/usr/lcoal:

`sudo mv go /usr/local`

使用nano打开profile文件,配置golang的PATH路径：

`nano ~/.profile`

在文件底部加入：

```csharp
export GOROOT=/usr/local/go
export GOPATH=$HOME/go
export PATH=$PATH:$GOROOT/bin:$GOPATH/bin
export GOPROXY=https://goproxy.cn

```



执行：

`source ~/.profile`

注意：上面的配置文件其实已经配置好了七牛云镜像地址。`export GOPROXY=https://goproxy.cn`,要单独配置，请参考下面的配置golang七牛云镜像。



#### 配置golang七牛云镜像

由于go是google公司的，很多网站在国内都是屏蔽了，需要把go相关的镜像切换到国内。

其实在上面的配置项目中，已经在 ~/.profile文件中加入了七牛云镜像，在这里就不用重复操作了。这里只是演示，单独增加七牛云镜像配置，其实最终也是修改的~/.profile配置文件。除了配置镜像有些区别，大致上其他操作跟这个帖子类似：[How To Install Go on Ubuntu 18.04](https://www.digitalocean.com/community/tutorials/how-to-install-go-on-ubuntu-18-04)

`go env -w GOPROXY=https://goproxy.cn,direct`

验证镜像：`go env | grep GOPROXY`

测试代理: ``time go get golang.org/x/tour``



把它配置到环境变量中：

```csharp
echo "export GO111MODULE=on" >> ~/.profile
```

```csharp
echo "export GOPROXY=https://goproxy.cn" >> ~/.profile
```

```csharp
source ~/.profile
```

搞定镜像代理之后，vscode命令行安装go的若干module才能成功:

<img src="https://cs-cn.top/images/posts/already_togo36.png"/>



#### 私有模块和公有模块设置

如果你使用的 Go 版本 >=1.13, 你可以通过设置 `GOPRIVATE` 环境变量来控制哪些私有仓库和依赖 (公司内部仓库) 不通过 proxy 来拉取，直接走本地，设置如下：

```csharp
go env -w GOPROXY=https://goproxy.cn,direct
```

设置不走 proxy 的私有仓库，多个用逗号相隔

```csharp
go env -w GOPRIVATE=*.corp.example.com
```



### Ubuntu安装vs code

Vs code安装到ubuntu上面做为golang的主要开发工具。首先是firefox浏览器进入到vs code 官方，下载ubuntu版本的安装包。

<img src="https://cs-cn.top/images/posts/vs_code_file224.png"/>

ubuntu 20.0.X版本安装的时候，右键选择install的时候会发现没有任何反应，可以换一个安装方法：

<img src="https://cs-cn.top/images/posts/open_with_install0253.png"/>

`sudo apt update`

`sudo apt install gdebi`

鼠标右键，改用另外的软件来打开vs code安装包：

<img src="https://cs-cn.top/images/posts/Gdebi_install24.png"/>

<img src="https://cs-cn.top/images/posts/installation_message337.png"/>



### 移除Vs Code

如果需要移除vs Code重装，Ubuntu下面执行如下指令：

`sudo apt purge code`

### 提升Ubuntu系统硬盘的大小

一开不建议中途去提升虚拟机硬盘大小，我这里初次安装的时候给虚拟机是45GB硬盘。如果实在不行，分配少了空间，后期再来提升UBUNTU硬盘，不过这里我的尝试遇到很多坑，还是建议一开始就设置到容量。

首先是分配更多的空间给到visualBox的虚拟机。然后进入到Ubuntu种对磁盘进行再分配。

<img src="https://cs-cn.top/images/posts/visual_disk_size5.png"/>

然后是进入到Ubuntu镜像光盘里面的GPart工具里面：

<img src="https://cs-cn.top/images/posts/GPart_tools607.png"/>

加载到光盘之后，进入到Try Ubuntu里面。

篇幅有限，这里推荐更加详细的地址：[How to increase the Disk Size of a Dynamically Allocated Disk in VirtualBox](https://ourcodeworld.com/articles/read/1434/how-to-increase-the-disk-size-of-a-dynamically-allocated-disk-in-virtualbox)





### Go语言格式化

进入到需要格式化的文件目录，执行gofmt -w test.go

<img src="https://cs-cn.top/images/posts/go_fmt5155.png"/>

<img src="https://cs-cn.top/images/posts/go_format428.png"/>



### GO语言的注释

go官方推荐行注释的风格，基本很少看到块注释。

行注释 就是： //



### GO语言代码风格

1.运算符之间有个空格。行代码需要有正确的缩进。

2.GO语言设计者认为“一个问题尽量只有一个解决方案”，对于大括号的写法，第一个大括号必须紧贴着函数，而不能单独换行。

<img src="https://cs-cn.top/images/posts/wrong_grammer_golang21.png"/>

3.go语言建议一行不要超过80个字符，超过了的话尽量用换行来表示，尽量保持代码优雅性。

如果是Println（"testsetstetstsetestetststestsetststsetsetstststet"）这种如果太长的话，建议使用逗号隔开，比如逗号会把换行的字符给拼接起来：

```go
Println(“sdfsfsdsfsdfdsf”，

“sdfsdfsdfsf”，

“sdfsdfsdfsdfsdfsf”)   
```





### Golang中的package

在**[golang的官方文档](https://golang.org/doc/tutorial/getting-started)**示例中，使用了rsc.io/quote这个模块来做为演示，并且官方文档给出了这个模块的地址是：`https://pkg.go.dev/rsc.io/quote`,在index中列出来了该模块可以被外部调用的几个函数。如果要使用其他模块，可以在https://pkg.go.dev/这个网站可以搜索自己需要的package。

<img src="https://cs-cn.top/images/posts/golang_package0616.png"/>

```go
package main

import "fmt"

import "rsc.io/quote"

func main() {
    fmt.Println(quote.Go())
}
```



<img src="https://cs-cn.top/images/posts/go_packages0243.png"/>

引入额外的模块之后，通过mod tidy，go会去网络中自动查找模块，类似于.net中的nuget包管理，会自动从镜像中拉取额外的package包。

````she
➜  hello go mod tidy
go: finding module for package rsc.io/quote
go: downloading rsc.io/quote v1.5.2
go: found rsc.io/quote in rsc.io/quote v1.5.2
go: downloading rsc.io/sampler v1.3.0
go: downloading golang.org/x/text v0.0.0-20170915032832-14c0d48ead0c

````

输入go run . 会执行该文件夹下面的hello.go文件，执行结果最终看到的是如下效果：

````shell
➜  hello go run .     
Don't communicate by sharing memory, share memory by communicating.

````

详细的官方解释已经说得非常清楚：

your code calls the `Go` function, printing a clever message about communication.

When you ran `go mod tidy`, it located and downloaded the `rsc.io/quote` module that contains the package you imported. By default, it downloaded the latest version -- v1.5.2.

当你运行go mod tidy的时候，go会自动加载并下载 `rsc.io/quote`模块，这个模块包含了你在hello.go中引入的package。默认情况下它下载的是最新版本。



### Golang中的module

创建go模块这个章节，官方给出了下面7个小节：

1. Create a module -- Write a small module with functions you can call from another module.
2. [Call your code from another module](https://golang.org/doc/tutorial/call-module-code.html) -- Import and use your new module.
3. [Return and handle an error](https://golang.org/doc/tutorial/handle-errors.html) -- Add simple error handling.
4. [Return a random greeting](https://golang.org/doc/tutorial/random-greeting.html) -- Handle data in slices (Go's dynamically-sized arrays).
5. [Return greetings for multiple people](https://golang.org/doc/tutorial/greetings-multiple-people.html) -- Store key/value pairs in a map.
6. [Add a test](https://golang.org/doc/tutorial/add-a-test.html) -- Use Go's built-in unit testing features to test your code.
7. [Compile and install the application](https://golang.org/doc/tutorial/compile-install.html) -- Compile and install your code locally.

根据官方文档的步骤，在Ubuntu的Home文件夹里面创建一个greetings文件夹，然后进入这个文件夹：

<img src="https://cs-cn.top/images/posts/create_module2359.png"/>

#### 创建自己的module

在创建自己的module之前，需要向初始化，初始化的目的就是为了提供一个模块的路径，就是万一那天你发布了你自己的私人模块的module的时候，你要让go能够通过网络找到你这个模块的直接下载网址，也就是你自己的私人模块的仓库地址：

比如这里举例 ，提供的module下载地址是： example.com/greetings

那么module初始化命令如下：

```shell
➜  greetings go mod init example.com/greetings
go: creating new go.mod: module example.com/greetings

```

执行完上面的命令之后，go会在当前目录下面创建一个go.mod文件用来追踪你引用的模块的变更。也就是你的代码依赖了哪些模块，这个有点类似于.net里面的nuget包管理，但是go语言这里对于第三方包的管理还没有一个官方的统一管理地址。这个go.mod文件主要是记录你所依赖的包的版本信息，其实这个地方跟.net的csproj项目信息里面的记录的包信息类似。当然，你也可以直接修改go.mod里面所依赖的模块的版本号来决定你需要使用哪个版本。

<img src="https://cs-cn.top/images/posts/create_greeting.go3351.png"/>

在greetings文件夹中创建greetings.go文件，并且粘贴如下代码：

````go
package greetings

import "fmt"

// Hello returns a greeting for the named person.
func Hello(name string) string {
    // Return a greeting that embeds the name in a message.
    message := fmt.Sprintf("Hi, %v. Welcome!", name)
    return message
}
````

In Go, the `:=` operator is a shortcut for declaring and initializing a variable in one line (Go uses the value on the right to determine the variable's type).

操作符`:=`在go语言中代表了两个动作，一个是声明，一个是初始化。`:`表示是声明一个变量，`=`表示是初始化一个变量。 

而上面这个简短的写法，是用一行代码，同时表示了对变量的声明和初始化操作。

`message := fmt.Sprintf("Hi, %v. Welcome!", name)`

如果要用分步骤的写法来表示上面这个代码的话，等价的写法如下：

```go
var message string
message = fmt.Sprintf("Hi, %v. Welcome!", name)
```

上面个代码，`fmt.Sprintf("Hi, %v. Welcome!", name)`调用的是Springf函数，这个函数里面有两个参数，第一个参数是格式化之后的字符串，而Sprintf会用name变量的value去替换掉字符串中的`%v` ，其实这个v是value的缩写，还是比较好理解的。

#### 调用module

下面我们需要使用之前hello文件夹里面的代码来调用greetings文件夹中的module，在ubuntu的home目录里面，已经有了如下两个目录：

```
<home>/
 |-- greetings/
 |-- hello/
```

<img src="https://cs-cn.top/images/posts/greetings_hello4735.png"/>

为了能够在hello.go中调用这个greetings.go模块，需要修改hello.go代码如下：

<img src="https://cs-cn.top/images/posts/hello.go005.png"/>

````go
package main

import (
    "fmt"

    "example.com/greetings"
)

func main() {
    // Get a greeting message and print it.
    message := greetings.Hello("Gladys")
    fmt.Println(message)
}
````

从这个代码中，需要几点说明：

在go语言中，如果你的代码是做为application执行的，那么必须要声明在main包里面。这个有点类似于.net里面的application的概念，在.net里面也有module的概念。类似。

上面的代码引入了 “fmt" 和 ”example.com/greetings"两个packages，这使得你的代码能够访问这个两个packages里面的函数，导入了“example.com/greetings"这个包，里面含有你之前创建的模块，让你可以访问Hello函数；而导入"fmt"这个包，使得你可以调用包里面输入输出的功能，比如在控制台中打印字符串。

##### 调用本地的module

因为这个是官方的测试代码，为了演示module的调用，我们刚才创建的greetings模块还没有上传到网络仓库中，如果是生产环境，我们是需要上传模块到一个网络仓库的，只有那样go才能够在生产环境中下载到模块的引用。这里是测试，在本地开发，我们需要让go语言模块的检测到这个greetings的时候，把它给重定向到本地路径中来。

因为是hello目录中的代码在调用这个greetings模块，所以我们修改hello文件夹中的mod配置文件，进入到hello目录执行如下指令：

````go
go mod edit -replace example.com/greetings=../greetings
````

当我们执行完上面这个语句的时候，在mod文件中应该看到如下,这里其实是把原来的那个url形式的路径给重定向到了Linux中的相对路径中，指向了greetings这个文件夹。

go.mod文件里面的所有代码如下：

````go
module example.com/hello

go 1.13

require rsc.io/quote v1.5.2

require (
        golang.org/x/text v0.0.0-20170915032832-14c0d48ead0c // indirect
        rsc.io/sampler v1.3.0 // indirect
)

replace example.com/greetings => ../greetings

````

为了让我们修改go.mod之后的模块做到同步，执行:

`go mod tidy`

在Ubuntu中控制台执行情况如下：

```sh
➜  hello go mod tidy
go: found example.com/greetings in example.com/greetings v0.0.0-00010101000000-000000000000

```

执行了上面的命令之后，go在本地环境中找到了greetings这个依赖，并且生成了一个假的版本号，这个版本号是带有语义的，实际上不存在这样子的版本号。如果go检测到的模块是一个已经发布在网络上的确切的模块，那么会以一个确定的版本号显示出来。

关于模块的版本号，go官方文档有明确的规定，具体请看 [Module version numbering](https://golang.org/doc/modules/version-numbers)。

最后执行下面的命令，运行你的hello.go代码：



```shell
➜  hello go run .
Hi, Gladys. Welcome!
➜  hello 

```

Congrats! You've written two functioning modules.

官方示例这里说的是：You've written two functioning modules. 也就是说，这样子编写的模块是`功能模块`，分别是hello和greetings.

### 返回错误_处理错误

用vim打开greetings.go文件，进入vim编辑模式，gg回到文件首行，dG删除整个文件内容，然后粘贴如下内容：

```go
package greetings

import (
    "errors"
    "fmt"
)

// Hello returns a greeting for the named person.
func Hello(name string) (string, error) {
    // If no name was given, return an error with a message.
    if name == "" {
        return "", errors.New("empty name")
    }

    // If a name was received, return a value that embeds the name
    // in a greeting message.
    message := fmt.Sprintf("Hi, %v. Welcome!", name)
    return message, nil
}
```

<img src="https://cs-cn.top/images/posts/paste_code740.png"/>

go语言的函数都是可以返回多个值的，具体请看go语言官方对于go语法特性的介绍[Multiple return values](https://golang.org/doc/effective_go#multiple-returns)。利用这个特性，修改greetings.go文件，让Hello这个函数返回了一个message，同时还返回错误信息，如果Hello方法接收到了name参数不为空字符则返回的error为空,即nil，如果name是空字符，则直接会通过errors.New抛出error对象。

- Add `nil` (meaning no error) as a second value in the successful return. That way, the caller can see that the function succeeded.

如果函数没有报错，则返回的nil这个表示“没有错误”。作为Hello函数的第二个返回值返回，上层调用者就会知道被调用的Hello函数成功执行了。

<img src="https://cs-cn.top/images/posts/nil291.png"/>

nil这个关键词，在官方文档很多地方的代码示例中都有出现：[Effecitve_go](https://golang.org/doc/effective_go#interfaces)，个人觉得nil它有点类似于.net C #里面的null，但是又不是完全相同，这里go语言主要是用来nil和error对象进行比较运算，判断函数内部是否发生了异常。比如： `if err == nil `   ,`err != nil`.

2.上面已经修改了greetings.go文件，下面修改hello.go文件，贴入如下代码：

```go
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

    // Request a greeting message.
    message, err := greetings.Hello("")
    // If an error was returned, print it to the console and
    // exit the program.
    if err != nil {
        log.Fatal(err)
    }

    // If no error was returned, print the returned message
    // to the console.
    fmt.Println(message)
}
```

在修改之后的这个文件中，引入了log这个package，用来打印一些东西。如果是出现了错误，则使用log.Fatal函数来打印错误信息并且结束程序。因为Hello这里调用的时候就是传入的空字符串，所以返回了错误。ubuntu里面执行这个demo得到的效果如下：

````sh
➜  hello go run .
greetings: empty name
exit status 1
➜  hello 

````

而如果传入一个有效值，执行结果会如何？

<img src="https://cs-cn.top/images/posts/modify_hello_function2775.png"/>

执行结果如下：

````sh
➜  hello go run .
Hi, caianhua. Welcome!
➜  hello 

````

以上就是go语言中对错误的处理。跟C # 和java 使用try  catch finally  去捕获异常，处理异常不同，这里go语言是直接通过error和nil来判断是否存在异常。然后它处理的异常方式和 C # 和 Java 完全不同的。

### 使用slice切片

对于slice ，[官方文档](https://golang.org/doc/tutorial/random-greeting)是这么介绍的：

````tex
A slice is like an array, except that its size changes dynamically as you add and remove items. The slice is one of Go's most useful types.
````

由上面这段话知道，slice其实就是一个动态数组，跟 C # 里面的`可变长度的数组`是差不多的东西。并且这里还提到slice是go里面最有用的类型。

关于slice更加详细的说明，参考官方博客这篇文章： [Go Slices: usage and internals](https://go.dev/blog/slices-intro) ，该文章用图文并茂的形式，详细解释了slice的用法和内部结构：

<img src="https://cs-cn.top/images/posts/go_slices310.png"/>



1.首先我们修改greetings.go文件中的代码，粘贴如下：

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

// init sets initial values for variables used in the function.
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

    // Return a randomly selected message format by specifying
    // a random index for the slice of formats.
    return formats[rand.Intn(len(formats))]
}
````

以上的代码，[官方文档](https://golang.org/doc/tutorial/random-greeting)中有详细的解释，这里简要的记录如下：这里需要重点注意的是官方文档提到这里package内部的函数方法，如果是小写字母开头的方法，只能在package内部调用。这个有点类似 C # 里class中的私有方法，是不会被暴露给外面调用的，注意。

<img src="https://cs-cn.top/images/posts/remark_code389.png"/>

这里的init()函数是给rand函数赋予一个种子值，目的是为了让rand函数在每次程序执行的时候，都得到不同的种子值，以产生真正的随机数，如果不提供种子值，那么rand.Seed给与的种子值默认是rand.Seed(1).产生出来的就是“伪随机数”。具体的解释，参考[官方文档Seed](https://pkg.go.dev/math/rand#Seed)小节。这里的seed接收的种子数是一个64位的长整型数。

go标准库中，关于rand的详细解释：[https://pkg.go.dev/math/rand](https://pkg.go.dev/math/rand)

2.如果hello.go中的参数为空，需要指定一个非空字符串，比如我传入字符串`caianhua`

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

    // Request a greeting message.
    message, err := greetings.Hello("caianhua")
    // If an error was returned, print it to the console and
    // exit the program.
    if err != nil {
        log.Fatal(err)
    }

    // If no error was returned, print the returned message
    // to the console.
    fmt.Println(message)
}

````

3.最后我们执行一下，看看这个随机获取数组的功能是否生效：Terminal中执行多次，每次运行的结果都是随机的

````shell
➜  hello go run .
Hail, caianhua! Well met!
➜  hello go run .
Great to see you, caianhua!
➜  hello go run .
Hail, caianhua! Well met!
➜  hello go run .
Hail, caianhua! Well met!
➜  hello go run .
Great to see you, caianhua!
➜  hello go run .
Hail, caianhua! Well met!
➜  hello go run .
Hi, caianhua. Welcome!
➜  hello 

````

这就是slice的一个使用。

#### Inital初始化函数

上面的demo中用到了一个初始化函数：

```go
// init sets initial values for variables used in the function.
func init() {
    rand.Seed(time.Now().UnixNano())
}
```

这里的备注，意思是：init初始化函数的作用是给某些变量提供初始值的，这些变量是被其他的函数内部所使用。

而官方文档对于init初始化函数有更详细的介绍[The init function](https://golang.org/doc/effective_go#init)，这个初始化函数的执行是在所有其他变量初始化之后才执行的，并且是在所有被导入的package都被初始化之后，这些变量才会被初始化。inital的执行在这个两者之后。并且是一个package里面可以有多个初始化函数。这个感觉有点类似于web页面head中js加载，放在靠底部的js最后加载。也有点像jquery中的某些函数，要等到页面初始化之后再加载。



