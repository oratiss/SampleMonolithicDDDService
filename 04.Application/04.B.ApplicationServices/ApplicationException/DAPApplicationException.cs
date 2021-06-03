using Utilities.BaseExceptions;

namespace ApplicationService.ApplicationException
{
    public class DapApplicationException:BaseException
    {
        public DapApplicationException(long code):base(code)
        {
        }
    }
}
