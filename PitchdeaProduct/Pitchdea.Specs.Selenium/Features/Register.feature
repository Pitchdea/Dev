Feature: Register
	I open the register page and fill the required credentials
	After completing those steps I will be given access to the site


Background: 
	Given "user" table is empty at first
		And page "/RegisterPage.aspx" is open

Scenario: Email already exists in database

	Given user with email "test@pitchdea.com" exists in the database
	When I fill "test@pitchdea.com" as email address
		And I click register button
	Then I see "Oops! That email is already in use" error message


Scenario: Username already exists in database

	Given user with username "test" is exists in the database
	When I fill "test" in username field
		And I click register button
	Then I see "Oops! That username has already been taken" error message


Scenario: User registers succesfully by clicking
User fills valid credentials and is logged in by clicking register button.

	When I fill email field with "test1@pitchdea.com"
		And I fill the username field with "mikko"
		And I fill the password field with "passu"
		And I fill password confirmation field with "passu"
		And I click register button 
	Then page "/mainPage.aspx" is open
		And I am logged in as "test@pitchdea.com"
	
Scenario: User registers succesfully with Enter 
User fills valid credentials and is logged in by hitting enter while password confirmation field is active.

	When I fill email field with "test1@pitchdea.com"
		And I fill the username field with "mikko"
		And I fill the password field with "passu"
		And I fill password confirmation field with "passu"
		#TODO: repeat "hit enter tests" for every box
		And I hit enter key while password confirmation field is focused
	Then page "/mainPage.aspx" is open
		And I am logged in as "test@pitchdea.com"
			

Scenario Outline: User fills invalid credentials, clicks, gets error message and is not registered.

	When I fill email field with "<email>"
		And I fill username field with "<username>" 
		And I fill password field with "<password>"
		And I fill password confirmation field with "<confpass>"
		And I click register button
	Then I get "<errorMessage>" error message
		And page "/RegisterPage.aspx" is open
		
	Examples: 
	| email                | username | password | confpass | errorMessage                                     |
	|                      | mikko    | passu    | passu    | You forgot to type an email.                     |
	| not an email address | mikko    | passu    | passu    | This doesn't seem to be an email address.        |
	| test1@pitchdea.com   | mikko    |          |          | You forgot to type a password.                   |
	| testi1@pitchea.com   |          | passu    | passu    | You forgot to type a username                    |
	| test1@pitchdea.com   | mikko    | passu    | salasana | password and password confirmation do not match. |
	| test1@pitchdea.com   | mikko    | passu    |          | password and password confirmation do not match. |