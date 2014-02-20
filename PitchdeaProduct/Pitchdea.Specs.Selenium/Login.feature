Feature: login(2) function
	The user can login into the service.

Scenario: The user inputs correct login information, clicks the login button.
Access is granted.
	Given user "test@pitchdea.com" with password "password123" exists in the database
		And page "/login.aspx" is open
		And username field value is "test@pitchdea.com"
		And password field value is "password123"
	When user clicks button "Log in"
	Then user is redirected to "/main.aspx"
		And user is logged in as "test@pitchdea.com"

Scenario: The user inputs correct login information and presses enter.
Access is granted.

Scenario: The user inputs incorrect login information and clicks the login button.
Access is not granted.

Scenario: The user tries to login when email field is empty.
An error message is shown to the user. Access is not granted.

Scenario: The user tries to login when password field is empty.
An error message is shown to the user. Access is not granted.

Scenario: The user inputs an invalid format email address and tries to login.
An error message is shown to the user. Access is not granted.