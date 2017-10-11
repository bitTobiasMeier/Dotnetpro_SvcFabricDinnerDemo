using System.Diagnostics.Tracing;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public interface IServiceEventSource
    {
        void Message(string message, params object[] args);
        void Message(string message);
        bool IsEnabled();
        bool IsEnabled(EventLevel level, EventKeywords keywords);
        void Dispose();
    }
}