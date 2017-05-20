using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using PersonalMemo.dal;

namespace PersonalMemo.model
{
    /// <summary>
    ///备忘录
    /// </summary>
    public class Memo
    { 
        [Key]
        [Required]
        public string tagid { get; set; }
        public string  content { get; set; }
        public DateTime lasttime { get; set; }
        public string salt { get; set; }
    }
}
