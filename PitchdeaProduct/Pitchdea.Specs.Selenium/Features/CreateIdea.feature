Feature: Create Idea
	User creates an idea.

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first

Scenario Outline: user submits an idea
	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open		
		And I fill idea title "<title>"
		And I fill idea summary "<summary>"
		And I fill idea description "<description>"
	When I click create idea button
	Then page title is "<title>" followed by " | Pitchdea"
		And idea title is "<title>"
		And idea summary is "<summary>"
		And idea description is "<description>"
		And idea owner is "test user"

		Examples:
			| title        | summary                     | description                                                                               |
			| My Idea      | I teach parrots to speak    | I am a ph.d. in neuroscience and I would like to found a parrot talk clinic               |
			| Great Idea   | Chaplin movies with dubbing | I would like to use my expertise to put romanian dubbing on chaplin movies                |
			| So Good Idea | Virtual piano lessons       | I am an alcoholic and have too much spare time so I could think I would be a good teacher |

Scenario: user creates an idea with multiline description

	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open		
		And I fill idea title "Multi-line idea"
		And I fill idea summary with lines
		"""
		This is a multiline idea!

		Yes, multiple lines!
		"""
		And I fill idea description with lines
		"""
		More lines!
		Even more lines!!
		And a few more...
		"""
	When I click create idea button
	Then page title is "Multi-line idea" followed by " | Pitchdea"
		And idea title is "Multi-line idea"
		And idea summary is multiline: 
		"""
		This is a multiline idea!

		Yes, multiple lines!
		"""
		And idea description is multiline:
		"""
		More lines!
		Even more lines!!
		And a few more...
		"""
		And idea owner is "test user"

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