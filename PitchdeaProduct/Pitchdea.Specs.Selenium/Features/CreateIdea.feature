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
		And I fill idea question "<question>"
	When I click create idea button
	Then page title is "<title>" followed by " | Pitchdea"
		And idea title is "<title>"
		And idea summary is "<summary>"
		And idea description is "<description>"
		And idea question is "<question>"
		And idea owner is "test user"

		Examples:
		| title   | summary                  | question                 | description                                                                 |
		| My Idea | I teach parrots to speak | Would you buy this idea? | I am a ph.d. in neuroscience and I would like to found a parrot talk clinic |

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
		And I fill idea question "Would you build this idea?"
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
		And idea question is "Would you build this idea?"
		And idea owner is "test user"

Scenario: User uploads an image
	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open
	When I choose to upload a picture "TestResources\testImage.jpg" 
	Then the image path is "TestResources\testImage.jpg" 
	#When I click upload image button
	#Then I get an Ok message "Your image was uploaded successfully."

#TODO: Scenario: User is not logged in and opens the page

#piilota kaikki ja laita "please login"

#TODO
#Character limits
# title = 70
# summary = 200
# description = 1500
# question = 90