using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ClassMiBlog.AdoNet
{
    class CommandContext
    {
        public CommandCommon DbContext { get; private set; }

        public CommandContext()
        {
            var provider = ConfigurationManager.AppSettings.Get("DataProvider");
            
            EnumDataProvider enumProvider;
            Enum.TryParse(provider, out enumProvider);

            if (Enum.TryParse(provider, out enumProvider))
                GetValue(enumProvider);
        }

        public CommandContext(EnumDataProvider enumProvider)
        {
            GetValue(enumProvider);
        }

        private void GetValue(EnumDataProvider enumProvider)
        {
            var cnx = ConfigurationManager.ConnectionStrings[enumProvider.ToString()].ConnectionString;
            DbConnection connection = null;
            DbCommand command = null;

            switch (enumProvider)
            {
                case  EnumDataProvider.Sql:
                    connection = new SqlConnection(cnx);
                    command = new SqlCommand();
                    break;
                case EnumDataProvider.MySql:
                    connection = new MySqlConnection(cnx);
                    command = new MySqlCommand();
                    break;
            }
            
            DbContext = new CommandCommon(command, connection);
        }
    }
}
