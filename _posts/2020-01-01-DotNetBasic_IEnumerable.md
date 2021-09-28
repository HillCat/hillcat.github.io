---

layout: post
title: DotNetCore项目初始化
categories: DotNetBasic
description: .net技术笔记
keywords: DotNetCore
---
经常会在阅读开源项目代码的时候遇到下面类似的代码：

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

本质上这是一个接口，接口里面有个方法GetEnumerator()，这个方法返回的是一个迭代器Enumerator，类似下面这样：

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

