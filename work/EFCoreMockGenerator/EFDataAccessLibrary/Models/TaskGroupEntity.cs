using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary
{
    [Table("task_group")]
    public class TaskGroupEntity
    {
        /// <summary>
        /// 主键ID 
        /// </summary>
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        /// <summary>
        /// 单位id,冗余任务主表接收单位id(即第三方单位id) 
        /// </summary>
        [Column("unitId", TypeName = "int(11)")]
        public int? UnitId { get; set; }
        /// <summary>
        /// 冗余任务表任务类型字段,1日常巡查,2桥梁检测,3专项评估,4维修加固,5完善资料,6其他 
        /// </summary>
        [Column("task_type_id", TypeName = "int(11)")]
        public int? TaskTypeId { get; set; }
        /// <summary>
        /// 任务组名称 
        /// </summary>
        [Column("task_group_name", TypeName = "varchar(200)")]
        public string TaskGroupName { get; set; }
        /// <summary>
        /// 是否删除,0为未删除,1为已删除,默认为0 
        /// </summary>
        [Column("is_deleted", TypeName = "int(1) unsigned zerofill")]
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
        [Column("update_time", TypeName = "date")]
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
        /// 任务组完成时间 
        /// </summary>
        [Column("complete_time", TypeName = "datetime")]
        public DateTime? CompleteTime { get; set; }
        /// <summary>
        /// 是否已完成,1为已完成,0为未完成 
        /// </summary>
        [Column("is_complete", TypeName = "int(1)")]
        public int? IsComplete { get; set; }
        /// <summary>
        /// 发布任务的单位id v1.3 
        /// </summary>
        [Column("delegate_unit_id", TypeName = "int(11)")]
        public int? DelegateUnitId { get; set; }
        /// <summary>
        /// 短信接收人登录账号userAcc 
        /// </summary>
        [Column("thirdparty_user_acc", TypeName = "varchar(50)")]
        public string ThirdpartyUserAcc { get; set; }
        /// <summary>
        /// 短信接收人手机号 
        /// </summary>
        [Column("thirdparty_user_phoneNo", TypeName = "varchar(50)")]
        public string ThirdpartyUserPhoneNo { get; set; }
        /// <summary>
        /// 任务结束时间限期 v1.3 
        /// </summary>
        [Column("time_end", TypeName = "datetime")]
        public DateTime? TimeEnd { get; set; }
        /// <summary>
        /// 短信接收人姓名 
        /// </summary>
        [Column("thirdparty_user_name", TypeName = "varchar(50)")]
        public string ThirdpartyUserName { get; set; }
        /// <summary>
        /// 任务指定开始日期 
        /// </summary>
        [Column("time_start", TypeName = "datetime")]
        public DateTime? TimeStart { get; set; }
        /// <summary>
        /// 愈期状态,1.逾期：超过任务要求完成时间; 2.正常 
        /// </summary>
        [Column("overdue_status", TypeName = "int(11)")]
        public int? OverdueStatus { get; set; }
        /// <summary>
        /// 第三方单位对任务的建议 
        /// </summary>
        [Column("thirdparty_user_advice", TypeName = "varchar(1000)")]
        public string ThirdpartyUserAdvice { get; set; }
        /// <summary>
        /// 目前只针对巡查任务组  0:组任务完成但未确认   1:组任务完成并已确认 
        /// </summary>
        [Column("confirmed", TypeName = "int(11)")]
        public int? Confirmed { get; set; }
        /// <summary>
        /// 确认时间 
        /// </summary>
        [Column("confirmed_time", TypeName = "datetime")]
        public DateTime? ConfirmedTime { get; set; }
    }
}
