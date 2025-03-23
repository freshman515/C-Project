using ScadaSystem.Helper;
using ScadaSystem.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Services {
    public class ScadaReadDataService : BaseService<ScadaReadDataEntity> {
        public  async Task<(List<ScadaReadDataEntity> Data, int TotalCount)> GetPagedListAsync(
    Expression<Func<ScadaReadDataEntity, bool>> where, int pageIndex, int pageSize) {
            try {
                RefAsync<int> totalNumber = 0; // 使用 RefAsync<int> 变量存储总条数

                var dataList = await SqlSugarHelper.Db.Queryable<ScadaReadDataEntity>()
                    .Where(where)
                    .ToPageListAsync(pageIndex, pageSize, totalNumber);

                return (dataList, totalNumber);
            } catch (Exception) {
                throw;
            }
        }
    }
}
