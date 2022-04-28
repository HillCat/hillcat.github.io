using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Dto
{
    public class AutomonitorDto
    {
        public int status { get; set; }
        public string name { get; set; }
        public string url { set; get; }

        public string bridgeId { get; set; }

        public int isEnable { get; set; }

        public string appid { set; get; }


    }
}
