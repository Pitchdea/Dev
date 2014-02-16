Feature: login function
	

Scenario: Page title is correct
	Given User is not logged in
	When page is loaded
	Then page title should be "Sign in | Pitchdea"
