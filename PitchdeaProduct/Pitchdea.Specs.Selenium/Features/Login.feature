Feature: login
	The user can login into the service.

Background: 
	Given the user database is empty first
		And user "test@pitchdea.com" with password "password123" exists in the database
		And page "/loginPage.aspx" is open

Scenario: Correct login information with button click
The user inputs correct login information, clicks the login button.
Access is granted.
	Given "MainContent_emailTextBox" field value is "test@pitchdea.com"
		And "MainContent_passwordTextBox" field value is "password123"
	When user clicks "MainContent_loginButton" button
	Then page "/mainPage.aspx" is open
		And user is logged in as "test@pitchdea.com"

Scenario Outline: Correct login information with enter press
The user inputs correct login information and presses enter.
Access is granted.
	Given "MainContent_emailTextBox" field value is "test@pitchdea.com"
		And "MainContent_passwordTextBox" field value is "password123"
	When user hits enter key while "<fieldname>" is focused
	Then page "/mainPage.aspx" is open
		And user is logged in as "test@pitchdea.com"

	Examples: 
		| fieldname |
		| MainContent_emailTextBox  |
		| MainContent_passwordTextBox  |

Scenario Outline: Incorrect login information
The user inputs incorrect login information and clicks the login button.
An error message is shown to the user. Access is not granted.
	Given "MainContent_emailTextBox" field value is "<username>"
		And "MainContent_passwordTextBox" field value is "<password>"
	When user clicks "MainContent_loginButton" button
	Then page "/loginPage.aspx" is open
		And "MainContent_errorMessage" field value is "<errorMessage>"

	Examples: 
		| username           | password    | errorMessage                                 |
		| test@pitchdea.com  | password124 | Email and password combination is incorrect. |
		| test1@pitchdea.com | password123 | Email and password combination is incorrect. |
		| test1@pitchdea.com | password124 | Email and password combination is incorrect. |


Scenario Outline: Missing login information
The user does not input login information or the information is invalid and clicks the login button.
An error message is shown to the user. Access is not granted.
	Given "MainContent_emailTextBox" field value is "<username>"
		And "MainContent_passwordTextBox" field value is "<password>"
	When user clicks "MainContent_loginButton" button
	Then page "/loginPage.aspx" is open
		And "MainContent_errorMessage" field value is "<errorMessage>"

	Examples: 
		| username             | password    | errorMessage                  |
		|                      | password124 | You forgot to type an email. |
		| test1@pitchdea.com   |             | You forgot to type a password.      |
		| not an email address | password124 | This doesn't seem to be an email address.   |


