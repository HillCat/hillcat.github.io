---

layout: post
title: Go语言快速入门
categories: Go
description: Golang相关笔记
keywords: Golang
---
Golang的开发环境大部分的情况是使用Linux居多。下面对于VisualBox在windows10系统中安装配置Ubuntu桌面版20.0.X LTS版本整理如下：刚开始安装Ubuntu的时候，**务必保证分配到45G左右的空间**，如果分配空间太少的话，会遇到System Root空间不足的告警，后期再去修改磁盘空间大小会遇到很多坑。

### 网络桥接模式

<img src="https://cs-cn.top/images/posts/bridge_connection4214.png"/>

VisualBox网络桥接模式，防止虚拟机安装之后无法更新。

### 修改Ubuntu镜像源

因为国内网速的问题，Ubuntu的镜像源需要设置为国内的阿里巴巴或者其他镜像。这个对于Ubuntu而是非常简单的，可以参考：[https://blog.csdn.net/laoluobo76/article/details/108302191](https://blog.csdn.net/laoluobo76/article/details/108302191)

<img src="https://cs-cn.top/images/posts/set_aliyun_mirror314.png"/>

因为Ubuntu可以直接在图像界面下修改镜像源地址为国内的，所以它比Centos和苹果的IOS其实更加适合程序员用来做为Linux开发环境。



### 调整自适应分辨率

更新了各种包之后，开始设置Ubuntu分辨率。现在一般台式机的显示器都是23寸的。而VisualBox虚拟机安装完Ubuntu之后，还需把桌面分辨率调节一下，并且如果是做为开发环境的话，显卡的显存分配，刷新率这些都需要调整到最佳状态。

在执行了：apt-get install update && apt-get install upgrade 之后，执行如下代码：

```csharp
sudo apt install virtualbox-guest-dkms
```

安装完上面这个dkms之后，需要关机，VisualBox中对虚拟机的显卡缓存拉到最大并且开启3D加速：

<img src="https://cs-cn.top/images/posts/view_card_settings53.png"/>

如果要使用Auto-resize Guest Display,则需要在我们的电脑中找到VisualBoxAdditional.ISO这个镜像，手动设置到Ubuntu的DVD光驱中，让Ubuntu开机的时候加载这个VisualBoxAdditional.ISO镜像：

<img src="https://cs-cn.top/images/posts/visualBoxAdditional1554.png"/>

然后找到了这个镜像文件之后，载入到Ubuntu的光盘里面中：

<img src="https://cs-cn.top/images/posts/LoadVisualBoxAdditional.ISO910.png"/>

经过上面这个设置之后，开机启动Ubuntu，Ubuntu的桌面就会显示出来DVD这个设备加载了一个光盘文件，会显示在桌面中，我们需要手动找到这个路径安装这个VisualBoxAdditional镜像里面的软件，

<img src="https://cs-cn.top/images/posts/file_box317.png"/>

进入到光盘文件中，右键鼠标，从Terminal中打开当前路径：

<img src="https://cs-cn.top/images/posts/open_teminal22537.png"/>

然后Terminal中敲入命令行 ./autorun.sh  ,执行光盘程序中的文件，安装相应的扩展：

<img src="https://cs-cn.top/images/posts/autorunsh2843.png"/>

它会弹出来一个验证框，要求你输入Ubuntu权限的密码，输入之后，Terminal开始执行命令行，开始安装：

<img src="https://cs-cn.top/images/posts/install_sh928.png"/>

安装完毕之后重启Ubuntu虚拟机。只要设置正确，那么VisualBox窗体顶部工具栏View菜单栏中的VisualBoxResize功能就可以被选中了，如下：

<img src="https://cs-cn.top/images/posts/auto_resize840.png"/>

当你拖放窗口大小的时候，分辨率会随着窗口的变化而变化的，对于程序员在Window上面搞开发而言非常方便了。

### 设置Ubuntu显卡

让ubuntu基于我们的硬件的显卡，设置到最高的分辨率，这里进入到display设置界面，选择我们的显示器最大的分辨率，比如我的是23寸，就选择1920 X 1440 （4:3），得到一个最舒适的分辨率，方便我们长期使用虚拟机得到最好的显示效果，保护我们的视力。

<img src="https://cs-cn.top/images/posts/setting_display4144.png"/>

<img src="https://cs-cn.top/images/posts/1920X1440_606.png"/>

如果不太习惯那种全屏模式的话，还是喜欢那种自适应模式的分辨率，那么可以View中选择Auto-Resize Guest  display 就是自动缩放的分辨率。全部设置完成之后，执行：sudo apt update ,更新一下配置信息。

**注意**：设置Ubuntu虚拟机窗口自适应的时候会遇到一些坑：调节VisualBox窗口大小和分辨率的时候，如果VisualBox窗体不小心进入了Scale Model，则会看不到VisualBox顶部的工具栏，只需要按住**键盘右边的Ctrl **+ Home键找回工具条，重新点击Scale Model就可以回到工具栏模式，对我们的窗口分辨率进行进一步设置。而点击**键盘右边的Ctrl **+C可以切换到缩略窗口模式。

### 修改MachineName

虚拟机在安装的时候，由于没有太注意，给定义的机器的名字非常长，先把机器名字修改简短一些，可以直接如下：

sudo nano /etc/hostname

进入到nano编辑器界面，修改了机器名之后，Ctrl + O 保存，然后Ctrl +X 退出机器，重启即可。



### 安装oh my zsh

在苹果笔记本上面很多人喜欢使用iterm2这个命令提示的shell，而之前我用过一段时间的zsh，这个[oh my zsh](https://github.com/ohmyzsh/ohmyzsh)是zsh的增强版本，带有智能提示，Github中的Star数量是132k，人气特别高的一个开源项目。特别是对于经常忘记Linux指令的人，非常有用。这里考虑用oh my zsh替换掉Ubuntu默认的bash shell。当然，这两个shell是可以互相切换的。不用担心，为了以防万一，操作之前对虚拟机进行快照备份。

1.首先是安装zsh：执行：sudo apt install zsh

2.把默认shell设置为zsh:  

````echo $SHELL````

`chsh -s $(which zsh)`

3.安装git,curl,wget这三个工具：

`sudo apt install curl wget git`

4.安装Oh My Zsh，通过如下命令行：

`sh -c "$(curl -fsSL https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"`

安装完oh my zsh之后，默认的shell就会是oh my zsh的。

其他更多扩展：oh my zsh安装插件，卸载oh myzsh ，参考：[How to Install OH-MY-ZSH in Ubuntu 20.04](https://www.tecmint.com/install-oh-my-zsh-in-ubuntu/)



如果是在Bash Shell情况下切换到zsh，直接敲入命令行：zsh  即可



#### shell命令自动提示

在安装了oh my zsh之后，我们使用git命令来测试下，这个shell命令工具是怎么提供提示信息的，比如我们敲入git，然后**按两下Tab键**，这个时候，下面会弹出来一堆提示信息，都是跟git指令相关的，而且这些提示补全指令，都是可以通过上下方向箭头去选择的，有了这个oh my zsh之后就非常方便。

<img src="https://cs-cn.top/images/posts/git_command_test12.png"/>



### Windows复制粘贴文件文本到Ubuntu

通过上面的“调整分辨率”那个章节，我们已经安装过VisualBoxAdditional.ISO这个光盘镜像了，那么VisualBox工具栏上面已经有了这个功能，可以把虚拟机中的剪切板内容分享给外面的windows宿主机，同时也可以把外面宿主机windows剪切板内容分享给虚拟机Ubuntu，可以是双向，也可以是windows -> Ubuntu，也可以是Ubuntu-> windows，这三种选项看自己需要来定。设置之后需要生效，要重启Ubuntu虚拟机。

<img src="https://cs-cn.top/images/posts/copy_paste026.png"/>

另外，拖动文件到Ubuntu里面都是可以的，也是在安装完VisualBoxAdditional之后才有的功能。

### 关掉Ubuntu自动锁屏

因为是在windows的VisualBox虚拟机环境使用Ubuntu，本身windows有锁屏功能，虚拟机Ubuntu的锁屏时间很短，只有5分钟，为了开发方便，直接关闭掉锁屏：

<img src="https://cs-cn.top/images/posts/auto_lock_screen04900.png"/>



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

以上golang的环境变量就配置好了，接下来是配置golang的国内镜像和开启Module管理

#### 启动Go Modules功能

`go env -w GO111MODULE=on`



#### 配置golang七牛云镜像

`go env -w GOPROXY=https://goproxy.cn,direct`

验证镜像：go env | grep GOPROXY

测试代理: ``time go get golang.org/x/tour``



把它配置到环境变量中：

```csharp
echo "export GO111MODULE=on" >> ~/.profile
echo "export GO111MODULE=on" >> ~/.profile
```

```csharp
echo "export GOPROXY=https://goproxy.cn" >> ~/.profile
```

```csharp
source ~/.profile
```

搞定镜像代理之后，vscode命令行安装go的模块才能成功:

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

Ubuntu下面执行如下指令：

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

<img src="https://cs-cn.top/images/posts/redrect0347.png"/>

go.mod文件里面的所有代码如下：

````go
module example.com/hello

go 1.17

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

go语言的函数都是可以返回多个值的，具体请看go语言官方对于go语法特性的介绍[Multiple return values](https://golang.org/doc/effective_go#multiple-returns)。利用这个特性，修改greetings.go文件，让Hello这个函数返回了一个message，同时还返回错误信息，如果Hello方法接收到了name参数则返回的Error为空，如果name是空，则直接会通过errors.New抛出错误对象。

- Add `nil` (meaning no error) as a second value in the successful return. That way, the caller can see that the function succeeded.

如果函数没有报错，则返回的nil这个表示“没有错误”。作为Hello函数的第二个返回值返回，上层调用者就会知道被调用的Hello函数成功执行了。



### golang官方快速入门教程

go官方网站提供了一个快速入门的系列教程，让你快速了解go语言的所有的语法，地址是:[A Tour of Go](https://tour.golang.org/welcome/1)

<img src="https://cs-cn.top/images/posts/A_Tour_of_GO144.png"/>

个人认为，作为一个有多年开发经验的.net，直接看[官方文档](https://tour.golang.org/welcome/1)是最快熟悉go的方法。





