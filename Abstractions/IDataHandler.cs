using System.Data;

namespace GenericDataAccessLayer.Abstractions
{
    public interface IDataHandler
    {
        DataSet GetDataSet(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null);

        DataTable GetDataTable(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null);

        IDataReader GetDataReader(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null);

        int ExecuteNonQuery(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null);

        object ExecuteScalar(string cmdText, CommandType cmdType, IDbDataParameter[] parameters = null);
    }
}
