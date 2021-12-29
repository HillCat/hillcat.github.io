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
	var tableList=new List<string>(){ "bge_superstructure_info","bge_superstructrue_info_ctn","bge_superstructrue_info_yjl","bge_superstructrue_info_xbl" };
	tableList.Dump();
	var DataList=(from D in bge_dictionar_classes
	join A in bge_dictionars on (int)D.Id equals A.Belong_class_id
	join B in bge_dictionary_subs
	on (int)A.Id equals B.Dic 
	where (tableList.Contains(A.Belong_table_name) && B.State==1 )
//    group A by A.En_name
//    into groupedDemoClass
//    select groupedDemoClass).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList()).Dump();
	select new{Level1_id=D.Id,Level1_name= D.Name,Level2_id=A.Id,Level2_name=A.Name,Level2_en_name=A.En_name,Level3_id=B.Id,Level1Key=A.Belong_table_name,level3_data_name=B.Data_name,B.State}).Dump();
   
	//groupedDemoClass.ToDictionary(d =>d.,d=>d. )
}

// You can define other methods, fields, classes and namespaces here
//对应的csharp代码如下
//var dataList = await(from A in _bgeDictionarEntity
//					 join B in _begeDictionarySubEntity
//						 on (int)A.Id equals B.Dic
//					 where (tableList.Contains(A.Belong_Table_Name) && (int)B.State == 1)
//					 orderby A.En_Name
//					 select new { itemId = A.Id, selector_cn_name = A.Name, selector_en_name = A.En_Name, drop_down_id = B.Id, drop_down_value = B.Data_Name, B.State, remark = A.Belong_Table_Name }
//			   ).ToListAsync();
//var dictObj = from a in dataList
//			  group a by a.selector_en_name
//	into b
//			  select b;
//var dicDto = dictObj.ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());