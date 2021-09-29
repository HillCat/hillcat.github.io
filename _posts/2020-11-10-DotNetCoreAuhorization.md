---

layout: post
title: DotNetCore框架源码解读(1)_Claim | ASP.NET CORE Identity
categories: DotNetCore
description: DotNetCore权限验证
keywords: .net
typora-root-url: ../
---

导读：本文会从.net core框架的身份权限验证一直到IdentityServer4这块做一个系列文章。本文涉及到的内容较多，会不断完善。

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

这个类里面主要是设置policy和roles属性，两个都是字符串类型的，policy是指定规则名称字符串，roles是指定角色名称字符串。一般这个数据是存储在数据库里面的。前端用户访问的时候，会从用户信息上下文的Context中拿到这些policy和roles信息进行比对判断用户是否具有某种权限。

Roles具体使用：

<img src="images/posts/Roles5994.png"/>

Policy具体使用：

<img src="images/posts/Policy7849.png"/>

#### Principal

Security Context里面包含了所有用户的信息，比如用户ID，用户名，地址等信息；这些信息一般是封装在了一个Object对象中，在.net core中这个Object对象叫做claims principle,或者叫做principal object.在一定程度上它可以直接代表user.这个principal里面含有很多Identities。即：**一个用户可以有很多Identity。**比如1个人可以有多种身份：学生，雇员，司机。

<img src="https://cs-cn.top/images/posts/Identity27182.png"/>



#### Identity_options

系统自带的类库中，有对Identity一些options做限制的。详细可以参考源码[Microsoft.AspNetCore.Identity源码](https://source.dot.net/#Microsoft.Extensions.Identity.Core/IdentityOptions.cs,c4d151da9fa86f53)。

<img src="/images/posts/IdentityOptions59.png"/>

Identity中，.net core可以对于Identiy中的option做一些限制，比如：可以对用户的密码组成进行限制，密码的长度等。这些都是.net core框架类库自带的一些功能。

##### Claim

一个Identity可以有多个claim。Claim在.net core中一般是键值对形式存在。比如Identity为司机，但是司机可以有DateStarted，表示这个司机什么时候开始从事这个行业，以计算出司机的工龄。比如3年以下工龄的，5年以上工龄的，这些就可以通过claim来识别。

<img src="images/posts/claims3858.png"/>

一个比较常见的使用方法就是，从context上下文拿到用户的Claims对象之后查找对应的Type的Value值。以判断用户是否具备某些权限或者条件。

<img src="https://cs-cn.top/images/posts/claim485.png"/>

在国内有一种叫法，叫做“基于声明的认证“，其实“声明”二字就是指的Claim；也就是context.User.Claim。

一个用户登录之后，可以对多个Claim进行验证。

<img src="https://cs-cn.top/images/posts/claim27357.png"/>



##### Policy

Policy就是Authorization Function，拿到User Context之后，对User数据进行具体的验证的Function，对应的是一组处理规则。微软.net core框架封装了一些常用的操作，通过设置option方便的设置Policy，也可以实现自己的Policy。

<img src="/images/posts/Policy0981.png"/>

对于policy的使用，比如.net core里面对Authorization的option进行一些设置：

<img src="images/posts/policy4940.png"/>

### 框架提供的功能

.net core框架中自带的IdentityUser这个class就包含了一些常用的属性。

````c#
namespace Microsoft.AspNetCore.Identity
{
   
    public class IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
       
        public IdentityUser();
        public IdentityUser(string userName);
        public virtual DateTimeOffset? LockoutEnd { get; set; }
       
        [PersonalData]
        public virtual bool TwoFactorEnabled { get; set; }
        
        [PersonalData]
        public virtual bool PhoneNumberConfirmed { get; set; }
        
        [ProtectedPersonalData]
        public virtual string PhoneNumber { get; set; }
       
        public virtual string ConcurrencyStamp { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PasswordHash { get; set; }
       
        [PersonalData]
        public virtual bool EmailConfirmed { get; set; }
       
        public virtual string NormalizedEmail { get; set; }
       
        [ProtectedPersonalData]
        public virtual string Email { get; set; }
       
        public virtual string NormalizedUserName { get; set; }
        
        [ProtectedPersonalData]
        public virtual string UserName { get; set; }
        
        [PersonalData]
        public virtual TKey Id { get; set; }
        
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public override string ToString();
    }
}
````

​	对应的数据库表结构：

<img src="/images/posts/AspNetUsers543.png"/>



另外，.net core框架自带的IdentityRole这个class也带了常用的属性。

````c#
namespace Microsoft.AspNetCore.Identity
{
    
    public class IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
        
        public IdentityRole();
       
        public IdentityRole(string roleName);
       
        public virtual TKey Id { get; set; }
       
        public virtual string Name { get; set; }
        
        public virtual string NormalizedName { get; set; }
       
        public virtual string ConcurrencyStamp { get; set; }

        public override string ToString();
    }
}
````

对应的数据库表：

<img src="https://cs-cn.top/images/posts/AspNetRoles9934.png"/>



### 参考资料

[Authentication&Authorization in Asp.Net Core -Part 1](https://medium.com/c-sharp-progarmming/authentication-and-authorization-in-asp-net-core-part-1-188866c4115e)

[https://github.com/T0shik/rolesvsclaimsvspolicy](https://github.com/T0shik/rolesvsclaimsvspolicy)

