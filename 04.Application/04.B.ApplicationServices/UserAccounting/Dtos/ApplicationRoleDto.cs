using System;
using System.Collections.Generic;
using System.Text;


namespace ApplicationService.UserAccounting.Dtos
{
    public class ApplicationRoleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SystemDescription { get; set; }
        public string Description { get; set; }
    }
}
