using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Dapper;
using PersonalMemo.model;
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
    /// <summary>
    /// 引用dapper和dapper.simpleCRUD简化操作(https://github.com/ericdc1/Dapper.SimpleCRUD)
    /// </summary>
    public class DbHelper
    {
        private static string strConnection = Environment.CurrentDirectory+ "\\memo.db";
        
        protected static SQLiteConnection GetSQLiteConnection(bool open = false)
        {
            //指定数据库类型
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLite);

            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
            sb.DataSource = strConnection;
            SQLiteConnection con = new SQLiteConnection(sb.ToString());
            if(open)
                con.Open();
            return con; 
        }
        /// <summary>
        /// 开始一个事务
        /// </summary>
        /// <returns></returns>
        public static IDbTransaction getTransaction() {
            IDbConnection con = GetSQLiteConnection(true);
            return con.BeginTransaction();  
        }
        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Get<T>(string id) 
        { 
            using (SQLiteConnection con=GetSQLiteConnection())
            { 
                return con.Get<T>(id);
            }
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereConditions"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string whereConditions,object paras=null)
        {
            using (SQLiteConnection con=GetSQLiteConnection())
            {   
                return con.GetList<T>(whereConditions,paras).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="condition">"where age = 10 or Name like '%Smith%'"</param>
        /// <param name="orderby">"Name desc"</param>
        /// <returns>当总页数大于当前页数时，返回当前页，否则，list返回null</returns>
        public static PageData<T> GetPages<T>(int pageNo,int pageSize,string condition,string orderby) {
            PageData<T> pages = new PageData<T>();
            pages.pageSize = pageSize;
            pages.pageNo = pageNo;
            using (SQLiteConnection con = GetSQLiteConnection())
            { 
                pages.totalNum= con.RecordCount<T>(condition);
                if(pages.pageCount>=pageNo)
                    pages.list = con.GetListPaged<T>(pageNo, pageSize, condition, orderby).ToList();
            } 
            return pages;
        }
        public static bool Add<T>(T t)
        {
            try
            {
                using (SQLiteConnection con = GetSQLiteConnection())
                {
                    con.Insert<string>(t);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Add<T>(T t,IDbTransaction tran)
        {
            try
            { 
                tran.Connection.Insert<string>(t,tran); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Modify<T>(T entity) {
            try
            {
                using (IDbConnection con = GetSQLiteConnection())
                {
                    con.Update(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Modify<T>(T entity,IDbTransaction tran)
        {
            try
            { 
                tran.Connection.Update(entity,tran); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Execute(string sql, object paras = null)
        {
            try
            { 
                using (IDbConnection con = GetSQLiteConnection())
                {  
                    con.Execute(sql,paras);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Execute(string sql, IDbTransaction tran, object paras = null)
        {
            try
            { 
                tran.Connection.Execute(sql, paras); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Remove<T>(string id) {
            try
            {
                using (SQLiteConnection con = GetSQLiteConnection())
                { 
                    con.Delete<T>(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Remove<T>(string id,IDbTransaction tran)
        {
            try
            { 
                tran.Connection.Delete<T>(id); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Removes<T>(string condition,object paras=null)
        {
            try
            {
                using (SQLiteConnection con = GetSQLiteConnection())
                { 
                    con.DeleteList<T>(condition,paras);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    } 
}
