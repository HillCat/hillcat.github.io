---
layout: post
title: Application_Domain
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

一些零碎的关于ABP整理的记录。

### ABP_Vnext单体项目

ABP框架是基于规则和约定的，框架内部有非常多默认的规则和约定。

#### 规则约定

Application层对外暴露的DTO会写在Application.Contracts中，而如果是Application层和Domain层交互使用的DTO则写在DomainShared中(内部交互)。



