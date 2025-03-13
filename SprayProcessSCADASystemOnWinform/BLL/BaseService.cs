using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    //T 继承 BaseEntity
    //T 有无参构造函数
    public class BaseService<T> where T : BaseEntity, new() {
        public virtual async Task<int> InsertAsync(T model) {
            try {
                // 创建了一个可执行的 SQL 命令
                var runsql = DB.SqlSugarClient.Insertable<T>(model);
                //执行命令
                var rows = await runsql.ExecuteCommandAsync();
                return rows;

            } catch (Exception) {
                throw;
            }
        }
        public virtual async Task<bool> UpdateAsync(T model) {
            try {
                var runsql = DB.SqlSugarClient.Updateable(model);
                int rows =  await runsql.ExecuteCommandAsync();
                return rows > 0;
            } catch (Exception) {

                throw;
            }
        } 
        public virtual async Task<bool> DeleteAsync(T model) {
            try {

                var runsql = DB.SqlSugarClient.Deleteable(model);
                int rows = await runsql.ExecuteCommandAsync();
                return rows > 0;
            } catch (Exception) {

                throw;
            }
        }
        //Expression<> 是 表达式树，它不是直接的委托，而是一种可以被解析为 SQL 查询的结构。
        //where 作为参数传递进方法后，会被 ORM（如 SqlSugar）解析成 SQL 语句，用于数据库查询。
        public virtual async Task<T> GetByOneAsync(Expression<Func<T, bool>> where) {
            //相当于：SELECT * FROM 表名 WHERE 条件
            var runsql = DB.SqlSugarClient.Queryable<T>().Where(where);
            //SELECT TOP 1 * FROM 表名 WHERE 条件
            return await runsql.FirstAsync();
        }

        /// <summary>
        /// 查询一批数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetListAsync(Expression<Func<T,bool>> where) {
            var runsql = DB.SqlSugarClient.Queryable<T>().Where(where);
            return await runsql.ToListAsync();
        }

        public virtual Task<bool> IsExistAsync(Expression<Func<T, bool>> where) {
            return DB.SqlSugarClient.Queryable<T>().Where(where).AnyAsync();
        }
    }
}
