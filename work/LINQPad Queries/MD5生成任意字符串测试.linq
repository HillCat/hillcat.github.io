<Query Kind="Statements" />

using (var md5 = System.Security.Cryptography.MD5.Create())
{
	var result = md5.ComputeHash(Encoding.UTF8.GetBytes("123456SafeSalt"));
	var strResult = BitConverter.ToString(result);
	string result3 = strResult.Replace("-", "").ToLower();
	Console.WriteLine(result3);
}