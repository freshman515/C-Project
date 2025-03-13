using MyToDo.Api.Context;
using MyToDo.Shared.Dtos;
using AutoMapper;
using MyToDo.Shared.Parameters;
using MyToDo.Shared.Contact;

namespace MyToDo.Api.Service {
    public class MemoService : IMemoService {
        public MemoService(IUnitOfWork unitOfWork, IMapper mapper) {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public async Task<ApiResponse> AddAsync(MemoDto entity) {

            try {
                var memoDto = Mapper.Map<Memo>(entity);
                await UnitOfWork.GetRepository<Memo>().InsertAsync(memoDto);
                if(await UnitOfWork.SaveChangesAsync() > 0) {
                    return new ApiResponse(true, memoDto);
                }
                return new ApiResponse(false, "Failed to add memo");

            } catch ( Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id) {
            try {
                var repository = UnitOfWork.GetRepository<Memo>();
                var memo =  await repository.GetFirstOrDefaultAsync(predicate:x => x.Id == id);
                repository.Delete(memo);
                if (await UnitOfWork.SaveChangesAsync() > 0) {
                    return new ApiResponse(true, "");
                }
                return new ApiResponse(false, "Failed to Delete memo");
            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }
        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter) {
            try {
                var memos = await UnitOfWork.GetRepository<Memo>().
                    GetPagedListAsync(
                        predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ?true: x.Title.Contains(parameter.Search),
                        orderBy: x => x.OrderByDescending(x => x.CreateDate),
                        pageIndex: parameter.PageIndex,
                        pageSize: parameter.PageSize
                    );
                return new ApiResponse(true, memos);
            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id) {
            try {
                var memo = await UnitOfWork.GetRepository<Memo>().GetFirstOrDefaultAsync(predicate: x => x.Id == id);
                return new ApiResponse(true, memo);
            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(MemoDto entity) {
            try {
                var memoDto = Mapper.Map<MemoDto, Memo>(entity);
                var repository = UnitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id == entity.Id);
                if(memo == null) {
                    return new ApiResponse(false, "Memo not found");
                }
                memo.Title = memoDto.Title;
                memo.Content = memoDto.Content;
                memo.Updatedate = DateTime.Now;
                repository.Update(memo);
                if(UnitOfWork.SaveChanges() > 0){ 
                    return new ApiResponse(true, memo);
                }
                return new ApiResponse("Failed to update memo");

            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
