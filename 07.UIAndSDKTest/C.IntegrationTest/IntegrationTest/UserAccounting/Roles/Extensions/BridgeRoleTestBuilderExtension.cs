using System.Threading.Tasks;
using TestBridge.Controllers.UserAccounting.Roles;
using TestBridge.Models.UserAccounting.Roles;
using static Utilities.SharedTools.Constants.RoleConstants;

namespace IntegrationTest.UserAccounting.Roles.Extensions
{
    public static class RoleIntegrationTestsExtension
    {
        public static async Task<(BridgeRoleViewModel, BridgeRoleViewModel)> AddSomeRoles(this RoleIntegrationTests roleTestBuilder, RoleController sut)
        {
            var someBridgeRoleViewModel = new BridgeRoleTestBuilder().AddSomeRole();
            var anotherBridgeRoleViewModel = new BridgeRoleTestBuilder().AddAnotherRole();
            someBridgeRoleViewModel = await sut.Create(someBridgeRoleViewModel);
            anotherBridgeRoleViewModel = await sut.Create(anotherBridgeRoleViewModel);

            return (someBridgeRoleViewModel, anotherBridgeRoleViewModel);
        }

        public static BridgeRoleViewModel AddSomeRole(this BridgeRoleTestBuilder roleTestBuilder)
        {
            return new BridgeRoleTestBuilder()
                    .With(r => r.Id, (long)0)
                    .With(r => r.Title, someTitle)
                    .With(r => r.Description, someDescription)
                    .With(r => r.SystemDescription, someSystemDescription)
                    .Build();
        }

        public static BridgeRoleViewModel AddAnotherRole(this BridgeRoleTestBuilder roleTestBuilder)
        {
            return new BridgeRoleTestBuilder()
                .With(r => r.Id, 0)
                .With(r => r.Title, anotherTitle)
                .With(r => r.Description, anotherDescription)
                .With(r => r.SystemDescription, anotherSystemDescription)
                .Build();
        }
        public static BridgeRoleViewModel AddSomeAnotherRole(this BridgeRoleTestBuilder roleTestBuilder)
        {
            return new BridgeRoleTestBuilder()
                .With(r => r.Id, 0)
                .With(r => r.Title, someAnotherTitle)
                .With(r => r.Description, someAnotherDescription)
                .With(r => r.SystemDescription, someAnotherSystemDescription)
                .Build();
        }
    }
}
