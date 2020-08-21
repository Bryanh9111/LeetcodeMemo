using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LeetcodeMemoApp_V1.Model;
using Mapster;

namespace LeetcodeMemoApp_V1.Entity
{
    public class DatabaseProvider
    {
        DatabaseContext _database;
        /// <summary>
        /// constructor
        /// </summary>
        public DatabaseProvider()
        {
            _database = new DatabaseContext();
        }
        /// <summary>
        /// GetLeetcodeMemoEntities
        /// </summary>
        /// <returns></returns>
        public IList<LeetcodeMemoEntity> GetLeetcodeMemoEntities()
        {
            try
            {
                var result = _database.LeetCodeMemo;
                return result != null ? result.ToList() : new List<LeetcodeMemoEntity>();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// GetLeetcodeMemoEntityByIndex
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LeetcodeMemoEntity GetLeetcodeMemoEntityByIndex(int index)
        {
            if (index <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(index)} is invalid.");

            try
            {
                var result = _database.LeetCodeMemo.Where(r => r.ProblemIndex == index).FirstOrDefault();
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public void UpdateLeetcodeMemoEntity(LeetcodeMemoModel leetcodeMemo)
        {
            try
            {
                var record = _database.LeetCodeMemo.Where(l => l.ID == leetcodeMemo.ID).FirstOrDefault();
                if(record != null)
                {
                    record = leetcodeMemo.Adapt(record);
                    _database.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// AddNewMemo
        /// </summary>
        /// <param name="memoEntity"></param>
        public void AddNewMemo(LeetcodeMemoEntity memoEntity)
        {
            try
            {
                _database.LeetCodeMemo.Add(memoEntity);
                _database.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// CopyTempLeetcodetoLeetcode
        /// </summary>
        public void CopyTempLeetcodetoLeetcode()
        {
            try
            {
                List<SqlParameter> parameterLst = new List<SqlParameter>();
                parameterLst.Add(new SqlParameter("@xxx", "value"));
                SqlParameter[] parameters = parameterLst.ToArray();
                _database.Database.ExecuteSqlCommand("EXEC dbo.usp_Transfer_LeetcodeTemp_To_Leetcode");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
