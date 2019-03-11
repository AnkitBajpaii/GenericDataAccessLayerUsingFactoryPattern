using GenericDataAccessLayer.Abstractions;
using GenericDataAccessLayer.DataAccess;
using System.Configuration;

namespace GenericDataAccessLayer
{
    public class DatabaseHandlerFactory
    {
        readonly ConnectionStringSettings connectionStringSettings;

        public DatabaseHandlerFactory(string connectionName)
        {
            this.connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionName];
        }

        public IDatabaseHandler CreateDatabaseHandler()
        {
            IDatabaseHandler dbHandler = null;

            switch (connectionStringSettings.ProviderName)
            {
                case "System.Data.SqlClient":
                    dbHandler = new SqlDataAccess(this.connectionStringSettings.ConnectionString);
                    break;

                case "System.Data.OdbcClient":
                    dbHandler = new OdbcDataAccess(this.connectionStringSettings.ConnectionString);
                    break;
                default:
                    break;
            }
            return dbHandler;
        }


    }
}
