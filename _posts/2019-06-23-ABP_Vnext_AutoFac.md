---
layout: post
title: ABP_Vnext_AutoFac自动注入
categories: DotNetCore
description: 
keywords: ABP_Vnext笔记
typora-root-url: ../
---

ABPVnext使用Autofac自动注入之后，有个大坑，就是子类和接口的命名约定，名字必须一致，要不然会报注入错误。并且很难排查. 出现如下的报错日志，下次要记得，90%是因为这里的命名约定不一致导致的。

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

第二种，就是没有设置DbSet；这个也是很容易被忽略的。如果没有设置Dbset，那么会报错提示类似Int32找不到。

![image-20211231170918313](/images/posts/image-20211231170918313.png)

![image-20211231171629493](/images/posts/image-20211231171629493.png)

第三种：不要用Private，而要用Public。

![image-20220427191836828](/images/posts/image-20220427191836828.png)

第四种：忘记了把DbContext添加到Abp的Context上下文里面。这个往往会被坑死。特别是同时操作了2个不同的ConnectionString的数据表的时候。特别容易忘记这个配置。

配置DbContext上下文，这个地方如果没有配置，也会发生报错Int32找不到Table主键。

![bLZhsDBHiu](/images/posts/bLZhsDBHiu.png)

![rider64_YhsvEpzKJ8](/images/posts/rider64_YhsvEpzKJ8.png)

具体报错如下：

```
[ERR] An exception was thrown while activating Castle.Proxies.AnkiDataManagerServiceProxy.
Autofac.Core.DependencyResolutionException: An exception was thrown while activating Castle.Proxies.AnkiDataManagerServiceProxy.
 ---> Autofac.Core.DependencyResolutionException: None of the constructors found with 'Autofac.Core.Activators.Reflection.DefaultConstructorFinder' on type 'Castle.Proxies.AnkiDataManagerServiceProxy' can be invoked with the available services and parameters:
Cannot resolve parameter 'Volo.Abp.Domain.Repositories.IRepository`2[LiveCaptionReceiver.Entities.AnkiNotesEntity,System.Int32] englishTextRepository' of constructor 'Void .ctor(Castle.DynamicProxy.IInterceptor[], Volo.Abp.Domain.Repositories.IRepository`2[LiveCaptionReceiver.Entities.AnkiNotesEntity,System.Int32], Volo.Abp.Uow.IUnitOfWorkManager, Microsoft.Extensions.Logging.ILogger`1[LiveCaptionReceiver.Services.AnkiDataManagerService])'.
   at Autofac.Core.Activators.Reflection.ReflectionActivator.GetAllBindings(ConstructorBinder[] availableConstructors, IComponentContext context, IEnumerable`1 parameters)
   at Autofac.Core.Activators.Reflection.ReflectionActivator.ActivateInstance(IComponentContext context, IEnumerable`1 parameters)
   at Autofac.Core.Activators.Reflection.ReflectionActivator.<ConfigurePipeline>b__11_0(ResolveRequestContext ctxt, Action`1 next)
   at Autofac.Core.Resolving.Middleware.DisposalTrackingMiddleware.Execute(ResolveRequestContext context, Action`1 next)
   at Autofac.Builder.RegistrationBuilder`3.<>c__DisplayClass41_0.<PropertiesAutowired>b__0(ResolveRequestContext ctxt, Action`1 next)
   at Autofac.Core.Resolving.Middleware.ActivatorErrorHandlingMiddleware.Execute(ResolveRequestContext context, Action`1 next)
   --- End of inner exception stack trace ---
   at Autofac.Core.Resolving.Middleware.ActivatorErrorHandlingMiddleware.Execute(ResolveRequestContext context, Action`1 next)
   at Autofac.Core.Resolving.Middleware.SharingMiddleware.Execute(ResolveRequestContext context, Action`1 next)
   at Autofac.Core.Resolving.Middleware.CircularDependencyDetectorMiddleware.Execute(ResolveRequestContext context, Action`1 next)
   at Autofac.Core.Resolving.ResolveOperation.GetOrCreateInstance(ISharingLifetimeScope currentOperationScope, ResolveRequest request)
   at Autofac.Core.Resolving.ResolveOperation.ExecuteOperation(ResolveRequest request)
   at Autofac.ResolutionExtensions.TryResolveService(IComponentContext context, Service service, IEnumerable`1 parameters, Object& instance)
   at Autofac.ResolutionExtensions.ResolveService(IComponentContext context, Service service, IEnumerable`1 parameters)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
   at Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator.Create(ControllerContext actionContext)
   at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass6_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextExceptionFilterAsync>g__Awaited|26_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
2022-11-03 05:45:30.107 +08:00 [ERR] ---------- Exception Data ----------
ActivatorChain = Castle.Proxies.AnkiDataManagerServiceProxy
```

第五种情况，没有把模块依赖写入，导致程序启动不了：

![image-20230709132936061](/images/posts/image-20230709132936061.png)

