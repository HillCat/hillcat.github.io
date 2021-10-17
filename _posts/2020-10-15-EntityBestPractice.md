---

layout: post
title: EFCore实践&构造Mock数据/Mysql安装
categories: DotNetCore
description: EntityFrameworkBestPractices
keywords: .net
typora-root-url: ../
---
EFCore快速创建本地LocalDB的增删改查。

首先，创建一个WebApplication项目基于.netcore的，其次在解决方案中创建一个.netLibrary项目，基于.netStandard标准的，这个Library项目中创建实体Models和DataAccess。Models文件夹中创建实体类。DataAccess中创建context类继承至DbContext，这个类里面DbSet<T>到具体的实体类。context子类的options通过父类DbContext传递进来。

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

`Update-Database`命令执行完成之后，数据库得到第一次初始化，这个时候数据库中出了实体表之外，还会有个Migration的记录表，里面记录了Migration迁移所使用到的迁移记录的MigrationId。



### 对字段的长度进行修改

<img src="https://cs-cn.top/images/posts/2827887.png"/>

如果是普通的类，没有对其字段的长度进行限制，那么code first模式生成出来的table里面的string字段就是max的。

我们可以分别对各个类的属性字段进行一定的限制。

<img src="https://cs-cn.top/images/posts/vis88.png"/>



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

### DbMigration注意事项

为了避免在Update-Database的时候发生各种异常情况：

````shell
Your startup project doesn't reference Microsoft.EntityFrameworkCore.Design
````

貌似是新EFcore的一个BUG,大多数情况下不会有这个问题，解决方案在中途添加其他项目的时候，偶尔会出现这个错误。网络上的解决办法各种各样的都有。

Microsoft.EntityFrameworkCore.Design和Microsoft.EntityFrameworkCore.Tools要一起安装。Startup项目webapplication也得安装。

<img src="https://cs-cn.top/images/posts/EntityFramework31259.png"/>



### 生成Mock Data

默认创建的web application中index.cshtml.cs文件中注入PeopleContext。创建和生成大量的mock data数据对于开发阶段测试非常有帮助，能够帮助提升开发效率，比如某些情况下SQL去重的问题，数据库中如果只有5条测试数据，是很难发现SQL的问题的，如果数据量有5万条，那么很方便的检测我们写的SQL是否有问题，常见的问题就是SQL忘记去重，导致上到正式环境的时候，用户使用过程中发现大量的重复数据，就是因为开发初期，没有足够的数据进行测试导致的，而Bogus可以一键生成几万条数据，方便我们测试。Bogus的免费版足够使用，付费版本开发效率更高。更多参考：[Bogus Library for Fake Data In ASP.NET Core WebAPI](https://medium.com/scrum-and-coke/quick-proof-of-concept-asp-net-core-web-api-using-swashbuckle-aspnetcore-and-bogus-19977c84d4a2#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6ImFkZDhjMGVlNjIzOTU0NGFmNTNmOTM3MTJhNTdiMmUyNmY5NDMzNTIiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJuYmYiOjE2MzQyNTEwNzMsImF1ZCI6IjIxNjI5NjAzNTgzNC1rMWs2cWUwNjBzMnRwMmEyamFtNGxqZGNtczAwc3R0Zy5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsInN1YiI6IjEwNDI0MTYwMTE4ODMyMDQ1MTMzMyIsImVtYWlsIjoiY2FpYW5odWFAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImF6cCI6IjIxNjI5NjAzNTgzNC1rMWs2cWUwNjBzMnRwMmEyamFtNGxqZGNtczAwc3R0Zy5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsIm5hbWUiOiLpvpnnjKsiLCJwaWN0dXJlIjoiaHR0cHM6Ly9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tL2EtL0FPaDE0R2hxakZISXVzdDc5czB1OGd1YXJpUnZWNjVoOWtNeGJJUGJKbHMyR0E9czk2LWMiLCJnaXZlbl9uYW1lIjoi54yrIiwiZmFtaWx5X25hbWUiOiLpvpkiLCJpYXQiOjE2MzQyNTEzNzMsImV4cCI6MTYzNDI1NDk3MywianRpIjoiOGYxZDM3YzQwMzNhYTlkZmNlOThhNjQzNTM2NmM5Y2ZiNTI3MjQ1OCJ9.ELbUyqoSOwMXbBCf78AJ291Q2em1dhZ34BH4RQnNPNo5q5u8xSALqPuR_wnIsjPyIEvBMBap5UarV1V9O-JMrMLhPn9YGIQk7hW6u_IyjpARN5lp2L9upd8lqnSBpL5W_kCwjbX_UVSMq5uOqxS5J6B9ZtyNxrbLwGICg4Td6xd_r5Xwtfg43MCNSRlDi5Lvn6eHvylJq_oXdNW5tOP4vXL5Vdff0vzXvhTbF8BRr7ZE8R2_qT9VyjusaVPCZxFsA2GIKxDbR8elG47_bZWq1PnQJjKiv5SAePzSCfu8lhfXZCyht7a0h1Ers11FYv18Ds-HNnaS87tKELkaKkZh9g)

````c#
 private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger,PeopleContext db)
        {
            _logger = logger;
            _db = db;
        }
````

web application的Startup.cs中配置好依赖注入项。

````c#
public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PeopleContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddRazorPages();
        }
````

#### 1.Bogus生成Mock data

为了测试增删改查，我们需要构造一些假数据供自己测试。这里使用[Bogus](https://github.com/bchavez/Bogus)这个开源项目的Nuget包生成Mock Data。把生成出来的文件序列化为Json放到项目配置文件中，便于开发调试接口。Bogus的商业版本[购买地址](https://www.bitarmory.com/bogus)，价格是RMB:66元一年。

````c#
 Randomizer.Seed = new Random(9353526);

            var EmailGenerator = new Faker<Email>()
                .RuleFor(e => e.EmailAddress, f => f.Internet.Email());
            var AddressGenerator = new Faker<Address>()
                .RuleFor(a => a.City, f => f.Person.Address.City)
                .RuleFor(a => a.State, f => f.Person.Address.State)
                .RuleFor(a => a.StreetAddress, f => f.Person.Address.Street)
                .RuleFor(a => a.ZipCode, f => f.Person.Address.ZipCode);


            var PersonGenerator = new Faker<EFDataAccessLibrary.Person>()
                .RuleFor(p => p.Addresses, f => AddressGenerator.Generate(f.Random.Number(1, 5)).ToList())
                .RuleFor(p => p.Age, f => f.Random.Int(20, 72))
                .RuleFor(p => p.EmailAddresses, f => EmailGenerator.Generate(f.Random.Number(1, 3)).ToList())
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName);

           
            var data = PersonGenerator.Ignore(p=>p.Id).Generate(120);

            var text = JsonSerializer.Serialize(data);
            Console.WriteLine(text);
````

<img src="https://cs-cn.top/images/posts/fake_data_generator5407.png"/>

#### 2.Mock Data入库

如果生成mock data的时候没有对自增Id设置规则，Id全部默认是零，Id=0。这样子方便进行批量替换，移除掉这些Id,交给数据库自己生成。

在razor page页面中的后台代码中，单独写一个方法，页面加载的时候mock data被写入数据库中。

`````c#
  public void OnGet()
        {
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            if (!_db.People.Any())
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _db.AddRange(people);
                _db.SaveChanges();
            }
        }
`````

<img src="https://cs-cn.top/images/posts/fake_data102.png"/>

私人git仓库demo地址：[https://gitee.com/caianhua/youtube-dot-net-core.git](https://gitee.com/caianhua/youtube-dot-net-core.git)

#### 3.Mock data支持中文

默认情况下Bogus是不支持中文字符串的，需要自己扩充，提供json文本，具体的扩展方法，可以查看官方源码。而我们可以根据自己的项目实际需要，限定mock数据的范围，比如：项目中的地级市只能限定在广东省，那么提供的mock数据源我们自己可以提前写在json文本中，Bogus框架生成数据的时候直接从json文本中取；下面是官方提供的一些自定义中文字符的代码：

```tex
If you want to add your own lorem at runtime, you can try the following

 var myLorem = new Bogus.Bson.BObject

              {

                 {"words", new BArray{"猫", "狗"}}

              };

 var zhCN = Bogus.Database.GetLocale("zh_CN");

 zhCN.Add("lorem", myLorem);
 var faker = new Faker("zh_CN");

faker.Lorem.Word().Dump();


// OUTPUT:

猫

For future, if you have questions, please create a GitHub issue this way these answers can help other people too. If you'd like more code examples of how to "patch" a locale with extra data, you can find those in the following tests:

https://github.com/bchavez/Bogus/blob/b9049abf8b40203c09079741bcb328da95899f81/Source/Bogus.Tests/BsonTests.cs
```



### 监听EFcore

使用sql server Management studio 连接localDb之后监听Efcore执行sql的过程。

开启sql server management studio,server name填入`(LocalDB)\.`,连接到local临时数据库。

<img src="https://cs-cn.top/images/posts/vs_management_studio9531.png"/>

通过SQL Server Management Studio监控到数据库中执行的sql，可以截获EF最终发往sql server的sql。

<img src="https://cs-cn.top/images/posts/ef_db_monitor04018.png"/>

过滤出我们想要的监控数据,这里面显示的duration时间单位是`微秒`。 1微秒 μs =0.001 毫秒 ms

<img src="https://cs-cn.top/images/posts/filter_data1681.png"/>

### Efcore查询数据

<img src="https://cs-cn.top/images/posts/the_data_selected2929.png"/>

#### 关联查询

通过Efcore把我们构造的Mock data数据全部加载出来。通过sql server management studio 监控到的sql如下：

````sql
SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], 
[a].[Id], [a].[City],[a].[PersonId], [a].[State], [a].[StreetAddress], 
[a].[ZipCode], [e].[Id], [e].[EmailAddress], [e].[PersonId] 
FROM [People] AS [p]  
LEFT JOIN [Addresses] AS [a] ON [p].[Id] = [a].[PersonId]  
LEFT JOIN [EmailAddresses] AS [e] ON [p].[Id] = [e].[PersonId]  
ORDER BY [p].[Id], [a].[Id], [e].[Id]
````

上面这个语句，实际上查询出来了724行数据。模拟数据中Pepole只有120个，但是Efcore查出来的结果有724行，其中有很多行的“部分数据”出现了重复。如果有非常多的Table间的LEFT JOIN查询，实际上查出来的数据量是非常大的，对于性能是有很大的影响的。特别是同时有很多人同时请求数据库的时候，这个数据行数会成几何倍数的增长，严重时可能造成数据库响应缓慢超时。

<img src="https://cs-cn.top/images/posts/left_join2231.png"/>

如果不对导航属性进行关联查询，得到的数据量是120行,得到的查询语句如下：

````sql
  # Csharp代码
  var people = _db.People
                //.Include(a => a.Addresses)
                //.Include(e => e.EmailAddresses)
                .ToList();
  # EF CORE 产生的SQL
SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName]  FROM [People] AS [p]
````

通过监控EF Core产生的SQL，可以让我们清楚的知道EF底层到底给我们生成了什么样的SQL，防止编写出性能低下的代码。

#### LINQ查询注意事项

下面是对于某一年龄段的人员数据进行查询，单独编写了一个C#方法，放到EFcore查询中。相比于`Where(x=>x.Age>=18 && x.Age <=65)`这种，C # 这种代码放到Linq中会导致`运行时报错`，提示C#代码无法翻译为sql.

````c#
 public void OnGet()
        {
            LoadSampleData();
            var people = _db.People
                .Include(a => a.Addresses)
                .Include(e => e.EmailAddresses)
                .Where(x=>ApprovedAge(x.Age))
               // .Where(x=>x.Age>=18 && x.Age <=65)
                .ToList();
        }

        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age <= 65);
        }
````

<img src="https://cs-cn.top/images/posts/Translate_Failed05032.png"/>



正常情况下`Where(x=>x.Age>=18 && x.Age <=65)`这种，上面的Linq得到的SQL如下：

````sql
SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [a].[Id], [a].[City], 
[a].[PersonId], [a].[State], [a].[StreetAddress], [a].[ZipCode], [e].[Id],
[e].[EmailAddress], [e].[PersonId]  
FROM [People] AS [p]  
LEFT JOIN [Addresses] AS [a] ON [p].[Id] = [a].[PersonId]  
LEFT JOIN [EmailAddresses] AS [e] ON [p].[Id] = [e].[PersonId]  
WHERE ([p].[Age] >= 18) AND ([p].[Age] <= 40)  ORDER BY [p].[Id], [a].[Id], [e].[Id]
````

### 关于EF Core



1.开发速度快。只需要少量的代码，就可以实现SQL一长串代码才能实现的功能，弊端是没有原生SQL性能高。如果想追求高性能，所有的查询都使用原生SQL，那么开发速度又会降低。

2.不必知道太多的SQL。这对于某些不太熟悉SQL的人而言，使用EF可能是一个福利。但是话有说回来，如果不太懂SQL的话，那就不会去用sql server management studio去监控EF生产的SQL代码从而进一步去优化SQL，也就无法写出高性能代码，无法对性能低下的代码做优化。根据监控到的sql 耗时来优化我们的查询。所以，使用EF的前提是必须要非常熟悉SQL才能更好驾驭EF。当应用程序的用户数量不多的时候，前期使用EF可能不会导致性能问题，但是随着应用程序的用户规模变得庞大，这个时候EF引发的性能问题就需要非常熟悉SQL优化的人才能够驾驭得了。

过度自信于上面2个‘好处’，会给平时的代码开发带来一定的风险，主要是性能上面的隐藏风险，而这些东西在项目上线的前期，用户数量少的时候是很难发现的。性能低，内存开销大的程序，会导致硬件服务器需要支付更多的内存，消耗更多的电力，给公司造成更高的成本。EF的坏处是，如果给到经验不足的人去驾驭EF，会引发潜在的性能问题，并且这种潜在的问题当被发现的时候已经太迟了。

### 关于Dapper

1.相比于Ef而言具备更高的生产运行性能。

2.对于**熟悉SQL的开发人员**更加友好。精确控制生产出来的SQL的同时，修改起来也非常快捷。

3.可以更好的解耦代码。如果是要在不同应用层之间传递数据，用Dapper只需要使用Class传递数据即可，而如果使用EF，在每个层上面都要依赖EF这个包，使得程序更加臃肿耦合度更高。

如果说要二选一的话，一般建议是EF Core和Dapper结合使用，但是作为比较熟悉SQL的人而言会更加倾向于Dapper。







