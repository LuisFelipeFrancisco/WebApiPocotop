
namespace WebApiPocotop.Configurations
{
    public class SQLServer
    {
        public static string getConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["pocotop"].ConnectionString;
        }
    }
}