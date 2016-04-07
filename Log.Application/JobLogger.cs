using System;
using Log.Dto;
using Log.Interface;

namespace Log.Application
{
    public class JobLogger
    {
        public LoggerOptionsDto LoggerOptionsDto { get; set; }
        public IDestination Destination { get; set; }

        public void LogMessage(LogDto logDto)
        {
            Valido(logDto);         // We validate the parameters
            Destination.LogMessage(logDto);     // Then we log the message
        }

        private void Valido(LogDto logDto)
        {
            if (logDto == null) throw new ArgumentNullException("logDto");
            if (LoggerOptionsDto == null) throw new ArgumentNullException("LoggerOptionsDto");
            if (Destination == null) throw new ArgumentNullException("Destination");


            var invalidOptions = false;
            switch (logDto.MessageType)
            {
                case MessageType.Message:
                    if (!LoggerOptionsDto.LogMessages)
                    {
                        invalidOptions = true;
                    }
                    break;
                case MessageType.Warning:
                    if (!LoggerOptionsDto.LogWarnings)
                    {
                        invalidOptions = true;
                    }
                    break;
                case MessageType.Error:
                    if (!LoggerOptionsDto.LogErrors)
                    {
                        invalidOptions = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (invalidOptions)
            {
                throw new Exception("Logger is not configured to log this type of message");
            }
        }
    }
}
