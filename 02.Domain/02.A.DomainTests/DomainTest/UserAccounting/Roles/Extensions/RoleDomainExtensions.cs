using Domain.UserAccounting.Roles;
using static Utilities.SharedTools.Constants.RoleConstants;

namespace DomainTest.UserAccounting.Roles.Extensions
{
    public static class RoleDomainExtensions
    {
        public static Role AddSomeRole(this RoleTestBuilder roleTestBuilder)
        {
            return new RoleTestBuilder()
                            .With(r => r.Id, someId)
                            .With(r => r.Title, someTitle)
                            .With(r => r.Description, someDescription)
                            .With(r => r.SystemDescription, someSystemDescription)
                            .Build();
        }      
        
        public static Role AddAnotherRole(this RoleTestBuilder roleTestBuilder)
        {
            return new RoleTestBuilder()
                            .With(r => r.Id, anotherId)
                            .With(r => r.Title, anotherTitle)
                            .With(r => r.Description, anotherDescription)
                            .With(r => r.SystemDescription, anotherSystemDescription)
                            .Build();
        }

        public static Role AddSomeAnotherRole(this RoleTestBuilder roleTestBuilder)
        {
            return new RoleTestBuilder()
                .With(r => r.Id, someAnotherId)
                .With(r => r.Title, someAnotherTitle)
                .With(r => r.Description, someAnotherDescription)
                .With(r => r.SystemDescription, someAnotherSystemDescription)
                .Build();
        }


    }
}
