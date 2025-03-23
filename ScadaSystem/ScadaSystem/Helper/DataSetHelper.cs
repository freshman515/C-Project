using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper {
    public static class DataSetHelper {
        public static DataSet ConvertToDataSet<T>(this IList<T> list) {
            // 获取泛型类型
            Type elementType = typeof(T);
            var ds = new DataSet();
            var t = new DataTable();
            ds.Tables.Add(t);

            // 遍历所有属性
            elementType.GetProperties().ToList().ForEach(elementInfo =>
                t.Columns.Add(elementInfo.Name, Nullable.GetUnderlyingType(elementInfo.PropertyType) ?? elementInfo.PropertyType)
            );

            // 添加数据
            foreach (T item in list) {
                var row = t.NewRow();
                elementType.GetProperties().ToList().ForEach(elementInfo =>
                    row[elementInfo.Name] = elementInfo.GetValue(item, null) ?? DBNull.Value
                );
                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
