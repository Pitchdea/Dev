Feature: EditIdea

Background: 
	Given test database is empty at first
		And user is logged in (with password) as "test" with password "password123"
		And an idea submitted by "test" with password "password123"  exists with values: "title1","summary1","description1","question1" and the page for that idea is open
	Then page title is "title1" followed by " | Pitchdea"
	When I press edit idea button
	Then edit page for "title1" is open
		And shown image is "http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg"
		And editable idea title is "title1"
		And editable idea summary is "summary1"
		And editable idea description is "description1"
		And editable idea question is "question1"
		And idea owner is "test"
		
Scenario: Open edit page and overwrite idea values
	
	When I edit idea title to "Another title"
		And I edit idea summary to "Something else."
		And I edit idea description to "Something totally else."
		And I edit idea question to "Another question?"
		And I press submit changes button
	Then page title is "Another title" followed by " | Pitchdea"
		And shown image is "http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg"
		And idea title is "Another title"
		And idea summary is "Something else."
		And idea description is "Something totally else."
		And idea question is "Another question?"
		And idea owner is "test"


Scenario: Open edit page and extend idea values
		
	When I extend idea title with " Another title"
		And I extend idea summary with " Something else."
		And I extend idea description with " Something totally else."
		And I extend idea question with " Another question?"
		And I press submit changes button
	Then page title is "title Another title" followed by " | Pitchdea"
		And shown image is "http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg"
		And idea title is "title Another title"
		And idea summary is "summary Something else."
		And idea description is "description Something totally else."
		And idea question is "question Another question?"
		And idea owner is "test"
		

Scenario: Open edit page and upload a new image
	
	When I choose to upload a picture "testImage.jpg" 
		And I click upload image button
		And I click done button
		And I press submit changes button
	Then page title is "title1" followed by " | Pitchdea"
		And shown image is not "http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg"
		And idea title is "title1"
		And idea summary is "summary1"
		And idea description is "description1"
		And idea question is "question1"
		And idea owner is "test"


Scenario: Open edit page and change to default image

	Given an idea submitted by "test" with password "password123" with image exists with values: "titlelabel1","testImage.jpg","summarylabel1","descriptionlabel1","questionLabel1" and the page for that idea is open.	
	Then page title is "title1" followed by " | Pitchdea"
	When I press edit idea button
	Then edit page for "title1" is open
		And shown image is "http://localhost:28231//img/ideaImages/testImage.jpg"
	When I press use default picture button
	Then shown image is "http://localhost:28231//img/ideaImages/uploaded/testImage.jpg"
	When I press submit changes button
	Then page title is "title Another title" followed by " | Pitchdea"
		And shown image is "http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg"
		And idea title is "title Another title"
		And idea summary is "summary Something else."
		And idea description is "description Something totally else."
		And idea question is "question Another question?"
		And idea owner is "test"