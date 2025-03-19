using ScadaSystem.Helper;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Services {
    public class BaseService<T> where T : BaseEntity, new() {
        public virtual async Task<int> AddAsync(T entity) {
            try {
                int rows = await SqlSugarHelper.Db.Insertable<T>(entity).ExecuteCommandAsync();
                return rows;
            } catch (Exception) {
                throw;
            }
        }
        public virtual async Task<bool> DeleteAsync(T entity) {
            try {

                int rows = await SqlSugarHelper.Db.Deleteable(entity).ExecuteCommandAsync();
                return rows > 0;
            } catch (Exception) {
                throw;
            }
        }
        public virtual async Task<bool> UpdateAsync(T entity) {
            try {
                int rows = await SqlSugarHelper.Db.Updateable(entity).ExecuteCommandAsync();
                return (rows > 0);
            } catch (Exception) {
                throw;
            }
        }
        //条件查询一个数据
        public virtual async Task<T> GetByOneAsync(Expression<Func<T, bool>> where) {
            try {
                return await SqlSugarHelper.Db.Queryable<T>().Where(where).FirstAsync();
            } catch (Exception) {
                throw;
            }
        }
        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> where) {
            try {
                return await SqlSugarHelper.Db.Queryable<T>().Where(where).ToListAsync();
            } catch (Exception) {
                throw;
            }
        }
        public virtual async Task<bool> IsExistAsync(Expression<Func<T,bool>> where) {
            try {
                return await SqlSugarHelper.Db.Queryable<T>().Where(where).AnyAsync();
            } catch (Exception) {
                throw;
            }
        }
    }
}
