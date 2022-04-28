using Bogus;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using GDBS.Shared.Data.Const;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GDBS.Shared.Data.Entity.Jket;
using Microsoft.AspNetCore.Components.Forms;
using GDBS.Shared.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EFDemoWeb.Pages
{
    public class CreateBridgeDataModel : PageModel
    {
        private readonly ILogger<CreateBridgeDataModel> _logger;
        private readonly BirdgeContext _gdbsDevDbContext;
        private readonly DongGuanBridgeContext _dongGuanBridgeContext;

       

        public CreateBridgeDataModel(ILogger<CreateBridgeDataModel> logger, BirdgeContext gdbsDevDbContext, DongGuanBridgeContext dongGuanBridgeContext)
        {
            _logger = logger;
            _gdbsDevDbContext = gdbsDevDbContext;
            _dongGuanBridgeContext = dongGuanBridgeContext;
           
        }

        /// <summary>
        /// 初始化1000座桥，并且加入自动化监测
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            GeneratorDongGuanBridgeData();
            GeneratorDongGuanBridgeLineData();
            //GeneratorAutoMonitor();


        }

        private async void GeneratorAutoMonitor()
        {
            //生成自动化监测数据
            //http://47.107.72.111:8191/bs/api/bridgeService/BridgeAutoMonitor/AddOrEditAutoMonitorAppConfig
            var thounthandBridgeList = await _gdbsDevDbContext.BgeInfoEntityNews.OrderByDescending(d => d.Id).Take(1000).ToListAsync();

            var monitorEntityList = new List<BgeAutoMonitorAppConfigEntity>();
            var mntSubEntityList = new List<MntSubjectEntity>();
            var nowTime = DateTime.Now;
            var serialMaxid = await _gdbsDevDbContext.BgeAutoMonitorAppConfigEntities.MaxAsync(x => x.SerialNumber) ?? +1;
            foreach (var bridge in thounthandBridgeList)
            {
                var monitorEntity = new BgeAutoMonitorAppConfigEntity()
                {
                    Url = "https://www.gdjkiot.com/",
                    Appid = "RHAUTO",
                    BridgeName = bridge.Name,
                    BridgeNo = bridge.BgeNo,
                    BridgeId = bridge.Id,
                    name = "自动化监测测试---" + bridge.Name,
                    CreateTime = nowTime,
                    CreateUser = 3,
                    IsEnable = 1,
                    SerialNumber = serialMaxid
                };

                var insMntSubject = new MntSubjectEntity
                {
                    BgeNo = bridge.BgeNo,
                    CreateTime = nowTime,
                    Creator = "方羽",
                    CreatorId = 3,
                    ModifyTime = nowTime,
                    Modifier = "方羽",
                    ModifierId = 3,
                    MonitorBeginTime = nowTime
                };
                mntSubEntityList.Add(insMntSubject);
                serialMaxid++;
                monitorEntityList.Add(monitorEntity);
            }

            _gdbsDevDbContext.BgeAutoMonitorAppConfigEntities.AddRange(monitorEntityList);

            _gdbsDevDbContext.MntSubjectEntities.AddRange(mntSubEntityList);

            await _gdbsDevDbContext.SaveChangesAsync();
        }
        /// <summary>
        /// 生成1000座桥梁主表数据
        /// </summary>
        private void GeneratorDongGuanBridgeData()
        {
            //读取东莞数据库的1000座桥梁数据
            var dongguanBridgeList =
                _dongGuanBridgeContext.DongGuanBgeInfoEntities.OrderByDescending(d => d.AreaId).Take(1000).ToList();
            var theLastOneBridge = _gdbsDevDbContext.BgeInfoEntityNews.OrderByDescending(d => d.Id).FirstOrDefault();
            if (theLastOneBridge != null)
            {
                var bgeNoInt = theLastOneBridge.Id;
                var bridgeMaintanType = new[] { 10, 11, 12, 13, 15 }; //桥梁养护类型
                var bridgeScale = new[] { 104, 105, 106, 107, 108 };
                var bridgeCuringGrade = new[] { 22, 23, 24 }; //养护类型
                var crossType = new[] { 5, 6, 7, 8, 9 }; //跨越类型
                var functionType = new[] { 16, 17, 18, 19, 20, 21 }; //功能类型
                var structType = new[] { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 97 }; //结构类型
                var bgeInfoEntityList = new List<BgeInfoEntityNew>();
                var faker = new Faker();
                var timeNow = DateTime.Now;
                //旧数据表的数据转移到新数据表
                foreach (var item in dongguanBridgeList)
                {
                    bgeNoInt++;
                    var bgeInfoEntityNew = new BgeInfoEntityNew()
                    {
                        Id = 0,
                        Uid = item.Uid,
                        ComId = 18,
                        BgeNo = "441900" + bgeNoInt,
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
                        CreateDate = timeNow,
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
                        StructType = faker.PickRandom(structType),
                        IsAutoDetection = 1

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
        /// <summary>
        /// 生成桥梁线路
        /// </summary>
        private void GeneratorDongGuanBridgeLineData()
        {
            var faker = new Faker();
            var bgeInfoEntityList =
                _gdbsDevDbContext.BgeInfoEntityNews.Where(d => !string.IsNullOrEmpty(d.Uid)|| d.Id>196).ToList();
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

    }
}
