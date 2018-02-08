using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexApp
{
    /// <summary>
    /// 查询结果类
    /// </summary>
    public class ResultModel
    {
        public ResultModel(int Num, string Value)
        {
            this.Num = Num;
            this.Value = Value;
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
