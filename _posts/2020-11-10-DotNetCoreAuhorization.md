---

layout: post
title: DotNetCore框架源码解读(1)_Claim | ASP.NET CORE Identity
categories: DotNetCore
description: DotNetCore权限验证
keywords: .net
---

导读：本文会从.net core框架的身份权限验证一直到IdentityServer4这块做一个系列文章。本文涉及到的内容较多，会不断完善。

.net core框架权限验证这块，有很多概念是需要搞清楚的，先是一些关键概念，然后是建立在这些概念上的原理。

[.net core权限验证API](https://source.dot.net/#q=System.Security)涉及到的命名空间：

````c#
System.Security.Permissions

System.Security.Claims  // Volo.Abp.Security  在此API的基础上进行了扩展

System.Security.AccessControl

System.Security.Principal

System.Security.SecureString

System.Security.Cryptography // 加密解密相关库

Microsoft.AspNetCore.Identity //对于Identity中属性的一些定义
````





### 基础概念

#### Authentication & Authorization

*Authentication → Who you are*

*Authorization → What you can do*

权限验证的时候，服务器端一般需要知道Who you are ，以及还需要知道What you can do；一个是要知道访问者的身份，还一个是需要知道访问者的权限(能够做什么)。

系统自带的类库，提供了一些简单的Authorization验证方法。比如：

[Microsoft.AspNetCore.Authorization](https://source.dot.net/#Microsoft.AspNetCore.Authorization/AuthorizeAttribute.cs,ce39c167c3cf6799,references)



#### Principal

Security Context里面包含了所有用户的信息，比如用户ID，用户名，地址等信息；这些信息一般是封装在了一个Object对象中，在.net core中这个Object对象叫做claims principle,或者叫做principal object.在一定程度上它可以直接代表user.这个principal里面含有很多Identities。即：**一个用户可以有很多Identity。**比如1个人可以有多种身份：学生，雇员，司机。

<img src="https://cs-cn.top/images/posts/Identity27182.png"/>



#### Identity_options

系统自带的类库中，有对Identity一些options做限制的。详细可以了解[Microsoft.AspNetCore.Identity源码](https://source.dot.net/#Microsoft.Extensions.Identity.Core/IdentityOptions.cs,c4d151da9fa86f53)。

<img src="https://cs-cn.top/images/posts/IdentityOptions59.png"/>

Identity中，.net core可以对于Identiy中的option做一些限制，比如：可以对用户的密码组成进行限制，密码的长度等。

<img src="https://cs-cn.top/images/posts/Identity5498.png"/>



##### Claim

一个Identity可以有多个claim。Claim在.net core中一般是键值对形式存在。比如Identity为司机，但是司机可以有DateStarted，表示这个司机什么时候开始从事这个行业，以计算出司机的工龄。比如3年以下工龄的，5年以上工龄的，这些就可以通过claim来识别。

<img src="https://cs-cn.top/images/posts/claims3858.png"/>

一个比较常见的使用方法就是，从context上下文拿到用户的Claims对象之后查找对应的Type的Value值。以判断用户是否具备某些权限或者条件。

<img src="https://cs-cn.top/images/posts/claim485.png"/>

在国内有一种叫法，叫做“基于声明的认证“，其实“声明”二字就是指的Claim；也就是图中context.User.Claims这种使用方式比较普遍。

一个用户登录之后，可以对多个Claim进行验证。

<img src="https://cs-cn.top/images/posts/claim27357.png"/>



##### Policy

Policy就是Authorization Function，拿到User Context之后，对User数据进行具体的验证的Function，对应的是一组处理规则。如果验证失败，返回403或401错误等。

<img src="https://cs-cn.top/images/posts/Policy0981.png"/>

对于policy的使用，比如.net core里面对Authorization的option进行一些设置：

<img src="https://cs-cn.top/images/posts/policy4940.png"/>

### 框架提供的功能



参考：[Authentication&Authorization in Asp.Net Core -Part 1](https://medium.com/c-sharp-progarmming/authentication-and-authorization-in-asp-net-core-part-1-188866c4115e)

​           [https://github.com/T0shik/rolesvsclaimsvspolicy](https://github.com/T0shik/rolesvsclaimsvspolicy)

