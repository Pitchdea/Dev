Feature: View idea
	User views an idea 

Background: 
	Given test database is empty at first

Scenario Outline: Idea is viewed
	Given an idea exists with values: "<titlelabel>","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And "MainContent_titleLabel" field value is "<titlelabel>"
		And shown image is "http://localhost:28231//img/ideaImages/defaultIdeaImage.jpg"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<descriptionlabel>"
		And "MainContent_questionLabel" field value is "<questionLabel>"
		# User "test" is defined in the Given step.
		And "MainContent_ideaOwner" field value is "test2"

	Examples:
	| titlelabel    | summarylabel                                         | descriptionlabel                                                             | questionLabel       |
	| My Idea.      | ÄÖ "teksti" #¤ £$€                                   | I am a PH.D. in neuroscience and I would like to found a parrot talk clinic. | This is a question? |
	| GREAT IDEA!   | 0123456789                                           | More NUMBERS for fun 123123                                                  | Is this a question? |
	| So-Good-Idea? | Virtual PIANO lessons `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <> | weird characters on label `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <>                     | Really?             |


Scenario Outline: Idea with image is viewed
	Given an idea with image exists with values: "<titlelabel>","testImage.jpg","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And "MainContent_titleLabel" field value is "<titlelabel>"
		And shown image is "http://localhost:28231//img/ideaImages/uploaded/testImage.jpg"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<descriptionlabel>"
		And "MainContent_questionLabel" field value is "<questionLabel>"
		# User "test" is defined in the Given step.
		And "MainContent_ideaOwner" field value is "test"

	Examples:
	| titlelabel | summarylabel       | descriptionlabel                                                             | questionLabel       |
	| My Idea.   | ÄÖ "teksti" #¤ £$€ | I am a PH.D. in neuroscience and I would like to found a parrot talk clinic. | This is a question? |

Scenario: Trying to open a non existing idea
	Given page "/viewIdeaPage.aspx?ID=hash123=" is open
	Then "Return to main page." link should be on the page


Scenario: Edit button is hidden when not logged in
	
	Given an idea exists with values: "title","summary","description","question" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And edit idea button does not exist


Scenario: Edit button is hidden when user is not the idea owner
	
	Given user is logged in (with password) as "test" with password "password123"
	Given an idea exists with values: "title","summary","description","question" and the page for that idea is open.
	Then page title is "title" followed by " | Pitchdea"
		And edit idea button does not exist