Feature: User Management
    In order to manage user efficiently
    as an Admin 
    I want to be able to the list of Users and add a new one to the list
    
    Scenario: viewing UserIndex page
        Given I am in side menu of website admin panel
        And I am in User panel
        When I click on Users management button
        Then I should be redirected into UserIndex page
        And I should see a table of Users and their corresponding fields of information
        And I should see a AddANewUser button on the left top of the page

    Scenario: Adding a new user
        Given I am in AddANewUser page
        When I enter Name as "mehdi"
        And I enter LName as "vahabisani"
        And I enter RoleTitle as "Blog Authors"
        And I Enter Email as "mehdivbs97@gmail.com"
        And I Enter Password as "810994117m"
        And I Enter PasswordRep as "810994117m"
        And I Enter MobileNum as "09157695921"
        And I click on save button
        Then I shoud be redircted into UserIndex page in Admin panel
        And I Should see the "mehdivbs97@gmail.com" on top of the List

    Scenario: Viewing UserIndex page from AddANewUser page
        Given I am in AddANewUser page in admin panel
        When I click on View UsersIndex button
        Then I should be redirected into UserIndex page
        And I should see a table of Users and their corresponding fields of information
        And I should see AddANewUser button on the left top of the page

    Scenario Outline: Null UserData entry
        Given I am in AddANewUser page in Admin Panel
        When I Enter <Name>, <LName>, <RoleTitle>, <Username>, <Email>, <Password>, <PasswordRep>, <MobileNum>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | Name   | LName    | RoleTitle    | Email           | Password   | PasswordRep | MobileNum | ErrorDesc                       |
            | null   | null     | null         | null            | null       | null        | null      | name can not be null            |
            | Masoud | null     | null         | null            | null       | null        | null      | Lastname can not be null        |
            | Masoud | Asgarian | null         | null            | null       | null        | null      | role type can not be null       |
            | Masoud | Asgarian | Blog Authors | null            | null       | null        | null      | email can not be null           |
            | Masoud | Asgarian | Blog Authors | MasAs@gmail.com | null       | null        | null      | password can not be null        |
            | Masoud | Asgarian | Blog Authors | MasAs@gmail.com | 12345MasAs | null        | null      | password repeat can not be null |
            | Masoud | Asgarian | Blog Authors | MasAs@gmail.com | 12345MasAs | 12345MasAs  | null      | mobile number can not be null   |

    Scenario Outline:  WhiteSpace UserData entry
        Given I am in AddANewUser page in Admin Panel
        When I Enter <Name>, <LName>, <RoleTitle>, <Username>, <Email>, <Password>, <PasswordRep>, <MobileNum>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | Name       | LName      | RoleTitle    | Email           | Password   | PasswordRep | MobileNum  | ErrorDesc                        |
            | whiteSpace | whiteSpace | whiteSpace   | whiteSpace      | whiteSpace | whiteSpace  | whiteSpace | name can not be empty            |
            | Masoud     | whiteSpace | whiteSpace   | whiteSpace      | whiteSpace | whiteSpace  | whiteSpace | Lastname can not be empty        |
            | Masoud     | Asgarian   | whiteSpace   | whiteSpace      | whiteSpace | whiteSpace  | whiteSpace | role type can not be empty       |
            | Masoud     | Asgarian   | Blog Authors | whiteSpace      | whiteSpace | whiteSpace  | whiteSpace | username can not be empty        |
            | Masoud     | Asgarian   | Blog Authors | whiteSpace      | whiteSpace | whiteSpace  | whiteSpace | email can not be empty           |
            | Masoud     | Asgarian   | Blog Authors | MasAs@gmail.com | whiteSpace | whiteSpace  | whiteSpace | password can not be empty        |
            | Masoud     | Asgarian   | Blog Authors | MasAs@gmail.com | 12345MasAs | whiteSpace  | whiteSpace | password repeat can not be empty |
            | Masoud     | Asgarian   | Blog Authors | MasAs@gmail.com | 12345MasAs | 12345MasAs  | whiteSpace | mobile number can not be empty   |

    Scenario Outline: Duplicated Value for email
        Given the following user already exists:
            | Name   | LName    | RoleTitle    | Email           | Password   | PasswordRep | MobileNum   |
            | Masoud | Asgarian | Blog Authors | MasAs@gmail.com | 12345MasAs | MasAs12345  | 09157695921 |
        And I am in AddANewUser page in Admin Panel in order to add a new user
        When I Enter <Name>, <LName>, <RoleTitle>, a Duplicated <Email>, <Password>, <PasswordRep>, <MobileNum>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | Name  | LName      | RoleTitle    | Email           | Password    | PasswordRep | MobileNum   | ErrorDesc                            |
            | mehdi | vahabisani | Blog Authors | MasAs@gmail.com | 123MehdiVBS | 123MehdiVBS | 09157695921 | Email Address has been already taken |

    Scenario Outline: non-identical pass repeat
        Given I am AddANewUser page in Admin Panel
        When I Enter <Name>, <LName>, <RoleTitle>, <Username>, <Email>, <Password>, a non-identical <PasswordRep>, <MobileNum>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | Name   | LName    | RoleTitle    | Username    | Email           | Password   | PasswordRep | MobileNum   | ErrorDesc                             |
            | Masoud | Asgarian | Blog Authors | MasAsgarian | MasAs@gmail.com | 12345MasAs | MasAs12345  | 09157695921 | password and PasswordRep do not match |

        