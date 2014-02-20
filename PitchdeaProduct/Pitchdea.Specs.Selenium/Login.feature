Feature: login(2) function
	The user can login into the service.

Background: 
	Given user "test@pitchdea.com" with password "password123" exists in the database
		And user "test@pitchdea.com" with password "password124" is not in the database
		And user "test2@pitchdea.com" with password "password123" is not in the database
		And user "test2@pitchdea.com" with password "password124" is not in the database
		And page "/login.aspx" is open

Scenario: The user inputs correct login information, clicks the login button.
Access is granted.
	Given "email" field value is "test@pitchdea.com"
		And "password" field value is "password123"
	When user clicks login button
	Then page "/main.aspx" is open
		And user is logged in as "test@pitchdea.com"

Scenario Outline: The user inputs correct login information and presses enter.
Access is granted.
	Given "username" field value is "test@pitchdea.com"
		And "password" field value is "password123"
	When user hits enter key while "<fieldname>" is focused
	Then page "/main.aspx" is open
		And user is logged in as "test@pitchdea.com"

	Examples: 
		| fieldname |
		| username  |
		| password  |

Scenario Outline: The user inputs incorrect login information and clicks the login button.
An error message is shown to the user. Access is not granted.
	Given "username" field value is "<username>"
		And "password" field value is "<password>"
	When user clicks login button
	Then page "/login.aspx" is open
		And "errorMessage" field value is "Email and password combination is incorrect."

	Examples: 
		| username           | password    |
		| test@pitchdea.com  | password124 |
		| test1@pitchdea.com | password123 |
		| test1@pitchdea.com | password124 |

Scenario: The user tries to login when email field is empty.
An error message is shown to the user. Access is not granted.
	Given "username" field is ""
	When user clicks login button
	Then page "/login.aspx" is open
		And "errorMessage" field value is "Email address field is empty."

Scenario: The user tries to login when password field is empty.
An error message is shown to the user. Access is not granted.
	Given "username" field value is "test@pitchdea.com"
		And "password" field is ""
	When user clicks login button
	Then page "/login.aspx" is open
		And "errorMessage" field value is "Password field is empty."

Scenario: The user inputs an invalid format email address and tries to login.
An error message is shown to the user. Access is not granted.
	Given "username" field value is "not an email address"
	When user clicks login button
	Then page "/login.aspx" is open
		And "errorMessage" field value is "Email address is not valid."