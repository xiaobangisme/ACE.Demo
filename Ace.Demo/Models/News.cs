using System;
using System.Collections.Generic;

namespace Ace.Demo.Models
{
    public partial class News
    {
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string Content { get; set; }
        public string ImageFile { get; set; }
        public string CreDate { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public Nullable<int> ClickNumber { get; set; }
        public string NewsType { get; set; }
    }
}
