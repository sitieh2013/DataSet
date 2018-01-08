using System.Data;
using System.Data.Common;

namespace ClassMiBlog.AdoNet
{
    class AdapterCommon
    {
        private readonly DbDataAdapter _adapter;

        public AdapterCommon(DbDataAdapter adapter, DbCommand comand, DbConnection connection)
        {
            _adapter = adapter;
            _adapter.SelectCommand = comand;
            _adapter.InsertCommand = comand;
            _adapter.UpdateCommand = comand;
            _adapter.DeleteCommand = comand;
            comand.Connection = connection;
            comand.CommandType = CommandType.StoredProcedure;
        }

        public DataTable Fill(string procedure, ParameterCommon[] parameters)
        {
            var datatable = new DataTable();

            _adapter.SelectCommand.CommandText = procedure;

            ParameterCommon.AddParameter(_adapter.DeleteCommand, parameters);

            _adapter.Fill(datatable);

            return datatable;
        }

        public DataTable Fill(string procedure)
        {
            return Fill(procedure, new ParameterCommon[0]);
        }

        public int Insert(string procedure, ParameterCommon[] parameters)
        {
            _adapter.InsertCommand.CommandText = procedure;

            ParameterCommon.AddParameter(_adapter.DeleteCommand, parameters);

            _adapter.InsertCommand.Connection.Open();
            var value = _adapter.InsertCommand.ExecuteNonQuery();
            _adapter.InsertCommand.Connection.Close();

            return value;
        }

        public int Update(string procedure, ParameterCommon[] parameters)
        {
            _adapter.UpdateCommand.CommandText = procedure;

            ParameterCommon.AddParameter(_adapter.DeleteCommand, parameters);

            _adapter.UpdateCommand.Connection.Open();
            var value = _adapter.UpdateCommand.ExecuteNonQuery();
            _adapter.UpdateCommand.Connection.Close();

            return value;
        }

        public int Delete(string procedure, ParameterCommon[] parameters)
        {
            _adapter.DeleteCommand.CommandText = procedure;

            ParameterCommon.AddParameter(_adapter.DeleteCommand, parameters);
           
            _adapter.DeleteCommand.Connection.Open();
            var value = _adapter.DeleteCommand.ExecuteNonQuery();
            _adapter.DeleteCommand.Connection.Close();

            return value;
        }

        public int DeleteAll(string procedure)
        {
            return Delete(procedure, new ParameterCommon[0]);
        }

        public object ExecuteScalar(string procedure, ParameterCommon[] parameters)
        {
            _adapter.SelectCommand.CommandText = procedure;

            ParameterCommon.AddParameter(_adapter.DeleteCommand, parameters);

            _adapter.SelectCommand.Connection.Open();
            var value = _adapter.SelectCommand.ExecuteScalar();
            _adapter.SelectCommand.Connection.Close();

            return value; 
        }

        public object ExecuteScalar(string procedure)
        {
            return ExecuteScalar(procedure, new ParameterCommon[0]);
        }
    }
}
