using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Persistence.Models.Positions;
using Persistence.Models.Roles;
using PersistenceTest.Positions;
using PersistenceTest.Positions.Extensions;
using EntityRole = Persistence.Models.Roles.Role;
using Utilities.ReflectionTools;
namespace PersistenceTest.Roles
{
    public class PersistenceRoleTestBuilder : ReflectionBuilder<EntityRole, PersistenceRoleTestBuilder>
    {
        private readonly PersistenceRoleTestBuilder _builderInstance = null;

        public int Id = RoleConstants.someId;
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
