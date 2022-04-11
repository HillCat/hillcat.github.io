<Query Kind="Program">
  <Connection>
    <ID>815d4b7b-a83a-4c1e-b8e0-a6236e635b65</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="linq2db.LINQPad" PublicKeyToken="no-strong-name">LinqToDB.LINQPad.LinqToDBDriver</Driver>
    <Provider>MySqlConnector</Provider>
    <Server>localhost</Server>
    <Database>gdbs_dev</Database>
    <DbVersion>5.7.30</DbVersion>
    <CustomCxString>User=root;Password=lmz123456;Database=gdbs_dev;Server=localhost;Port=3306;</CustomCxString>
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
</Query>

void Main()
{
	var enums = Enum.GetNames(typeof(BridgeMaintainTypeEnum)).Dump();
	var dics = enums.Select((t,i)=> new BridgeMainTainTypeDicDto() { id = i+10==14?15:i+10, name = t }).ToList().Dump();
	
}

public enum BridgeMaintainTypeEnum
{
	I类养护 = 10,
	ⅱ类养护 = 11,
	ⅲ类养护 = 12,
	ⅳ类养护 = 13,
	ⅴ类养护 = 15
}

public class BridgeMainTainTypeDicDto
{
	public int id { get; set; }
	public string name { get; set; }

}