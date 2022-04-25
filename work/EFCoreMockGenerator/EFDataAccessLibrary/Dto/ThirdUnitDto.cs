using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Dto
{
    public class ThirdUnitDto
    {
        /// <summary>
        /// 上传单位Id
        /// </summary>
        public int upload_insititution_Id { get; set; }
        /// <summary>
        /// 上传者id
        /// </summary>
        public int upload_user_Id { get; set; }
        /// <summary>
        /// 检测人名字
        /// </summary>
        public string det_name { get; set; }
        /// <summary>
        /// 三方单位名字
        /// </summary>
        public string detInstitution { get; set; }
        /// <summary>
        /// 检测单位Id
        /// </summary>
        public int detInsititutionId { get; set; }
        /// <summary>
        /// 上传者姓名
        /// </summary>
        public string upload_user_name { set; get; }
        /// <summary>
        /// 制表者
        /// </summary>
        public string scheduler { set; get; }
        /// <summary>
        /// 测试人
        /// </summary>
        public string auditor { get; set; }

    }
}
