Feature: Login status control

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first

Scenario: User is logged in

	Given user is logged in as "test"
		And page "/mainPage.aspx" is open
	Then "Logout" link should be on the page
		And "Login" link should not be on the page
		And "Register" link should not be on the page
		And user is logged in as "test"
	When user clicks "Logout" link
		Then user is not logged in
		
Scenario Outline: User is not logged in
	
	Given page "/mainPage.aspx" is open
	Then "Login" link should be on the page
		And "Register" link should be on the page
		And "Logout" link should not be on the page	
	When user clicks "<link>" link
		Then page "<page>" is open

	Examples: 
	| link     | page               |
	| Login    | /loginPage.aspx    |
	| Register | /registerPage.aspx |

Scenario: user logs in and is redirected back to previous page
User is not logged in and they are on create idea page, when they click log in and succesfully complete it,
they are redirected back to the idea creation page.

#createpage
	Given user "test" with email "test@pitchdea.com" with password "password123" exists in the database 
		And page "/createIdeaPage.aspx" is open
	When user clicks "Login" link
#loginpage
	Then page "/loginPage.aspx?url=http://localhost:28231/createIdeaPage.aspx" is open
		When I fill email field with "test@pitchdea.com"
		And I fill password field with "password123" 
		And I click login button
#createpage
	Then page "/createIdeaPage.aspx" is open
		And user is logged in as "test"


