using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalMemo.model;
/* ==============================================================================
 * 功能描述：Class1  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 14:40:20
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo.context
{
    /// <summary>
    /// 会话信息，相当于web中的session
    /// </summary>
    public class Session
    {
        //当前登录用户
        public static SysUser currUser;
    }
}
