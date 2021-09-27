---

layout: post
title: DotNetCore框架源码解读(1)_Claim | ASP.NET CORE Identity
categories: DotNetCore
description: DotNetCore权限验证
keywords: .net
---

导读：本文会从.net core框架的身份权限验证一直到IdentityServer4这块跟.net core集成，做一个系列的篇章。调用各种国内外的各种资源，对.net core权限授权验证这一块知识进行一个拓展。本文会不定期更新完善。

微软的.net core框架中进行权限验证相关的一些原理，相关的资源：

权限验证涉及到的系统中的命名空间：

System.Security.Permissions

System.Security.Claims                ------ Volo.Abp.Security  在系统库的基础上进行了扩展

System.Security.AccessControl

System.Security.Principal

System.Security.SecureString

System.Security.Cryptography    -----密码学

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









