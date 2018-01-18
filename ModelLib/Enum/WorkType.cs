using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLib
{
    /// <summary>
    /// 工作类型枚举
    /// </summary>
    public enum WorkType
    {
        /// <summary>
        /// 文员
        /// </summary>
        [Display(Name = "文员", Description = "文员描叙")]
        Clerk = 0,

        /// <summary>
        /// 销售
        /// </summary>
        [Display(Name = "销售", Description = "销售描叙")]
        Sales = 1,

        /// <summary>
        /// 管理人员
        /// </summary>
        [Display(Name = "管理人员", Description = "管理人员描叙")]
        Management

    }
}
