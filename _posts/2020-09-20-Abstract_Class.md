---

layout: post
title: 抽象类的作用
categories: .net
description: 使用委托来解耦代码
keywords: dotnet
---

抽象类把Interface和Base Class的功能融合到一起，有接口的特性又有基类的特征，有接口的特征是因为抽象类的子类要实现抽象类里面的抽象方法，而且跟基类一样，如果抽象父类里面有“虚方法”或者是“普通”方法，子类都会继承这些“虚方法”(在没有override的情况下)和“普通”方法。

### 抽象类使用场景

比如在数据库sqlhelper帮助类里面，要针对不同类型的数据库链接不同的connect string,而每个数据库都有LoadData 和SaveData方法，而这个两个方式是必须的。并且不同厂商的数据库实现的方式不一样，数据库connet string不一样。这种场景同时具有接口的特性，也同时具备父类和子类的特征。抽象类就比较适合这种场景。

<img src="https://cs-cn.top/images/posts/ClassDiagram347.png"/>

子类override了父类的方法的时候，仍然可以通过base直接调用父类的方法。并且，父类里面如果不是virtual方法，执行的时候这个父类方法会按照原样被调用。

````c#
public class SqliteDataAccess : DataAccess
    {
        public override string LoadConnectionString(string name)
        {
            string output = base.LoadConnectionString(name);

            output += " (from SQLite)";

            return output;
        }

        public override void LoadData(string sql)
        {
            Console.WriteLine("Loading SQLite Data");
        }

        public override void SaveData(string sql)
        {
            Console.WriteLine("Saving data to SQLite");
        }
    }
````

````c#
 public class SqlDataAccess : DataAccess
    {

        public override void LoadData(string sql)
        {
            Console.WriteLine("Loading Microsoft SQL Data");
        }

        public override void SaveData(string sql)
        {
            Console.WriteLine("Saving data to Microsoft SQL Server");
        }
    }
````

````c#
 public abstract class DataAccess
    {
        public virtual string LoadConnectionString(string name)
        {
            Console.WriteLine("Load Connection String");
            return "testConnectionString";
        }

        public abstract void LoadData(string sql);
        public abstract void SaveData(string sql);
    }
````

````c#
 public interface IDataAccess
    {
        string LoadConnectionString(string name);
        void LoadData(string sql);
        void SaveData(string sql);
    }
````



注意：抽象类里面不一定所有方法都是抽象方法，可以是一部分是抽象方法，其他方法是虚方法或者是正常普通的方法。但是抽象方向一定是在抽象类里面。抽象类同时保留了接口和父类特征，有对子类的行为约束，子类继承父类的普通方法。



