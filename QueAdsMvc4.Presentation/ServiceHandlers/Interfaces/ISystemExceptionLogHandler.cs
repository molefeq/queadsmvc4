using System;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Interfaces
{
    public interface ISystemExceptionLogHandler
    {
        void LogError(Exception exception);
    }
}
