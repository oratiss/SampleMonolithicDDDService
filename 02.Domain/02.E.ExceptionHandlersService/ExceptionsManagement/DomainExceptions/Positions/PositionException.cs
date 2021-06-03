using System;
using ExceptionsManagement.DomainExceptions.BaseDomainExceptions;

namespace ExceptionsManagement.DomainExceptions.Positions
{
    public class PositionException : DomainException
    {
        public PositionException(long exceptionCode):base(exceptionCode)
        {
        }
    }
}