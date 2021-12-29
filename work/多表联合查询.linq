<Query Kind="Program">
  <Connection>
    <ID>f0adcb30-ee29-47d7-9518-31792c5f079e</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="linq2db.LINQPad" PublicKeyToken="no-strong-name">LinqToDB.LINQPad.LinqToDBDriver</Driver>
    <Provider>MySqlConnector</Provider>
    <Server>81.70.158.167</Server>
    <Database>gdbs_dev</Database>
    <DbVersion>5.7.34-log</DbVersion>
    <CustomCxString>SERVER=81.70.158.167; PORT=3306; DATABASE=gdbs_dev; USER=root; PASSWORD=lmz123456;</CustomCxString>
    <ExcludeRoutines>true</ExcludeRoutines>
    <DisplayName>腾讯云测试库</DisplayName>
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
	//var DataList = (from D in bge_dictionar_classes
	//				join A in bge_dictionars on (int)D.Id equals A.Belong_class_id
	//				join B in bge_dictionary_subs
	//				on (int)A.Id equals B.Dic
	//				where (tableList.Contains(A.Belong_table_name) && B.State == 1)
	//			
	//				select new { Level1_id = D.Id, Level1_name = D.Name, Level2_id = A.Id, Level2_name = A.Name, Level2_en_name = A.En_name, Level3_id = B.Id, Level1Key = A.Belong_table_name, level3_data_name = B.Data_name, B.State }).Dump();

var TEMP=	(from A in bge_superstructure_infos
	join B in bge_superstructrue_info_ctns 
	on A.Beginfo_id equals B.Beginfo_id 
	join C in bge_superstructrue_info_yjls
	on B.Beginfo_id equals C.Beginfo_id 
	join D in bge_superstructrue_info_xbls
	on C.Beginfo_id equals D.Beginfo_id 
	select  new {A,B,C,D}).ToListAsync().Dump();


}
// You can define other methods, fields, classes and namespaces here