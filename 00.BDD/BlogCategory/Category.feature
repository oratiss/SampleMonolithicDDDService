    
Feature: category Management
    In order to manage categories efficienty
    As an Admin
    I want to see the list of Categories and add a new one to the list

    Scenario: Adding a new Category
        Given I am in AddANewCategory page in admin panel
        When I enter CategoryTitle as "Podcasts"
        And I click on save button
        Then I should be redirected to CategoryIndex page
        And I should see the "Podcasts" record on top of the list

    Scenario: viewing CategoryIndex Page from AddANewCategory page
        Given I am in AddANewCategory page in admin panel
        When I click on ViewCategoryIndex button
        Then I should be redirected into CategoryIndex page
        And I should see a table of Categories and their corresponding fields of information
        And I should see AddANewCategory button on the left top of the page

    
        Scenario Outline: Null CategoryData entry
        Given I am in AddANewCategory page in Admin Panel
        When I Enter <CategoryTitle>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | CategoryTitle | ErrorDesc                      |
            | Null          | Category title can not be Null |

    Scenario Outline: whiteSpace CategoryData entry
        Given I am in AddANewCategory page in Admin Panel
        When I Enter <CategoryTitle>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | CategoryTitle | ErrorDesc                       |
            | whiteSpace    | Category title can not be empty |

    Scenario Outline: Duplicated Value for Category name
        Given A category named as "Podcasts" already exists
        And I am in AddANewCategory page in Admin Panel in order to add a new category
        When I Enter a Duplicated <CategoryTitle>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | CategoryTitle | ErrorDesc                                 |
            | Podcasts      | This category has already been registered |
         


        