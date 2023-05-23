using Backend_OddityVR.Model;
using System.Data;
using System.Reflection;

namespace Backend_OddityVR.Service
{
    public static class RepoHelper
    {
        public static void AddParameters(IDbCommand command, IModel table)
        {
            PropertyInfo[] properties = table.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (prop.GetValue(table) != null)
                {
                    IDbDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = $"@{prop.Name}";
                    parameter.Value = prop.GetValue(table);
                    command.Parameters.Add(parameter);
                }
            }
        }
    }
}
