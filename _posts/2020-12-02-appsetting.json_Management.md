---
layout: post
title: 更好管理appsetting.json文件
categories: DotNetCore
description: VisualStudio常用技巧2
keywords: trpora
typora-root-url: ../
---

在开发微服务过程中，本地开发环境需要在IIS中发布调试，appsettings.json文件经常被github拉取下来的配置给覆盖掉，而本地开发调试使用的配置又和生产环境的不一样。如何既不影响生产环境， 又不用每次拉取的时候覆盖本地的appsettings.json配置呢？可以修改windows10环境变量为Tagging，并且在开发环境中加入appsetting.tagging.json文件，这样子本地开发环境就使用的是这个文件，而不影响生产环境。

具体的设置，可以参考官方文档：[https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-6.0](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-6.0)

参考：[https://stackoverflow.com/questions/50397343/appsettings-json-different-versions](https://stackoverflow.com/questions/50397343/appsettings-json-different-versions)

CMD进入control panel ---> system----->Advanced system settings --------Enviroment Variables设置 

````c#
ASPNETCORE_ENVIRONMENT
Development
````



![image-20220401001159846](/images/posts/image-20220401001159846.png)



![image-20220401003846501](/images/posts/image-20220401003846501.png)

我们可以冗余一份appsetting.Development.json配置文件，然后把本机环境全局变量设置为Development，然后发布到IIS的时候强制输出那份appsetting.Development.json文件。

![image-20220401013157238](/images/posts/image-20220401013157238.png)

````c#
<configuration>
  <system.webServer>
    <handlers>
      <remove name="aspNetCore" />
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="dotnet" arguments=".\SampleNetCoreApp.dll">
      <environmentVariables>
        <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
      </environmentVariables>
    </aspNetCore>
  </system.webServer>
</configuration>
````

````c#
<aspNetCore processPath="dotnet" arguments=".\GDBS.AuthServer.Hosting.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess">
      <environmentVariables>
        <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
      </environmentVariables>
      </aspNetCore>
````

