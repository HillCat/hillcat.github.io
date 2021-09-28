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

