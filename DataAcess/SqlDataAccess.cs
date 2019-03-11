using GenericDataAccessLayer.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace GenericDataAccessLayer.DataAccess
{
    public class SqlDataAccess : DataAccessBase, IDatabaseHandler
    {
        readonly string connectionString;

        public SqlDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbDataAdapter CreateAdapter(IDbCommand command)
        {
            return new SqlDataAdapter(command as SqlCommand);
        }

        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection connection, IDbDataParameter[] parameters = null)
        {
            var cmd = new SqlCommand(cmdText, connection as SqlConnection);
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
            return new SqlConnection(this.connectionString);
        }
    }
}
