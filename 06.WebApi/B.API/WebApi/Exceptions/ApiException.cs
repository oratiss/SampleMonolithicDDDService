using Utilities.BaseExceptions;

namespace WebApi.Exceptions
{
    public class ApiException : BaseException
    {
        public ApiException(long code) : base(code)
        {
        }
    }
}
