using DAL;
using Helper;
using HZY.Framework.DependencyInjection;
using Mapster;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class RecipeManager : IScopedSelfDependency {
        private readonly RecipeService _recipeService;

        public RecipeManager(RecipeService recipeService) {
            this._recipeService = recipeService;
        }

        public async Task<BaseResult> AddRecipeAsync(AddRecipeDto request) {
            var isExist = await _recipeService.IsExistAsync(i => i.产品类型 == request.产品类型);
            if (isExist) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"配方{request.产品类型}已经存在" };
            }
            var entity = request.Adapt<RecipeEntity>();
            var res = await _recipeService.InsertAsync(entity);
            if (res <= 0) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"配方{entity.产品类型}添加失败" };
            }
            return new BaseResult();
        }

        public async Task<BaseResult> UpdateRecipeAsync(UpdateRecipeDto request) {
            //var isexist = await _recipeservice.isexistasync(i => i.产品类型 == request.产品类型);
            //if (!isexist) {
            //    return new baseresult() { status = systemenums.result.fail, message = $"配方{request.产品类型}不存在" };
            //}
            var entity = request.Adapt<RecipeEntity>();
            var res = await _recipeService.UpdateAsync(entity);
            if (!res) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"配方{entity.产品类型}更新失败" };
            }
            return new BaseResult();
        }
        public async Task<BaseResult> DeleteRecipeAsync(DeleteRecipeDto request) {
            var entity = request.Adapt<RecipeEntity>();
            //通过映射一个主键所得到的对象,就能够通过sqlsugar 的库来进行删除数据库表的一条数据
            var res = await _recipeService.DeleteAsync(entity);
            if (!res) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"配方{entity.产品类型}删除失败" };
            }
            return new BaseResult();
        }
        public async Task<BaseResult<QueryRecipeResultDto>> GetRecipeListAsync() {
            var res = await _recipeService.GetListAsync(i => true);
            var dtos = res.Adapt<List<QueryRecipeResultDto>>(); //把实体类数组映射为Dto层的数据进行传输
            return new BaseResult<QueryRecipeResultDto> { Data = dtos };
        }
        /// <summary>
        /// 工作流程：先传进来一个只有Id属性Dto的类对象（因为查找只需要id），映射为Entity实体类取查找是否存在，如果存在就去数据中取出当前实体类
        ///然后构建一个BaseResult<T>返回类型，该返回类型携带参数，参数是一个Dto对象，所以要把从数据库中取出的实体类再转换为Dto对象返回
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResult<QueryRecipeResultDto>> GetRecipeByIdAsync(GetRecipeByIdDto request) {
            
            var entity = request.Adapt<RecipeEntity>();
            if (!await _recipeService.IsExistAsync(i => i.Id == entity.Id)) {
                return new BaseResult<QueryRecipeResultDto>() { Status = SystemEnums.Result.Fail, Message = "配方不存在" };
            }
            var res = await _recipeService.GetByOneAsync(i => i.Id == entity.Id);
            return new BaseResult<QueryRecipeResultDto> { Data = new List<QueryRecipeResultDto> { res.Adapt<QueryRecipeResultDto>() } };
        }
    }
}
