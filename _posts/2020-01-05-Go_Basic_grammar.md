---

layout: post
title: Go语言快速入门：golang关键语法(5)
categories: Go
description: Golang相关笔记
keywords: Golang
---
Go指南系列代码通过一系列的代码演示，来展现Go语言语法跟其他语言的不同。

### 零值

`````go
package main

import "fmt"

func main() {
	var i int
	var f float64
	var b bool
	var s string
	fmt.Printf("%v %v %v %q\n", i, f, b, s)
}

#输出结果：

0 0 false ""
`````

没有明确初始值的变量声明会被赋予他们的“零值”。数值类的零值为0，布尔类型的零值为false，字符串类型的零值为""（空字符串）。

### 类型转换

Go语言不同类型之间的转换需要显示转换，这一点跟 C #不同。

````go
package main

import (
	"fmt"
	"math"
)

func main() {
	var x, y int = 3, 4
	var f float64 = math.Sqrt(float64(x*x + y*y))
	var z uint = uint(f)
	fmt.Println(x, y, z)
}

````

### 类型推导

在声明一个变量而不指定其类型时（即使用不带类型的 `:=` 语法或 `var =` 表达式语法），变量的类型由右值推导得出。

当右值声明了类型时，新变量的类型与其相同：

```
var i int
j := i // j 也是一个 int
```

不过当右边包含未指明类型的数值常量时，新变量的类型就可能是 `int`, `float64` 或 `complex128` 了，这取决于常量的精度：

```
i := 42           // int
f := 3.142        // float64
g := 0.867 + 0.5i // complex128
```

尝试修改示例代码中 `v` 的初始值，并观察它是如何影响类型的。

### 常量

常量的声明与变量类似，只不过是使用 `const` 关键字。

常量可以是字符、字符串、布尔值或数值。

常量不能用 `:=` 语法声明。

### 无限循环

````go
package main

func main() {
	for {
	}
}

````

### If语句

Go 的 `if` 语句与 `for` 循环类似，表达式外无需小括号 `( )` ，而大括号 `{ }` 则是必须的。

````go
package main

import (
	"fmt"
	"math"
)

func sqrt(x float64) string {
	if x < 0 {
		return sqrt(-x) + "i"
	}
	return fmt.Sprint(math.Sqrt(x))
}

func main() {
	fmt.Println(sqrt(2), sqrt(-4))
}

````

同 `for` 一样， `if` 语句可以在条件表达式前执行一个简单的语句。

该语句声明的变量作用域仅在 `if` 之内。

````go
package main

import (
	"fmt"
	"math"
)

func pow(x, n, lim float64) float64 {
	if v := math.Pow(x, n); v < lim {
		return v
	}
	return lim
}

func main() {
	fmt.Println(
		pow(3, 2, 10),
		pow(3, 3, 20),
	)
}

````

### If和else中变量作用域

在 `if` 的简短语句中声明的变量同样可以在任何对应的 `else` 块中使用。

````go
package main

import (
	"fmt"
	"math"
)

func pow(x, n, lim float64) float64 {
	if v := math.Pow(x, n); v < lim {
		return v
	} else {
		fmt.Printf("%g >= %g\n", v, lim)
	}
	// 这里开始就不能使用 v 了
	return lim
}

func main() {
	fmt.Println(
		pow(3, 2, 10),
		pow(3, 3, 20),
	)
}
````

### switch case

go语言的switch case语句，case分句后面不需要加break语句，这个跟 C # 是不一样的。go语言里面只要匹配成功，判断语句就会停止。注意它这里的赋值和判断`switch os := runtime.GOOS; os {  }`

````go
package main

import (
	"fmt"
	"runtime"
)

func main() {
	fmt.Print("Go runs on ")
	switch os := runtime.GOOS; os {
	case "darwin":
		fmt.Println("OS X.")
	case "linux":
		fmt.Println("Linux.")
	default:
		// freebsd, openbsd,
		// plan9, windows...
		fmt.Printf("%s.\n", os)
	}
}

//输出结果：
Go runs on Linux.
````

而如果是**C #语言**，case后面是要加 `break;` 的.

````c#
string commandName = "start";

switch (commandName)
{
    case "start":
        Console.WriteLine("Starting service...");
        StartService();
        break;
    case "stop":
        Console.WriteLine("Stopping service...");
        StopService();
        break;
    default:
        Console.WriteLine(String.Format("Unknown command: {0}", commandName));
        break;
}
````

#### 没有条件的switch

````go
package main

import (
	"fmt"
	"time"
)

func main() {
	t := time.Now()
	switch {
	case t.Hour() < 12:
		fmt.Println("Good morning!")
	case t.Hour() < 17:
		fmt.Println("Good afternoon.")
	default:
		fmt.Println("Good evening.")
	}
}

//输出结果
Good evening.
````

### defer语句

defer 语句会将函数推迟到外层函数返回之后执行。

推迟调用的函数其参数会立即求值，但直到外层函数返回前该函数都不会被调用。

````go
package main

import "fmt"

func main() {
	defer fmt.Println("world")
     defer fmt.Println("world333")
	fmt.Println("hello")
	
	defer fmt.Println("world4444")
}

//输出结果

hello
world4444
world333
world
````

从上面的执行结果来看，defer更像是把待执行的任务放到了堆栈里面，先进后出 的策略。defer其实就是个栈。

### 指针

Go 拥有指针。指针保存了值的内存地址。

类型 `*T` 是指向 `T` 类型值的指针。其零值为 `nil`。

```
var p *int
```

`&` 操作符会生成一个指向其操作数的指针。

```
i := 42
p = &i
```

`*` 操作符表示指针指向的底层值。

```
fmt.Println(*p) // 通过指针 p 读取 i
*p = 21         // 通过指针 p 设置 i
```

这也就是通常所说的“间接引用”或“重定向”。

go

````go
package main

import "fmt"

func main() {
	i, j := 42, 2701

	p := &i         // 指向 i
	fmt.Println(*p) // 通过指针读取 i 的值
	*p = 21         // 通过指针设置 i 的值
	fmt.Println(i)  // 查看 i 的值

	p = &j         // 指向 j
	*p = *p / 37   // 通过指针对 j 进行除法运算
	fmt.Println(j) // 查看 j 的值
}

//输出结果：

42
21
73
````



从go语言的指针和 C #来对比看。 这里的指针相当于 C #里面的引用类型，指针指向的改变等于就是改变了引用。



### 结构体

结构体这个概念，在 C # 里面也有，这里的结构体概念跟那个类似。

````go
package main

import "fmt"

type Vertex struct {
	X int
	Y int
}

func main() {
	fmt.Println(Vertex{1, 2})
}
//输出结果：
{1 2}

````

结构体字段采用点号来访问，其实这里有点类似于C # 里面访问结构体的属性一样，只不过 C #那边结构体的本质还是class.

````go
package main

import "fmt"

type Vertex struct {
	X int
	Y int
}

func main() {
	v := Vertex{1, 2}
	v.X = 4
	fmt.Println(v.X)
}

````

结构体字段可以通过结构体指针来访问。

如果我们有一个指向结构体的指针 `p`，那么可以通过 `(*p).X` 来访问其字段 `X`。不过这么写太啰嗦了，所以语言也允许我们使用隐式间接引用，直接写 `p.X` 就可以。



````go
package main

import "fmt"

type Vertex struct {
	X int
	Y int
}

func main() {
	v := Vertex{1, 2}
	p := &v
	p.X = 1e9
	fmt.Println(v)
}

//输出结果：
{1000000000 2}

````

结构体也是可以通过指引对期属性进行读写操作。这个有点类似于 C# 对类的属性的读写操作。

#### 结构体的使用

````go
package main

import "fmt"

type Vertex struct {
	X, Y int
}

var (
	v1 = Vertex{1, 2}  // 创建一个 Vertex 类型的结构体
	v2 = Vertex{X: 1}  // Y:0 被隐式地赋予
	v3 = Vertex{}      // X:0 Y:0
	p  = &Vertex{1, 2} // 创建一个 *Vertex 类型的结构体（指针）
)

func main() {
	fmt.Println(v1, p, v2, v3)
}
//输出结果
{1 2} &{1 2} {1 0} {0 0}
````

指针在打印的时候会输出 &符号。结构体中没有被初始化的属性的值默认是零值。

### 数组

普通的数组输出值如下，go语言这里跟C #语言一样。go语言里面数组的零值是可以直接使用的。

`````go
package main

import "fmt"

func main() {
	var a [2]string
	a[0] = "Hello"
	a[1] = "World"
	fmt.Println(a[0], a[1])
	fmt.Println(a)

	primes := [6]int{2, 3, 5, 7, 11, 13}
	fmt.Println(primes)
}

//输出值
Hello World
[Hello World]
[2 3 5 7 11 13]
`````



在go语言中还有个更常用的动态数组，名字叫做切片：切片通过一个冒号，来界定数据范围的上界和下界：`a[low : high]`

`````go
package main

import "fmt"

func main() {
	primes := [6]int{2, 3, 5, 7, 11, 13}

	var s []int = primes[1:4]
	fmt.Println(s)
}
//输出结果：
[3 5 7]
`````

需要注意的是切片这里的下标是一个**半开区间**：`var s []int = primes[1:4]`,这里包含的元素是从 1 到 3 的元素。

#### 切片的用法和本质

切片这个数据结构golang中使用的频率非常高，详细理解切片的内部结构和原理，可以查看官方的博客详解《[切片的用法和本质](https://blog.go-zh.org/go-slices-usage-and-internals)》。

#### 切片数据的修改

切片对通过索引找到对应的值进行修改，实际上修改的是引用的值。把原来的值给修改了。

````go
package main

import "fmt"

func main() {
	names := [4]string{
		"John",
		"Paul",
		"George",
		"Ringo",
	}
	fmt.Println(names)

	a := names[0:2]
	b := names[1:3]
	fmt.Println(a, b)

	b[0] = "XXX"
	fmt.Println(a, b)
	fmt.Println(names)
}

//输出结果：
[John Paul George Ringo]
[John Paul] [Paul George]
[John XXX] [XXX George]
[John XXX George Ringo]
````

#### 结构体和切片结合使用

结构体和切片结合使用有点像C # 里面的  `List<StructObject>` ，切片数组里面装的是一批实例化好的Struct对象，而Struct内部的属性的类型是声明的时候定义好了。

````go
package main

import "fmt"

func main() {
	q := []int{2, 3, 5, 7, 11, 13}
	fmt.Println(q)

	r := []bool{true, false, true, true, false, true}
	fmt.Println(r)

	s := []struct {
		i int
		b bool
	}{
		{2, true},
		{3, false},
		{5, true},
		{7, true},
		{11, false},
		{13, true},
	}
	fmt.Println(s)
}
//输出结果
[2 3 5 7 11 13]
[true false true true false true]
[{2 true} {3 false} {5 true} {7 true} {11 false} {13 true}]
````

这里对于切片和Struct结合使用，达到的效果类似于C #里面的` list<T>`对象的实例化，只是这里类似于`new() { } `这样子的语法。还一不同的是T这个类型，go用strcut来代替了，实例化的时候直接通过类似于js的语法搞定的。

#### 切片的默认上界和下界

````go
package main

import "fmt"

func main() {
	s := []int{2, 3, 5, 7, 11, 13}

	s = s[1:4]
	fmt.Println(s)

	s = s[:2]
	fmt.Println(s)

	s = s[1:]
	fmt.Println(s)
}

//输出结果：
[3 5 7]
[3 5]
[5]
````

切片下界的默认值为 `0`，上界则是该切片的长度。对于数组

```
var a [10]int
```

来说，以下切片是等价的：

```
a[0:10]
a[:10]
a[0:]
a[:]
```

#### 切片的长度和容量

````go
package main

import "fmt"

func main() {
	s := []int{2, 3, 5, 7, 11, 13}
	printSlice(s)

	// 截取切片使其长度为 0
	s = s[:0]
	printSlice(s)

	// 拓展其长度
	s = s[:4]
	printSlice(s)

	// 舍弃前两个值
	s = s[2:]
	printSlice(s)
}

func printSlice(s []int) {
	fmt.Printf("len=%d cap=%d %v\n", len(s), cap(s), s)
}

//输出值
len=6 cap=6 [2 3 5 7 11 13]
len=0 cap=6 []
len=4 cap=6 [2 3 5 7]
len=2 cap=4 [5 7]
````

注意这里的用法，如果是把上面的拓展其长度的代码修改为;

````go
// 拓展其长度
	s = s[:6]
	printSlice(s)
````

````go
len=6 cap=6 [2 3 5 7 11 13]
len=0 cap=6 []
len=6 cap=6 [2 3 5 7 11 13]
len=4 cap=4 [5 7 11 13]
````

也就是说下面这种方法，`s[:0]`获取到的是[] 空切片，原来的切片容量没有改变，原来切片里的数据也没有改变。

````go
// 截取切片使其长度为 0
	s = s[:0]
	printSlice(s)
````

`s[2:]`如果起始位置不是从0开始，这样子截取的话，会修改切片的容量。

#### 长度和容量的区别

![img](https://blog.go-zh.org/images/posts/go-slices-usage-and-internals_slice-struct.png)



![img](https://blog.go-zh.org/images/posts/go-slices-usage-and-internals_slice-2.png)

切片操作并不复制切片指向的元素。它创建一个新的切片并复用原来切片的底层数组。 这使得切片操作和数组索引一样高效。因此，通过一个新切片修改元素会影响到原始切片的对应元素。

```go
d := []byte{'r', 'o', 'a', 'd'}
e := d[2:]
// e == []byte{'a', 'd'}
e[1] = 'm'
// e == []byte{'a', 'm'}
// d == []byte{'r', 'o', 'a', 'm'}
```

这里通过索引下标的方式去修改了切片的值，导致e对象和d对象里面的底层数组都发生了变化，证明指向了同一块底层数据。



#### nil切片

切片的零值是 `nil`。nil 切片的长度和容量为 0 且没有底层数组。跟C #相比的话，相当于是一个null，一个空的引用。但是go这里也不完全等同于C #中的null，空的切片跟nil进行比对的时候，布尔值是True。

````go
package main

import "fmt"

func main() {
	var s []int
	fmt.Println(s, len(s), cap(s))
	if s == nil {
		fmt.Println("nil!")
	}
}

//输出
[] 0 0
nil!
````

#### 切片实例化

注意：这里有个非常有意思的地方就是`b := make([]int, 0, 5) // len(b)=0, cap(b)=5` 切片里面的length长度和capacity容量是两个不同的概念。前面这个句子，b这个切片通过make创建之后，长度是0，容量是5. 第二个参数是长度，第三个参数是容量。

````go
package main

import "fmt"

func main() {
	a := make([]int, 5)
	printSlice("a", a)

	b := make([]int, 0, 5)
	printSlice("b", b)

	c := b[:2]
	printSlice("c", c)

	d := c[2:5]
	printSlice("d", d)
}

func printSlice(s string, x []int) {
	fmt.Printf("%s len=%d cap=%d %v\n",
		s, len(x), cap(x), x)
}

//输出结果
a len=5 cap=5 [0 0 0 0 0]
b len=0 cap=5 []
c len=2 cap=5 [0 0]
d len=3 cap=3 [0 0 0]
````

注意看下面的代码：

````go
b := make([]int, 0, 5) // len(b)=0, cap(b)=5

b = b[:cap(b)] // len(b)=5, cap(b)=5
b = b[1:]      // len(b)=4, cap(b)=4
````

切片的下界一般默认为0，如果大于0，则会舍弃掉切片内容的一部分，影响到切片的长度和容量。



#### 切片中的切片

切片中的成员，除了可以是其他类型的对象，也还可以是切片本身这种类型。相当于c # 中`List<T>`  ，里面再嵌套一个List变为`List<List<string>>`,跟这个效果有点类似。

````go
package main

import (
	"fmt"
	"strings"
)

func main() {
	// 创建一个井字板（经典游戏）
	board := [][]string{
		[]string{"_", "_", "_"},
		[]string{"_", "_", "_"},
		[]string{"_", "_", "_"},
	}

	// 两个玩家轮流打上 X 和 O
	board[0][0] = "X"
	board[2][2] = "O"
	board[1][2] = "X"
	board[1][0] = "O"
	board[0][2] = "X"

	for i := 0; i < len(board); i++ {
		fmt.Printf("%s\n", strings.Join(board[i], " "))
	}
}

//输出内容
X _ X
O _ X
_ _ O
````

#### 向切片追加元素

````go
package main

import "fmt"

func main() {
	var s []int
	printSlice(s)

	// 添加一个空切片
	s = append(s, 0)
	printSlice(s)

	// 这个切片会按需增长
	s = append(s, 1)
	printSlice(s)

	// 可以一次性添加多个元素
	s = append(s, 2, 3, 4)
	printSlice(s)
}

func printSlice(s []int) {
	fmt.Printf("len=%d cap=%d %v\n", len(s), cap(s), s)
}

//输入结果
len=0 cap=0 []
len=1 cap=1 [0]
len=2 cap=2 [0 1]
len=5 cap=6 [0 1 2 3 4]
````

go语言这里的append函数，其实类似于 C#  里面`list<T>`的方法append一样，向容器的末尾追加数据。

#### 切片中追加切片

除了上面这种语法，还有另外几种追加元素的方法：

如果是要将一个切片追加到另一个切片尾部，需要使用 `...` 语法将第2个参数展开为参数列表。这个语法有点类似于JavaScript的语法。

```go
a := []string{"John", "Paul"}
b := []string{"George", "Ringo", "Pete"}
a = append(a, b...) // equivalent to "append(a, b[0], b[1], b[2])"
// a == []string{"John", "Paul", "George", "Ringo", "Pete"}
```

#### 循环追加内容到切片

由于切片的零值 nil 用起来就像一个长度为零的切片，我们可以声明一个切片变量然后在循环 中向它追加数据：

````go
// Filter returns a new slice holding only
// the elements of s that satisfy fn()
func Filter(s []int, fn func(int) bool) []int {
    var p []int // == nil
    for _, v := range s {
        if fn(v) {
            p = append(p, v)
        }
    }
    return p
}
````

go语言这里的操作思路其实跟 C #里面的`List<T>`操作方式一摸一样。先声明一个空的List对象，然后在利用List append方法追加元素，通过遍历的方式存入元素，这个经常用到。

#### 遍历切片

for range 语句可以遍历切片。

```go
package main

import "fmt"

var pow = []int{1, 2, 4, 8, 16, 32, 64, 128}

func main() {
	for i, v := range pow {
		fmt.Printf("2**%d = %d\n", i, v)
	}
}

//输出结果
2**0 = 1
2**1 = 2
2**2 = 4
2**3 = 8
2**4 = 16
2**5 = 32
2**6 = 64
2**7 = 128
```

for range的时候，如果不需要打印出来i下标值，只需要拿到结果值，可以使用[空白符](https://cs-cn.top/2020/01/04/Golang_learning3/#4for%E5%BE%AA%E7%8E%AF%E4%B8%AD%E7%9A%84_%E7%A9%BA%E7%99%BD%E7%AC%A6%E5%8F%B7)_ 。

````go
package main

import "fmt"

func main() {
	pow := make([]int, 10)
	for i := range pow {
		pow[i] = 1 << uint(i) // == 2**i
	}
	for _, value := range pow {
		fmt.Printf("%d\n", value)
	}
}

//输出结果如下
1
2
4
8
16
32
64
128
256
512
````

#### 切片GC释放的问题

切片操作并不会复制底层的数组。整个数组将被保存在内存中，直到它不再被引用。 有时候可能会因为一个小的内存引用导致保存所有的数据。

例如， `FindDigits` 函数加载整个文件到内存，然后搜索第一个连续的数字，最后结果以切片方式返回。

```
var digitRegexp = regexp.MustCompile("[0-9]+")

func FindDigits(filename string) []byte {
    b, _ := ioutil.ReadFile(filename)
    return digitRegexp.Find(b)
}
```

这段代码的行为和描述类似，返回的 `[]byte` 指向保存整个文件的数组。因为切片引用了原始的数组， 导致 GC 不能释放数组的空间；只用到少数几个字节却导致整个文件的内容都一直保存在内存里。

要修复整个问题，可以将感兴趣的数据复制到一个新的切片中：

```
func CopyDigits(filename string) []byte {
    b, _ := ioutil.ReadFile(filename)
    b = digitRegexp.Find(b)
    c := make([]byte, len(b))
    copy(c, b)
    return c
}
```

可以使用 `append` 实现一个更简洁的版本。这里的原理其实类似于 C #中引用类型对象一样，只要程序运行过程中，对象始终被运行中的程序给引用了，那么内存中就会一直持有这个对象导致GC无法回收。而在大对象的切片数据处理的时候，需要注意这个问题，可能引发内存暴涨的风险的。

### 映射(map)

go这里的映射，更像是C #中的一种字典结构，而且这种字典是泛型的。下面这段代码，有点类似于C #中的`Dictionary<string,T>`，通过通过make方式创建了一个map对象，并且初始化，得到一个map对象。

````go
package main

import "fmt"

type Vertex struct {
	Lat, Long float64
}

var m map[string]Vertex

func main() {
	m = make(map[string]Vertex)
	m["Bell Labs"] = Vertex{
		40.68433, -74.39967,
	}
	fmt.Println(m["Bell Labs"])
}

//输出结果
{40.68433 -74.39967}

````

#### map实例化

go语言这里对一个object进行实例化的时候都是直接用一个**大括号括起来**，里面直接就是对object的初始化赋值操作。并且这里object里面的每个list都要以**逗号结尾**，如果最后一个list item结尾的时候，没有逗号，那么就会报错。

```go
package main

import "fmt"

type Vertex struct {
	Lat, Long float64
}

var m = map[string]Vertex{
	"Bell Labs": Vertex{
		40.68433, -74.39967,
	},
	"Google": Vertex{
		37.42202, -122.08408,
	},
}

func main() {
	fmt.Println(m)
}

//输出结果
map[Bell Labs:{40.68433 -74.39967} Google:{37.42202 -122.08408}]
```

如果去掉逗号:

````go
"Google": Vertex{
		37.42202, -122.08408,
	}
}
````

那么就会抛出异常：

````go
./prog.go:15:3: syntax error: unexpected newline, expecting comma or }
````

这个在 C #里面是允许的，但是在golang是会直接报错。

#### map省略写法

go语言这里初始化map的时候，struct对应的类型名都可以直接省略掉。比如Vertex 在这里初始化的时候就直接省略掉了。更加简洁。

````go
package main

import "fmt"

type Vertex struct {
	Lat, Long float64
}

var m = map[string]Vertex{
	"Bell Labs": {40.68433, -74.39967},
	"Google":    {37.42202, -122.08408},
}

func main() {
	fmt.Println(m)
}

//输出结果
map[Bell Labs:{40.68433 -74.39967} Google:{37.42202 -122.08408}]
````

#### 判断某个键是否存在

通过双赋值检测某个键是否存在：

```go
elem, ok = m[key]
```

若 `key` 在 `m` 中，`ok` 为 `true` ；否则，`ok` 为 `false`。

若 `key` 不在映射中，那么 `elem` 是该映射元素类型的零值。

````go
package main

import "fmt"

func main() {
	m := make(map[string]int)

	m["Answer"] = 42
	fmt.Println("The value:", m["Answer"])

	m["Answer"] = 48
	fmt.Println("The value:", m["Answer"])

	delete(m, "Answer")
	fmt.Println("The value:", m["Answer"])

	v, ok := m["Answer"]
	fmt.Println("The value:", v, "Present?", ok)
}

//运行结果：
The value: 42
The value: 48
The value: 0
The value: 0 Present? false
````

