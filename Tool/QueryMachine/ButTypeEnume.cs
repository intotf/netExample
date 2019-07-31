using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueryMachine
{
    /// <summary>
    /// 按钮类型枚举
    /// </summary>
    public enum ButTypeEnume
    {
        /// <summary>
        /// 区域按键
        /// </summary>
        [Display(Name = "区域按键")]
        AreaKey = 1,

        /// <summary>
        /// 键盘A-Z,0-9
        /// </summary>
        [Display(Name = "键盘A-Z,0-9")]
        Keyboard = 0
    }
}
