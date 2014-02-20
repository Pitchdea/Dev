Feature: login function
	User should not be logged in until username/email and password fields are filled.
	User should not be logged in until login-button is clicked
	User should not be logged in if username/email or password fields are invalid.
Scenario: Page title is correct
	Given page "/login.aspx" is open
	Then page title should be "Sign in | Pitchdea"

Scenario: User name field is visible and active
	Given page "/login.aspx" is open
	Then there should be active user field

Scenario: password field is visible and active
	Given page "/login.aspx" is open
	Then there should be active passwd field

Scenario: login-button is visible and clickable
	Given page "/login.aspx" is open
	Then there should be clickable button "login"

Scenario: log in
	Given user with <usr> and <pwd> exists in the database
		And user is at page "/login.aspx"
		And usr text field value is "<usr>"
		And pwd text field value is "<pwd>"
	When user presses button "login"
	Then user is redirected to "main.aspx"
		And user is logged in as <usr>