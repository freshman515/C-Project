using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper.Dtos {
    public class QueryReadDataByDateDto {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalNumber { get; set; }
    }
}
