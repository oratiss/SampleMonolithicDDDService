Feature: Role Management
    In order to manage user roles efficiently
    as an Admin
    I want to be able to see a list of roles and add a new one to the list

    Scenario: viewing Role index page from admin panel subsiders
        Given I am in side menu of website admin panel
        And I am in Users panel
        When I click on Roles management button
        Then I should be redirected into role index page
        And I should see a table of role titles and their corresponding description
        And I should see Add a new user role button on the left top of the page

    Scenario: Adding a new Role
        Given I want to as an administrator should be able to add a new role "Blog Authors"
        And I am in Add Role Page in Admin Panel
        When I Enter Role Tile as "Blog Authors"
        And I Enter Role Description as "The Users with right to add/remove/edit BlogCategories and BlogPosts"
        And I Press Save Button
        Then I shoud be redircted into Role Index page in Admin panel
        And I Should be able to see the "Blog Authors" in the List

    Scenario: viewing Role index page from AddANewUserRole page
        Given I am in Add a new user role page in admin panel
        When I click on View roles index button
        Then I shoud be redircted into Role Index page in Admin panel
        And I should see a table of role titles and their corresponding description
        And I should see Add a new user role button on the left top of the page

    Scenario Outline: Null RoleData entry
        Given I am in Add Role Page in Admin Panel
        When I Enter <RoleTitle>, <RoleDesc>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | RoleTitle    | RoleDesc                                                 | ErrorDesc                        |
            | null         | The Users with right to add BlogCategories and BlogPosts | Role title can not be null       |
            | Blog Authors | null                                                     | Role Description can not be null |

    Scenario Outline: whiteSpace RoleData entry
        Given I am in Add Role Page in Admin Panel
        When I Enter <RoleTitle>, <RoleDesc>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | RoleTitle    | RoleDesc                                                 | ErrorDesc                         |
            | whiteSpace   | The Users with right to add BlogCategories and BlogPosts | Role title can not be empty       |
            | Blog Authors | whiteSpace                                               | Role Description can not be empty |
    