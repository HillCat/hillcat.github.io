using Bogus;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BirdgeContext _gdbsDevDbContext;
        private readonly DongGuanBridgeContext _dongGuanBridgeContext;

        public IndexModel(ILogger<IndexModel> logger, BirdgeContext gdbsDevDbContext,
            DongGuanBridgeContext dongGuanBridgeContext)
        {
            _logger = logger;
            _gdbsDevDbContext = gdbsDevDbContext;
            _dongGuanBridgeContext = dongGuanBridgeContext;
        }

        public void OnGet()
        {
            //GeneratorStaticTestData();

            GeneratorDongGuanBridgeData();
            GeneratorDongGuanBridgeLineData();
        }

        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age <= 40);
        }

        private void GeneratorStaticTestData()
        {
            #region 批量导入静载测试数据

            //if (!_gdbsDevDbContext.DetectionStaticTests.Any())
            //{

            //    for (int i = 0; i < 4; i++)
            //    {
            //        var file = System.IO.File.ReadAllText("c:/temp/" + "statictest" + i + ".json");
            //        var dataList = JsonSerializer.Deserialize<List<DetectionStaticTest>>(file);
            //        _gdbsDevDbContext.AddRange(dataList);
            //        _gdbsDevDbContext.SaveChanges();
            //    }
            //} 

            #endregion

            #region 批量导入动载测试数据

            //if (!_gdbsDevDbContext.DetectionLoadTestEntities.Any())
            //{
            //    //test111.json
            //    for (var i = 0; i < 4; i++)
            //    {
            //        var file = System.IO.File.ReadAllText("c:/temp/" + "loadtest" + i + ".json");
            //        //var file = System.IO.File.ReadAllText("c:/temp/" + "test111"  + ".json");
            //        var dataList = JsonSerializer.Deserialize<List<DetectionLoadTestEntity>>(file);
            //        _gdbsDevDbContext.AddRange(dataList);
            //        _gdbsDevDbContext.SaveChanges();
            //    }

            //} 

            #endregion

        }

        private void GeneratorDongGuanBridgeData()
        {
            //读取东莞数据库的1000座桥梁数据
            var dongguanBridgeList =
                _dongGuanBridgeContext.DongGuanBgeInfoEntities.OrderByDescending(d => d.AreaId).Take(1000).ToList();
            var bgeNoNew = _gdbsDevDbContext.BgeInfoEntityNews.OrderByDescending(d => d.Id).FirstOrDefault();
            if (bgeNoNew != null)
            {
                var bgeNoInt = Convert.ToInt32(bgeNoNew.BgeNo);
                var bridgeMaintanType = new[] {10, 11, 12, 13, 15}; //桥梁养护类型
                var bridgeScale = new[] {104, 105, 106, 107, 108};
                var bridgeCuringGrade = new[] {22, 23, 24}; //养护类型
                var crossType = new[] {5, 6, 7, 8, 9}; //跨越类型
                var functionType = new[] {16, 17, 18, 19, 20, 21}; //功能类型
                var structType = new[] {25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 97}; //结构类型
                var bgeInfoEntityList = new List<BgeInfoEntityNew>();
                var faker = new Faker();
                //旧数据表的数据转移到新数据表
                foreach (var item in dongguanBridgeList)
                {
                    bgeNoInt++;
                    var bgeInfoEntityNew = new BgeInfoEntityNew()
                    {
                        Id = 0,
                        Uid = item.Uid,
                        ComId = 18,
                        BgeNo = bgeNoInt.ToString(),
                        Name = item.Name,
                        BgeLength = item.BgeLength,
                        BgeWidth = item.BgeWidth,
                        ProvinceoId = "440000",
                        CityId = "441900",
                        AreaId = "441900107",
                        TownId = item.TownId,
                        Address = item.Address,
                        GpsLog = item.GpsLog,
                        GpsLan = item.GpsLan,
                        CompletionYear = item.CompletionYear,
                        Remark = item.Remark,
                        Enable = item.Enable,
                        OrderNo = item.OrderNo,
                        Locatetype = 1,
                        CreateId = 16,
                        Creator = "桥头镇养护单位",
                        CreateDate = item.CreateDate,
                        ModifyId = item.ModifyId,
                        Modifier = item.Modifier,
                        ModifyDate = item.ModifyDate,
                        Area = item.Area,
                        Construction = item.Construction,
                        CreateintId = item.CreateintId,
                        ConstructionintId = item.ConstructionintId,
                        RiskState = Convert.ToSByte(item.RiskState),
                        UpdateTime = item.UpdateTime,
                        SupervisingintId = item.SupervisingintId,
                        MaintenanceintId = 2,
                        ManagementintId = 18,
                        Iocurl = "bgecustomicon/default1.png",
                        BridgeMaintainType = faker.PickRandom(bridgeMaintanType),
                        BridgeScale = faker.PickRandom(bridgeScale),
                        BridgeCuringGrade = faker.PickRandom(bridgeCuringGrade),
                        BridgeStatus = 48,
                        FunctionType = faker.PickRandom(functionType),
                        CrossingType = faker.PickRandom(crossType),
                        StructType = faker.PickRandom(structType)

                    };
                    bgeInfoEntityList.Add(bgeInfoEntityNew);
                }


                _gdbsDevDbContext.AddRange(bgeInfoEntityList);


                //bgeInfoEntityList
                //var text = JsonSerializer.Serialize(bgeInfoEntityList, options: new JsonSerializerOptions()
                //{
                //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                //});


            }

            _gdbsDevDbContext.SaveChanges();
        }

        private void GeneratorDongGuanBridgeLineData()
        {
            var faker = new Faker();
            var bgeInfoEntityList =
                _gdbsDevDbContext.BgeInfoEntityNews.Where(d => !string.IsNullOrEmpty(d.Uid)).ToList();
            var startTime = Convert.ToDateTime("1989-01-01");
            var endTime = Convert.ToDateTime("2017-05-08");

            var bridgeLineList = bgeInfoEntityList.Select(item => new BgeLineInfoEntity()
            {
                Id = 0,
                Crossnumber = 1,
                Span = faker.Random.Number(200, 2000).ToString(),
                LaneWidth = faker.Random.Decimal(25, 120),
                SideWidth = faker.Random.Decimal(8, 22),
                LoadGrade = faker.Random.Number(100, 1000).ToString(),
                CreateYear = faker.Date.Between(startTime, endTime).ToString("yyyy-MM"),
                CreateId = 16,
                Creator = "乔某某",
                CreateDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                Name = "主线",
                Uid = item.Uid,
                Enable = 1,
                BgeId = item.Id,
                StructType = item.StructType
            }).ToList();
            _gdbsDevDbContext.AddRange(bridgeLineList);
            _gdbsDevDbContext.SaveChanges();
        }

        private void GeneratorDongGuanBridgeDictData()
        {
        }
    }
}
