using DomainServiceContract.Roles;

namespace ExceptionsManagement.DomainExceptions.Roles
{
    public class RoleExceptionHelper : IDomainRoleExceptionHelper
    {
        public void ThrowExceptionMessage(long exceptionCode)
        {
            throw new RoleException(exceptionCode);
        }
    }
}
