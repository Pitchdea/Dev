Feature: login function
	

@mytag
Scenario: Page title is correct
	Given User is not logged in
	When page is loaded
	Then page title should be "Sign in | Pitchdea"
