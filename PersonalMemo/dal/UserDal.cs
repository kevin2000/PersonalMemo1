using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalMemo.model;
using PersonalMemo.common;
using PersonalMemo.context;

namespace PersonalMemo.dal
{
    public class UserDal:BaseDal<SysUser>
    {
        public static SysUser get(string username, string password)
        {
            string encryptPwd = password;
            if(Session.EncryptMode){
                encryptPwd = EncryptUtil.EncryptMd5Salt(password, password);
            }
            
            List<SysUser> users = GetList("where username=@username and password=@password", new { username = username, password = encryptPwd });
            if (users != null && users.Count > 0)
                return users.First<SysUser>();
            else
                return null;
        }
    }
}
