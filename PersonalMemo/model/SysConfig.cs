using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
/* ==============================================================================
 * 功能描述：SysConfig  
  * 创 建 者：liqiao
  * 创建日期：2017/5/22 11:43:46
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo.model
{
    /// <summary>
    /// 系统配置
    /// </summary>
    [Table("sys_config")]
    public class SysConfig
    {
        [Key]
        [Required]
        public string id { get; set; }
        public string name{ get; set; }
        public string convalue { get; set; }
    }
}
