using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalMemo.model;

namespace PersonalMemo.dal
{
    public class UserDal:BaseDal<SysUser>
    {
        public static SysUser get(string username, string password)
        { 
            List<SysUser> users = GetList("where username=@username and password=@password", new { username=username,password=password});
            if (users != null && users.Count > 0)
                return users.First<SysUser>();
            else
                return null;
        }
    }
}
