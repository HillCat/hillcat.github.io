using Bogus;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using EFDataAccessLibrary;

namespace EFDemoWeb.Pages
{
    public class InportTestDataModel : PageModel
    {
        private readonly BirdgeContext _gdbsDevDbContext;

        public InportTestDataModel(BirdgeContext gdbsDevDbContext)
        {
            _gdbsDevDbContext = gdbsDevDbContext;
        }

        public void OnGet()
        {
            GeneratorStaticTestData();
        }

        private void GeneratorStaticTestData()
        {
            #region 批量导入静载测试数据

            if (_gdbsDevDbContext.DetectionStaticTests.Any())
            {

                for (int i = 0; i < 6; i++)
                {
                    var file = System.IO.File.ReadAllText("c:/temp/" + "jingzai" + i + ".json");
                    var dataList = JsonSerializer.Deserialize<List<DetectionStaticTest>>(file);
                    _gdbsDevDbContext.AddRange(dataList);
                    _gdbsDevDbContext.SaveChanges();
                }
            }

            #endregion

            #region 批量导入动载测试数据

            if (_gdbsDevDbContext.DetectionLoadTestEntities.Any())
            {
                //test111.json
                for (var i = 0; i < 4; i++)
                {
                    var file = System.IO.File.ReadAllText("c:/temp/" + "dongzai" + i + ".json");
                    //var file = System.IO.File.ReadAllText("c:/temp/" + "test111"  + ".json");
                    var dataList = JsonSerializer.Deserialize<List<DetectionLoadTestEntity>>(file);
                    _gdbsDevDbContext.AddRange(dataList);
                    _gdbsDevDbContext.SaveChanges();
                }

            }

            #endregion

        }
    }
}
