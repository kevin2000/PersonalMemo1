using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* ==============================================================================
 * 功能描述：Class1  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 14:40:20
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo.common
{
    /// <summary>
    /// 分页对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageData<T>
    {
        public int pageCount { get {
            if (totalNum % pageSize == 0)
                return totalNum/pageSize;
            else
                return totalNum / pageSize+1;
        } }
        public int pageSize { get; set; }
        public int pageNo { get; set; }
        public List<T> list { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int totalNum { get; set; }
    }
}
