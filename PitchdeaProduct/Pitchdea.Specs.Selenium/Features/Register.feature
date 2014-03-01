Feature: Register
	I open the register page and fill the required credentials
	After completing those steps I will be given access to the site and sent a confirmation email


Scenario Outline: User fills valid credentials, is logged in by clicking and gets notification email.
	Given register page is open
		And my "<username>" does not exist in database
		And my "<email>" does not exist in database
	When I fill my "<email>", "<username>" and password
#click
		And click registerbutton
#registering
	Then my credentials are added to database
		And logged in with  my "<email>"
		And email is sent to my "<email>"

	Examples: 
	| username  | email                |
	| käyttäjä1 | kayttaja@hotmail.com |
	| user5     | user@gmail.com       |


Scenario Outline: User fills valid credentials, is logged in by pressing enter and gets notification email.
	Given register page is open
		And my "<username>" does not exist in database
		And my "<email>" does not exist in database
	When I fill my "<email>", "<username>" and password
#enter
		And press enter
#registering
	Then my credentials are added to database
		And logged in with  my "<email>"
		And email is sent to my "<email>"
	Examples: 
	| username  | email                |
	| käyttäjä1 | kayttaja@hotmail.com |
	| user5     | user@gmail.com       |
	

Scenario Outline: User fills invalid credentials, clicks, gets error message and is not registered.
	Given register page is open
		And my "<username>" does not exist in database
		And my "<email>" does not exist in database
	When I fill my "<email>", "<username>" and "<password>"
#click
		And click registerbutton
	Then I get "<errorMessage>"
		And I am not sent an email
		And I am not logged in
		And my credentials are not added to database

	Examples: 
	| email                | username | password | errorMessage                              |
	|                      | mikko    | passu    | You forgot to type an email.              |
	| test1@pitchdea.com   |          |          | You forgot to type a password.            |
	| not an email address | mikko    | passu    | This doesn't seem to be an email address. |


Scenario Outline: User fills invalid credentials, hits enter, gets error message and is not registered.
	Given register page is open
		And my "<username>" does not exist in database
		And my "<email>" does not exist in database
	When I fill my "<email>", "<username>" and "<password>"
#enter
		And presses enter
	Then I get "<errorMessage>"
		And I am not sent an email
		And I am not logged in
		And my credentials are not added to database

	Examples: 
	| email                | username | password | errorMessage                              |
	|                      | mikko    | passu    | You forgot to type an email.              |
	| test1@pitchdea.com   |          |          | You forgot to type a password.            |
	| not an email address | mikko    | passu    | This doesn't seem to be an email address. |