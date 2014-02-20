Feature: login(2) function
	The user can login into the service.

Scenario: The user inputs correct login information, clicks the login button.
Access is granted.

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