Feature: Like functionality
User can like and dislike ideas, except their own. The amount of likes is shown on the viewidea page.

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first
		And page "\viewIdeaPage.aspx" is open
		And user is logged in as "test"
		And an idea exists with values: "<titlelabel>","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And number of likes is "0"



Scenario: User likes an idea

	When I click the like button
	Then number of likes is "1"
#		And the like button is active
	When I refresh the page
	Then number of likes is "1"
#		And the like button is active


Scenario: User dislikes an idea
	
	When I click the dislike button
#	Then the dislike button is active
		And number of dislikes in database is "1"
	When I refresh the page
#	Then the dislike button is active
		And number of dislikes in database is "1"

#		And the dislike button is active


Scenario: User unlikes an idea without refresh

	When I click the like button
	Then number of likes is "1"
#		And the like button is active
	When I click the like button
	Then number of likes is "0"
#		And the like button is inactive
	When I refresh the page
	Then number of likes is "0"
#		And the like button is inactive
	

Scenario: User unlikes an idea with refresh

	When I click the like button
	Then number of likes is "1"
#		And the like button is active
	When I refresh the page
	Then number of likes is "1"
#		And the like button is active
	When I click the like button
	Then number of likes is "0"
#		And the like button is inactive
	When I refresh the page
	Then number of likes is "0"
#		And the like button is inactive


Scenario: User un-dislikes an idea
	
	When I click the dislike button
	Then number of dislikes in database is "1"
#		And the dislike button is active
	When I click the dislike button
	Then number of dislikes in database is "0"
#		And the dislike button is inactive
	When I refresh the page
	Then number of dislikes in database is "0"
#		And the dislike button is inactive 


Scenario: Dislike -> Like
	
	Given number of dislikes in database is "1"
#		And dislike button is active
	When I click the like button 
	Then number of dislikes in database is "0"
		And number of likes is "1"
#		And like button is active 
#		And dislike button is inactive


Scenario: Like -> Dislike

	Given number of likes is "1"
#		And like button is active
	When I click the dislike button 
	Then number of likes is "0"
		And number of dislikes in database is "1"
#		And dislike button is active 
#		And like button is inactive
	

#Scenario: User opens their own idea
#	When user opens their own idea
#	Then like button is hidden 
		#And dislike button is hidden

