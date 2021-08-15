---
layout: post
title: Out和Ref区别
categories: interview
description: .net面试
keywords: English
---
Out关键是用来返回多个value的；在参数传入out的时候不需要初始化，而传出out的时候，参数是需要初始化的。Ref在这个地方刚好和Out相反，在传入Ref之前必须要初始化，而传出Ref之前无需初始化。Out是参数的单向传递，而Ref的参数是可以双向传递的。

### Out演示代码

下面是Out参数的演示：

```c#
// C# program to illustrate the
// concept of out parameter
using System;
  
class GFG {
  
    // Main method
    static public void Main()
    {
  
        // Declaring variable
        // without assigning value
        int G;
  
        // Pass variable G to the method
        // using out keyword
        Sum(out G);
  
        // Display the value G
        Console.WriteLine("The sum of" + 
                " the value is: {0}", G);
    }
  
    // Method in which out parameter is passed
    // and this method returns the value of
    // the passed parameter
    public static void Sum(out int G)
    {
        G = 80;
        G += G;
    }
}
```

输出结果：

```c#
The sum of the value is: 160
```



### Ref演示代码

下面是Ref参数的演示：

```c#
// C# program to illustrate the
// concept of ref parameter
using System;

class GFG {

	// Main Method
	public static void Main()
	{

		// Assign string value
		string str = "Geek";

		// Pass as a reference parameter
		SetValue(ref str);

		// Display the given string
		Console.WriteLine(str);
	}

	static void SetValue(ref string str1)
	{

		// Check parameter value
		if (str1 == "Geek") {
			Console.WriteLine("Hello!!Geek");
		}

		// Assign the new value
		// of the parameter
		str1 = "GeeksforGeeks";
	}
}

```

输出结果：

```c#
Hello!!Geek
GeeksforGeeks
```



### Out和Ref的区别

| Ref                                                          | Out                                               |
| :----------------------------------------------------------- | :------------------------------------------------ |
| 参数在传递给 ref 之前应该初始化。                            | 没有必要在参数传递到 out 之前对其进行初始化。     |
| 在返回调用方法之前不需要初始化参数的值。                     | 有必要在返回调用方法之前初始化参数的值。          |
| 当被调用的方法还需要更改传递参数的值时，通过 ref 参数传递值非常有用。 | 当方法返回多个值时，通过 out 参数声明参数很有用。 |
| 当使用 ref 关键字时，数据可以双向传递。                      | 当使用 out 关键字时，数据仅以单向方式传递。       |

参考资料：[https://www.geeksforgeeks.org/difference-between-ref-and-out-keywords-in-c-sharp/?ref=leftbar-rightbar](https://www.geeksforgeeks.org/difference-between-ref-and-out-keywords-in-c-sharp/?ref=leftbar-rightbar)

