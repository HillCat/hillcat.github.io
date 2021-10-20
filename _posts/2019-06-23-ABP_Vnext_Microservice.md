---
layout: post
title: ABP_Vnext_Microservice_Practice
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

### 微服务

ABP_Vnext微服务架构，参考文档：[ABP Framework微服务文档](https://docs.abp.io/zh-Hans/abp/latest/Samples/Microservice-Demo)

#### 端口号

01 **AuthServer**：8087   登陆验证

02 **PublicGateway**： 8088  微服务网关

03 **ProjectService**：8089  菜单权限

04 Shared 公共帮助类库

05 **BridgeService**：8090 桥梁服务

06 ReceAndSendMsgService ：8086  桥梁收发文服务

07 ProvincialLevelService ：8082 省级服务

08 ThirdPartyService ：8083 桥梁第三方服务

09 MonitoringService ：8084  桥梁监听服务

10 LogService ： 8085  通用日志服务
