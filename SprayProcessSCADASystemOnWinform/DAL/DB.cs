using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public static class DB {
        //数据库操作客户端接口。
        public static ISqlSugarClient SqlSugarClient {get; private set;}  //用于数据库的增删改查
        //用于对依赖注入的扩展方法
        public static void AddSqlSugarSetUp(this IServiceCollection service,SqlSugar.DbType dataType,string conn) {
            //单例模式注入IOC容器
            service.AddSingleton<ISqlSugarClient>(s => {
                //配置连接
                //SqlSugarScope 继承自 ISqlSugarClient，是 SqlSugar 的线程安全模式
                SqlSugarClient = new SqlSugarScope(new ConnectionConfig() {
                    DbType = dataType,    //数据库类型
                    ConnectionString = conn,  //连接字符串
                    IsAutoCloseConnection = true  //自动关闭连接
                });
                return SqlSugarClient;
            });
        }

    }
}
