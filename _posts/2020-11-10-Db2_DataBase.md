---

layout: post
title: Dynamics365开发
categories: .net
description: Db2数据库的使用
keywords: .net
---

微软Dynamics 365支持很多的自定义开发功能，并且为开发人员提供了丰富的资源和接口。总的来说，Dynamics 365的开发模块分为2种：客户端和服务器。

1.客户端开发

我们知道在Dynamics 365中，系统通过表单的形式来向客户展示数据。表单中会包含很多属性，比如字段，子网格等等。Dynamics 365向开发人员提供了专门的客户端API对象来对表单中的内容进行操作，比如控制的字段的赋值，隐藏等等功能。这些功能可以与我们的业务逻辑相互配合，从而实现我们完整的需求。同时表单中提供了多种触发JS代码的条件，用户可以选在在表单加载(OnLoad)，保存(OnSave)，还是指定的字段内容变更时(OnChange)调用我们写好的JS方法。您可以参考下面的技术文章来对Dynamics 365客户端开发进行更详细的学习和了解。

[https://docs.microsoft.com/zh-cn/dynamics365/customer-engagement/developer/clientapi/client-scripting](https://docs.microsoft.com/zh-cn/dynamics365/customer-engagement/developer/clientapi/client-scripting)

同时，Dynamics 365还提供了专门的web api接口，用来从内部或外部对Dynamics 365中的数据进行访问/更改。Dynamics 365 web api基于ODATA 4.0开发，支持不同平台和编程语言。请阅读以下文章进行学习和了解。

[https://docs.microsoft.com/zh-cn/dynamics365/customer-engagement/developer/use-microsoft-dynamics-365-web-api](https://docs.microsoft.com/zh-cn/dynamics365/customer-engagement/developer/use-microsoft-dynamics-365-web-api)

2.服务器开发

Dynamics 365提供了一种名为工作流的机制，用来通过服务器端代码(C#)自动执行对数据的操作。我们可以使用Plug-in Registration Tool工具来把我们写好的代码加载到Dynamics 365中进行运行与测试。我们可以从微软提供的文章中获取更多的信息。

[https://docs.microsoft.com/zh-cn/powerapps/developer/common-data-service/overview](https://docs.microsoft.com/zh-cn/powerapps/developer/common-data-service/overview)

To Plug-in Registration Tool: [https://www.nuget.org/packages/Microsoft.CrmSdk.XrmTooling.PluginRegistrationTool](https://www.nuget.org/packages/Microsoft.CrmSdk.XrmTooling.PluginRegistrationTool)

To SDK: [https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/download-dynamics-365-sdk-v9](https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/download-dynamics-365-sdk-v9)

To plug-in 介绍: [https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-plugin-extend-business-processes](https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-plugin-extend-business-processes)

### app涉及范围

Dynamics 365得APP主要涉及如下方面：
Microsoft Dynamics 365 for Field Service

Microsoft Dynamics 365 for Commerce

Microsoft Dynamics 365 for Sales

Microsoft Dynamics 365 for Finance

Microsoft Dynamics 365 for Project Service Automation

Microsoft Dynamics 365 for Artificial Intelligence

Microsoft Dynamics 365 for Business Central

Microsoft Dynamics 365 for Marketing

Microsoft Dynamics 365 for Human Resources

Microsoft Dynamics 365 for Customer Service

Microsoft Dynamics 365 for Supply Chain Management

Microsoft Dynamics 365 for Project Operations

Microsoft Dynamics 365 for Mixed Reality



