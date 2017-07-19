using System.Data;
using DevLib.Utils;
using DevStack.OrmLite;

namespace EfashionCool.Infrastructure
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            OrmLiteConfig.DialectProvider = MySqlDialect.Provider;
        }

        public static string Db
        {
            get
            {
                return
                    ConfigHelper.GetConnectionString("EfashionCool");
            }
        }

        public static IDbConnection GetConnection()
        {
            return Db.OpenDbConnection();
        }

    }
}
