using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalMemo.common;
using System.Data;
/* ==============================================================================
 * 功能描述：Class1  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 14:40:20
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo.dal
{
    public class BaseDal<T>
    {
        public static T Get(string id) {
            return DbHelper.Get<T>(id);
        }
        public static List<T> GetAll()
        {
            return DbHelper.GetList<T>("where 1=1");
        }
        public static List<T> GetList(string condition, object paras = null) {
            return DbHelper.GetList<T>(condition, paras);
        }
        public static PageData<T> GetPages(int pageNo, int pageSize, string condition, string orderby)
        {
            return DbHelper.GetPages<T>(pageNo, pageSize, condition, orderby);
        }
        public static bool Add(T entity)
        {
            return DbHelper.Add<T>(entity);
        }
        public static bool Add(T entity,IDbTransaction tran)
        {
            return DbHelper.Add<T>(entity,tran);
        }
        public static bool Remove(string id)
        {
            return DbHelper.Remove<T>(id);
        }
        public static bool Remove(string id,IDbTransaction tran)
        {
            return DbHelper.Remove<T>(id,tran);
        }
        public static bool Modify(T entity)
        {
            return DbHelper.Modify<T>(entity);
        }
        public static bool Modify(T entity,IDbTransaction tran)
        {
            return DbHelper.Modify<T>(entity,tran);
        }
        public static bool Execute(string sql, object paras = null)
        {
            return DbHelper.Execute(sql, paras);
        }
        public static bool Execute(string sql, IDbTransaction tran, object paras = null)
        {
            return DbHelper.Execute(sql, tran, paras);
        }
        public static bool Removes(string condition, object paras = null)
        {
            return DbHelper.Removes<T>(condition, paras);
        }
        public static IDbTransaction getTransaction() {
            return DbHelper.getTransaction();
        }
    }
}
