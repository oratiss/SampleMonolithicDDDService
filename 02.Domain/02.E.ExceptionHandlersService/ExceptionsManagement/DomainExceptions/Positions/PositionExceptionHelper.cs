using DomainServiceContract.Positions;

namespace ExceptionsManagement.DomainExceptions.Positions
{
    public class PositionExceptionHelper : IDomainPositionExceptionHelper
    {
        public void ThrowExceptionMessage(long exceptionCode)
        {
            throw new PositionException(exceptionCode);
        }
    }
}