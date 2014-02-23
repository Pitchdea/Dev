Feature: View idea
	User views an idea 

Scenario Outline: Idea is created then viewed
	Given Given idea exists with values: "<titleLabel>","<summaryLabel>","<desrcriptionLabel>" and the page for that idea is open.
	Then title is "<titleLabel> | Pitchdea"
		And "MainContent_titleLabel" field value is "<titleLabel>"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<titlelabel>"

	Examples:
	| titlelabel    | summarylabel                                         | descriptionlabel                                                             |
	| My Idea.      | ÄÖ "teksti" #¤ £$€                                   | I am a PH.D. in neuroscience and I would like to found a parrot talk clinic. |
	| GREAT IDEA!   | 0123456789                                           | More NUMBERS for fun 123123                                                  |
	| So-Good-Idea? | Virtual PIANO lessons `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <> | weird characters on label `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <>                     |
	| this_is_title | this_is_summary .                                    | this is\r\n\  multiline \r\n\text                                            |