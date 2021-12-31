---
layout: post
title: ABP_Vnext_AutoFac自动注入
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

ABPVnext使用Autofac自动注入之后，有个大坑，就是字类和接口的命名约定，名字必须一致，要不然会报注入错误。并且很难排查. 出现如下的报错日志，下次要记得，90%是因为这里的命名约定不一致导致的。

![image-20211231110925209](/images/posts/image-20211231110925209.png)

```c#
2021-12-31 09:34:17.247 +08:00 [ERR] An exception was thrown while activating GDBS.BridgeService.HttpApi.Controller.BgeSurfaceDeviceInfoController.
Autofac.Core.DependencyResolutionException: An exception was thrown while activating GDBS.BridgeService.HttpApi.Controller.BgeSurfaceDeviceInfoController.
 ---> Autofac.Core.DependencyResolutionException: None of the constructors found with 'Autofac.Core.Activators.Reflection.DefaultConstructorFinder' on type 'GDBS.BridgeService.HttpApi.Controller.BgeSurfaceDeviceInfoController' can be invoked with the available services and parameters:
Cannot resolve parameter 'GDBS.BridgeService.Application.Contracts.BgeSurfaceDeviceInfo.IBgeSurfaceDeviceAppService bgeSurfaceDeviceAppService' of constructor 'Void .ctor(GDBS.BridgeService.Application.Contracts.BgeSurfaceDeviceInfo.IBgeSurfaceDeviceAppService)'.
   at Autofac.Core.Activators.Reflection.ReflectionActivator.GetValidConstructorBindings(ConstructorInfo[] availableConstructors, IComponentContext context, IEnumerable`1 parameters)
   at Autofac.Core.Activators.Reflection.ReflectionActivator.ActivateInstance(IComponentContext context, IEnumerable`1 parameters)
   at Autofac.Core.Resolving.InstanceLookup.CreateInstance(IEnumerable`1 parameters)
```

第二种，就是没有设置DbSet；这个也是很容易被忽略的。

![image-20211231170918313](/images/posts/image-20211231170918313.png)

