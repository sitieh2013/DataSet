using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ClassMiBlog.AdoNet
{
    class AdapterContext
    {
        public AdapterCommon DbContext { get; private set; }

        public AdapterContext()
        {
            var provider = ConfigurationManager.AppSettings.Get("DataProvider");
            
            EnumDataProvider enumProvider;
            Enum.TryParse(provider, out enumProvider);

            if (Enum.TryParse(provider, out enumProvider))
                GetValue(enumProvider);
        }

        public AdapterContext(EnumDataProvider enumProvider)
        {
            GetValue(enumProvider);
        }

        private void GetValue(EnumDataProvider enumProvider)
        {
            var cnx = ConfigurationManager.ConnectionStrings[enumProvider.ToString()].ConnectionString;

            DbConnection connection = null;
            DbCommand command = null;
            DbDataAdapter adapter = null;

            switch (enumProvider)
            {
                case EnumDataProvider.Sql:
                    connection = new SqlConnection(cnx);
                    command = new SqlCommand();
                    adapter = new SqlDataAdapter();
                    break;
                case EnumDataProvider.MySql:
                    connection = new MySqlConnection(cnx);
                    command = new MySqlCommand();
                    adapter = new MySqlDataAdapter();
                    break;
            }

            DbContext = new AdapterCommon(adapter, command, connection);
        }
    }
}
