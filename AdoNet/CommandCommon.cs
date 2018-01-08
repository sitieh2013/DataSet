using System.Data;
using System.Data.Common;

namespace ClassMiBlog.AdoNet
{
    class CommandCommon
    {
        private readonly DbCommand _command;

        public CommandCommon(DbCommand command, DbConnection connection)
        {
            _command = command;
            _command.Connection = connection;
            _command.CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteComand(string procedure, ParameterCommon[] parameters)
        {
            _command.CommandText = procedure;
            ParameterCommon.AddParameter(_command, parameters);

            _command.Connection.Open();
            var rowCount = _command.ExecuteNonQuery();
            _command.Connection.Close();

            return rowCount;
        }

        public int ExecuteComand(string procedure)
        {
            return ExecuteComand(procedure, new ParameterCommon[0]);
        }

        public DataTable Fill(string procedure, ParameterCommon[] parameters)
        {
            _command.CommandText = procedure;
            ParameterCommon.AddParameter(_command, parameters);
            var dataTable = new DataTable();

            _command.Connection.Open();
            var datareader = _command.ExecuteReader();
            dataTable.Load(datareader);
            datareader.Close();
            _command.Connection.Close();

           return dataTable;
        }

        public DataTable Fill(string procedure)
        {
            return Fill(procedure, new ParameterCommon[0]);
        }

        public object ExecuteScalar(string procedure, ParameterCommon[] parameters)
        {
            _command.CommandText = procedure;
            
            ParameterCommon.AddParameter(_command, parameters);

            _command.Connection.Open();
            var value = _command.ExecuteScalar();
            _command.Connection.Close();

            return value; 
        }

        public object ExecuteScalar(string procedure)
        {
            return ExecuteScalar(procedure, new ParameterCommon[0]);
        }
    }
}
