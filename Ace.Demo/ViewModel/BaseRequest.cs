using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ace.Demo.ViewModel
{
    public class BaseRequest
    {
        public int? id { get; set; }

        public oper oper { get; set; }
    }

    public enum oper
    {
        /// <summary>
        /// 添加
        /// </summary>
        add = 1,

        /// <summary>
        /// 修改
        /// </summary>
        edit = 0,

        /// <summary>
        /// 删除
        /// </summary>
        del = -1
    }
}