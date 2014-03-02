Feature: Register
	I open the register page and fill the required credentials
	After completing those steps I will be given access to the site and sent a confirmation email


Background: 
	Given "user" table is empty at first
		And my username "<username>" does not exist in database
		And my email "<email>" does not exist in database
		| username | email              |
		| mikko    | test1@pitchdea.com |

Scenario: Email already exists in database

	Given register page "/RegisterPage.aspx" is open
		And email address "test@pitchdea.com" exists in the database
	When I enter "test@pitchdea.com" as email address
		And click "Maincontent_registerButton" register button
	Then I get "<errorMessage>" error message
#
#	Examples: 
#		| errorMessage                       |
#		| Oops! That email is already in use |

Scenario: Username already exists in database

	Given register page "/RegisterPage.aspx" is open
#		And username "test" already exists in database
	When I enter "test" in "Maincontent_usernameTextBox" username field
		And I hit enter key while "Maincontent_passwordConfirmationTextBox" password confirmation field is focused
	Then I get "<errorMessage>" error message
#
#	Examples: 
#		| errorMessage                               |
#		| Oops! That username has already been taken |


Scenario Outline: User fills valid credentials, is logged in by clicking and gets notification email.

	When I fill email field "Maincontent_emailTextBox" with "<email>" 
		And fill the username field "Maincontent_usernameTextBox" with "<username>"  
		And fill the password field "Maincontent_passwordTextBox" with password 
		And fill confirmation field "Maincontent_passwordConfirmationTextBox" with password confirmation
		And click "Maincontent_registerButton" register button 
	Then I am logged in with my email address "<email>"


	Examples: 
	| username  | email                |
	| käyttäjä1 | kayttaja@hotmail.com |
	| user5     | user@gmail.com       |


Scenario Outline: User fills valid credentials, is logged in by pressing enter and gets notification email.

	When I fill email field "Maincontent_emailTextBox" with "<email>"
		And fil username field "Maincontent_usernameTextBox" with "<username>" 
		And fill password field "Maincontent_passwordTextBox" with password
		And fill password confirmation field ""Maincontent_passwordConfirmationTextBox" with password confirmation
		And hit enter key while "Maincontent_passwordConfirmationTextBox" password confirmation field is focused
	Then I am logged in with  my "<email>"

	Examples: 
	| username  | email                |
	| käyttäjä1 | kayttaja@hotmail.com |
	| user5     | user@gmail.com       |
	

Scenario Outline: User fills invalid credentials, clicks, gets error message and is not registered.

	When I fill email field "Maincontent_emailTextBox" with email "<email>"
		And fill username field "Maincontent_usernameTextBox" with username "<username>" 
		And fill password field "Maincontent_passwordTextBox" with password
		And fill password confirmation field "Maincontent_passwordConfirmationTextBox" with password confirmation
		And click "Maincontent_registerButton" register button
	Then I get "<errorMessage>" error message
		And I am not logged in
		
	Examples: 
	| email                | username | password | confpass | errorMessage                                     |
	|                      | mikko    | passu    | passu    | You forgot to type an email.                     |
	| not an email address | mikko    | passu    | passu    | This doesn't seem to be an email address.        |
	| test1@pitchdea.com   | mikko    |          |          | You forgot to type a password.                   |
	| testi1@pitchea.com   |          | passu    | passu    | You forgot to type a username                    |
	| test1@pitchdea.com   | mikko    | passu    | salasana | password and password confirmation do not match. |
	| test1@pitchdea.com   | mikko    | passu    |          | password and password confirmation do not match. |



Scenario Outline: User fills invalid credentials, hits enter, gets error message and is not registered.

	When I fill email field "Maincontent_emailTextBox" with "<email>" email address
		And fill username field "Maincontent_usernameTextBox" with "<username>" username
		And fill password field "Maincontent_passwordTextBox" with "<password>" password
		And fill password confirmation field "Maincontent_passwordConfirmationTextBox" "<confpass>" password confirmation
		And hit enter key while "Maincontent_passwordConfirmationTextBox" field is focused
	Then I get "<errorMessage>" error message
		And I am not logged in

	Examples: 
		| email                | username | password | confpass | errorMessage                                     |
		|                      | mikko    | passu    | passu    | You forgot to type an email.                     |
		| not an email address | mikko    | passu    | passu    | This doesn't seem to be an email address.        |
		| test1@pitchdea.com   | mikko    |          |          | You forgot to type a password.                   |
		| testi1@pitchea.com   |          | passu    | passu    | You forgot to type a username                    |
		| test1@pitchdea.com   | mikko    | passu    | salasana | password and password confirmation do not match. |
		| test1@pitchdea.com   | mikko    | passu    |          | password and password confirmation do not match. |