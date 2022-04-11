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

var zhlDtoList = await(from zhl in bge_superstructrue_info_zhls
					   join bgline in bge_line_infos on (int)zhl.Beginfo_id.Value equals (int)bgline.Id into gline
					   from line in gline.DefaultIfEmpty()
					   join bge in bge_infos on (int)line.Bge_id equals (int)bge.Id into gbge
					   from bridge in gbge.DefaultIfEmpty()
					   orderby zhl.Id descending
					   select new bgeSupZhlCustomReportDto
					   {
						   bge_no = bridge.Bge_no,
						   bge_name = bridge.Name,
						   bge_line_name = line.Name,
						   bridge_span_form = (from bgesub in bge_dictionary_subs where bgesub.Id == line.Struct_type select bgesub.Data_name).FirstOrDefault(),
						   main_girder_section_form=(from bgesub in bge_dictionary_subs where bgesub.Id == zhl.Main_girder_section_form  select bgesub.Data_name).FirstOrDefault(),
						   main_girder_height=zhl.Main_girder_height.ToString(),
						   main_girder_length=zhl.Main_girder_length.ToString(),
						   main_girder_width=zhl.Main_girder_width.ToString(),
						   is_variable_section=zhl.Is_variable_section==1?"是":"否",
						   beam_material=(from bgesub in bge_dictionary_subs where bgesub.Id == zhl.Beam_material select bgesub.Data_name).FirstOrDefault(),
						    beam_count=zhl.Beam_count.ToString(),
							beam_section_form=(from bgesub in bge_dictionary_subs where bgesub.Id == zhl.Beam_section_form select bgesub.Data_name).FirstOrDefault(),
							beam_height=zhl.Beam_height.ToString(),
							bridge_panel_material=(from bgesub in bge_dictionary_subs where bgesub.Id == zhl.Bridge_panel_material select bgesub.Data_name).FirstOrDefault(),
							bridge_panel_width=zhl.Bridge_panel_width.ToString()
					   }).ToListAsync().Dump();
