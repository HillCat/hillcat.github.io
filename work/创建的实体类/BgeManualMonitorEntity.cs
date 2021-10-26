using System;
using System.Collections.Generic;
using System.Text; 
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace  GDBS.BridgeService.Domain 
 { 
     /// <summary>
     /// 桥梁监测--->人工监测,测点版本数据主表 
     /// </summary>
     [Table("bge_manual_monitor")]
      public  class BgeManualMonitorEntity:Entity<int>
     {

        /// <summary>
        /// 桥梁id 
        /// </summary>
        [Column("bge_id", TypeName = "int(11)")]
        public int? BgeId { get; set; }
        /// <summary>
        /// 桥梁名称 
        /// </summary>
        [Column("bge_name", TypeName = "varchar(50)")]
        public string BgeName { get; set; }
        /// <summary>
        /// 版本名称,格式为“2013-03-18” 
        /// </summary>
        [Column("ver_name", TypeName = "varchar(20)")]
        public string VerName { get; set; }
        /// <summary>
        /// 监测时间 输出给前端格式为"2021-05-08" 
        /// </summary>
        [Column("monitor_time", TypeName = "datetime")]
        public DateTime? MonitorTime { get; set; }
        /// <summary>
        /// 挠度是否超限,1 是,0 否 
        /// </summary>
        [Column("naodu_over", TypeName = "int(1)")]
        public int? NaoduOver { get; set; }
        /// <summary>
        /// 主要受力构件结构变形变位是否超限,1 是,0 否 
        /// </summary>
        [Column("bianxing_over", TypeName = "int(1)")]
        public int? BianxingOver { get; set; }
        /// <summary>
        /// 上传的相关报告附件,格式:.rar .zip .doc .docx .pdf .jpg 
        /// </summary>
        [Column("upload_file_url", TypeName = "varchar(500)")]
        public string UploadFileUrl { get; set; }
        /// <summary>
        /// 上传的“布点图”, 格式: .png .jpg 
        /// </summary>
        [Column("upload_img_url", TypeName = "varchar(500)")]
        public string UploadImgUrl { get; set; }
        /// <summary>
        /// 上传时间 
        /// </summary>
        [Column("upload_time", TypeName = "datetime")]
        public DateTime? UploadTime { get; set; }
        /// <summary>
        /// 监测单位名称 
        /// </summary>
        [Column("company_name", TypeName = "varchar(100)")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 监测单位ID 
        /// </summary>
        [Column("company_id", TypeName = "int(11)")]
        public int? CompanyId { get; set; }
        /// <summary>
        /// 创建用户 
        /// </summary>
        [Column("create_userid", TypeName = "int(11)")]
        public int? CreateUserid { get; set; }
        /// <summary>
        /// 创建时间 
        /// </summary>
        [Column("create_time", TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 是否删除,0为未删除,1为已删除,默认为0 
        /// </summary>
        [Column("is_deleted", TypeName = "int(1)")]
        public int? IsDeleted { get; set; }
        /// <summary>
        /// 删除人id 
        /// </summary>
        [Column("delete_userid", TypeName = "int(11)")]
        public int? DeleteUserid { get; set; }
        /// <summary>
        /// 删除时间 
        /// </summary>
        [Column("delete_time", TypeName = "datetime")]
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 修改人id 
        /// </summary>
        [Column("update_userid", TypeName = "int(11)")]
        public int? UpdateUserid { get; set; }
        /// <summary>
        /// 修改时间 
        /// </summary>
        [Column("update_time", TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }

    } 
} 