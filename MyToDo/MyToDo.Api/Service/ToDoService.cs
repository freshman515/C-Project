using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using System.Reflection.Metadata;
using System.Collections.ObjectModel;

namespace MyToDo.Api.Service {
    /// <summary>
    /// 待办事项的实现
    /// </summary>

    /*
     ToDoService 是 IToDoService 接口的实现，它包含具体的业务逻辑代码。服务层通常从 UnitOfWork 获取存储库并调用它们的 CRUD 操作方法。

    ToDoService.cs 的作用：
    实现 IToDoService 接口。
    从 UnitOfWork 获取 ToDoRepository。
    执行业务逻辑，并调用 Repository 完成数据库操作。
    将数据和结果返回给控制器。
     */
    public class ToDoService : IToDoService {
        private readonly IMapper mapper;

        /// <summary>
        /// 通过构造函数注入 UnitOfWork
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper) {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 服务实现
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddAsync(ToDoDto entity) {
            try {
                var todo = mapper.Map<ToDoDto, ToDo>(entity);
                await UnitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await UnitOfWork.SaveChangesAsync() > 0) {
                    return new ApiResponse(true, todo); //添加数据成功
                } else {
                    return new ApiResponse("添加数据失败");
                }

            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        /// <summary>
        /// 删除数据接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteAsync(int id) {
            try {
                //通常用来从集合中查找第一个符合条件的元素。如果没有找到符合条件的元素，则返回 null 或默认值
                var repository = UnitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                repository.Delete(todo);
                if (await UnitOfWork.SaveChangesAsync() > 0) {
                    return new ApiResponse(true, "");
                } else {
                    return new ApiResponse("删除数据失败");
                }

            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter) {
            try {
                //通常用来从集合中查找第一个符合条件的元素。如果没有找到符合条件的元素，则返回 null 或默认值
                var repository = UnitOfWork.GetRepository<ToDo>();
                //分页查 询  ,根据parameter.Search是否为空来判断是否需要查询,如果为空则查询所有,否则根据条件查询
                var todos = await repository.GetPagedListAsync(predicate:
                    x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: x => x.OrderByDescending(y => y.Title));
                return new ApiResponse(true, todos);

            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(ToDoParameter parameter) {
            try {
                //通常用来从集合中查找第一个符合条件的元素。如果没有找到符合条件的元素，则返回 null 或默认值
                var repository = UnitOfWork.GetRepository<ToDo>();
                //分页查 询  ,根据parameter.Search是否为空来判断是否需要查询,如果为空则查询所有,否则根据条件查询
                var todos = await repository.GetPagedListAsync(predicate:
                x => (string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search))
                && (parameter.Status == null ? true : x.Status.Equals(parameter.Status)),
                pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: x => x.OrderByDescending(y => y.Title));
                return new ApiResponse(true, todos);

            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id) {
            try {
                var repository = UnitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id == id);
                return new ApiResponse(true, todo);

            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> Summary() {
            try {
                //待办事项结果
                var todos = await UnitOfWork.GetRepository<ToDo>().GetAllAsync(orderBy: source => source.OrderByDescending(t => t.CreateDate));
                var memos = await UnitOfWork.GetRepository<Memo>().GetAllAsync(orderBy: source => source.OrderByDescending(t => t.CreateDate));
                
                SummaryDto summary = new SummaryDto();
                summary.Sum = todos.Count;
                summary.Completed = todos.Where(i => i.Status == 1).Count();
                summary.CompletedRatio = ((double)summary.Completed / (double)summary.Sum).ToString("0%");
                summary.MemoCount = memos.Count();
                summary.ToDoList = new ObservableCollection<ToDoDto>(mapper.Map<List<ToDoDto>>(todos.Where(t=>t.Status==0)));
                summary.MemoList = new ObservableCollection<MemoDto>(mapper.Map<List<MemoDto>>(memos));
                return new ApiResponse(true, summary);

                
            } catch (Exception) {

                return new ApiResponse("汇总api调用错误");
                throw;
            }
        }

        public async Task<ApiResponse> UpdateAsync(ToDoDto entity) {
            try {
                var todoDto = mapper.Map<ToDoDto, ToDo>(entity);
                // 获取 ToDo 实体的 Repository
                var repository = UnitOfWork.GetRepository<ToDo>();

                // 查找数据库中是否已有此条记录
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(todoDto.Id));

                // 更新现有记录的属性
                todo.Title = entity.Title;
                todo.Content = entity.Content;
                todo.Status = entity.Status;
                todo.Updatedate = DateTime.Now;

                repository.Update(todo);

                // 执行保存操作，更新数据
                // 如果 repository 只是执行 CRUD 操作，则通过 UnitOfWork 提交更改
                if (await UnitOfWork.SaveChangesAsync() > 0) {
                    return new ApiResponse(true, todo);
                } else {
                    return new ApiResponse("更新数据异常");
                }

            } catch (Exception ex) {
                // 异常处理
                return new ApiResponse(false, ex.Message);
            }
        }
    }
}
