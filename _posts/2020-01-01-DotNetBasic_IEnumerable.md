---

layout: post
title: IEnumerable和Enumerator
categories: DotNetCore
description: .net技术笔记
keywords: DotNetCore
typora-root-url: ../
---
开源项目代码经常会有如下代码，引发出对IEnumerable和迭代器的讨论。

````c#
public class DisplayViewModel
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersViewModel> Users { get; set; }
    }

    public class UsersViewModel
    {
        public string Email { get; set; }
        public IEnumerable<UsersRole> Roles { get; set; }
    }

public class UpdateUserRoleViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string UserEmail { get; set; }
        public string Role { get; set; }
        public bool Delete { get; set; }
    }
````

IEnumerable<T> 这个是一个接口，主要是提供一个容器来存储泛型类型的集合对象，英文里面把这个T称之为generic对象，与之对应的就是non-generic非泛型对象。下面是这两种的主要区别：

<img src="https://cs-cn.top/images/posts/Collections14511.png"/>

系统中自带的泛型集合，[List<T>](https://source.dot.net/#System.Private.CoreLib/List.cs,cf7f4095e4de7646)这个是非常常见的，它所在的命名空间是：System.Collections.Generic,根据命名空间知道这个是跟泛型有关的，看看它这个对象所继承的接口。会发现它是继承了`interface IEnumerable<out T> : IEnumerable`的。



Non-Generic的例子：

<img src="https://cs-cn.top/images/posts/Non-Generic_Collection6953.png"/>

````c#
namespace System.Collections.Generic
{
    
    public interface IEnumerable<out T> : IEnumerable
    {
        IEnumerator<T> GetEnumerator();
    }
}
````

本质上这是一个接口，接口里面有个方法GetEnumerator()，这个方法返回的是一个迭代器Enumerator，这是一个struct类型，在C#中是属于值类型的，跟class类型不同的是，struct是进行的“值拷贝”，每次分配给一个变量的时候，都会重新开辟一块新的内存区域给到变量，不像class这种引用类型，变量赋值的时候是“引用拷贝”。

```c#
 Enumerator GetEnumerator() => new Enumerator(this);
```

这个Enumerator对象，本质上是一个结构体，具体的代码如下,内部通过MoveNext()方法来迭代遍历。

```c#
/// <summary>
        /// A struct that represents an Enumerator
        /// </summary>
        public struct Enumerator : IEnumerator<KeyValuePair<string, object>>
        {
            private readonly EventData _eventData;
            private readonly int _count;
 
            private int _index;
 
            /// <summary>
            /// Current keyvalue pair.
            /// </summary>
            public KeyValuePair<string, object> Current { get; private set; }
 
            internal Enumerator(EventData eventData)
            {
                _eventData = eventData;
                _count = eventData.Count;
                _index = -1;
                Current = default;
            }
 
            /// <inheritdoc/>
            public bool MoveNext()
            {
                var index = _index + 1;
                if (index >= _count)
                {
                    return false;
                }
 
                _index = index;
 
                Current = _eventData[index];
                return true;
            }
 
            /// <inheritdoc/>
            public void Dispose() { }
            object IEnumerator.Current => Current;
            void IEnumerator.Reset() => throw new NotSupportedException();
        }
```

### 使用Collections的好处

Collections集合的好处，是可以进行Adding，Delteting, Replacing ,Searching，Copying操作。

### Struct Vs Class

通过数组结构存储一组struct和class对比，struct类型的数组在内存中的操作效率要高于class类型的数组。因为struct数组中的成员在内存中的分布是连续的。而class类型的数组在内存中分布是分散的。CPU缓存在操作连续内存的时候速度要快于操作那些分散的内存。连续的内存只需要取一次即可把所有数据全部取到，而分散的内存，需要分很多次去取。

![structArray_112.png](/images/posts/structArray_112.png)



如果是对一个大型的集合对象进行密集计算操作，比如进行一些循环操作，使用struct的性能会更好。从上面的Enumerator也可以看得出来，这个迭代器本质上就是一个struct类型。

如果用一个class类型的变量指向一个struct类型的值，会发生装箱操作，值类型会变为引用类型。

#### struct嵌套

struct中不能嵌套同类型的struct。在内存分配的时候，会引发无限递归的问题。编译器会直接报错。如果是引用类型的嵌套没有这个问题，因为引用类型的内存分配是引用配分，发生嵌套的时候，内存的分配还是分配的引用。

![struct_4873.png](/images/posts/struct_4873.png)

