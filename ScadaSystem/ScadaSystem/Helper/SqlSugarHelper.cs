using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper {
    public static class SqlSugarHelper {
        public static SqlSugarClient Db { get; set; }
        public static void AddSqlSugarSetup(DbType dbType, string connectString) {
            Db = new SqlSugarClient(new ConnectionConfig() {
                ConnectionString = connectString,
                DbType = dbType,
                IsAutoCloseConnection = true,
            },
                  db => {

                    db.Aop.OnLogExecuting = (sql, pars) => {

                     //获取原生SQL推荐 5.1.4.63  性能OK
                         Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));
                   };
                  });
        }
    }
}
