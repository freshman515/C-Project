using ScadaSystem.Helper.Dtos;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using ScadaSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace ScadaSystem.Manager {
    public class ScadaReadDataManager {
        public ScadaReadDataManager(ScadaReadDataService scadaReadDataService) {
            this.scadaReadDataService = scadaReadDataService;
        }
        private ScadaReadDataService scadaReadDataService;


        public async Task<BaseResult> AddScadaReadDateAsync(ReadDataAddDto readDataAddDto) {
            var entity = readDataAddDto.Adapt<ScadaReadDataEntity>();
            //var isExist = await scadaReadDataService.IsExistAsync(i => i.Username == userAddDto.Username);
            //if (isExist) {
            //    return new BaseResult(false, "该用户已经存在");
            //}
            var res = await scadaReadDataService.AddAsync(entity);
            if (res <= 0) {
                return new BaseResult(false, "添加数据错误");
            }
            return new BaseResult();
        }
        public async Task<BaseResult> UpdateUserAsync(ReadDataUpdateDto request) {
            var entity = request.Adapt<ScadaReadDataEntity>();
            //var isExist = await scadaReadDataService.IsExistAsync(i => i.Username == entity.Username && i.Id != entity.Id);
            //if (isExist) {
            //    return new BaseResult(false, "修改的用户名以存在");
            //}
            var res = await scadaReadDataService.UpdateAsync(entity);
            if (!res) {
                return new BaseResult(false, $"更改数据失败");
            }
            return new BaseResult();
        }
        public async Task<BaseResult> DeleteUserAsync(ReadDataDeleteDto request) {
            var entity = request.Adapt<ScadaReadDataEntity>();
            var res = await scadaReadDataService.DeleteAsync(entity);
            if (!res) {
                return new BaseResult(false, $"删除数据失败");
            }
            return new BaseResult();
        }
        //查询所有数据
        public async Task<BaseResult<QueryReadDataResultDto>> GetReadDataListAsync() {
            var res = await scadaReadDataService.GetListAsync(c => true);
            var dtos = res.Adapt<List<QueryReadDataResultDto>>();
            return new BaseResult<QueryReadDataResultDto> { Status = true, Data = dtos };
        }

        public async Task<BaseResult<QueryReadDataResultDto>> GetListByDateAsync(QueryReadDataByDateDto request) {
            if (request.StartTime > request.EndTime) {
                return new BaseResult<QueryReadDataResultDto>() { Status = false, Message = "查询时间错误" };
            }
            var res = await scadaReadDataService.GetListAsync(i => i.CreateTime >= request.StartTime && i.CreateTime <= request.EndTime);
            var resList = res.Adapt<List<QueryReadDataResultDto>>();
            return new BaseResult<QueryReadDataResultDto> { Data = resList };
        }

        //分页查询
        public async Task<BaseResult<QueryReadDataResultDto>> GetListByPagingAsync(QueryReadDataByDateDto request) {
            if (request.StartTime > request.EndTime) {
                return new BaseResult<QueryReadDataResultDto>() { Status = false, Message = "查询时间错误" };
            }

            // 调用 Service 获取分页数据和总记录数
            var (res, totalNumber) = await scadaReadDataService.GetPagedListAsync(
                i => i.CreateTime >= request.StartTime && i.CreateTime <= request.EndTime,
                request.TotalPages, // 当前页数
                request.PageSize
            );

            // 计算总页数
            int totalPages = (int)Math.Ceiling((double)totalNumber / request.PageSize);

            // 转换 DTO
            var resList = res.Adapt<List<QueryReadDataResultDto>>();

            return new BaseResult<QueryReadDataResultDto> {
                Status = true,
                Message = "查询成功",
                Data = resList,
                TotalNumber = totalNumber, // 总条数
                TotalPages = totalPages // 总页数
            };

        }
    }
}
