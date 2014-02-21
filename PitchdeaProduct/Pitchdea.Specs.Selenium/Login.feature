Feature: login
	The user can login into the service.

Background: 
	Given the user database is empty first
		And user "test@pitchdea.com" with password "password123" exists in the database
		And page "/login.aspx" is open

Scenario: Correct login information with button click
The user inputs correct login information, clicks the login button.
Access is granted.
	Given "MainContentPlaceHolder_emailTextBox" field value is "test@pitchdea.com"
		And "MainContentPlaceHolder_passwordTextBox" field value is "password123"
	When user clicks "MainContentPlaceHolder_loginButton" button
	Then page "/main.aspx" is open
		And user is logged in as "test@pitchdea.com"

Scenario Outline: Correct login information with enter press
The user inputs correct login information and presses enter.
Access is granted.
	Given "MainContentPlaceHolder_emailTextBox" field value is "test@pitchdea.com"
		And "MainContentPlaceHolder_passwordTextBox" field value is "password123"
	When user hits enter key while "<fieldname>" is focused
	Then page "/main.aspx" is open
		And user is logged in as "test@pitchdea.com"

	Examples: 
		| fieldname |
		| MainContentPlaceHolder_emailTextbox  |
		| MainContentPlaceHolder_passwordTextbox  |

Scenario Outline: Incorrect login information
The user inputs incorrect login information and clicks the login button.
An error message is shown to the user. Access is not granted.
	Given "MainContentPlaceHolder_emailTextBox" field value is "<username>"
		And "MainContentPlaceHolder_passwordTextBox" field value is "<password>"
	When user clicks "MainContentPlaceHolder_loginButton" button
	Then page "/login.aspx" is open
		And "MainContentPlaceHolder_errorMessage" field value is "Email and password combination is incorrect."

	Examples: 
		| username           | password    |
		| test@pitchdea.com  | password124 |
		| test1@pitchdea.com | password123 |
		| test1@pitchdea.com | password124 |

Scenario: Empty email field
The user tries to login when email field is empty.
An error message is shown to the user. Access is not granted.
	Given "MainContentPlaceHolder_emailTextBox" field value is ""
	When user clicks "MainContentPlaceHolder_loginButton" button
	Then page "/login.aspx" is open
		And "MainContentPlaceHolder_errorMessage" field value is "Email address field is empty."

Scenario: Empty password field
The user tries to login when password field is empty.
An error message is shown to the user. Access is not granted.
	Given "MainContentPlaceHolder_emailTextBox" field value is "test@pitchdea.com"
		And "MainContentPlaceHolder_passwordTextBox" field value is ""
	When user clicks "MainContentPlaceHolder_loginButton" button
	Then page "/login.aspx" is open
		And "MainContentPlaceHolder_errorMessage" field value is "Password field is empty."

Scenario: Invalid email format
The user inputs an invalid format email address and tries to login.
An error message is shown to the user. Access is not granted.
	Given "MainContentPlaceHolder_emailTextBox" field value is "not an email address"
	When user clicks "MainContentPlaceHolder_loginButton" button
	Then page "/login.aspx" is open
		And "MainContentPlaceHolder_errorMessage" field value is "Email address is not valid."