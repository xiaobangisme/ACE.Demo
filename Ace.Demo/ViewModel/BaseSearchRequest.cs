using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ace.Demo.ViewModel
{
    public class BaseSearchRequest
    {
        public string sidx { get; set; }

        public string sord { get; set; }

        public int page { get; set; }

        public int rows { get; set; }
    }
}