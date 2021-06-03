using Domain.UserAccounting.Roles;
using static Utilities.SharedTools.Constants.RoleConstants;

using Utilities.ReflectionTools;

namespace DomainTest.UserAccounting.Roles
{
    public class RoleTestBuilder : ReflectionBuilder<Role, RoleTestBuilder>
    {
        private readonly RoleTestBuilder _builderInstance = null;

        public int Id = someId;
        public string Title = someTitle;
        public string SystemDescription = someSystemDescription;
        public string Description = someDescription;

        public RoleTestBuilder()
        {
            _builderInstance = this;
        }

        public override Role Build()
        {
            return new Role(Id, Title, SystemDescription, Description);
        }
    }
}