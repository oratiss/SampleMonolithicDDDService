using Utilities.BaseExceptions;

namespace Persistence.Exceptions
{
    public class PersistenceException : BaseException
    {
        public PersistenceException(long code) : base(code)
        {
        }
    }
}
