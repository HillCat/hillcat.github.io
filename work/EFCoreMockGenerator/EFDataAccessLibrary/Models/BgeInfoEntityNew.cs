using System;
using System.Collections.Generic;
using System.Text; 
using System.ComponentModel.DataAnnotations.Schema; 
namespace  EFDataAccessLibrary.Models 
 { 
     /// <summary>
     /// 桥梁基础信息表,A.信息主表: 维护桥梁最基本的信息,B.UID-是为了和PAD端同步的唯一编码 桥梁与结构部分相关的表都有此字段 (不能用ID),C.ModityDate: 新设计取消了信息版本, PAD和WEB的信息同步直接使用修改时间与UID就可以.,D.LatestVersion: 最新一个 [可用结构版本],E.BgeNO: 桥梁编号, 用于省桥梁系统同步,F.Town: 县城为手填非字典.,G.GPS: 百度地图标记的经纬度.,H.LocateType: 地理类型: 约定枚举 1-省内 2-省外,I.BgeStatus: 桥梁状态, 1为正常 2为检测中. 在检测中的桥梁, 任何公司都不能把它加入新建项目中,J.ComID: 这里指代第一家创建这条桥的公司ID,之后修改桥结构可能有不同公司维护然后累加结构版本, 桥梁创建遵守哪家公司创建就归属哪家公司的原则, 但是, 如果是省内桥梁类型, 则所有公司均可见且可以直接维护, 故此, 如果一条桥在检测中状态, 其他公司不能通过项目把它添加到自己的新项目中.,K.AuditStatus审核状态-草稿/已提交/已审核,L.RuleType: 桥梁规范类型: 约定枚举 1-公路版国标 2-市政版国标 3-市政版省标 只是个参考用的字段. BCI计算以项目的RuleType为主 ,,M.组织结构下面的桥梁显示单位与桥梁关系,桥梁为所有关系的桥梁。 
     /// </summary>
     [Table("bge_info")]
      public  class BgeInfoEntityNew
     {  
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id",TypeName ="int(11)")]
        public int    Id { get; set; } 
        /// <summary>
        /// UID,桥梁系统这边没有使用该字段 
        /// </summary>
        [Column("uid",TypeName ="varchar(36)")]
        public string    Uid { get; set; } 
        /// <summary>
        /// 公司ID ,冗余字段,0.5代码中该字段有在使用,先不删除 
        /// </summary>
        [Column("com_id",TypeName ="int(11)")]
        public int ?  ComId { get; set; } 
        /// <summary>
        /// 桥梁编号 
        /// </summary>
        [Column("bge_no",TypeName ="varchar(50)")]
        public string    BgeNo { get; set; } 
        /// <summary>
        /// 桥梁名字 
        /// </summary>
        [Column("name",TypeName ="varchar(200)")]
        public string    Name { get; set; } 
        /// <summary>
        /// 桥梁长度 
        /// </summary>
        [Column("bge_length",TypeName ="varchar(50)")]
        public string    BgeLength { get; set; } 
        /// <summary>
        /// 桥梁宽度 
        /// </summary>
        [Column("bge_width",TypeName ="varchar(50)")]
        public string    BgeWidth { get; set; } 
        /// <summary>
        /// 省份 
        /// </summary>
        [Column("provinceo_id",TypeName ="varchar(30)")]
        public string    ProvinceoId { get; set; } 
        /// <summary>
        /// 城市 
        /// </summary>
        [Column("city_id",TypeName ="varchar(30)")]
        public string    CityId { get; set; } 
        /// <summary>
        /// 区县 
        /// </summary>
        [Column("area_id",TypeName ="varchar(30)")]
        public string    AreaId { get; set; } 
        /// <summary>
        /// 镇街道 
        /// </summary>
        [Column("town_id",TypeName ="varchar(30)")]
        public string    TownId { get; set; } 
        /// <summary>
        /// 详细地址 
        /// </summary>
        [Column("address",TypeName ="varchar(500)")]
        public string    Address { get; set; } 
        /// <summary>
        /// 经度 
        /// </summary>
        [Column("gps_log",TypeName ="decimal(18,7)")]
        public decimal ?  GpsLog { get; set; } 
        /// <summary>
        /// 纬度 
        /// </summary>
        [Column("gps_lan",TypeName ="decimal(18,7)")]
        public decimal ?  GpsLan { get; set; } 
        /// <summary>
        /// 完工年份 
        /// </summary>
        [Column("completion_year",TypeName ="varchar(50)")]
        public string    CompletionYear { get; set; } 
        /// <summary>
        /// 备注 
        /// </summary>
        [Column("remark",TypeName ="varchar(200)")]
        public string    Remark { get; set; } 
        /// <summary>
        /// 启用 false-未启用0,true-启用 1 
        /// </summary>
        [Column("enable",TypeName ="tinyint(4)")]
        public sbyte    Enable { get; set; } 
        /// <summary>
        /// 排序 
        /// </summary>
        [Column("order_no",TypeName ="int(11)")]
        public int ?  OrderNo { get; set; } 
        /// <summary>
        /// 地理类型 
        /// </summary>
        [Column("locatetype",TypeName ="int(11)")]
        public int ?  Locatetype { get; set; } 
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
        /// 修改人ID 
        /// </summary>
        [Column("modify_id",TypeName ="int(11)")]
        public int ?  ModifyId { get; set; } 
        /// <summary>
        /// 修改人 
        /// </summary>
        [Column("modifier",TypeName ="varchar(50)")]
        public string    Modifier { get; set; } 
        /// <summary>
        /// 修改日期 
        /// </summary>
        [Column("modify_date",TypeName ="datetime")]
        public DateTime ?  ModifyDate { get; set; } 
        /// <summary>
        /// 面积(m2) 
        /// </summary>
        [Column("area",TypeName ="decimal(10,2)")]
        public decimal ?  Area { get; set; } 
        /// <summary>
        /// 总造价(万元） 
        /// </summary>
        [Column("construction",TypeName ="int(11)")]
        public int ?  Construction { get; set; } 
        /// <summary>
        /// 建设单位Id  
        /// </summary>
        [Column("createint_id",TypeName ="int(11)")]
        public int ?  CreateintId { get; set; } 
        /// <summary>
        /// 监理单位Id 
        /// </summary>
        [Column("constructionint_id",TypeName ="int(11)")]
        public int ?  ConstructionintId { get; set; } 
        /// <summary>
        /// 是否是危桥：1、是危桥,2、正常 
        /// </summary>
        [Column("risk_state",TypeName ="tinyint(4)")]
        public sbyte    RiskState { get; set; } 
        /// <summary>
        /// 更新时间 
        /// </summary>
        [Column("update_time",TypeName ="datetime")]
        public DateTime ?  UpdateTime { get; set; } 
        /// <summary>
        /// 施工单位Id 
        /// </summary>
        [Column("supervisingint_id",TypeName ="int(11)")]
        public int ?  SupervisingintId { get; set; } 
        /// <summary>
        /// 管理单位Id 
        /// </summary>
        [Column("maintenanceint_Id",TypeName ="int(11)")]
        public int ?  MaintenanceintId { get; set; } 
        /// <summary>
        /// 养护单位Id 
        /// </summary>
        [Column("managementint_id",TypeName ="int(11)")]
        public int ?  ManagementintId { get; set; } 
        /// <summary>
        /// 桥梁小图标 
        /// </summary>
        [Column("iocurl",TypeName ="varchar(255)")]
        public string    Iocurl { get; set; } 
        /// <summary>
        /// 是否自动监测0：不是,1：是 
        /// </summary>
        [Column("is_auto_detection",TypeName ="int(4)")]
        public int ?  IsAutoDetection { get; set; } 
        /// <summary>
        /// 桥梁类型 104,105,106,107,108 分别：特大桥,大桥,中桥,小桥,涵洞 
        /// </summary>
        [Column("bridge_scale",TypeName ="int(11)")]
        public int ?  BridgeScale { get; set; } 
        /// <summary>
        /// 桥梁养护等级 22,23,24 分别I级,II级,III级 
        /// </summary>
        [Column("bridge_curing_grade",TypeName ="int(11)")]
        public int    BridgeCuringGrade { get; set; } 
        /// <summary>
        /// 桥梁现行状态,48通行,49维修,50关闭,51退役,53限载 
        /// </summary>
        [Column("bridge_status",TypeName ="int(11)")]
        public int    BridgeStatus { get; set; } 
        /// <summary>
        /// 通航水位(v1.2新增字段) 
        /// </summary>
        [Column("navigalble_water_level",TypeName ="decimal(10,2)")]
        public decimal ?  NavigalbleWaterLevel { get; set; } 
        /// <summary>
        /// 设计水位(v1.2新增字段) 
        /// </summary>
        [Column("design_water_level",TypeName ="decimal(10,2)")]
        public decimal ?  DesignWaterLevel { get; set; } 
        /// <summary>
        /// 路面限高(v1.2新增字段) 
        /// </summary>
        [Column("road_height_limit",TypeName ="decimal(10,2)")]
        public decimal ?  RoadHeightLimit { get; set; } 
        /// <summary>
        /// 资金来源(v1.2新增字段) 
        /// </summary>
        [Column("fund_from",TypeName ="varchar(50)")]
        public string    FundFrom { get; set; } 
        /// <summary>
        /// 墩台类型(v1.2新增字段) 
        /// </summary>
        [Column("pier_type",TypeName ="varchar(12)")]
        public string    PierType { get; set; } 
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
        /// 限载(v1.2新增字段) 
        /// </summary>
        [Column("load_limit",TypeName ="varchar(10)")]
        public string    LoadLimit { get; set; } 
        /// <summary>
        /// 有无扩建,1有,0无(v1.2新增字段) 
        /// </summary>
        [Column("is_expand",TypeName ="int(4)")]
        public int ?  IsExpand { get; set; } 
        /// <summary>
        /// 建造日期(v1.2新增字段) 
        /// </summary>
        [Column("build_date",TypeName ="datetime")]
        public DateTime ?  BuildDate { get; set; } 
        /// <summary>
        /// 工程造价(万元)(v1.2新增字段) 
        /// </summary>
        [Column("construction_price",TypeName ="decimal(10,2)")]
        public decimal ?  ConstructionPrice { get; set; } 
        /// <summary>
        /// 养护类别(v1.3新增) (10 I类养护,11 Ⅱ类养护,12Ⅲ类养护,13Ⅳ类养护,15Ⅴ类养护,注意:这里没有14) 
        /// </summary>
        [Column("bridge_maintainType",TypeName ="int(4)")]
        public int    BridgeMaintainType { get; set; } 
        /// <summary>
        /// 结构类型(v1.3新增) 25 简支桥梁 26 连续梁桥 27 悬臂梁桥 28 组合梁桥 29 钢架桥 30 T型刚构桥 31 连续刚构桥 32 桁架拱桥 33 上承式拱桥 34 中承式拱桥 35 下承式拱桥 36 斜拉桥 37 悬索桥 97 桁架梁桥 
        /// </summary>
        [Column("struct_type",TypeName ="int(4)")]
        public int ?  StructType { get; set; } 
        /// <summary>
        /// 功能类型(v1.3新增) 16 跨江河桥 17 跨河涌桥 18 跨铁路桥 19 立交桥 20 高架桥 21 人行天桥 
        /// </summary>
        [Column("function_type",TypeName ="int(4)")]
        public int ?  FunctionType { get; set; } 
        /// <summary>
        /// 跨越类型(v1.3新增) 5 江河 6 河涌 7 铁路 8 道路 9 建筑物 
        /// </summary>
        [Column("crossing_type",TypeName ="int(4)")]
        public int ?  CrossingType { get; set; } 
        /// <summary>
        /// 跨越物体名称 
        /// </summary>
        [Column("cross_staff_name",TypeName ="varchar(50)")]
        public string    CrossStaffName { get; set; } 
        /// <summary>
        /// 所在位置地名 
        /// </summary>
        [Column("location_place_name",TypeName ="varchar(50)")]
        public string    LocationPlaceName { get; set; } 

     } 
} 