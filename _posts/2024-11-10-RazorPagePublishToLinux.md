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

下面是publish之后的项目打包文件：

![image-20241110220243001](/media/image-20241110220243001.png)

整个打包文件压缩为zip压缩包，通过宝塔面板的“文件”菜单，上传到根目录www目录中，创建一个你自己的文件夹，然后上传到这个文件夹中，我这里设置的是ICS-Print-Debug文件夹，上传压缩包zip之后解压到当前目录。

![image-20241110221115494](/media/image-20241110221115494.png)

默认上传到www文件夹下面的文件，所属的权限组是www，用户组也是www。然后配置这个程序的启动项，.net core项目选择“其他项目”，在项目信息页面中进行启动配置,如下：

~~~~json
项目执行文件：/www/ICS-Print-Debug/HK-ICS-Print-Debug.dll
项目名称：ICS_Print
项目端口：5000
执行命令：dotnet /www/ICS-Print-Debug/HK-ICS-Print-Debug.dll
运行用户：www
是否开机启动：是
~~~~

宝塔面板这里的“项目名称”只支持下划线，单横线这种是不支持的，注意。

![image-20241110221625250](/media/image-20241110221625250.png)

运行用户这里，要和你的程序所属的权限组用户名一致，这里默认是www这个用户。因为我们是吧程序文件放到了根目录的www用户文件夹下面，所以.net core默认的静态根目录是寻找当权user所在的wwwroot目录，所以.net core的静态根目录就是/www/wwwroot/这个文件夹。如果这个不一致就会出现wwwroot里面js和css文件报错，出现http请求404错误，比如你直接在Linux命令行以root用户运行这个程序的时候，会发现前端的js,css引用路径找不到报404错误，因为root用户，默认的.net core静态文件路径是/root/wwwroot/

![image-20241110221800683](/media/image-20241110221800683.png)

![image-20241110223937147](/media/image-20241110223937147.png).Nginx的反向代理配置比较简单，域名管理这里，只需要配置服务器的对外公网IP地址加上端口即可。这里我配置的是3000端口号，指向宿主机的localhost:5000端口。

![image-20241110224247636](/media/image-20241110224247636.png)

这个就是Nginx的代理的地址3000端口，这个端口是需要在防火墙放开的。而Razor Page ，.net core8.0程序的端口是localhost:5000.

![image-20241110224708781](/media/image-20241110224708781.png)

