using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class BaseEntity {
        [SugarColumn(IsPrimaryKey = true,IsIdentity =true)]  //主键，自增长
        public int Id { get; set; }
    }
}
