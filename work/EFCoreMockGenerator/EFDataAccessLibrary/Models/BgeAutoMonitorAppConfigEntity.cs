using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDBS.Shared.Data.Entity.Jket
{
    /// <summary>
    /// 桥梁监测--自动化监测(appid,url配置,是否启用) 
    /// </summary>
    [Table("bge_auto_monitor_app_config")]
    public class BgeAutoMonitorAppConfigEntity
    {
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        /// <summary>
        /// 名字 
        /// </summary>
        [Column("name", TypeName = "varchar(50)")]
        public string name { get; set; }
        /// <summary>
        /// 序号(前端显示,冗余字段) 
        /// </summary>
        [Column("serial_number", TypeName = "int(11)")]
        public int? SerialNumber { get; set; }
        /// <summary>
        /// URL 
        /// </summary>
        [Column("url", TypeName = "varchar(500)")]
        public string Url { get; set; }
        /// <summary>
        /// 监控范围(桥梁Id,英文逗号隔开) 
        /// </summary>
        [Column("bridge_id", TypeName = "int(11)")]
        public int? BridgeId { get; set; }
        /// <summary>
        /// 监控范围(桥梁名称,英文逗号隔开,冗余字段) 
        /// </summary>
        [Column("bridge_name", TypeName = "varchar(500)")]
        public string BridgeName { get; set; }
        /// <summary>
        /// 监控范围(桥梁名称,英文逗号隔开,冗余字段) 
        /// </summary>
        [Column("bridge_no", TypeName = "varchar(100)")]
        public string BridgeNo { get; set; }
        /// <summary>
        /// 是否启用(1启用,0停用) 
        /// </summary>
        [Column("is_enable", TypeName = "int(4)")]
        public int? IsEnable { get; set; }
        /// <summary>
        /// appid 
        /// </summary>
        [Column("appid", TypeName = "varchar(120)")]
        public string Appid { get; set; }
        /// <summary>
        /// 创建时间 
        /// </summary>
        [Column("create_time", TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人 
        /// </summary>
        [Column("create_user", TypeName = "int(11)")]
        public int? CreateUser { get; set; }
        /// <summary>
        /// 修改时间 
        /// </summary>
        [Column("update_time", TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 修改人 
        /// </summary>
        [Column("update_user", TypeName = "int(11)")]
        public int? UpdateUser { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("is_deleted", TypeName = "int(11)")]
        public bool IsDeleted { get; set; }
    }
}
