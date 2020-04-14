using Serilog;
using Serilog.Core;
using System;

namespace MyCrowdFund.Services {
   public class LoggerService : ILoggerService {

        private Logger log_ { get; set; }

        public LoggerService() {

            log_ = new LoggerConfiguration()
                .WriteTo.File( " log.txt ", rollingInterval: RollingInterval.Infinite )
                .CreateLogger();
        }

        public void LogError( StatusCode errorCode, string text ) {

            log_.Error( $" Error : {errorCode} \n Text : {text} \n Date : { DateTime.UtcNow} \n \n " );
        }

        public void LogInformation( string text ) {

            log_.Information( text );
        }
    }
}
