using System;
using System.Collections.Generic;
using System.Text; 
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace  GDBS.BridgeService.Domain 
 { 
     /// <summary>
     /// 桥梁监测-->人工监测 测点版本数据详情表 
     /// </summary>
     [Table("bge_manual_monitor_point_detail")]
      public  class BgeManualMonitorPointDetailEntity:Entity<int>
     {

        /// <summary>
        /// 测点名称, 比如：墩-10A 
        /// </summary>
        [Column("point_name", TypeName = "varchar(50)")]
        public string PointName { get; set; }
        /// <summary>
        /// 沉降量 
        /// </summary>
        [Column("drop_down", TypeName = "varchar(12)")]
        public string DropDown { get; set; }
        /// <summary>
        /// 温度 
        /// </summary>
        [Column("temperature", TypeName = "varchar(12)")]
        public string Temperature { get; set; }
        /// <summary>
        /// 裂缝宽度 
        /// </summary>
        [Column("crack_width", TypeName = "varchar(12)")]
        public string CrackWidth { get; set; }
        /// <summary>
        /// 位移 
        /// </summary>
        [Column("distance", TypeName = "varchar(12)")]
        public string Distance { get; set; }
        /// <summary>
        /// 应变  
        /// </summary>
        [Column("reactivity", TypeName = "varchar(12)")]
        public string Reactivity { get; set; }
        /// <summary>
        /// 倾角XS 
        /// </summary>
        [Column("angle_x", TypeName = "varchar(12)")]
        public string AngleX { get; set; }
        /// <summary>
        /// 倾角YS 
        /// </summary>
        [Column("angle_y", TypeName = "varchar(12)")]
        public string AngleY { get; set; }
        /// <summary>
        /// 索力 
        /// </summary>
        [Column("cable_force", TypeName = "varchar(12)")]
        public string CableForce { get; set; }
        /// <summary>
        /// 平均风速 
        /// </summary>
        [Column("wind_speed", TypeName = "varchar(12)")]
        public string WindSpeed { get; set; }
        /// <summary>
        /// 风向 
        /// </summary>
        [Column("wind_direction", TypeName = "varchar(12)")]
        public string WindDirection { get; set; }
        /// <summary>
        /// 湿度 
        /// </summary>
        [Column("wet", TypeName = "varchar(12)")]
        public string Wet { get; set; }
        /// <summary>
        /// 高度 
        /// </summary>
        [Column("height", TypeName = "varchar(12)")]
        public string Height { get; set; }
        /// <summary>
        /// 倾覆 
        /// </summary>
        [Column("overturn", TypeName = "varchar(12)")]
        public string Overturn { get; set; }
        /// <summary>
        /// 创建时间 
        /// </summary>
        [Column("create_time", TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 版本名称 
        /// </summary>
        [Column("ver_name", TypeName = "varchar(20)")]
        public string VerName { get; set; }
        /// <summary>
        /// bge_manual_monitor主表id,版本id 
        /// </summary>
        [Column("ver_id", TypeName = "int(11)")]
        public int? VerId { get; set; }
        /// <summary>
        /// 对象名,比如:C匝道 
        /// </summary>
        [Column("object_name", TypeName = "varchar(50)")]
        public string ObjectName { get; set; }
        /// <summary>
        /// 更新时间 
        /// </summary>
        [Column("update_time", TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 桥梁主表id 
        /// </summary>
        [Column("bge_id", TypeName = "int(11)")]
        public int? BgeId { get; set; }
        /// <summary>
        /// 创建人id 
        /// </summary>
        [Column("create_userid", TypeName = "int(11)")]
        public int? CreateUserid { get; set; }
        /// <summary>
        /// 更新人id 
        /// </summary>
        [Column("update_userid", TypeName = "int(11)")]
        public int? UpdateUserid { get; set; }
        /// <summary>
        /// 删除人id 
        /// </summary>
        [Column("delete_userid", TypeName = "int(11)")]
        public int? DeleteUserid { get; set; }
        /// <summary>
        /// 是否删除 1是,0否 
        /// </summary>
        [Column("is_deleted", TypeName = "int(1)")]
        public int IsDeleted { get; set; }
    } 
} 