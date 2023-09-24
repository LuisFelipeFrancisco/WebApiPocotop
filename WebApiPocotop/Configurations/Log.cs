using System;

namespace WebApiPocotop.Configurations
{
    public class Log
    {
        public static string getLogPath()
        {
            string fileName = $"WebApiPocotopLog-{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            string path = System.Configuration.ConfigurationManager.AppSettings["caminho-arquivo-log"];
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string fullpath = System.IO.Path.Combine(path, fileName);
            return $@"C:\ProgramData\WebApiPocotop\Logs\{fileName}";
        }
    }
}