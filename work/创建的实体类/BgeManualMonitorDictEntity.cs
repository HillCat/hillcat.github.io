using System;
using System.Collections.Generic;
using System.Text; 
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace  GDBS.BridgeService.Domain 
 { 
     /// <summary>
     /// 人工监测,测点类型字典 
     /// </summary>
     [Table("bge_manual_monitor_dict")]
      public  class BgeManualMonitorDictEntity:Entity<int>
     {

        /// <summary>
        /// 类型名 
        /// </summary>
        [Column("type_name", TypeName = "varchar(50)")]
        public string TypeName { get; set; }
        /// <summary>
        /// 参数列名 
        /// </summary>
        [Column("cloumn_name", TypeName = "varchar(50)")]
        public string CloumnName { get; set; }
        /// <summary>
        /// 单位,比如:mm,℃ 
        /// </summary>
        [Column("unit", TypeName = "varchar(10)")]
        public string Unit { get; set; }
        /// <summary>
        /// 是否启用, 1启用 ,0不启用 
        /// </summary>
        [Column("is_show", TypeName = "int(1)")]
        public int IsShow { get; set; }
        /// <summary>
        /// 备注, 冗余字段 
        /// </summary>
        [Column("remark", TypeName = "varchar(20)")]
        public string Remark { get; set; }

    } 
} 