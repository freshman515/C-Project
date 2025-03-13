﻿using MyToDo.Shared.Contact;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Service {
    /// <summary>
    /// 被限制在引用类型的泛型服务接口，用于定义基本的增删改查操作
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseService <TEntity> where TEntity :class{
        Task<ApiResponse<TEntity>> AddAsync(TEntity entity);
        Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<TEntity>> GetByIdAsync(int id);
        Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(QueryParameter parameter);
    }
}
