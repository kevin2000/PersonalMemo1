using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using PersonalMemo.dal;

namespace PersonalMemo.model
{
    [Table("sys_user")]
    public class SysUser
    { 
        [Key]
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string  name { get; set; }
    }
}
