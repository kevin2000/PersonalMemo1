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
    public class StringUtil
    {
        /// <summary>
        /// 返回32位不带任何符号的guid字符串
        /// 
        /// </summary>
        /// <returns></returns>
        public static string getGuidN() {
            return Guid.NewGuid().ToString("N");
        }
    }
}
