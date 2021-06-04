using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using static Utilities.SharedTools.Constants.RoleConstants;

namespace PersistenceTest.Roles.Extensions
{
    public static class PersistenceRoleExtension
    {
        public static Role AddSomeRole(this PersistenceRoleTestBuilder roleTestBuilder)
        {
            return new PersistenceRoleTestBuilder()
                .With(r => r.Id, 0)
                .With(r => r.Title, someTitle)
                .With(r => r.Description, someDescription)
                .With(r => r.SystemDescription, someSystemDescription)
                .Build();
        }

        public static Role AddAnotherRole(this PersistenceRoleTestBuilder roleTestBuilder)
        {
            return new PersistenceRoleTestBuilder()
                .With(r => r.Id, 0)
                .With(r => r.Title, anotherTitle)
                .With(r => r.Description, anotherDescription)
                .With(r => r.SystemDescription, anotherSystemDescription)
                .Build();
        }

        public static Role AddSomeAnotherRole(this PersistenceRoleTestBuilder roleTestBuilder)
        {
            return new PersistenceRoleTestBuilder()
                .With(r => r.Id, 0)
                .With(r => r.Title, someAnotherTitle)
                .With(r => r.Description, someAnotherDescription)
                .With(r => r.SystemDescription, someAnotherSystemDescription)
                .Build();
        }

        public static (Role, Role) AddSomeAndAnotherRoles(this RoleRepositoryTests roleRepositoryTests, IGenericRepository<Role, long> sut)
        {
            var someRole = new PersistenceRoleTestBuilder().AddSomeRole();
            var anotherRole = new PersistenceRoleTestBuilder().AddAnotherRole();
            var firstResult = sut.Add(someRole, true);
            var secondResult = sut.Add(anotherRole, true);
            return (firstResult, secondResult);
        }
    }

}
