Feature: Like functionality
User can like and dislike ideas, except their own. The amount of likes is shown on the viewidea page.

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first
		And page "\viewIdeaPage.aspx" is open
		And user is logged in

Scenario: User opens an idea and likes it 
	Given an idea exists with values: "<titlelabel>","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And number of likes is "0"
	When I click like button
	Then number of likes is "1"
		And the like button is active

#TODO: all below

Scenario: User opens an idea and dislikes it
#Idea has not been liked before by this user
	When I click dislike button
	Then number of dislikes is "1"
		And the dislike button is active

Scenario: User opens an idea which he has already liked and tries to like again, new like is not added.
#Idea has been liked before by this user
	Given User opens an idea he has already liked
		And the like button is active
	When user clicks like button
	Then nothing happens
	

Scenario: User opens and idea which he has already disliked and tries to dislike again.
#Idea has been liked before by this user
	Given User opens an idea he has already disliked
		And dislike button is active
	When user clicks dislike button
	Then nothing happens

Scenario: User opens an idea which he has already liked and dislikes it.
User opens and idea he has liked, and is allowed to dislike it instead
#Idea has been liked before by this user
	Given like button is active
		And number of likes is "1"
	When the user clicks dislike button
	Then number of likes is "0"
		And number of dislikes is "1"
		And the dislike button is active

Scenario: User opens an idea which he has disliked and likes it.
	Given dislike button is active
		And number of dislikes is "1"
	When the user clicks the like button
	Then number of dislikes is "0"
		And number of likes is "1"
		And like button is active

Scenario: User opens their own idea
	When user opens their own idea
	Then like button is hidden 
		And dislike button is hidden

