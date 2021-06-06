namespace Utilities.BaseEntities
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity(T id)
        {
            Id = id;
        }
    }
}
