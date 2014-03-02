Feature: Register
	I open the register page and fill the required credentials
	After completing those steps I will be given access to the site and sent a confirmation email

Scenario: Email already exists in database

	Given register page is open
		And my "<email>" already exists in database
	When I click registerbutton
	Then I get "<errorMessage>"

	Examples: 
		| email              | errorMessage                       |
		| test1@pitchdea.com | Oops! That email is already in use |

Scenario: Username already exists in database

	Given register page is open
		And my "<username>" already exists in database
	When I hit enter key while "Maincontent_passwordConfirmationTextBox" field is focused
	Then I get "<errorMessage>"

	Examples: 
		| username | errorMessage                               |
		| test     | Oops! That username has already been taken | 


#Background is here
	Background: 
		Given register page is open
		And my "<username>" does not exist in database
		And my "<email>" does not exist in database

Scenario Outline: User fills valid credentials, is logged in by clicking and gets notification email.

	When I fill "<email>" field
		And fill "<username>"  field
		And fill password field
		And fill passwordconfirmation field 
		And click registerbutton
	Then I am logged in with  my "<email>"


	Examples: 
	| username  | email                |
	| käyttäjä1 | kayttaja@hotmail.com |
	| user5     | user@gmail.com       |


Scenario Outline: User fills valid credentials, is logged in by pressing enter and gets notification email.

	When I fill my "<email>"
		And fill my "<username>" 
		And fill my password
		And hit enter key while "Maincontent_passwordConfirmationTextBox" field is focused
	Then I am logged in with  my "<email>"

	Examples: 
	| username  | email                |
	| käyttäjä1 | kayttaja@hotmail.com |
	| user5     | user@gmail.com       |
	

Scenario Outline: User fills invalid credentials, clicks, gets error message and is not registered.

	When I fill my "<email>", "<username>" and "<password>"
		And click registerbutton
	Then I get "<errorMessage>"
		And I am not logged in
		
	Examples: 
	| email                | username | password | confpass | errorMessage                                     |
	| email                | username | password | confpass | errorMessage                                     |
	|                      | mikko    | passu    | passu    | You forgot to type an email.                     |
	| not an email address | mikko    | passu    | passu    | This doesn't seem to be an email address.        |
	| test1@pitchdea.com   | mikko    |          |          | You forgot to type a password.                   |
	| testi1@pitchea.com   |          | passu    | passu    | You forgot to type a username                    |
	| test1@pitchdea.com   | mikko    | passu    | salasana | password and password confirmation do not match. |
	| test1@pitchdea.com   | mikko    | passu    |          | password and password confirmation do not match. |



Scenario Outline: User fills invalid credentials, hits enter, gets error message and is not registered.

	When I fill my "<email>"
		And fill "<username>" 
		And fill "<password>"
		And fill "<confpass>"
		And hit enter key while "Maincontent_passwordConfirmationTextBox" field is focused
	Then I get "<errorMessage>"
		And I am not logged in

	Examples: 
		| email                | username | password | confpass | errorMessage                                     |
		|                      | mikko    | passu    | passu    | You forgot to type an email.                     |
		| not an email address | mikko    | passu    | passu    | This doesn't seem to be an email address.        |
		| test1@pitchdea.com   | mikko    |          |          | You forgot to type a password.                   |
		| testi1@pitchea.com   |          | passu    | passu    | You forgot to type a username                    |
		| test1@pitchdea.com   | mikko    | passu    | salasana | password and password confirmation do not match. |
		| test1@pitchdea.com   | mikko    | passu    |          | password and password confirmation do not match. |



	