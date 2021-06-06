using System;
using BDD.SPECS.User;
using TechTalk.SpecFlow;

namespace BDD.SPECS.Role
{
    [Binding]
    public class RoleManagementStepsViewingRoleIndexPageFromAdminPanelSubsiders:Steps
    {
        private readonly UserContext _userContext;
        public RoleManagementStepsViewingRoleIndexPageFromAdminPanelSubsiders(UserContext userContext)
        {
            _userContext = userContext;
        }
        [Given(@"I am in side menu of website admin panel")]
        public void GivenIAmInSideMenuOfWebsiteAdminPanel()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am in Users panel")]
        public void GivenIAmInUsersPanel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on Roles management button")]
        public void WhenIClickOnRolesManagementButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be redirected into role index page")]
        public void ThenIShouldBeRedirectedIntoRoleIndexPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see a table of role titles and their corresponding description")]
        public void ThenIShouldSeeATableOfRoleTitlesAndTheirCorrespondingDescription()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see Add a new user role button on the left top of the page")]
        public void ThenIShouldSeeAddANewUserRoleButtonOnTheLeftTopOfThePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
