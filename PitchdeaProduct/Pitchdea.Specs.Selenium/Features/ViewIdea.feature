Feature: View idea
	User views an idea 

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first

Scenario Outline: Idea is created then viewed
	Given an idea exists with values: "<titlelabel>","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And "MainContent_titleLabel" field value is "<titlelabel>"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<descriptionlabel>"
		And "MainContent_questionLabel" field value is "<questionLabel>"
		# User "test" is defined in the Given step.
		And "MainContent_ideaOwner" field value is "test"

	Examples:
	| titlelabel    | summarylabel                                         | descriptionlabel                                                             | questionLabel       |
	| My Idea.      | ÄÖ "teksti" #¤ £$€                                   | I am a PH.D. in neuroscience and I would like to found a parrot talk clinic. | This is a question? |
	| GREAT IDEA!   | 0123456789                                           | More NUMBERS for fun 123123                                                  | Is this a question? |
	| So-Good-Idea? | Virtual PIANO lessons `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <> | weird characters on label `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <>                     | Really?             |

Scenario: Trying to open a non existing idea
	Given page "/viewIdeaPage.aspx?ID=hash123=" is open
	Then TODO
	
	#https://www.youtube.com/watch?v=_qDe3Afwg
	#"Go back to the main page"-link
