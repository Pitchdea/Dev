Feature: login function
	
Scenario: Page title is correct
	Given page "/login.aspx" is open
	Then page title should be "Sign in | Pitchdea"
