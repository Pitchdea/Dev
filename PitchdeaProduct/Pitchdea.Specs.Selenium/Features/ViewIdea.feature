Feature: View idea
	User views an idea 

Scenario Outline: Idea is created then viewed
	Given idea exists in the database 
		And the viewIdea page linked to the idea is open
	Then title is "<titleLabel> | Pitchdea"
		And "MainContent_titleLabel" field value is "<titleLabel>"
		And "MainContent_summaryLabel" field value is "<summarylabel>"
		And "MainContent_descriptionLabel" field value is "<titlelabel>"

	Examples:
	| titlelabel   | summarylabel                | descriptionlabel                                                                          |
	| My Idea      | I teach parrots to speak    | I am a ph.d. in neuroscience and I would like to found a parrot talk clinic               |
	| Great Idea   | Chaplin movies with dubbing | I would like to use my expertise to put romanian dubbing on chaplin movies                |
	| So Good Idea | Virtual piano lessons       | I am an alcoholic and have too much spare time so I could think I would be a good teacher |