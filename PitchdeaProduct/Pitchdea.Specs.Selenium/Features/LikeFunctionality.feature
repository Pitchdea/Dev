Feature: Like functionality
User can like and dislike ideas, except their own. The amount of likes is shown on the viewidea page.

Background: 
User is logged in and page "/viewIdeaPage.aspx" is open
Idea exists with correct IdeaID and title

Scenario: User opens an idea and likes it 
#Idea has not been liked before by this user
Given "Maincontent_LikeInfoLabel" field value is "You can like this idea below"
When the user clicks the "Maincontent_LikeIdeaButton"
Then "Maincontent_VoteValueLabel" field value is "You gave this idea +1"
	And "Maincontent_LikeCountLabel" field value is increased by 1 point

Scenario: User opens an idea and dislikes it
#Idea has not been liked before by this user
When the user clicks the "Maincontent_DislikeButton"
Then "Maincontent_LikeInfoLabel" field value is "You gave this idea -1"
	And "Maincontent_LikeCountLabel" field value is decreased by 1 point

Scenario: User opens and idea which he has already liked and tries to like again
#Idea has been liked before by this user
Given User opens and idea he has already liked
And "Maincontent_LikeInfoLabel" field value is "You gave this idea +1"
	And "Maincontent_DislikeButton" button is disabled
	And "Maincontent_LikeButton" button is enabled

Scenario: User opens and idea which he has already disliked and tries to dislike again
#Idea has been liked before by this user
Given User opens and idea he has already disliked
And "Maincontent_LikeInfoLabel" field value is "You gave this idea -1"
	And "Maincontent_DislikeButton" button is enabled
	And "Maincontent_LikeButton" button is disabled

Scenario: User opens and idea which he has already liked and dislikes it
User opens and idea he has liked, and is allowed to dislike it instead
#Idea has been liked before by this user
When the user clicks the "Maincontent_DislikeIdeaButton"
Then "Maincontent_VoteValueLabel" field is changed to "You gave this idea -1 point"
	And "Maincontent_LikeCountLabel" field value is decreased by 1 point

Scenario: User opens their own idea
When user opens their own idea
Then "Maincontent_LikeButton" button is disabled and "Maincontent_DislikeButton" button is disabled
