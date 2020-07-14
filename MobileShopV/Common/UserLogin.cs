using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShopV.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UseerName { get; set; }
    }
}