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

### IIS调试部署

参考：[win10 IIS 托管DotNetCore](https://youtu.be/Q_A_t7KS5Ss)

给windows添加IIS的时候，全部勾选上必要的选项；

然后win + R ，输入inetmgr 打开IIS管理面板。

![win10_install_iis_2717.png](/images/posts/win10_install_iis_2717.png)

1.首先是在IIS中建立好一个Server，比如：Mywebsite,路径设置为C盘中的C:\inetpub\wwwroot\Mywebsite.然后把默认的APP池设置为No Managed Code。

![defualt_pooling_2827.png](/images/posts/defualt_pooling_2827.png)



2.把项目属性中的debug环境设置Development改为Production，这是发布到IIS之前需要做的事情。

![production_enviroment_18172.png](/images/posts/production_enviroment_18172.png)

3.然后是发布到本地电脑的某个文件夹中：

![publish_to_some_filepath_28271.png](/images/posts/publish_to_some_filepath_28271.png)

4.这里设置Portable是为了让Dotnetcore程序可以运行在任何类型的操作系统环境中，是跨平台的，默认就是这么设置的。

![deployment_settings_2827.png](/images/posts/deployment_settings_2827.png)

5.如果是发布程序到C盘，那么请用administrator打开visual studio 2019并执行发布操作。

![publish_visual_studio2019_18173.png](/images/posts/publish_visual_studio2019_18173.png)



6.最后需要安装DotNetCore的Host模块。

参考微软官方文档：[Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-5.0)，直接下载最新版本的Hosting Bundle。

![host_bundle_837.png](/images/posts/host_bundle_837.png)

参考上面这个链接提供的信息，安装IIS的DotNet Host模块。安装完成之后，发布到IIS目录下面的项目就可以访问了。

![iis_open_dotnetcore_2348.png](/images/posts/iis_open_dotnetcore_2348.png)

### 常见问题

IIS部署完微服务之后，访问本地微服务端口会报错，查看EventViewer能够发现更具体的报错信息，是因为我们把程序发布到C盘，系统盘没有访问权限导致的。

![fabucuowu_873628.png](/images/posts/fabucuowu_873628.png)

如果是发布DotNetCore程序到本地win10机器的C盘，会出现Access Denied 。需要配置文件夹访问权限。需要设置inetpub下面www文件夹的Everyone访问权限。参考资料 [设置c盘inetpub_wwwroot目录权限](https://youtu.be/A_0SqnOPSng)

![image-20211021063130600](/images/posts/image-20211021063130600.png)

![image-20211021063215111](/images/posts/image-20211021063215111.png)



![image-20211021063249095](/images/posts/image-20211021063249095.png)

给予全部访问权限即可，设置完成之后，发布到C盘inetpub/wwwroot目录下面的所有.net core程序访问权限就具备了。



