---
layout: post
title: MatLab软件的使用操作
categories: Math
description: 高等数学
keywords: 高等数学
typora-root-url: ../

---

MatLab软件的操作和使用。在学习高等数学的时候，经常用到一些仿真的方式来加快某些公式的理解，可以通过调试仿真参数生成曲线图或者3D图片的方式来增加对于抽象概念的理解。类似的软件在手机端也有很多，最强大和专业的还是MatLab.《马同学图解数学》中经常用到很多动态图片，其实就是使用类似MatLab生成的。

![image-20231125163442559](/images/posts/image-20231125163442559.png)

#### 1.清除控制台

```shell
clc
```

![image-20231125163523074](/images/posts/image-20231125163523074.png)

#### 2.清楚右侧工作区

```shell
clear all
```

![image-20231125163954096](/images/posts/image-20231125163954096.png)

#### 3.MatLab数据类型和运算符

##### 3.1字符串

字符串使用单引号包裹，类似于JavaScript里面的语法。变量要以字母开始。书写的脚本可以复制之后点击运行，有点类似于Sqlserver Management Studio中操作sql语句。

![image-20231125164122953](/images/posts/image-20231125164122953.png)

##### 3.2选中代码执行

MatLab中支持选中脚本执行，比如:char(97) ,执行之后得到字符串 a ;

![image-20231125164446169](/images/posts/image-20231125164446169.png)

##### 3.3 常见语法

###### 3.3.1 字符串的长度

```matlab
str ='Hello World!'
length(str)
```

###### 3.3.2 数字转字符串

```matlab
num2str(65)
```

![image-20231125174137286](/images/posts/image-20231125174137286.png)

###### 3.3.3 矩阵运算

矩阵运算是MatLab中最为强大的功能，很多的数学运算最终可以转为矩阵运算，计算机中的自动驾驶，神经网络等等。

```matlab
A = [1 2 3;4 5 2;3 2 7]
```

![image-20231125174539587](/images/posts/image-20231125174539587.png)

矩阵使用分号隔开，成员之间可以使用空格或者逗号分开。

