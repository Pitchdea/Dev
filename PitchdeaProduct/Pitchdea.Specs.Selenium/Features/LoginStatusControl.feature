Feature: Login status control

Scenario: User is logged in

	Given user is logged in as "test"
		And page "/mainPage.aspx" is open
	Then "Logout" link should be on the page
		And "Login" link should not be on the page
		And "Register" link should not be on the page
		And user is logged in as "test"


Scenario: User is not logged in
	
	Given page "/mainPage.aspx" is open
	Then "Login" link should be on the page
		And "Register" link should be on the page
		And "Logout" link should not be on the page