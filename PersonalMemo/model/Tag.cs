using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using PersonalMemo.dal;

namespace PersonalMemo.model
{
    /// <summary>
    ///  
    /// </summary>
   [Table("tag")]
    public class Tag
    { 
       [Key]
       [Required]
       public string id { get; set; }
       public string userid { get; set; }
       public string tag { get; set; }
       public DateTime addtime { get; set; }
    }
}
