<Query Kind="Statements">
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

var List = (from dictionar in bge_dictionars
join dictionarySub in bge_dictionary_subs
	on (int)dictionar.Id equals dictionarySub.Dic
join dictionarySubTable in bge_dictionary_sub_tables
	on (int)dictionarySub.Id equals (int)dictionarySubTable.Item_id
join bgeLineInfo in bge_line_infos
	on (int)dictionarySubTable.Tabler_id equals (int)bgeLineInfo.Id
			where (dictionar.En_name == "limit_level" && bgeLineInfo.Name == "主线"&&bgeLineInfo.Enable==1) select new 
			{
				bridge_line_id = dictionarySubTable.Tabler_id,
				dict_en_name = dictionar.En_name,
				data_dict_name = dictionarySub.Data_name,
				data_dict_id = dictionarySubTable.Item_id,
				bridge_id = bgeLineInfo.Bge_id
			}).OrderByDescending(d=>d.bridge_id).ToList().Dump();