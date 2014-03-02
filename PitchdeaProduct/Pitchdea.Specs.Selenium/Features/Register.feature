Feature: Register
	I open the register page and fill the required credentials
	After completing those steps I will be given access to the site


Background: 
	Given "user" table is empty at first
		And page "/RegisterPage.aspx" is open

Scenario: Email already exists in database

	Given user with email "test@pitchdea.com" exists in the database
	When I enter "test@pitchdea.com" as email address
		And I click register button
	Then I see "Oops! That email is already in use" error message


Scenario: Username already exists in database

	Given user with username "test" is exists in the database
	When I enter "test" in username field
		And I click register button
	Then I see "Oops! That username has already been taken" error message


Scenario: User fills valid credentials, is logged in by clicking.

	When I fill email field with "test1@pitchdea.com"
		And fill the username field with "mikko"
		And fill the password field with password "passu"
		And fill fill password confirmation field with "passu"
		And click register button 
	Then I am logged in with my email address "test1@pitchdea.com"
	

Scenario Outline: User fills valid credentials, is logged in by pressing enter.

	When I fill email field with "<email>"
		And fil username field with "<username>" 
		And fill password field with password
		And fill password confirmation field ""Maincontent_passwordConfirmationTextBox" with password confirmation
		And hit enter key while "Maincontent_passwordConfirmationTextBox" password confirmation field is focused
	Then I am logged in with  my email address "<email>"

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

		# 		And I hit enter key while password confirmation field is focused