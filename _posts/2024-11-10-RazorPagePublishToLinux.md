---
layout: post
title: RazorPagePublishToLinuxBtDashBoard
categories: Math
description: Blazor
keywords: Blazor
typora-root-url: ../

---

Razor Page部署到Debian 12 ，宝塔面板中，使用Nginx做反向代理，然后程序启动的时候监听localhost:5000端口，外网使用3000端口访问。首先是在Debian12系统上面，按照微软官方文档，安装好.net core 8.0 LTS版本的稳定版本的cli  SDK之后，publish 项目的时候可以选择potable方式，vs2022的设置如下：

![image-20241110220216962](/media/image-20241110220216962.png)

![image-20241110220243001](/media/image-20241110220243001.png)

压缩为zip压缩包，然后上传到宝塔面板中。

![image-20241110221115494](/media/image-20241110221115494.png)

因为这个截图是在4K分辨率显示器上截图的，所以会看到界面上宝塔面板对于px像素兼容屏幕这块还是又文字堆积的情况。Razor Page项目部署到Linux上面主要是要设置Nginx反向代理。以及这个文件里面需要明确指定一下useStaticFile这个地方的代码，另外一定要注意，文件归属的group和你要运行执行这个程序的group要是同一个权限组，我这里使用的宝塔默认的权限组'www'这个权限组。

因为.net core的useStaticFile这个中间件，在Linux上面运行的时候，都是查找当前执行程序的当前user的用户组，如果你是用超级root权限执行，会发现页面会找不到js路径，它会去找root/wwwroot/这个路径，而不是找www/wwwroot/这个路径作为静态文件的根目录。

![image-20241110221625250](/media/image-20241110221625250.png)

项目执行文件：/www/ICS-Print-Debug/HK-ICS-Print-Debug.dll

项目名称：ICS_Print

项目端口：5000

执行命令：dotnet /www/ICS-Print-Debug/HK-ICS-Print-Debug.dll

运行用户：www

是否开机启动：是

![image-20241110221800683](/media/image-20241110221800683.png)

![image-20241110223937147](/media/image-20241110223937147.png)

文件这块，权限/所有者，基本能够看出来这个执行文件是www的。所以上面设置的那个“运行用户”也是www。y要不然会出现Nginx定向到.net core的时候，页面中的js，css会报错404.

![image-20241110224022866](/media/image-20241110224022866.png)

![image-20241110224247636](/media/image-20241110224247636.png)

这个就是Nginx的代理的地址3000端口，这个端口是需要在防火墙放开的。而Razor Page ，.net core8.0程序的端口是localhost:5000.

![image-20241110224708781](/media/image-20241110224708781.png)

