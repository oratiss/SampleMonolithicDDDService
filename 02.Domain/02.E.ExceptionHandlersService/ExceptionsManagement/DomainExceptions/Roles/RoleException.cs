using System;
using System.Runtime.Serialization;
using ExceptionsManagement.DomainExceptions.BaseDomainExceptions;

namespace ExceptionsManagement.DomainExceptions.Roles
{
    [Serializable]
    public sealed class RoleException : DomainException
    {
        public RoleException(long code):base(code)
        {
        }

    
    }

  
}