using Bogus;
using EFDataAccessLibrary;
using EFDataAccessLibrary.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace FakeDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Randomizer.Seed = new Random();
            var faker = new Faker("zh_CN");

            //var emailGenerator = new Faker<Email>()
            //    .RuleFor(e => e.EmailAddress, f => f.Internet.Email());
            //var addressGenerator = new Faker<Address>()
            //    .RuleFor(a => a.City, f => f.Person.Address.City)
            //    .RuleFor(a => a.State, f => f.Person.Address.State)
            //    .RuleFor(a => a.StreetAddress, f => f.Person.Address.Street)
            //    .RuleFor(a => a.ZipCode, f => f.Person.Address.ZipCode);


            //var personGenerator = new Faker<Person>()
            //    //.RuleFor(p => p.Id, f => f.Random.Int())
            //    //.RuleFor(p => p.FirstName, f => f.Lorem.Word())
            //    //.RuleFor(p => p.LastName, f => f.Lorem.Word())
            //    //.RuleFor(p => p.Age, f => f.Random.Int())
            //    //.RuleFor(p => p.Addresses, f => default)
            //    //.RuleFor(p => p.EmailAddresses, f => default);
            //    .RuleFor(p => p.Addresses, f => addressGenerator.Generate(f.Random.Number(1, 5)).ToList())
            //    .RuleFor(p => p.Age, f => f.Random.Int(20, 72))
            //    .RuleFor(p => p.EmailAddresses, f => emailGenerator.Generate(f.Random.Number(1, 3)).ToList())
            //    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            //    .RuleFor(p => p.LastName, f => f.Person.LastName);
            //开始时间
            var startDate = Convert.ToDateTime("2022-03-12 00:00:00");
            //结束时间
            var endDate = Convert.ToDateTime("2022-05-27 00:00:00");
            var taskTimeSpanStart = Convert.ToDateTime("2022-03-10 00:00:00");
            var taskTimeSpanEnd = Convert.ToDateTime("2022-03-12 00:00:00");
            var stringRamdon = new List<string>()
            {
                "维修加固方案或建议",
                "继续监测3-9",
                "测试数据001-hwm-修改后",
                "建议加强保养",
                "检测内容为第一部分实验内容3-28"

            };
            var thirdUnitIdList = new List<ThirdUnitDto>()
            {
                new ThirdUnitDto()
                {
                    upload_insititution_Id = 3,
                    upload_user_Id = 3,
                    det_name = "方羽",
                    detInstitution = "第三方单位1",
                    auditor =  "方羽",
                    detInsititutionId = 3,
                    upload_user_name = "方羽",
                    scheduler = "方羽",
                },
                new ThirdUnitDto()
                {
                    upload_insititution_Id = 17,
                    upload_user_Id = 15,
                    det_name = "刘虎",
                    detInstitution = "第三方单位1",
                    auditor =  "刘虎",
                    detInsititutionId = 17,
                    upload_user_name = "刘虎",
                    scheduler = "刘虎",
                },
                new ThirdUnitDto()
                {
                    upload_insititution_Id = 5,
                    upload_user_Id = 5,
                    det_name = "孙某",
                    detInstitution = "第三方单位1",
                    auditor =  "孙某",
                    detInsititutionId = 5,
                    upload_user_name = "孙某",
                    scheduler = "孙某",
                },
            };

            var dongzai_231 = new Faker<DetectionLoadTestEntity>()
                .RuleFor(d => d.ThirdUnitDto, f => f.PickRandom(thirdUnitIdList))
                .RuleFor(d => d.BgeId, f => 231)//桥梁id
                .RuleFor(d => d.Type, f => Convert.ToSByte(3))
                .RuleFor(d => d.Time, f => f.Date.Between(startDate, endDate))
                .RuleFor(d => d.UploadInstitiutionId, (f, d) => d.ThirdUnitDto.upload_user_Id)
                .RuleFor(d => d.UploadUserId, (f, d) => d.ThirdUnitDto.upload_user_Id)
                .RuleFor(d => d.UploadUserName, (f, d) => d.ThirdUnitDto.upload_user_name)
                .RuleFor(d => d.DetName, (f, d) => d.ThirdUnitDto.det_name)
                .RuleFor(d => d.DetInstitiution, (f, d) => d.ThirdUnitDto.detInstitution)
                .RuleFor(d => d.DetInstitiutionId, (f, d) => d.ThirdUnitDto.upload_insititution_Id)
                .RuleFor(d => d.Result, f => f.Lorem.Word())
                .RuleFor(d => d.Consequence, f => f.Lorem.Word())
                .RuleFor(d => d.Auditor, (f, d) => d.ThirdUnitDto.auditor)
                .RuleFor(d => d.Checker, (f, d) => d.ThirdUnitDto.auditor)
                .RuleFor(d => d.ReportUrl, f => f.Lorem.Word())
                .RuleFor(d => d.ProjectName, f => f.Lorem.Word())
                .RuleFor(d => d.ArchiveLable, f => "LMX-" + f.Date.Between(taskTimeSpanStart, taskTimeSpanEnd).ToString("yyyyMMddHHmmssfff"))
                .RuleFor(d => d.MaintenanceReinforcement, f => f.Lorem.Sentence())
                .RuleFor(d => d.TaskId, f => 0)
                .RuleFor(d => d.Remark, f => f.Lorem.Sentence())
                .RuleFor(d => d.Content, f => f.Lorem.Sentence())
                .RuleFor(d => d.Scheduler, (f, d) => d.ThirdUnitDto.auditor);

            var dongzai_232 = new Faker<DetectionLoadTestEntity>()
                .RuleFor(d => d.ThirdUnitDto, f => f.PickRandom(thirdUnitIdList))
                .RuleFor(d => d.BgeId, f => 232)//桥梁id
                .RuleFor(d => d.Type, f => Convert.ToSByte(3))
                .RuleFor(d => d.Time, f => f.Date.Between(startDate, endDate))
                .RuleFor(d => d.UploadInstitiutionId, (f, d) => d.ThirdUnitDto.upload_user_Id)
                .RuleFor(d => d.UploadUserId, (f, d) => d.ThirdUnitDto.upload_user_Id)
                .RuleFor(d => d.UploadUserName, (f, d) => d.ThirdUnitDto.upload_user_name)
                .RuleFor(d => d.DetName, (f, d) => d.ThirdUnitDto.det_name)
                .RuleFor(d => d.DetInstitiution, (f, d) => d.ThirdUnitDto.detInstitution)
                .RuleFor(d => d.DetInstitiutionId, (f, d) => d.ThirdUnitDto.upload_insititution_Id)
                .RuleFor(d => d.Result, f => f.Lorem.Word())
                .RuleFor(d => d.Consequence, f => f.Lorem.Word())
                .RuleFor(d => d.Auditor, (f, d) => d.ThirdUnitDto.auditor)
                .RuleFor(d => d.Checker, (f, d) => d.ThirdUnitDto.auditor)
                .RuleFor(d => d.ReportUrl, f => f.Lorem.Word())
                .RuleFor(d => d.ProjectName, f => f.Lorem.Word())
                .RuleFor(d => d.ArchiveLable, f => "LMX-" + f.Date.Between(taskTimeSpanStart, taskTimeSpanEnd).ToString("yyyyMMddHHmmssfff"))
                .RuleFor(d => d.MaintenanceReinforcement, f => f.Lorem.Sentence())
                .RuleFor(d => d.TaskId, f => 0)
                .RuleFor(d => d.Remark, f => f.Lorem.Sentence())
                .RuleFor(d => d.Content, f => f.Lorem.Sentence())
                .RuleFor(d => d.Scheduler, (f, d) => d.ThirdUnitDto.auditor);


            var jingzai233 = new Faker<DetectionStaticTest>()
                .RuleFor(d => d.BgeId, f => 233)
                .RuleFor(d => d.Type, Convert.ToSByte(2))
                .RuleFor(d => d.Time, f => f.Date.Between(startDate, endDate))
                .RuleFor(d => d.UploadInstitiutionId, f => f.PickRandom(thirdUnitIdList).upload_insititution_Id)
                .RuleFor(d => d.UploadUserId, f => f.PickRandom(thirdUnitIdList).upload_user_Id)
                .RuleFor(d => d.DetName, f => f.PickRandom(thirdUnitIdList).det_name)
                .RuleFor(d => d.DetInstitiution, f => f.PickRandom(thirdUnitIdList).detInstitution)
                .RuleFor(d => d.Result, f => f.Lorem.Word())
                .RuleFor(d => d.Consequence, f => f.Lorem.Word())
                .RuleFor(d => d.Auditor, f => f.PickRandom(thirdUnitIdList).auditor)
                .RuleFor(d => d.Checker, f => f.PickRandom(thirdUnitIdList).auditor)
                .RuleFor(d => d.ReportUrl, f => "")
                .RuleFor(d => d.ProjectName, f => "")
                .RuleFor(d => d.ArchiveLable, f => "LMX-" + f.Date.Between(taskTimeSpanStart, taskTimeSpanEnd).ToString("yyyyMMddHHmmssfff"))
                .RuleFor(d => d.MaintenanceReinforcement, "维修加固建议......test")
                .RuleFor(d => d.TaskId, f => 0)
                .RuleFor(d => d.DetInstitiutionId, f => f.PickRandom(thirdUnitIdList).detInsititutionId)
                .RuleFor(d => d.UploadUserName, f => f.PickRandom(thirdUnitIdList).upload_user_name)
                .RuleFor(d => d.Remark, f => "备注信息测试remark Message Test")
                .RuleFor(d => d.Content, f => f.Lorem.Sentence())
                .RuleFor(d => d.Scheduler, f => f.PickRandom(thirdUnitIdList).scheduler)
                .RuleFor(d => d.LabProject, f => f.Lorem.Word());

            var jingzai234 = new Faker<DetectionStaticTest>()
                .RuleFor(d => d.BgeId, f => 234)
                .RuleFor(d => d.Type, Convert.ToSByte(2))
                .RuleFor(d => d.Time, f => f.Date.Between(startDate, endDate))
                .RuleFor(d => d.UploadInstitiutionId, f => f.PickRandom(thirdUnitIdList).upload_insititution_Id)
                .RuleFor(d => d.UploadUserId, f => f.PickRandom(thirdUnitIdList).upload_user_Id)
                .RuleFor(d => d.DetName, f => f.PickRandom(thirdUnitIdList).det_name)
                .RuleFor(d => d.DetInstitiution, f => f.PickRandom(thirdUnitIdList).detInstitution)
                .RuleFor(d => d.Result, f => f.Lorem.Word())
                .RuleFor(d => d.Consequence, f => f.Lorem.Word())
                .RuleFor(d => d.Auditor, f => f.PickRandom(thirdUnitIdList).auditor)
                .RuleFor(d => d.Checker, f => f.PickRandom(thirdUnitIdList).auditor)
                .RuleFor(d => d.ReportUrl, f => "")
                .RuleFor(d => d.ProjectName, f => "")
                .RuleFor(d => d.ArchiveLable, f => "LMX-" + f.Date.Between(taskTimeSpanStart, taskTimeSpanEnd).ToString("yyyyMMddHHmmssfff"))
                .RuleFor(d => d.MaintenanceReinforcement, "维修加固建议......test")
                .RuleFor(d => d.TaskId, f => 0)
                .RuleFor(d => d.DetInstitiutionId, f => f.PickRandom(thirdUnitIdList).detInsititutionId)
                .RuleFor(d => d.UploadUserName, f => f.PickRandom(thirdUnitIdList).upload_user_name)
                .RuleFor(d => d.Remark, f => "备注信息测试remark Message Test")
                .RuleFor(d => d.Content, f => f.Lorem.Sentence())
                .RuleFor(d => d.Scheduler, f => f.PickRandom(thirdUnitIdList).scheduler)
                .RuleFor(d => d.LabProject, f => f.Lorem.Word());

            var jingzai235 = new Faker<DetectionStaticTest>()
                .RuleFor(d => d.BgeId, f => 235)
                .RuleFor(d => d.Type, Convert.ToSByte(2))
                .RuleFor(d => d.Time, f => f.Date.Between(startDate, endDate))
                .RuleFor(d => d.UploadInstitiutionId, f => f.PickRandom(thirdUnitIdList).upload_insititution_Id)
                .RuleFor(d => d.UploadUserId, f => f.PickRandom(thirdUnitIdList).upload_user_Id)
                .RuleFor(d => d.DetName, f => f.PickRandom(thirdUnitIdList).det_name)
                .RuleFor(d => d.DetInstitiution, f => f.PickRandom(thirdUnitIdList).detInstitution)
                .RuleFor(d => d.Result, f => f.Lorem.Word())
                .RuleFor(d => d.Consequence, f => f.Lorem.Word())
                .RuleFor(d => d.Auditor, f => f.PickRandom(thirdUnitIdList).auditor)
                .RuleFor(d => d.Checker, f => f.PickRandom(thirdUnitIdList).auditor)
                .RuleFor(d => d.ReportUrl, f => "")
                .RuleFor(d => d.ProjectName, f => "")
                .RuleFor(d => d.ArchiveLable, f => "LMX-" + f.Date.Between(taskTimeSpanStart, taskTimeSpanEnd).ToString("yyyyMMddHHmmssfff"))
                .RuleFor(d => d.MaintenanceReinforcement, "维修加固建议......test")
                .RuleFor(d => d.TaskId, f => 0)
                .RuleFor(d => d.DetInstitiutionId, f => f.PickRandom(thirdUnitIdList).detInsititutionId)
                .RuleFor(d => d.UploadUserName, f => f.PickRandom(thirdUnitIdList).upload_user_name)
                .RuleFor(d => d.Remark, f => "备注信息测试remark Message Test")
                .RuleFor(d => d.Content, f => f.Lorem.Sentence())
                .RuleFor(d => d.Scheduler, f => f.PickRandom(thirdUnitIdList).scheduler)
                .RuleFor(d => d.LabProject, f => f.Lorem.Word());
            #region 不需要任务
            //任务数据生成规则
            //var taskGroupGenerator = new Faker<TaskGroupEntity>("zh_CN")
            //    .RuleFor(t => t.UnitId, f => 5)
            //    .RuleFor(t => t.TaskTypeId, f => 2)
            //    .RuleFor(t => t.TaskGroupName, f=> @"桥梁检测-静载试验" +  f.Date.Between(taskTimeSpanStart, taskTimeSpanEnd).ToString("yyyyMMddHHmmssfff"))
            //    .RuleFor(t => t.IsDeleted, f => 0)
            //    .RuleFor(t => t.CreateUserid, f => 3)
            //    .RuleFor(t => t.ReceiveUserid, f => 5)
            //    .RuleFor(t => t.CreateTime, DateTime.Now)
            //    .RuleFor(t => t.UpdateUserid, f => default)
            //    .RuleFor(t => t.UpdateTime, f => default)
            //    .RuleFor(t => t.DeleteUserid, f => default)
            //    .RuleFor(t => t.DeleteTime, f => default)
            //    .RuleFor(t => t.Remark, f => f.Lorem.Word())
            //    .RuleFor(t => t.CompleteTime, f => default)
            //    .RuleFor(t => t.IsComplete, f => 0)
            //    .RuleFor(t => t.DelegateUnitId, f => 3)
            //    .RuleFor(t => t.ThirdpartyUserAcc, f => "jiankeyuan")
            //    .RuleFor(t => t.ThirdpartyUserPhoneNo, f => "13112345687")
            //    .RuleFor(t => t.TimeEnd, f => Convert.ToDateTime("2022-05-27 00:00:00"))
            //    .RuleFor(t => t.ThirdpartyUserName, f => f.Lorem.Word())
            //    .RuleFor(t => t.TimeStart, f => Convert.ToDateTime("2022-03-10 00:00:00"))
            //    .RuleFor(t => t.OverdueStatus, f => 2)
            //    .RuleFor(t => t.ThirdpartyUserAdvice, f => f.Lorem.Word())
            //    .RuleFor(t => t.Confirmed, f => f.Random.Int(0,1))
            //    .RuleFor(t => t.ConfirmedTime, f => f.Date.Between(startDate,endDate));

            #endregion

            //动载测试生成20W数据
            for (int i = 0; i < 2; i++)
            {
                var detectionLoadTest = dongzai_231.Ignore(p => p.Id).Generate(50000);

                var text = JsonSerializer.Serialize(detectionLoadTest, options: new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                //var path = "c:/temp/test" + i + ".json";
                var path = "c:/temp/dongzai" + i + ".json";
                File.WriteAllText(path, text);
                //Console.WriteLine(text);
            }

            for (int i = 0; i < 2; i++)
            {
                var detectionLoadTest = dongzai_232.Ignore(p => p.Id).Generate(50000);

                var text = JsonSerializer.Serialize(detectionLoadTest, options: new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                //var path = "c:/temp/test" + i + ".json";
                var number = 2 + i;
                var path = "c:/temp/dongzai" + number + ".json";
                File.WriteAllText(path, text);
                //Console.WriteLine(text);
            }
            //静载测试生成30W数据
            for (int i = 0; i < 2; i++)
            {
                var detectionDtoList = jingzai233.Ignore(p => p.Id).Generate(50000);

                var text = JsonSerializer.Serialize(detectionDtoList, options: new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                var number =  i;
                var path = "c:/temp/jingzai" + number + ".json";
                File.WriteAllText(path, text);
            }

            for (int i = 0; i < 2; i++)
            {
                var detectionDtoList = jingzai234.Ignore(p => p.Id).Generate(50000);

                var text = JsonSerializer.Serialize(detectionDtoList, options: new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                var number = 2 + i;
                var path = "c:/temp/jingzai" + number + ".json";
                File.WriteAllText(path, text);
            }

            for (int i = 0; i < 2; i++)
            {
                var detectionDtoList = jingzai235.Ignore(p => p.Id).Generate(50000);

                var text = JsonSerializer.Serialize(detectionDtoList, options: new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                var number = 4 + i;
                var path = "c:/temp/jingzai" + number + ".json";
                File.WriteAllText(path, text);
            }

            //var data = personGenerator.Ignore(p=>p.Id).Generate(10000);

            //Console.WriteLine(text);




        }


    }
}
