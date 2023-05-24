using Backend_OddityVR.Application.DTO;
using System.Reflection;

namespace Backend_OddityVR.Domain.Service
{
    public static class CmdFieldsChecker
    {
        public static bool Check(ICmdAndDTO cmd)
        {
            PropertyInfo[] properties = cmd.GetType().GetProperties(); ;
            string errorMessage = "";

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(cmd).ToString() == "")
                {
                    errorMessage += "The element " + property.ToString() + " of the form is missing\n";
                };
            }
            if (errorMessage != "")
            {
                Console.WriteLine(errorMessage);
                return false;
            }
            return true;
        }
    }
}
