using TestBridge.Models.UserAccounting.Roles;
using Utilities.ReflectionTools;
using static Utilities.SharedTools.Constants.RoleConstants;

namespace IntegrationTest.UserAccounting.Roles
{
    public class BridgeRoleTestBuilder : ReflectionBuilder<BridgeRoleViewModel, BridgeRoleTestBuilder>
    {
        private readonly BridgeRoleTestBuilder _builderInstance;

        public long Id = someId;
        public string Title = someTitle;
        public string SystemDescription = someSystemDescription;
        public string Description = someDescription;

        public BridgeRoleTestBuilder()
        {
            _builderInstance = this;
        }

        public override BridgeRoleViewModel Build()
        {
            return new BridgeRoleViewModel(Id, Title, SystemDescription, Description);
        }
    }
}
