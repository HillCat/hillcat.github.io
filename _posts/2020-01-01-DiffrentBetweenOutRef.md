---
layout: post
title: Out和Ref区别
categories: interview
description: .net面试
keywords: English
---
Out和Ref是C#中使用率比较高的两个关键词。

Out关键是用来返回多个value的；在参数传入out的时候不需要初始化，而传出out的时候，参数是需要初始化的。

Ref在这个地方刚好和Out相反，在传入Ref之前必须要初始化，而传出Ref之前无需初始化。

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







参考资料：[https://www.geeksforgeeks.org/difference-between-ref-and-out-keywords-in-c-sharp/?ref=leftbar-rightbar](https://www.geeksforgeeks.org/difference-between-ref-and-out-keywords-in-c-sharp/?ref=leftbar-rightbar)

