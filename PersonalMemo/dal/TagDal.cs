using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalMemo.model;
using System.Data;

namespace PersonalMemo.dal
{
    public class TagDal:BaseDal<Tag>
    {
        public static List<Tag> GetMyTags(string userid)
        {
            return GetList("where userid=@userid", new { userid=userid});
        }
        public static bool IsExistTag(string userid, string tag)
        {
            List<Tag> tags = GetList("where userid=@userid and tag=@tag", new { userid = userid ,tag=tag});
            if (tags != null && tags.Count > 0)
                return true;
            else
                return false;
        }
        public static bool AddTagAndMemo(Tag tag,Memo memo)
        {
            IDbTransaction tran = getTransaction();
            try
            {
                if (Add(tag,tran))
                {
                    if (MemoDal.Add(memo,tran))
                    {
                        tran.Commit();
                        return true;
                    }
                    else
                    {
                        tran.Rollback();
                        return false;
                    }
                }
                else
                {
                    tran.Rollback();
                    return false;
                }
            }
            catch (Exception) {
                tran.Rollback();
                return false;
            }
            finally
            { 
                tran.Dispose(); 
            } 
        }
        public static bool RemoveTagAndMemo(string tagId)
        {
            IDbTransaction tran = getTransaction();
            try
            {
                if (Remove(tagId,tran))
                {
                    if (MemoDal.Remove(tagId, tran))
                    {
                        tran.Commit();
                        return true;
                    }
                    else
                    {
                        tran.Rollback();
                        return false;
                    }
                }
                else
                {
                    tran.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                tran.Dispose();
            }
        }
    }
}
