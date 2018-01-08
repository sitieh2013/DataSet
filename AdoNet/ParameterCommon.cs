using System.Data;

namespace ClassMiBlog.AdoNet
{
    sealed class ParameterCommon
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public static void AddParameter(IDbCommand comand, ParameterCommon[] parameters)
        {
            if (comand.Parameters.Count > 0)
                comand.Parameters.Clear();

            foreach (var parameter in parameters)
            {
                var p = comand.CreateParameter();
                p.ParameterName = parameter.Name;
                p.Value = parameter.Value;
                comand.Parameters.Add(p);
            }
        }
    }
}
