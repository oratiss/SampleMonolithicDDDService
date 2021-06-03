using System;

namespace Utilities.BaseExceptions
{
    public class BaseException:Exception
    {
        public readonly long _code;
        public BaseException(long code)
        {
            _code = code;
        }
    }
}
