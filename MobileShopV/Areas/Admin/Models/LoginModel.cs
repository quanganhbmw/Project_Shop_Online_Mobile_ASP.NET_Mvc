using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShopV.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập User Name")]
        public string UserNamee { set; get; }
        [Required(ErrorMessage = "Mời nhập PassWord")]
        public string PassWordd { set; get; }
        public bool Remember { get; set; }
    }
}
