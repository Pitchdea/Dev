Feature: login function
	User should not be logged in until username/email and password fields are filled.
	User should not be logged in until login-button is clicked
	User should not be logged in if username/email or password fields are invalid.
Scenario: Page title is correct
	Given page "/login.aspx" is open
	Then page title should be "Sign in | Pitchdea"

Scenario: User name field is visible and active
	Given page "/login.aspx" is open
	Then there should be active user_field

Scenario: password field is visible and active
	Given page "/login.aspx" is open
	Then there should be active passwd_field

Scenario: login-button is visible and clickable
	Given page "/login.aspx" is open
	Then there should be clickable submit-button

Scenario: log in
	Given page "/login.aspx" is open
		And user_field is not empty
		And passwd_field is not empty
	When I press the login button	
	Given user field input is found from database
		And password_field input is found from database
	Then user should be logged in 
		And redirected to main page