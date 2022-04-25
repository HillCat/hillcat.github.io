using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary
{
    [Table("detection_static_test")]
    public class DetectionStaticTest
    {
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        /// <summary>
        /// 关联的桥梁id 
        /// </summary>
        [Column("bge_id", TypeName = "int(11)")]
        public int? BgeId { get; set; }
        /// <summary>
        /// 检测类型枚举,1、外观检测,2、静载试验,3、动载试验,4、无损检测,5、定期结构检测   6.人工监测测 7. 特殊检测    8.其它检测 
        /// </summary>
        [Column("type", TypeName = "tinyint(4)")]
        public sbyte? Type { get; set; }
        /// <summary>
        /// 检测时间 
        /// </summary>
        [Column("time", TypeName = "datetime")]
        public DateTime? Time { get; set; }
        /// <summary>
        /// 上传单位ID 
        /// </summary>
        [Column("upload_institiution_id", TypeName = "int(11)")]
        public int? UploadInstitiutionId { get; set; }
        /// <summary>
        /// 上传人ID 
        /// </summary>
        [Column("upload_user_id", TypeName = "int(11)")]
        public int? UploadUserId { get; set; }
        /// <summary>
        /// 检测人 
        /// </summary>
        [Column("det_name", TypeName = "varchar(50)")]
        public string DetName { get; set; }
        /// <summary>
        /// 检测单位 
        /// </summary>
        [Column("detInstitiution", TypeName = "varchar(50)")]
        public string DetInstitiution { get; set; }
        /// <summary>
        /// 检测结果 
        /// </summary>
        [Column("result", TypeName = "varchar(200)")]
        public string Result { get; set; }
        /// <summary>
        /// 检测结论 
        /// </summary>
        [Column("consequence", TypeName = "varchar(150)")]
        public string Consequence { get; set; }
        /// <summary>
        /// 审核人 
        /// </summary>
        [Column("auditor", TypeName = "varchar(20)")]
        public string Auditor { get; set; }
        /// <summary>
        /// 校核人 
        /// </summary>
        [Column("checker", TypeName = "varchar(20)")]
        public string Checker { get; set; }
        /// <summary>
        /// 检测报告文件URL 
        /// </summary>
        [Column("report_url", TypeName = "varchar(500)")]
        public string ReportUrl { get; set; }
        /// <summary>
        /// 项目名称 
        /// </summary>
        [Column("project_name", TypeName = "varchar(50)")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 归档编号 
        /// </summary>
        [Column("archive_lable", TypeName = "varchar(50)")]
        public string ArchiveLable { get; set; }
        /// <summary>
        /// 维修加固建议 
        /// </summary>
        [Column("maintenance_reinforcement", TypeName = "varchar(500)")]
        public string MaintenanceReinforcement { get; set; }
        /// <summary>
        /// 任务Id 
        /// </summary>
        [Column("task_id", TypeName = "int(11)")]
        public int? TaskId { get; set; }
        /// <summary>
        /// 检测单位Id 
        /// </summary>
        [Column("detInstitiutionId", TypeName = "int(11)")]
        public int? DetInstitiutionId { get; set; }
        /// <summary>
        /// 上传人名 
        /// </summary>
        [Column("upload_user_name", TypeName = "varchar(50)")]
        public string UploadUserName { get; set; }
        /// <summary>
        /// 备注 
        /// </summary>
        [Column("remark", TypeName = "varchar(200)")]
        public string Remark { get; set; }
        /// <summary>
        /// 检测内容 
        /// </summary>
        [Column("content", TypeName = "varchar(500)")]
        public string Content { get; set; }
        /// <summary>
        /// 制表人 
        /// </summary>
        [Column("scheduler", TypeName = "varchar(50)")]
        public string Scheduler { get; set; }
        /// <summary>
        /// 试验项目 
        /// </summary>
        [Column("lab_project", TypeName = "varchar(200)")]
        public string LabProject { get; set; }

    }
}
