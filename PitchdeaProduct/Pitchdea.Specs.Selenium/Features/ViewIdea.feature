Feature: View idea
	User views an idea 

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first

Scenario Outline: Idea is created then viewed
	Given an idea exists with values: "<titleLabel>","<summaryLabel>","<descriptionlabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And "MainContent_titleLabel" field value is "<titleLabel>"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<descriptionlabel>"

	Examples:
	| titlelabel    | summarylabel                                         | descriptionlabel                                                             |
	| My Idea.      | ÄÖ "teksti" #¤ £$€                                   | I am a PH.D. in neuroscience and I would like to found a parrot talk clinic. |
	| GREAT IDEA!   | 0123456789                                           | More NUMBERS for fun 123123                                                  |
	| So-Good-Idea? | Virtual PIANO lessons `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <> | weird characters on label `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <>                     |

Scenario Outline: User creates an idea with a multiline description 
	Given user writes two lines "<line1>" followed by "<line2>"
	Then "MainContent_descriptionLabel" field value is two lines "<line1>" followed by "<line2>"

	Examples:
	| line1 | line2 |
	| foo   | bar   |

