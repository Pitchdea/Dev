Feature: Create Idea
	User creates an idea.

Background: 
	Given test database is empty at first

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
		And shown image is "http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg"

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
		And shown image is "http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg"

Scenario Outline: user submits an idea WITH image.
	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open		
		And I fill idea title "<title>"
		And I fill idea summary "<summary>"
		And I fill idea description "<description>"
		And I fill idea question "<question>"
	When I choose to upload a picture "testImage.jpg" 
		And I click upload image button
		And I click done button
	Then I get an Ok message "Your image was uploaded successfully."
	When I click create idea button
	Then page title is "<title>" followed by " | Pitchdea"
		And idea title is "<title>"
		And idea summary is "<summary>"
		And idea description is "<description>"
		And idea question is "<question>"
		And idea owner is "test user"
		And shown image is not "http://localhost:28231/img/ideaImages/defaultIdeaImage.jpg"

		Examples:
		| title   | summary                  | question                 | description                                                                 |
		| My Idea | I teach parrots to speak | Would you buy this idea? | I am a ph.d. in neuroscience and I would like to found a parrot talk clinic |

Scenario: image preview

	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open
	Then image preview should not be shown
	When I choose to upload a picture "testImage.jpg" 
		And I click upload image button
		And I click done button
	Then image preview should be shown

Scenario Outline: information is missing

	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open
		And I fill idea title "<title>"
		And I fill idea summary "<summary>"
		And I fill idea description "<description>"
		And I fill idea question "<question>"
	When I click create idea button
	Then page "/createIdeaPage.aspx" is open
		And I see "<errorMessage>" error message

	Examples: 
	| title | summary | description | question  | errorMessage                     |
	|       | summary | description | question? | The idea title is missing.       |
	| title |         | description | question? | The idea summary is missing.     |
	| title | summary |             | question? | The idea description is missing. |
	| title | summary | description |           | The idea question is missing.    |
	
Scenario Outline: information is too long
#Character limits
# title = 70
# summary = 200
# description = 1500
# question = 90

	Given user is logged in as "test user"
		And page "/createIdeaPage.aspx" is open
		And I fill idea title with "<title>" characters
		And I fill idea summary with "<summary>" characters
		And I fill idea description with "<description>" characters
		And I fill idea question with "<question>" characters
	When I click create idea button
	Then page "/createIdeaPage.aspx" is open
		And I see "<errorMessage>" error message

	Examples: 
	| title | summary | description | question | errorMessage                                                        |
	| 71    | 150     | 1499        | 80       | The title is too long, the maximum length is 70 characters.         |
	| 68    | 201     | 200         | 80       | The summary is too long, the maximum length is 200 characters.      |
	| 69    | 199     | 1501        | 80       | The description is too long, the maximum length is 1500 characters. |
	| 70    | 200     | 80          | 91       | The question is too long, the maximum length is 90 characters.      |


Scenario: User is not logged
User is not logged in and when they open the create idea page all the content 
are hidden and user sees a suggestion to login
	Given user is not logged in
		And page "/createIdeaPage.aspx" is open
	Then title text box is hidden
		And summary text box is hidden
		And content text box is hidden
		And question text box is hidden
		And upload image control is hidden
		And upload image button is hidden
		And image preview is hidden
		And create your idea button is hidden