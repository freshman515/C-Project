using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Context;

namespace MyToDo.Api.Context.Repository {
    //数据访问层
    //负责实现数据访问操作。
    //处理数据库实体（如 ToDo）的增删改查（CRUD）操作。
    //通过依赖注入传递给其他服务层。
    public class ToDoRepository : Repository<ToDo>, IRepository<ToDo> {
        public ToDoRepository(MyToDoContext dbContext) : base(dbContext) {
        }
    }
}
