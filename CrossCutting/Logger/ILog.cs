namespace BlogServer.CrossCutting.Logger
{
    public interface ILog
    {
        void DebugLog(string message);
        void ErrorLog(string message);
        void InfoLog(string message);
        void WarningLog(string message);
    }
}