---
layout: post
title: 泛型
categories: DotNetCore
description: .net的泛型
keywords: .net的泛型
typora-root-url: ../
---
泛型出来之前，在.net的类库中有一个叫做ArrayList对象的类型，这个类型是一个`list<object>`类型的对象，里面可以存入字符串类型的对象，也可以存入数字类型的对象。当通过数组下标获取对象的时候，非常容易引发系统异常，而且取出对象的时候都要进行类型的转换，频繁出现装箱拆箱的操作，非常影响性能。

### 如果没有泛型，会发生什么

如果没有泛型，需要面对的问题有：

1. 参数类型写死的问题。
2. 会有拆箱装箱的问题。比如：方法形参声明要求是一个object类型，而传递了一个int类型，这个时候会遇到装箱的问题，从栈里面到堆里面，数据转换的时候会有性能损失。

泛型对应的英文单词Generic， 非泛型Non-Generic.

Generic：List<T>  , IEnumerable<T> 

Non-Generic:

### 泛型是如何避免拆箱和装箱的

1. 声明的时候没有指定参数类型，到了调用的时候才指定类型。
2. 使用了延迟声明,其实就是把编译阶段延后到了JIT运行时编译，JIT的编译反射。

#### 延迟声明，底层是怎么实现的？

问题：C#里面的泛型需要编译器和JIT同时支持。这里比较难的是运行时编译的时候，如何证明JIT把占位符给替换为真实类型了？

回答：无法通过调试的方式实时看到，但是能够通过对比强类型声明和泛型声明方法的**执行耗时**来推导证明。

1. 编译器，有占位符把T类型给占位；
2. JIT第二次运行时编译的时候，通过反射会把占位符替换为真实的类型。

通过一个测试，调用三种不同的方法，三种方法的参数类型分别是 int类型，object类型，泛型T；通过for循环1亿次分别调用3个方法，通过秒表计时，会发现明确指定了参数类型的方法和泛型方法，在耗时上面是基本相同的。而object类型的方法执行的时候由于发生了拆箱装箱，性能耗时基本是前者的2倍。这个主要是得益于JIT即时编译，把正确的类型最终转化为二进制本地代码。通过性能耗时上面对比，推测出泛型方法和原生的“强类型被明确声明指定”的这种方法，在耗时上基本一致，推导出泛型内部的机制，最终是把占位符给替换为了和”强类型被明确声明指定“一样的类似的代码，要不然，它们的性能不可能会那么一致。



### 泛型的特点

泛型是一种可以通过多种方式改进您的程序的技术，例如：

- 它可以帮助您实现代码重用、性能和类型安全。
- 您可以创建自己的通用类、方法、接口和委托。
- 您可以创建通用集合类。.NET 框架类库在 System.Collections.Generic 命名空间中包含许多新的泛型集合类。
- 您可以在运行时获取有关泛型数据类型中使用的类型的信息。



### 泛型的优势

- **可重用性：**您可以在同一代码中将单个泛型类型定义用于多种用途，而无需进行任何更改。例如，您可以创建一个通用方法来将两个数字相加。此方法可用于添加两个整数和两个浮点数，而无需对代码进行任何修改。
- **类型安全：**泛型数据类型提供更好的类型安全，特别是在集合的情况下。使用泛型时，您需要定义要传递给集合的对象类型。这有助于编译器确保只有那些在定义中定义的对象类型才能传递给集合。
- **性能：**与普通系统类型相比，泛型类型提供更好的性能，因为它们减少了对变量或对象的装箱、拆箱和类型转换的需要。



### 参考资料

[https://www.geeksforgeeks.org/c-sharp-generics-introduction/](https://www.geeksforgeeks.org/c-sharp-generics-introduction/)

[https://www.differencebetween.com/difference-between-generic-and-vs-non-generic-collection-in-c/#Similarities%20Between%20Generic%20and%20Non-Generic%20Collection%20in%20C#](https://www.differencebetween.com/difference-between-generic-and-vs-non-generic-collection-in-c/#Similarities%20Between%20Generic%20and%20Non-Generic%20Collection%20in%20C#)

