using GDBS.BridgeService.Application.Contracts.BgeBridgeDanger;
using GDBS.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDBS.BridgeService.Application.Contracts.BgeManualMonitor
{
    /// <summary>
    /// 人工监测数据管理接口
    /// </summary>
    public interface IBridgeManualMonitorServer
    {
        /// <summary>
        /// 查询桥梁人工监测列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ReturnPageWithDataDto> GetBridgeManualMonitorList(GetManualMonitorListInputDto input);

    }
}
