using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryMachine
{
    /// <summary>
    /// 查询车辆信息记录
    /// </summary>
    public class SearchModel : IEqualityComparer<SearchModel>
    {
        public SearchModel() { }

        public SearchModel(string carNo, DateTime inTime)
        {
            this.carNo = carNo;
            this.inTime = inTime;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNo { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime inTime { get; set; }

        public bool Equals(SearchModel x, SearchModel y)
        {
            return true;
        }

        public int GetHashCode(SearchModel obj)
        {
            return obj.carNo.GetHashCode();
        }
    }
}
