Feature: View idea
	User views an idea 

Scenario Outline: Idea is created then viewed
	Given Given idea exists with values: "<titleLabel>","<summaryLabel>","<desrcriptionLabel>" and the page for that idea is open.
	Then title is "<titleLabel> | Pitchdea"
		And "MainContent_titleLabel" field value is "<titleLabel>"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<titlelabel>"

	Examples:
	| titlelabel    | summarylabel                                         | descriptionlabel                                                                          |
	| My Idea!      | ÄÖ "teksti" #¤ £$€                                   | I am a ph.d. in neuroscience and I would like to found a parrot talk clinic               |
	| GREAT IDEA    | 0123456789                                           |                                                                                           |
	| So-Good-Idea? | Virtual piano lessons `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <> | I am an alcoholic and have too much spare time so I could think I would be a good teacher |
	|               |                                                      | weird characters on label `?=)(/&%¤#"!@£$€{[]} \ ~*'^ <>                                  |
 #todo:      
	| title         | summary                                              | multiline text                                                                            |