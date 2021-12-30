---

layout: post
title: Go语言快速入门：函数和接口(6)
categories: Go
description: Golang相关笔记
keywords: Golang
typora-root-url: ../
---
Go没有类的概念，只有Strtuct这个东西，而要想达到 C # 那样子给类添加方法，就是给go的Struct添加方法。 这个语法有点类似于 C # 里面给class添加扩展方法的思路。所以go这个语法是非常好理解的。

### 给类添加方法

go官方对给结构体定义方法，是这么描述的：

`方法就是一类带特殊的 **接收者** 参数的函数。方法接收者在它自己的参数列表内，位于 func 关键字和方法名之间。`

这个描述，跟C #里面对于扩展方法的描述我感觉是同一个东西，只是长得不一样。

````go
//在此例中，Abs 方法拥有一个名为 v，类型为 Vertex 的接收者。
package main

import (
	"fmt"
	"math"
)

type Vertex struct {
	X, Y float64
}

func (v Vertex) Abs() float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

func main() {
	v := Vertex{3, 4}
	fmt.Println(v.Abs())
}

//以上是一个数学运算，计算的是数组的平方根，输出结果
5
````



<img src="https://cs-cn.top/images/posts/go_function45929.png"/>

整体而言语法还是比较精简。下面是官方的定义：

````tex
方法就是一类带特殊的 接收者 参数的函数。

方法接收者在它自己的参数列表内，位于 func 关键字和方法名之间。

在此例中，Abs 方法拥有一个名为 v，类型为 Vertex 的接收者。
````



#### 方法里面传递一个对象

````go
package main

import (
	"fmt"
	"math"
)

type Vertex struct {
	X, Y float64
}

func Abs(v Vertex) float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

func main() {
	v := Vertex{3, 4}
	fmt.Println(Abs(v))
}
````



#### 为其他类型声明方法

go语言里面除了可以给struct声明方法之外，还可以给非struct的类型声明方法。但是只能是同一个包内定义的接收者，不能是其他包内的类型或者是golang语言内置的类型。

````go
package main

import (
	"fmt"
	"math"
)

type MyFloat float64

func (f MyFloat) Abs() float64 {   //就是接收者的类型定义和方法声明必须在同一包内；不能为内建类型声明方法
	if f < 0 {
		return float64(-f)
	}
	return float64(f)
}

func main() {
	f := MyFloat(-math.Sqrt2)
	fmt.Println(f.Abs())
}

````

#### 指针接收者(*)

对于指针接收者，这里需要注意的事情就是，这是一个比较常用的手段，因为函数经常需要修改接收者。下面是官方指南的说明：

````te
指针接收者的方法可以修改接收者指向的值（就像 Scale 在这做的）。由于方法经常需要修改它的接收者，指针接收者比值接收者更常用。

试着移除第 16 行 Scale 函数声明中的 *，观察此程序的行为如何变化。

若使用值接收者，那么 Scale 方法会对原始 Vertex 值的副本进行操作。（对于函数的其它参数也是如此。）Scale 方法必须用指针接受者来更改 main 函数中声明的 Vertex 的值。
````



````go
package main

import (
	"fmt"
	"math"
)

type Vertex struct {
	X, Y float64
}

func (v Vertex) Abs() float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

func (v *Vertex) Scale(f float64) { //如果把这里的指针的* 去掉的话，程序输出结果为 5， 也就是说原来的值没有改变
	v.X = v.X * f
	v.Y = v.Y * f
}

func main() {
	v := Vertex{3, 4}
	v.Scale(10)
	fmt.Println(v.Abs())
}

//输出结果为 50


````

#### 方法和函数的关系

方法只是个带接收者参数的函数。  如果拿C # 的语法来理解的话，这里的go里面的方法其实属于**“对象成员”**，函数是单独存在。

#### 方法与指针重定向

这里的重定向，指的是"成员方法"会根据

````go
package main

import "fmt"

type Vertex struct {
	X, Y float64
}

func (v *Vertex) Scale(f float64) {
	v.X = v.X * f
	v.Y = v.Y * f
}

func ScaleFunc(v *Vertex, f float64) {
	v.X = v.X * f
	v.Y = v.Y * f
}

func main() {
	v := Vertex{3, 4}
	v.Scale(2)
	ScaleFunc(&v, 10)

	p := &Vertex{4, 3}
	p.Scale(3)
	ScaleFunc(p, 8)

	fmt.Println(v, p)
}

//输出结果
5
````

带指针参数的**函数**必须接受一个指针：

```
var v Vertex
ScaleFunc(v, 5)  // 编译错误！
ScaleFunc(&v, 5) // OK
```

而以指针为接收者的**方法**被调用时，接收者既能为值又能为指针：

```
var v Vertex
v.Scale(5)  // OK
p := &v
p.Scale(10) // OK
```

对于语句 `v.Scale(5)`，即便 `v` 是个值而非指针，带指针接收者的方法也能被直接调用。 也就是说，由于 `Scale` 方法有一个指针接收者，为方便起见，Go 会将语句 `v.Scale(5)` 解释为 `(&v).Scale(5)`。

总结：指针类似于C # 里面的引用类型， 声明的时候带上 符号*，调用的时候带上 符号 & . 

这里，最为重要的就是理解指针其实是一个引用。



````go
package main

import (
	"fmt"
	"math"
)

type Vertex struct {
	X, Y float64
}

func (v Vertex) Abs() float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

func AbsFunc(v Vertex) float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

func main() {
	v := Vertex{3, 4}
	fmt.Println(v.Abs())
	fmt.Println(AbsFunc(v))

	p := &Vertex{4, 3}
	fmt.Println(p.Abs()) //会被解释为 (*p).Abs()
	fmt.Println(AbsFunc(*p))
}

//输出结果：
5
5
5
5
````

##### 函数和方法的区别

接受一个值作为参数的函数必须接受一个指定类型的值：

```tex
var v Vertex
fmt.Println(AbsFunc(v))  // OK
fmt.Println(AbsFunc(&v)) // 编译错误！
```

而以值为接收者的方法被调用时，接收者既能为值又能为指针：

```tex
var v Vertex
fmt.Println(v.Abs()) // OK
p := &v
fmt.Println(p.Abs()) // OK
```

### 选择值或指针作为接收者

<img src="https://cs-cn.top/images/posts/function_1324.png"/>

```go
package main

import (
	"fmt"
	"math"
)

type Vertex struct {
	X, Y float64
}

func (v *Vertex) Scale(f float64) {
	v.X = v.X * f
	v.Y = v.Y * f
}

func (v *Vertex) Abs() float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

func main() {
	v := &Vertex{3, 4}
	fmt.Printf("Before scaling: %+v, Abs: %v\n", v, v.Abs())
	v.Scale(5)
	fmt.Printf("After scaling: %+v, Abs: %v\n", v, v.Abs())
}

//输出结果
Before scaling: &{X:3 Y:4}, Abs: 5
After scaling: &{X:15 Y:20}, Abs: 25
```

使用指针接收者的好处是避免在每次调用方法的时候复制该值，对于大型结构体更加高效。

C #的比较：这里的指针接收者类似于C #里面使用比较普遍的引用类型。指针接收者指向的对象的值被修改。这里的指针类型更像是C #中的“类型实例”。



### 接口

golang里面的接口跟C#里面的接口差不多。

```go
package main

import (
	"fmt"
	"math"
)

type Abser interface {
	Abs() float64
}

func main() {
	var a Abser
	f := MyFloat(-math.Sqrt2)
	v := Vertex{3, 4}

	a = f  // a MyFloat 实现了 Abser
	a = &v // a *Vertex 实现了 Abser

	// 下面一行，v 是一个 Vertex（而不是 *Vertex）
	// 所以没有实现 Abser。
	a = v

	fmt.Println(a.Abs())
}

type MyFloat float64

func (f MyFloat) Abs() float64 {
	if f < 0 {
		return float64(-f)
	}
	return float64(f)
}

type Vertex struct {
	X, Y float64
}

func (v *Vertex) Abs() float64 {
	return math.Sqrt(v.X*v.X + v.Y*v.Y)
}

```

上面的代码a = v ，这里v这个对象并没有提供接口的实现，所以不能用v来给a赋值。

```go
./prog.go:22:4: cannot use v (type Vertex) as type Abser in assignment:
	Vertex does not implement Abser (Abs method has pointer receiver)
```

#### 接口的隐式实现

golang中对于接口的隐式实现，从表面上看这里仅仅是给一个普通的类型增加了一个方法的具体实现而已。并没有显式地声明我们实现了某个接口。

```go
package main

import "fmt"

type I interface {
	M()
}

type T struct {
	S string
}

// This method means type T implements the interface I,
// but we don't need to explicitly declare that it does so.
func (t T) M() {
	fmt.Println(t.S)
}

func main() {
	var i I = T{"hello"}
	i.M()
}

```

