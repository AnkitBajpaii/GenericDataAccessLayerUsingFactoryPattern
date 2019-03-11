using System.Data;

namespace GenericDataAccessLayer.DataAccess
{
    public class DataAccessBase
    {
        public void CloseConnection(IDbConnection connection)
        {
            connection.Close();
        }

        public IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, int size = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            return ParameterFactory.CreateParameter(providerName, name, value, dbType, size, direction);
        }
    }
}
