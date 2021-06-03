using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.UserAccounting.Dtos
{
    public class DomainRoleDto
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string SystemDescription { get; private set; }
        public string Description { get; private set; }
    }
}
