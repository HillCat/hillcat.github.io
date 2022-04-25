using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary
{
    public class BridgeTaskEntity
    {
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        /// <summary>
        /// 桥梁id 
        /// </summary>
        [Column("bridge_id", TypeName = "int(11)")]
        public int? BridgeId { get; set; }
        /// <summary>
        /// 桥梁名称 
        /// </summary>
        [Column("bridge_name", TypeName = "varchar(100)")]
        public string BridgeName { get; set; }
        /// <summary>
        /// 桥梁编号 
        /// </summary>
        [Column("bridge_no", TypeName = "varchar(100)")]
        public string BridgeNo { get; set; }
        /// <summary>
        /// 任务id 
        /// </summary>
        [Column("task_id", TypeName = "int(11)")]
        public int? TaskId { get; set; }
        /// <summary>
        /// 是否删除：0为未删除,1为已删除,默认为0 
        /// </summary>
        [Column("is_deleted", TypeName = "int(1)")]
        public int? IsDeleted { get; set; }
        /// <summary>
        /// 创建人id 
        /// </summary>
        [Column("create_userid", TypeName = "int(11)")]
        public int? CreateUserid { get; set; }
        /// <summary>
        /// 任务接收人id 
        /// </summary>
        [Column("receive_userid", TypeName = "int(11)")]
        public int? ReceiveUserid { get; set; }
        /// <summary>
        /// 创建时间 
        /// </summary>
        [Column("create_time", TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
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
        /// 备注 
        /// </summary>
        [Column("remark", TypeName = "varchar(200)")]
        public string Remark { get; set; }
        /// <summary>
        /// 任务组id 
        /// </summary>
        [Column("taskGroup_id", TypeName = "int(11)")]
        public int? TaskGroupId { get; set; }
    }
}
