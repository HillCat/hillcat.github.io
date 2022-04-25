using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFDataAccessLibrary.Models
{ 
     /// <summary>
     /// 桥梁线路基础信息表,A.线路信息主表: 线路信息,B. 
     /// </summary>
     [Table("bge_line_info")]
      public  class BgeLineInfoEntity
     {  
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id",TypeName ="int(11)")]
        public int    Id { get; set; } 
        /// <summary>
        /// 桥梁跨数 
        /// </summary>
        [Column("crossnumber",TypeName ="int(11)")]
        public int ?  Crossnumber { get; set; } 
        /// <summary>
        /// 跨径组合（m） 
        /// </summary>
        [Column("span",TypeName ="varchar(255)")]
        public string    Span { get; set; } 
        /// <summary>
        /// 车道净宽（m） 
        /// </summary>
        [Column("lane_width",TypeName ="decimal(10,2)")]
        public decimal ?  LaneWidth { get; set; } 
        /// <summary>
        /// 人行道净宽（m） 
        /// </summary>
        [Column("side_width",TypeName ="decimal(10,2)")]
        public decimal ?  SideWidth { get; set; } 
        /// <summary>
        /// 设计荷载 
        /// </summary>
        [Column("load_grade",TypeName ="varchar(50)")]
        public string    LoadGrade { get; set; } 
        /// <summary>
        /// 抗震烈度 
        /// </summary>
        [Column("antiseismic",TypeName ="varchar(50)")]
        public string    Antiseismic { get; set; } 
        /// <summary>
        /// 正斜交角 
        /// </summary>
        [Column("positive_angle",TypeName ="varchar(50)")]
        public string    PositiveAngle { get; set; } 
        /// <summary>
        /// 常水位 
        /// </summary>
        [Column("norwater_level",TypeName ="tinyint(4)")]
        public sbyte ?  NorwaterLevel { get; set; } 
        /// <summary>
        /// 最高水位 
        /// </summary>
        [Column("maxwater_level",TypeName ="tinyint(4)")]
        public sbyte ?  MaxwaterLevel { get; set; } 
        /// <summary>
        /// 泄水管尺寸（长度） 
        /// </summary>
        [Column("drain_length",TypeName ="decimal(10,2)")]
        public decimal ?  DrainLength { get; set; } 
        /// <summary>
        /// 建造年份 
        /// </summary>
        [Column("create_year",TypeName ="varchar(50)")]
        public string    CreateYear { get; set; } 
        /// <summary>
        /// 创建人ID 
        /// </summary>
        [Column("create_id",TypeName ="int(11)")]
        public int ?  CreateId { get; set; } 
        /// <summary>
        /// 创建人 
        /// </summary>
        [Column("creator",TypeName ="varchar(50)")]
        public string    Creator { get; set; } 
        /// <summary>
        /// 创建日期 
        /// </summary>
        [Column("create_date",TypeName ="datetime")]
        public DateTime ?  CreateDate { get; set; } 
        /// <summary>
        /// 修改日期 
        /// </summary>
        [Column("update_time",TypeName ="datetime")]
        public DateTime ?  UpdateTime { get; set; } 
        /// <summary>
        /// 线路名字 
        /// </summary>
        [Column("name",TypeName ="varchar(200)")]
        public string    Name { get; set; } 
        /// <summary>
        /// HUID 
        /// </summary>
        [Column("huid",TypeName ="varchar(0)")]
        public string    Huid { get; set; } 
        /// <summary>
        /// UID 
        /// </summary>
        [Column("uid",TypeName ="varchar(36)")]
        public string    Uid { get; set; } 
        /// <summary>
        /// 排序 
        /// </summary>
        [Column("order_no",TypeName ="int(11)")]
        public int ?  OrderNo { get; set; } 
        /// <summary>
        /// 启用 
        /// </summary>
        [Column("enable",TypeName ="tinyint(4)")]
        public sbyte    Enable { get; set; } 
        /// <summary>
        /// 桥梁Id 
        /// </summary>
        [Column("bge_id",TypeName ="int(11)")]
        public int ?  BgeId { get; set; } 
        /// <summary>
        /// 河道等级 
        /// </summary>
        [Column("river_level",TypeName ="varchar(50)")]
        public string    RiverLevel { get; set; } 
        /// <summary>
        /// 接管时间 
        /// </summary>
        [Column("takeover_time",TypeName ="datetime")]
        public DateTime ?  TakeoverTime { get; set; } 
        /// <summary>
        /// 通车时间 
        /// </summary>
        [Column("opening_time",TypeName ="datetime")]
        public DateTime ?  OpeningTime { get; set; } 
        /// <summary>
        /// 旧桥梁系统线路id 
        /// </summary>
        [Column("sync_line_id",TypeName ="varchar(255)")]
        public string    SyncLineId { get; set; } 
        /// <summary>
        /// 桥头路名(v1.2新增字段) 
        /// </summary>
        [Column("head_road_name",TypeName ="varchar(50)")]
        public string    HeadRoadName { get; set; } 
        /// <summary>
        /// 桥尾路名(v1.2新增字段) 
        /// </summary>
        [Column("tail_road_name",TypeName ="varchar(50)")]
        public string    TailRoadName { get; set; } 
        /// <summary>
        /// 曲线半径(v1.2新增字段) 
        /// </summary>
        [Column("curve_radius",TypeName ="decimal(10,2)")]
        public decimal ?  CurveRadius { get; set; } 
        /// <summary>
        /// 车道数量(v1.2新增字段) 
        /// </summary>
        [Column("lane_count",TypeName ="int(11)")]
        public int ?  LaneCount { get; set; } 
        /// <summary>
        /// 限载(v1.2新增字段) 
        /// </summary>
        [Column("load_limit",TypeName ="varchar(20)")]
        public string    LoadLimit { get; set; } 
        /// <summary>
        /// 限宽(v1.2新增字段) 
        /// </summary>
        [Column("width_limit",TypeName ="decimal(10,2)")]
        public decimal ?  WidthLimit { get; set; } 
        /// <summary>
        /// 限高(v1.2新增字段) 
        /// </summary>
        [Column("height_limit",TypeName ="decimal(10,2)")]
        public decimal ?  HeightLimit { get; set; } 
        /// <summary>
        /// 限速(v1.2新增字段) 
        /// </summary>
        [Column("speed_limit",TypeName ="decimal(10,2)")]
        public decimal ?  SpeedLimit { get; set; } 
        /// <summary>
        /// 步梯数量(v1.2新增字段) 
        /// </summary>
        [Column("step_ladder_count",TypeName ="int(11)")]
        public int ?  StepLadderCount { get; set; } 
        /// <summary>
        /// 桥面横坡坡度(v1.2新增字段) 
        /// </summary>
        [Column("cross_slope_grade",TypeName ="varchar(50)")]
        public string    CrossSlopeGrade { get; set; } 
        /// <summary>
        /// 桥面纵坡坡度(v1.2新增字段) 
        /// </summary>
        [Column("vertical_slope_grade",TypeName ="varchar(50)")]
        public string    VerticalSlopeGrade { get; set; } 
        /// <summary>
        /// 引道长度(v1.2新增字段) 
        /// </summary>
        [Column("lead_road_length",TypeName ="decimal(10,2)")]
        public decimal ?  LeadRoadLength { get; set; } 
        /// <summary>
        /// 引桥桥纵坡坡度(v1.2新增字段) 
        /// </summary>
        [Column("lead_bge_vertical_grade",TypeName ="varchar(50)")]
        public string    LeadBgeVerticalGrade { get; set; } 
        /// <summary>
        /// 备注(v1.2新增字段) 
        /// </summary>
        [Column("remark",TypeName ="varchar(255)")]
        public string    Remark { get; set; } 
        /// <summary>
        /// 结构类型(v1.3新增字段) 
        /// </summary>
        [Column("struct_type",TypeName ="int(4)")]
        public int ?  StructType { get; set; } 

     } 
} 