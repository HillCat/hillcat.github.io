using System;
using System.Collections.Generic;
using System.Text;

namespace GDBS.Shared.Data.Const
{
  public static  class WebApiHeaderStrConst
    {
        /// <summary>
        /// Head_Authorization=Authorization
        /// </summary>
        public const string Head_Authorization = "Authorization";

        /// <summary>
        /// Head_MediaType=application/json
        /// </summary>
        public const string Head_MediaType="application/json";

        /// <summary>
        /// Bearer 常量
        /// </summary>
        public const string BearerStr = "Bearer";

        /// <summary>
        ///  Bearer 常量 有空格
        /// </summary>
        public const string BearerHaveEmptyStr = "Bearer ";
    }
}
