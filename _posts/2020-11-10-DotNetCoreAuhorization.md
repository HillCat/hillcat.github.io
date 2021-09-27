---

layout: post
title: DotNetCore框架源码解读(1)_Claim | ASP.NET CORE Identity
categories: DotNetCore
description: DotNetCore权限验证
keywords: .net
---

导读：本文会从.net core框架的身份权限验证一直到IdentityServer4这块跟.net core集成，做一个系列的篇章。调用各种国内外的资源，对.net core权限授权验证这一块进行一个拓展。本文会不定期更新完善。

微软的.net core框架中进行权限验证相关的一些原理，相关的资源：

权限验证涉及到的系统中的命名空间：

System.Security.Permissions

System.Security.Claims                ------ Volo.Abp.Security  在系统库的基础上进行了扩展

System.Security.AccessControl

System.Security.Principal

System.Security.SecureString

System.Security.Cryptography    -----密码学



 1.ClaimsPrincipal, ClaimsIdentity and Claim | ASP.NET CORE Identity & Security Series | Episode #3

[https://youtu.be/3i0RcKrVyTo](https://youtu.be/3i0RcKrVyTo)



