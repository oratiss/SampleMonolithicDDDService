using System.Collections.Generic;
using Persistence.Models.Positions;
using Utilities.BaseEntities;

namespace Persistence.Models.Roles
{
    public class Role : BaseEntity<long>
    {
        public Role(long id) : base(id)
        {

        }

        public Role(long id, string title, string description, string systemDescription) : base(id)
        {
            Title = title;
            Description = description;
            SystemDescription = systemDescription;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SystemDescription { get; set; }

        //Navigation Properties and Foreign Keys
        public ICollection<Position> Positions { get; set; }
    }
}
