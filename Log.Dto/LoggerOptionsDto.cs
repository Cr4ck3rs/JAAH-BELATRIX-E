using System;

namespace Log.Dto
{
    public class LoggerOptionsDto
    {
        public bool LogErrors { get; set; }
        public bool LogWarnings { get; set; }
        public bool LogMessages { get; set; }

        public LoggerOptionsDto(bool logErrors, bool logWarnings, bool logMessages)
        {
            //Options validation
            if (!logErrors && !logWarnings && !logMessages)
            {
                throw new Exception("Invalid Configuration");
            }

            LogErrors = logErrors;
            LogWarnings = logWarnings;
            LogMessages = logMessages;
        }
    }
}