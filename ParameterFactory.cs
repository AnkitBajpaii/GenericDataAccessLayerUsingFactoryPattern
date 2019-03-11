using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace GenericDataAccessLayer
{
    public static class ParameterFactory
    {
        public static IDbDataParameter CreateParameter(string providerName, string parameterName, object value, DbType dbType, int size = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;

            switch (providerName)
            {
                case "System.Data.SqlClient":
                    parameter = CreateSqlParameter(parameterName, value, dbType, size, direction);
                    break;

                case "System.Data.OdbcClient":
                    parameter = CreateOdbcParameter(parameterName, value, dbType, size, direction);
                    break;
                default:
                    break;
            }

            return parameter;
        }

        private static SqlParameter CreateSqlParameter(string name, object value, DbType dbType, int size = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };

        }

        private static OdbcParameter CreateOdbcParameter(string name, object value, DbType dbType, int size = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            return new OdbcParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };

        }
    }
}
