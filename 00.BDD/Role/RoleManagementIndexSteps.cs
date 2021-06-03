using System;
using TechTalk.SpecFlow;

namespace DAP.BDD.SPECS.Role
{
    [Binding]
    public class RoleManagementIndexSteps
    {
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
        
        [Then(@"I should see Add a new user role button on the left top of the page")]
        public void ThenIShouldSeeAddANewUserRoleButtonOnTheLeftTopOfThePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
