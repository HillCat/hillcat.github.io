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
  <Reference>C:\caianhua\caianhua_work_space\GDBS1.0-service\GDBS.BridgeService\GDBS.BridgeService.HttpApi.Hosting\bin\Debug\netcoreapp3.1\GDBS.BridgeService.Application.Contracts.dll</Reference>
  <Namespace>GDBS.BridgeService.Application.Contracts.BgeReportStatistics</Namespace>
</Query>

var zhlDtoList = await(from gjq in bge_superstructrue_info_gjqs
					   join bgline in bge_line_infos on (int)gjq.Beginfo_id.Value equals (int)bgline.Id into gline
					   from line in gline.DefaultIfEmpty()
					   join bge in bge_infos on (int)line.Bge_id equals (int)bge.Id into gbge
					   from bridge in gbge.DefaultIfEmpty()
					   orderby gjq.Id descending
					   select new bgeSupGjqCustomReportDto
					   {
						   bge_no = bridge.Bge_no,
						   bge_name = bridge.Name,
						   bge_line_name = line.Name,
						   bridge_span_form = (from bgesub in bge_dictionary_subs where bgesub.Id == line.Struct_type select bgesub.Data_name).FirstOrDefault(),
					       span_serial_number=gjq.Span_serial_number,
						   main_girder_material= (from bgesub in bge_dictionary_subs where bgesub.Id == gjq.Main_girder_material select bgesub.Data_name).FirstOrDefault(),
					   }).ToListAsync().Dump();
