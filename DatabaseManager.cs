using GenericDataAccessLayer.Abstractions;
using System.Data;

namespace GenericDataAccessLayer
{
    public class DatabaseManager : IDatabaseHandler, IDataHandler
    {
        readonly IDatabaseHandler databaseHandler;

        /// <summary>
        /// creates a dbManager
        /// </summary>
        /// <param name="connectionName">connection name in app.config or web.config</param>
        public DatabaseManager(string connectionName)
        {
            var factory = new DatabaseHandlerFactory(connectionName);
            this.databaseHandler = factory.CreateDatabaseHandler();
        }

        public void CloseConnection(IDbConnection connection)
        {
            this.databaseHandler.CloseConnection(connection);
        }

        public IDbDataAdapter CreateAdapter(IDbCommand command)
        {
            return this.databaseHandler.CreateAdapter(command);
        }

        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection connection, IDbDataParameter[] parameters = null)
        {
            return this.databaseHandler.CreateCommand(cmdText, cmdType, connection, parameters);
        }

        public IDbConnection CreateConnection()
        {
            return this.databaseHandler.CreateConnection();
        }

        public IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, int size = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            return this.databaseHandler.CreateParameter(providerName, name, value, dbType, size, direction);
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null)
        {
            int i = 0;
            using (var conn = this.CreateConnection())
            {
                var cmd = this.CreateCommand(cmdText, cmdType, conn, parameters);
                cmd.CommandType = cmdType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                conn.Open();
                i = cmd.ExecuteNonQuery();
            }

            return i;
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null)
        {
            object obj = null;
            using (var conn = this.CreateConnection())
            {
                var cmd = this.CreateCommand(cmdText, cmdType, conn, parameters);
                cmd.CommandType = cmdType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                conn.Open();
                obj = cmd.ExecuteScalar();
            }

            return obj;
        }

        public IDataReader GetDataReader(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null)
        {
            IDataReader dr = null;

            using (var conn = this.CreateConnection())
            {
                var cmd = this.CreateCommand(cmdText, cmdType, conn, parameters);
                cmd.CommandType = cmdType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                conn.Open();
                dr = cmd.ExecuteReader();
            }

            return dr;
        }

        public DataSet GetDataSet(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null)
        {
            DataSet ds = null;

            using (var conn = this.CreateConnection())
            {
                var cmd = this.CreateCommand(cmdText, cmdType, conn, parameters);
                cmd.CommandType = cmdType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                var da = this.CreateAdapter(cmd);
                da.Fill(ds);
            }

            return ds;
        }

        public DataTable GetDataTable(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null)
        {
            DataSet ds = null;

            using (var conn = this.CreateConnection())
            {
                var cmd = this.CreateCommand(cmdText, cmdType, conn, parameters);
                cmd.CommandType = cmdType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                var da = this.CreateAdapter(cmd);
                da.Fill(ds);
            }

            return ds?.Tables[0];
        }
    }
}
