using System;
using System.Collections.Generic;
using System.Text; 
using System.ComponentModel.DataAnnotations.Schema;

namespace GDBS.Shared.Data
{ 
     /// <summary>
     /// 自动化监测-监测主体表 
     /// </summary>
     [Table("mnt_subject")]
      public  class MntSubjectEntity
     {
         /// <summary>
         /// 主键ID 
         /// </summary>
         [Column("id", TypeName = "int(11)")]
         public int Id { get; set; }
        /// <summary>
        /// 桥梁编号
        /// </summary>
        [Column("bge_no",TypeName ="varchar(50)")]
        public string BgeNo { get; set; }
        /// <summary>
        /// 运营监测开始时间 
        /// </summary>
        [Column("monitor_begin_time",TypeName ="datetime")]
        public DateTime ?  MonitorBeginTime { get; set; } 
        /// <summary>
        /// 创建时间 
        /// </summary>
        [Column("create_time",TypeName ="datetime")]
        public DateTime ?  CreateTime { get; set; } 
        /// <summary>
        /// 创建人id 
        /// </summary>
        [Column("creator_id",TypeName ="int(11)")]
        public int ?  CreatorId { get; set; } 
        /// <summary>
        /// 创建人 
        /// </summary>
        [Column("creator",TypeName ="varchar(255)")]
        public string    Creator { get; set; } 
        /// <summary>
        /// 修改时间 
        /// </summary>
        [Column("modify_time",TypeName ="datetime")]
        public DateTime ?  ModifyTime { get; set; } 
        /// <summary>
        /// 修改人id 
        /// </summary>
        [Column("modifier_id",TypeName ="int(11)")]
        public int ?  ModifierId { get; set; } 
        /// <summary>
        /// 修改人 
        /// </summary>
        [Column("modifier",TypeName ="varchar(255)")]
        public string    Modifier { get; set; } 
        /// <summary>
        /// 是否已删除 
        /// </summary>
        [Column("Is_deleted",TypeName ="int(4)")]
        public bool    IsDeleted { get; set; } 

     } 
} 