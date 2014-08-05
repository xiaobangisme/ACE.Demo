using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ace.Demo.ViewModel
{
    public class RoleModel:BaseRequest
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}