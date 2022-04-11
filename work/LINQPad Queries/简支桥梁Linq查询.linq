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
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>


var jzlDtoList=await (from jzl in  bge_superstructrue_info_jzls 
               join bgline in bge_line_infos  on (int)jzl.Beginfo_id.Value equals (int)bgline.Id into gline
			   from line in gline.DefaultIfEmpty()
			   join bge in bge_infos on (int)line.Bge_id  equals (int)bge.Id into gbge
			   from bridge in gbge.DefaultIfEmpty()
			   orderby jzl.Id descending
			   select new bgeSupJzlCustomReportDto{
			   	bge_no=bridge.Bge_no,
				bge_name=bridge.Name,
				bge_line_name=line.Name,
				bridge_span_form=(from bgesub in bge_dictionary_subs where bgesub.Id==line.Struct_type select bgesub.Data_name).FirstOrDefault(),
				span_serial_number=jzl.Span_serial_number,
				main_girder_material=(from bgesub in bge_dictionary_subs where bgesub.Id==jzl.Main_girder_material select bgesub.Data_name).FirstOrDefault(),
				main_girder_count=jzl.Main_girder_count,
				section_form=(from bgesub in bge_dictionary_subs where bgesub.Id==jzl.Section_form select bgesub.Data_name).FirstOrDefault(),
				main_girder_height=jzl.Main_girder_height,
				main_girder_width=jzl.Main_girder_width,
				main_girder_cross_length=jzl.Main_girder_cross_length,
				beam_material=(from bgesub in bge_dictionary_subs where bgesub.Id==jzl.Beam_material select bgesub.Data_name).FirstOrDefault(),
				beam_count=jzl.Beam_count,
				beam_section_form=(from bgesub in bge_dictionary_subs where bgesub.Id==jzl.Beam_section_form select bgesub.Data_name).FirstOrDefault(),
				beam_height=jzl.Beam_height,
				beam_length=jzl.Beam_length,
				beam_thickness=jzl.Beam_thickness,
				wet_seam_count=jzl.Wet_seam_count,
				wet_seam_width=jzl.Wet_seam_width,
				span_length=jzl.Span_length
			   }).ToListAsync().Dump();
			   