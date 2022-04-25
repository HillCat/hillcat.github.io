using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary
{ 
    
     /// <summary>
     /// 桥梁基础信息表,A.信息主表: 维护桥梁最基本的信息,B.UID-是为了和PAD端同步的唯一编码 桥梁与结构部分相关的表都有此字段 (不能用ID),C.ModityDate: 新设计取消了信息版本, PAD和WEB的信息同步直接使用修改时间与UID就可以.,D.LatestVersion: 最新一个 [可用结构版本],E.BgeNO: 桥梁编号, 用于省桥梁系统同步,F.Town: 县城为手填非字典.,G.GPS: 百度地图标记的经纬度.,H.LocateType: 地理类型: 约定枚举 1-省内 2-省外,I.BgeStatus: 桥梁状态, 1为正常 2为检测中. 在检测中的桥梁, 任何公司都不能把它加入新建项目中,J.ComID: 这里指代第一家创建这条桥的公司ID,之后修改桥结构可能有不同公司维护然后累加结构版本, 桥梁创建遵守哪家公司创建就归属哪家公司的原则, 但是, 如果是省内桥梁类型, 则所有公司均可见且可以直接维护, 故此, 如果一条桥在检测中状态, 其他公司不能通过项目把它添加到自己的新项目中.,K.AuditStatus审核状态-草稿/已提交/已审核,L.RuleType: 桥梁规范类型: 约定枚举 1-公路版国标 2-市政版国标 3-市政版省标 只是个参考用的字段. BCI计算以项目的RuleType为主 ,,M.组织结构下面的桥梁显示单位与桥梁关系,桥梁为所有关系的桥梁。 
     /// </summary>
     [Table("bge_info")]
      public  class BgeInfoEntityDongGuan
     {  
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id",TypeName ="int(11) unsigned")]
        public int    Id { get; set; } 
        /// <summary>
        /// UID 
        /// </summary>
        [Column("uid",TypeName ="varchar(36)")]
        public string    Uid { get; set; } 
        /// <summary>
        /// 公司ID 
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
        /// 启用 
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
        ///  
        /// </summary>
        [Column("constructionint_id",TypeName ="int(11)")]
        public int ?  ConstructionintId { get; set; } 
        /// <summary>
        /// 是否是危桥：1、是危桥,2、正常 
        /// </summary>
        [Column("risk_state",TypeName ="tinyint(4)")]
        public sbyte ?  RiskState { get; set; } 
        /// <summary>
        ///  
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
        /// 旧桥梁系统id 
        /// </summary>
        [Column("sync_bridge_id",TypeName ="varchar(255)")]
        public string    SyncBridgeId { get; set; } 
        /// <summary>
        ///  
        /// </summary>
        [Column("bridge_name",TypeName ="varchar(255)")]
        public string    BridgeName { get; set; } 
        /// <summary>
        /// 桥梁id 
        /// </summary>
        [Column("bridge_id",TypeName ="int(11)")]
        public int ?  BridgeId { get; set; } 
        /// <summary>
        /// 桥梁编号 
        /// </summary>
        [Column("bridge_code",TypeName ="int(11)")]
        public int ?  BridgeCode { get; set; } 
        /// <summary>
        /// 区域编号 
        /// </summary>
        [Column("area_code",TypeName ="int(11)")]
        public int ?  AreaCode { get; set; } 
        /// <summary>
        /// 桥梁类型 
        /// </summary>
        [Column("bridge_type",TypeName ="int(11)")]
        public int ?  BridgeType { get; set; } 

     } 
} 