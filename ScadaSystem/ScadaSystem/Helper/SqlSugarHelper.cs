using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper {
    public class SqlSugarHelper {
        public static SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig() {
            ConnectionString = "server=localhost;Database=scadawpf;Uid=root;Pwd=root",
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
        },
        //创建数据库对象 (用法和EF Dappper一样通过new保证线程安全)
              db => {

                  db.Aop.OnLogExecuting = (sql, pars) => {

                      //获取原生SQL推荐 5.1.4.63  性能OK
                      Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

                      //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
                      //Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer,sql,pars))


                  };

                  //注意多租户 有几个设置几个
                  //db.GetConnection(i).Aop

              });

    }
}
