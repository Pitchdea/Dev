Feature: Create Idea
	User creates an idea.


Scenario Outline: user submits an idea
	Given page "/createIdeaPage.aspx" is open
		And user is logged in as "test@pitchdea.com"
		And "MainContent_titleTextBox" field value is "<title>"
		And "MainContent_ideaTextBox" field value is "<ideatext>"
		And "MainContent_questionTextBox" field value is "<question>"
	When user clicks "MainContent_createIdeaButton" button
	Then page title is "<title>"
		And "Maincontent_ideaHeader" value is "<title>"
		And "MainContent_ideaText" value is"<ideatext>"
		And "MainContent_questionText" value is "<question>"
		And "MainContent_statusMessage" field value is "Your idea has been created succesfully!"

		Examples:
			| title        | ideatext                    | question                   |
			| My Idea      | I teach parrots to speak    | Do you like this idea?     |
			| Great Idea   | Chaplin movies with dubbing | Would you go see?          |
			| So Good Idea | Virtual piano lessons       | Would you pay 20 USD/hour? |