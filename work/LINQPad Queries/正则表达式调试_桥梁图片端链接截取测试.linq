<Query Kind="Program">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
    <Persist>true</Persist>
  </Connection>
</Query>

void Main()
{
    var newStr="top:8802/jketdev/1648448949357/%E6%A1%A5%E6%A2%81_3a02e163a46dfdf9c347ab64f8feee44.jpg?X-Amz-Algorithm=AWS4-HMAC-SHA256&amp;X-Amz-Credential=root%2F20220328%2Fus-east-1%2Fs3%2Faws4_request&amp;X-Amz-Date=20220328T071342Z&amp;X-Amz-Expires=600&amp;X-Amz-SignedHeaders=host&amp;X-Amz-Signature=aad155fe915398177eaf974f03dace4d3c7a76ba18b34081a2caeffcfda41ef4";	
    var bb= 	Regex.Matches (newStr, @"(.*?)\?.*", RegexOptions.None);
	var dd=bb[0];
	var ee=dd.Groups[1];
	var cc=string.Empty;
}

