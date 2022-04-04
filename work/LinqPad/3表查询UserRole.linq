<Query Kind="Statements">
  <Connection>
    <ID>815d4b7b-a83a-4c1e-b8e0-a6236e635b65</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="linq2db.LINQPad" PublicKeyToken="no-strong-name">LinqToDB.LINQPad.LinqToDBDriver</Driver>
    <Provider>MySqlConnector</Provider>
    <Server>localhost</Server>
    <Database>gdbs_identity</Database>
    <DbVersion>5.7.30</DbVersion>
    <CustomCxString>User=root;Password=lmz123456;Database=gdbs_identity;Server=localhost;Port=3306;</CustomCxString>
    <ExcludeRoutines>true</ExcludeRoutines>
    <DisplayName>LocalHostMysql</DisplayName>
    <DriverData>
      <providerName>MySqlConnector</providerName>
      <excludeRoutines>true</excludeRoutines>
      <excludeFKs>false</excludeFKs>
      <optimizeJoins>true</optimizeJoins>
      <commandTimeout>0</commandTimeout>
    </DriverData>
  </Connection>
  <Namespace>static LinqToDB.Reflection.Methods.LinqToDB</Namespace>
</Query>

var list = (from user in sys_users
			join userrole in sys_user_roles
			on (int)user.Id equals userrole.User_id
			join rolename in sys_roles
			on (int)userrole.Role_id equals (int)rolename.Id
			select new { user.Id, userrole.Role_id, user.User_name, user.Account, rolename.Display_name, rolename.Type_name }).GroupBy(x => x.User_name).Select(d => new { UserName = d.First().User_name, Items=d.ToList()}).Dump();

