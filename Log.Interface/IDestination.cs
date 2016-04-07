using Log.Dto;

namespace Log.Interface
{
    public interface IDestination
    {
        void LogMessage(LogDto logDto);
    }
}