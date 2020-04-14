namespace MyCrowdFund.Services {
  public  interface ILoggerService {
        void LogError( StatusCode errorCode, string text );
        void LogInformation( string text );
    }
}