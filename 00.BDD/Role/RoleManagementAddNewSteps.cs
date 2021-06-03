using System;
using TechTalk.SpecFlow;

namespace DAP.BDD.SPECS.Role
{
    [Binding]
    public class RoleManagementAddNewSteps
    {
        [Given(@"I want to as an administrator should be able to add a new role ""(.*)""")]
        public void GivenIWantToAsAnAdministratorShouldBeAbleToAddANewRole(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I am in Add Role Page in Admin Panel")]
        public void GivenIAmInAddRolePageInAdminPanel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I Enter Role Tile as ""(.*)""")]
        public void WhenIEnterRoleTileAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I Enter Role Description as ""(.*)""")]
        public void WhenIEnterRoleDescriptionAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I Press Save Button")]
        public void WhenIPressSaveButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I shoud be redircted into Role Index page in Admin panel")]
        public void ThenIShoudBeRedirctedIntoRoleIndexPageInAdminPanel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I Should be to see the ""(.*)"" in the List")]
        public void ThenIShouldBeToSeeTheInTheList(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
