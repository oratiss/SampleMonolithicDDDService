using Persistence.Models.Roles;
using Utilities.ReflectionTools;
using EntityRole = Persistence.Models.Roles.Role;
namespace PersistenceTest.Roles
{
    public class PersistenceRoleTestBuilder : ReflectionBuilder<EntityRole, PersistenceRoleTestBuilder>
    {
        private readonly PersistenceRoleTestBuilder _builderInstance = null;

        public long Id = RoleConstants.someId;
        public string Title = RoleConstants.someTitle;
        public string SystemDescription = RoleConstants.someSystemDescription;
        public string Description = RoleConstants.someDescription;
        public PersistenceRoleTestBuilder()
        {
            _builderInstance = this;
        }
        public override EntityRole Build()
        {
            return new EntityRole(Id, Title, Description, SystemDescription);
        }
    }
}
