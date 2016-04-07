using System;
using Log.Dto;
using Log.Interface;

namespace Log.Destination.ToConsole
{
    public class ConsoleDestination : IDestination
    {
        public void LogMessage(LogDto logDto)
        {

            switch (logDto.MessageType)
            {
                case MessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(DateTime.Now.ToShortDateString() + "-" + logDto.Message);
        }
    }
}