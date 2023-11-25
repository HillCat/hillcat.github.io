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

## 1.清除控制台

```shell
clc
```

![image-20231125163523074](/images/posts/image-20231125163523074.png)

## 2.清除右侧工作区

```shell
clear all
```

![image-20231125163954096](/images/posts/image-20231125163954096.png)

## 3.MatLab数据类型和运算符

### 3.1字符串

字符串使用单引号包裹，类似于JavaScript里面的语法。变量要以字母开始。书写的脚本可以复制之后点击运行，有点类似于Sqlserver Management Studio中操作sql语句。

![image-20231125164122953](/images/posts/image-20231125164122953.png)

### 3.2选中代码执行

MatLab中支持选中脚本执行，比如:char(97) ,执行之后得到字符串 a ;

![image-20231125164446169](/images/posts/image-20231125164446169.png)

### 3.3 常见语法

#### 3.3.1 字符串的长度

```matlab
str ='Hello World!'
length(str)
```

#### 3.3.2 数字转字符串

```matlab
num2str(65)
```

![image-20231125174137286](/images/posts/image-20231125174137286.png)

#### 3.3.3 矩阵运算

矩阵运算是MatLab中最为强大的功能，很多的数学运算最终可以转为矩阵运算，计算机中的自动驾驶，神经网络等等。

```matlab
A = [1 2 3;4 5 2;3 2 7]
```

![image-20231125174539587](/images/posts/image-20231125174539587.png)

矩阵使用分号隔开，成员之间可以使用空格或者逗号分开。

##### 1 矩阵转置

矩阵的转置：一个矩阵M, 把它的第一行变成第一列，第二行变成第二列，......,最末一行变为最末一列， 从而得到一个新的矩阵N。 这一过程称为矩阵的转置，英文定义：Transpose (转置矩阵)

```matlab
B =A'
```

![image-20231125175051543](/images/posts/image-20231125175051543.png)

##### 2.矩阵拉长

语法：

```matlab
C=A(:)
```

纵向拉长排列

```matlab
>> A = [1 2 3;4 5 2;3 2 7]

A =

     1     2     3
     4     5     2
     3     2     7

>> C=A(:)

C =

     1
     4
     3
     2
     5
     2
     3
     2
     7

>> 
```

##### 3.矩阵求幂

```matlab
D = inv(A)
```

![image-20231125181945888](/images/posts/image-20231125181945888.png)

#### 3.4 绘制二维曲线图

##### 1.绘制x,y坐标平面图

场景：基于x坐标和y坐标，绘制一个二维平面曲线图

```matla
>> x=0:0.3:2*pi;
y=sin(x);
figure
plot(x,y)
```

figure是绘制画布，plot(x,y) 是把这个坐标曲线绘制出来

![image-20231125192421519](/images/posts/image-20231125192421519.png)

这个对于理解线性代数里面的东西非常有帮助。

##### 2.给坐标平面增加注释

```matlab
>> x=0:0.3:2*pi;
>> y=sin(x);
>> figure;
>> plot(x,y);
>> title('y = sin(x)');
>> xlabel('x');
>> ylabel('sin(x)');
```

![image-20231125204943293](/images/posts/image-20231125204943293.png)

如果要控制坐标显示的区域，可以给坐标设置限制范围，比如：限制坐标x显示的范围是 0 到 2*pi的区间，可以如下指令：

````matlab
xlim([0 2*pi])
````

xlim 意思是 x limit的缩写。
