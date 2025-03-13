using DAL;
using Helper;
using HZY.Framework.DependencyInjection;
using Mapster;
using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class DataManager : IScopedSelfDependency {
        private readonly DataService _dataService;

        public DataManager(DataService dataService) {
            this._dataService = dataService;
        }
        public async Task<BaseResult> AddDataAsync(AddDataDto request) {
            var entity = request.Adapt<DataEntity>();
            var res =await _dataService.InsertAsync(entity);
            if(res <= 0) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = "插入数据失败" };
            }
            return new BaseResult();
        }
        public async Task<BaseResult< QueryDataResultDto>> GetDataListByTimeAsync(QueryDataDto request) {
            //查询在starttime和 endtime之间的数据，用SqlSugar.SqlFunc.Between
            var res = await _dataService.GetListAsync(i => SqlFunc.Between(i.InsertTime, request.StartTime, request.EndTime));
            return new BaseResult< QueryDataResultDto> { Data = res.Adapt<List<QueryDataResultDto>>() };
        }
    }
}
