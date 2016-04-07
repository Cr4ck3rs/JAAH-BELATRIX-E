using System;
using Log.Destination.ToConsole;
using Log.Destination.ToFile;
using Log.Destination.ToSql;
using Log.Interface;

namespace Log.Application.Factory
{
    public class DestinationFactory
    {
        public static IDestination Make(DestinationFactoryOption destinationFactoryOption)
        {
            switch (destinationFactoryOption)
            {
                case DestinationFactoryOption.Sql:
                    return new SqlDestination();
                case DestinationFactoryOption.Console:
                    return new ConsoleDestination();
                case DestinationFactoryOption.File:
                    return new FileDestination();
                default:
                    throw new ArgumentOutOfRangeException("destinationFactoryOption", destinationFactoryOption, null);
            }
        }
    }
}