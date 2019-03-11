using System.Data;

namespace GenericDataAccessLayer.Abstractions
{
    public interface IDatabaseHandler
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection connection);
        IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection connection, IDbDataParameter[] parameters = null);

        IDbDataAdapter CreateAdapter(IDbCommand command);

        IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, int size = 0, ParameterDirection direction = ParameterDirection.Input);
    }
}
