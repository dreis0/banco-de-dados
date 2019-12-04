using Domain.DBHelper;
using System.Linq;

namespace Domain
{
    public static class Extensions
    {
        public static string GetTableName<T>(this T entity)
        {
            var atts = entity.GetType().GetCustomAttributes(true);
            var tableNameAtt = atts.SingleOrDefault(a => a.GetType() == typeof(TableNameAttribute));

            return ((TableNameAttribute)tableNameAtt).TableName;
        }
    }
}
