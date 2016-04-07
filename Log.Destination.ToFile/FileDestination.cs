using System;
using System.Configuration;
using System.IO;
using Log.Dto;
using Log.Interface;

namespace Log.Destination.ToFile
{
    public class FileDestination : IDestination
    {
        public void LogMessage(LogDto logDto)
        {
            const string fileExtension = ".txt";

            var pathToFile = ConfigurationManager.AppSettings["LogFileDirectory"];
            var fileName = ConfigurationManager.AppSettings["LogFileName"];

            var file = string.Format("{0}{1}{2}{3}", pathToFile, fileName, DateTime.Now.ToShortDateString(),
                fileExtension);

            if (!Directory.Exists(pathToFile))
            {
                var logContent = string.Format("{0}-{1}", DateTime.Now.ToShortDateString(), logDto.Message);

                if (!File.Exists(file))
                {
                    logContent = string.Format("{0}{1}", File.ReadAllText(file), logContent);
                }

                File.WriteAllText(file, logContent);    
            }
            else
            {
                throw  new Exception(string.Format("The Logs Directory {0} does not exists", pathToFile));
            }
        }
    }
}