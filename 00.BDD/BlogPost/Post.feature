
Feature: Post Management
    In order to manage Posts efficienty
    As an Admin
    I want to see the list of Posts and add a new one to the list

    Scenario: Adding a new post
        Given I am in NewPost page in admin panel
        When I enter PostTitle as "Papillon 1973 and its soundtracks"
        And I enter ShortDesc as "A masterpiece by Jerry Goldsmith"
        And I enter Text as "Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history"
        And I enter CreationDate as "2020/09/11"
        And I enter CategoryTitle as "Podcasts"
        And I enter BlogAuthor as "Mehdi Vahabisani"
        And I enter KeyWord as "Papillon"
        And I click on save button
        Then I should be redirected to PostIndex page
        And I should see the "Papillon 1973 and its soundtracks" record on top of the list

    Scenario: Viewing PostIndex Page from NewPost page
        Given I am in NewPost page in admin panel
        When I click on ViewPostIndex button
        Then I should be redirected into PostIndex page
        And I should see a table of Posts and their corresponding fields of information
        And I should see NewPost button on the left top of the page

    Scenario Outline: Null PostData entry
        Given I am in NewPost page in Admin Panel
        When I Enter <PostTitle>, <ShortDesc>, <Text>, <CreationDate>, <CategoryTitle>, <BlogAuthor>, <KeyWord>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | PostTitle | ShortDesc | Text | CreationDate | CategoryTitle | BlogAuthor |KeyWord |ErrorDesc |
            |null|null|null|null|null|null|null|Post Title can not be null|
            |Papillon 1973 and its soundtracks|null|null|null|null|null|null|Short Description can not be null|
            |Papillon 1973 and its soundtracks|A masterpiece by Jerry Goldsmith|null|null|null|null|null|text can not be null|
            |Papillon 1973 and its soundtracks|A masterpiece by Jerry Goldsmith|Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history|null|null|null|null|creation date can not be null|
            |Papillon 1973 and its soundtracks|A masterpiece by Jerry Goldsmith|Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history|2020/09/11|null|null|null|category title can not be null|
            |Papillon 1973 and its soundtracks|A masterpiece by Jerry Goldsmith|Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history|2020/09/11|Podcasts|null|null|blog author can not be null|
            |Papillon 1973 and its soundtracks|A masterpiece by Jerry Goldsmith|Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history|2020/09/11|Podcasts|Mehdi Vahabisani|null|KeyWord can not be null|
         

    Scenario Outline: WhiteSpace PostData entry
        Given I am in NewPost page in Admin Panel
        When I Enter <PostTitle>, <ShortDesc>, <Text>, <CreationDate>, <CategoryTitle>, <BlogAuthor>, <KeyWord>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | PostTitle                         | ShortDesc                        | Text                                                                                                      | CreationDate | CategoryTitle | BlogAuthor       | KeyWord    | ErrorDesc                           |
            | whiteSpace                        | whiteSpace                       | whiteSpace                                                                                                | whiteSpace   | whiteSpace    | whiteSpace       | whiteSpace | post title can not be empty         |
            | Papillon 1973 and its soundtracks | whiteSpace                       | whiteSpace                                                                                                | whiteSpace   | whiteSpace    | whiteSpace       | whiteSpace | Short Description can not be empty  |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | whiteSpace                                                                                                | whiteSpace   | whiteSpace    | whiteSpace       | whiteSpace | Text can not be empty               |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | whiteSpace   | whiteSpace    | whiteSpace       | whiteSpace | creation date can not be empty      |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | 2020/09/11   | whiteSpace    | whiteSpace       | whiteSpace | category title can not be empty     |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | 2020/09/11   | Podcasts      | whiteSpace       | whiteSpace | passworblog author can not be empty |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | 2020/09/11   | Podcasts      | Mehdi Vahabisani | whiteSpace | KeyWord can not be empty            |
    
    Scenario Outline: Duplicated value for Post title
        Given the following Post item already exists:
            | PostTitle                         | ShortDesc                        | Text                                                                                                      | CreationDate | CategoryTitle | BlogAuthor       | KeyWord  |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | 2020/09/11   | Podcasts      | Mehdi Vahabisani | Papillon |
        And I am in NewPost page in Admin Panel in order to add a new post
        When I Enter a Duplicated <PostTitle>, <ShortDesc>, <Text>, <CreationDate>, <CategoryTitle>, <BlogAuthor>, <KeyWord>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
            | PostTitle                         | ShortDesc                        | Text                                                                                                      | CreationDate | CategoryTitle | BlogAuthor       | KeyWord  |
            | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | 2020/09/11   | Podcasts      | Mehdi Vahabisani | Papillon |

    Scenario Outline: invalid post creation date (entering a date greater than today)
        Given I am in NewPost page in Admin Panel
        When I Enter <PostTitle>, <ShortDesc>, <Text>, a <CreationDate> greater than today , <CategoryTitle>, <BlogAuthor>, <KeyWord>
        And I click on save button
        Then I should see <ErrorDesc> correctly
        Examples:
        | PostTitle                         | ShortDesc                        | Text                                                                                                      | CreationDate | CategoryTitle | BlogAuthor       | KeyWord  | ErrorDesc                                    |
        | Papillon 1973 and its soundtracks | A masterpiece by Jerry Goldsmith | Composed by Jerry Goldsmith, Papillon 1973 soundtrack yet is one of most memorable songs in movie history | 2020/10/24   | Podcasts      | Mehdi Vahabisani | Papillon | creation date must not be greater than today |
