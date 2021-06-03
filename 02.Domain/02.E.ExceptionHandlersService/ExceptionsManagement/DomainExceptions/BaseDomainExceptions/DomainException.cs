using Utilities.BaseExceptions;

namespace ExceptionsManagement.DomainExceptions.BaseDomainExceptions
{
    public class DomainException:BaseException
    {
        protected DomainException(long code) : base(code)
        {
        }

        
    }
}
