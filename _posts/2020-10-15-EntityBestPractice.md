---

layout: post
title: EntityBestPractices
categories: .net
description: EntityFrameworkBestPractices
keywords: .net
---
EntityFramework快速创建本地LocalBd的增删改查程序示例。

首页，创建一个WebApplication项目基于.netcore的，其次在解决方案中创建一个.netLibrary项目，基于.netStandard标准的，这个Library项目中创建实体Models和DataAccess。Models文件夹中创建实体类。DataAccess中创建context类继承至DbContext，这个类里面DbSet<T>到具体的实体类。context子类的options通过父类DbContext传递进来。

DbContext的配置项opitons参数通过WebApplication端Startup.cs中ConfigureServices配置，通过services.AddDbContext<T>

### Models

```c#
 public class Address
    {
        public int Id { get; set; }
        public string StreetAddress   { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


    }
```

```c#
  public class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
    }
```

```c#
public class Person 
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> EmailAddresses { get; set; }
    }
```

### DataAccess

```c#
 public class PeopleContext:DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options){}
        public  DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }

    }
```



### Startup.cs ConfigureServices

AddDbContext，把DbContext通过依赖注入的方式引入到系统中，并且配置好options参数，设置好对SqlServer的配置。

```c#
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PeopleContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddRazorPages();
        }
```

### addsettings.json

配置好本地数据库地址

```c#
  "ConnectionStrings": {
    "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFDemoWeb;Integrated Security=True;"
  } 
```



### DataMigration Stript

<img src="https://cs-cn.top/images/posts/sql_exploer5750.png"/>

<img src="https://cs-cn.top/images/posts/EntityFrameworkScript0028.png"/>

如果这个Package Manager Console中的字体太小，也是可以调整的：

<img src="https://cs-cn.top/images/posts/Package_Manager_Console104.png"/>



#### Migration Tools

非常容易忘记安装Migration Tools的Nuget工具包，会导致如下错误：

<img src="https://cs-cn.top/images/posts/Migration308.png"/>

<img src="https://cs-cn.top/images/posts/migration_tools506.png"/>

定位到EFDataAccessLibray项目，使用Migration Tools,执行Add-Migration InitialDBCreation,得到一个Migration脚本。

<img src="https://cs-cn.top/images/posts/Migration_Files244.png"/>

在脚本中可以看到两个方法，一个是Up，一个是Down，Up是将要执行的语句，而Down是回滚语句。

数据库外键这里，`FK_Addresses_People_PersonId`意思是Addresses Link到People表(通过PersonId)。principal是主表， constraints表示含有外键的这个表。PersonId是这个表里面的外键。`onDelete: ReferentialAction.Restrict`这是一种强关联的模式，主表在删除的时候，如果关联了外键，那么就需要连同外键一并删除。

```c#
 constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
```

