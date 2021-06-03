using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UserAccounting.Roles
{
    public class RoleEventArgs:EventArgs
    {
        public Role Role { get; set; }
    }
}
