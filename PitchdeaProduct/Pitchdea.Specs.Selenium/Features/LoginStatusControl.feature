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