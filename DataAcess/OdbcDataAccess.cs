using GenericDataAccessLayer.Abstractions;
using System.Data;
using System.Data.Odbc;

namespace GenericDataAccessLayer.DataAccess
{
    public class OdbcDataAccess : DataAccessBase, IDatabaseHandler
    {
        readonly string connectionString;

        public OdbcDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbDataAdapter CreateAdapter(IDbCommand command)
        {
            return new OdbcDataAdapter(command as OdbcCommand);
        }

        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection connection, IDbDataParameter[] parameters = null)
        {
            var cmd = new OdbcCommand(cmdText, connection as OdbcConnection);
            cmd.CommandType = cmdType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            return cmd;
        }

        public IDbConnection CreateConnection()
        {
            return new OdbcConnection(this.connectionString);
        }
    }
}
