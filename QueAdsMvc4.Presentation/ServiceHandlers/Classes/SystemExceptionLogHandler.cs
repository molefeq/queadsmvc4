using QueAds.Common.ErrorLogging.DatabaseLogger;

using QueAds.Service.Presentation.Factories;

using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;

using System;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Classes
{
    public class SystemExceptionLogHandler : ISystemExceptionLogHandler
    {
        public void LogError(Exception exception)
        {
            EntityFactory.SystemExceptionLogManager.CreateSystemExceptionLog(DatabaseSystemExceptionErrorLogger.Instance.LogError("QueAds.Web", "QueAds", exception));
        }
    }
}
