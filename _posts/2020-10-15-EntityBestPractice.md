---

layout: post
title: EntityFramework最佳实践
categories: .net
description: EntityFrameworkBestPractices
keywords: .net
---
EntityFramework快速创建本地LocalDB的增删改查程序示例。

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

update-database命令执行完成之后，数据库得到第一次初始化，这个时候数据库中出了实体表之外，还会有个Migration的记录表，里面记录了Migration迁移所使用到的迁移记录的MigrationId。

<img src="https://cs-cn.top/images/posts/migration_Id1153.png"/>



### 对字段的长度进行修改

<img src="https://cs-cn.top/images/posts/datatable2419.png"/>

如果是普通的类，没有对其字段的长度进行限制，那么code first模式生成出来的table里面的string字段就是max的。

我们可以分别对各个类的属性字段进行一定的限制。

<img src="https://cs-cn.top/images/posts/limited_address2624.png"/>



### 修改字段类型

<img src="https://cs-cn.top/images/posts/zip_code23537.png"/>

默认情况下string类型的字段会被自动创建为nvarchar(max)类型，如果要修改为varchar类型,使用Column Attribute进行标注。

```c#
 [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string ZipCode { get; set; }
```

这个Column特性是位于命名空间： System.ComponentModel.DataAnnotations.Schema，使用codefrist模式相对而言在开发过程中是非常灵活方便的。如果是等到Application用户很多了，已经上了正式生产环境了，用户数量都已经非常多了，那个时候再来修改数据表字段类型就会很麻烦。

<img src="https://cs-cn.top/images/posts/dataanotation_scheme3756.png"/>

注意事项：修改字段长度的时候，有可能造成数据丢失。比如把FirstName长度为100的原来的表，修改为长度为50，如果原来的表中含有的数据中存在长度超过50的FirstName，当使用codefirst缩短为50的时候，原来数据库中的某些数据会被截断为50，造成数据丢失。

<img src="https://cs-cn.top/images/posts/Migration_Validation0705.png"/>
