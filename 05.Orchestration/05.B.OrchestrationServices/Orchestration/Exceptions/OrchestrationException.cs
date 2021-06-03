using Utilities.BaseExceptions;

namespace Orchestration.Exceptions
{
    public class OrchestrationException:BaseException
    {
        public OrchestrationException(long code):base(code)
        {
        }
    }
}
