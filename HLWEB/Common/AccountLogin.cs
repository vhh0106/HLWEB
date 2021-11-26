using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLWEB.Common
{
    [Serializable]
    public class AccountLogin
    {
        public long AccountID { get; set; }
        public string UserName { get; set; }
    }
}