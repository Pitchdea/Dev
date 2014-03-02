Feature: Create Idea
	User creates an idea.


Scenario Outline: user submits an idea
	Given page "/createIdeaPage.aspx" is open
		And user is logged in as "test@pitchdea.com"
		And "MainContent_titleTextBox" field value is "<title>"
		And "MainContent_summaryTextBox" field value is "<summary>"
		And "MainContent_descriptionTextBox" field value is "<description>"
	When user clicks "MainContent_createIdeaButton" button
	Then page title is "<title> | Pitchdea"
		And "Maincontent_ideatitle" value is "<title>"
		And "MainContent_summaryTextBox" value is"<summary>"
		And "MainContent_descriptionTextBox" value is "<description>"
		And "MainContent_statusMessage" field value is "Your idea has been created succesfully!"

		Examples:
			| title        | summary                     | description                                                                               |
			| My Idea      | I teach parrots to speak    | I am a ph.d. in neuroscience and I would like to found a parrot talk clinic               |
			| Great Idea   | Chaplin movies with dubbing | I would like to use my expertise to put romanian dubbing on chaplin movies                |
			| So Good Idea | Virtual piano lessons       | I am an alcoholic and have too much spare time so I could think I would be a good teacher |

#TODO
#Tapio's multiline version 2: (google: PyStringNode)
#
#Scenario: user creates a multiline idea
#	When user fills "MainContent_description textBox" field with: 
#    """
#    This is line 1
#    This is line 2
#    This is line 3
#    """
#Then "MainContent_descriptionLabel" field value is:
# "  
#	"""
#    This is line 1
#    This is line 2
#    This is line 3
#    """
# "	