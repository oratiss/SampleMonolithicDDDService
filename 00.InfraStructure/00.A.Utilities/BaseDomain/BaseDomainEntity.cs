using Utilities.BaseEntities;

namespace Utilities.BaseDomain
{
    public class BaseDomainEntity<TKey> : BaseEntity<TKey> where TKey : struct
    {
        public BaseDomainEntity(TKey id) : base(id)
        {
        }
    }
}
