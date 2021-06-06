using static Utilities.SharedTools.Constants.RoleConstants;

using System;
using Utilities.ReflectionTools;

namespace Domain.UserAccounting.Roles
{
    public class RoleBuilder : ReflectionBuilder<Role, RoleBuilder>
    {
        private readonly RoleBuilder _builderInstance = null;

        public long Id = someId;
        public string Title = someTitle;
        public string SystemDescription = someSystemDescription;
        public string Description = someDescription;

        public RoleBuilder()
        {
            _builderInstance = this;
        }

        public override Role Build()
        {
            return new Role(Id, Title, SystemDescription, Description);
        }
    }
}
