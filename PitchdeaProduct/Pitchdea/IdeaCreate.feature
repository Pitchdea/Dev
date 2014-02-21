Feature: IdeaCreate
	User creates an idea.


Scenario: user submits an idea
	Given page "/ideaPage.aspx" is open
		And MainContent_titleTextBox field value is not ""
		And MainContent_ideaTextBox field value is not ""
		And MainContent_questionTextBox field value is not ""
	When user clicks "MainContent_createIdeaButton" button
	Then page "/mainPage.aspx" is open
		And "MainContentPlaceHolder_okMessage" field value is "Your idea has been created succesfully!"
