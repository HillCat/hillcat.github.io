using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDBS.Shared.Data;

namespace GDBS.BridgeService.Application.Contracts.BgeManualMonitor
{
    public class GetManualMonitorListInputDto:PagingInput
    {

        /// <summary>
        /// 桥梁名称
        /// </summary>
        public string BridgeName { get; set; }
        /// <summary>
        /// 监测单位名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        
    }
}
