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

System.Security.Claims                ------ Volo.Abp.Security  在此API的基础上进行了扩展

System.Security.AccessControl

System.Security.Principal

System.Security.SecureString

System.Security.Cryptography    -----加密解密相关库
````





### 基础概念

#### Part1

*Authentication → Who you are*

*Authorization → What you can do*

权限验证的时候，服务器端一般需要知道Who you are ，以及还需要知道What you can do；一个是要知道访问者的身份，还一个是需要知道访问者的权限(能够做什么)。

#### Part2

Security Context里面包含了所有用户的信息，比如用户ID，用户名，地址等信息；这些信息一般是封装在了一个Object对象中，在.net core中这个Object对象叫做claims principle,或者叫做principal object.在一定程度上它可以直接代表user.这个principal里面含有很多Identities。即：**一个用户可以有很多Identity。**比如1个人可以有多种身份：学生，雇员，司机。

<img src="https://cs-cn.top/images/posts/Identity27182.png"/>



一个Identity可以有多个claim。

<img src="https://cs-cn.top/images/posts/claims3858.png"/>





参考：[Authentication&Authorization in Asp.Net Core -Part 1](https://medium.com/c-sharp-progarmming/authentication-and-authorization-in-asp-net-core-part-1-188866c4115e)

​           [https://github.com/T0shik/rolesvsclaimsvspolicy](https://github.com/T0shik/rolesvsclaimsvspolicy)

