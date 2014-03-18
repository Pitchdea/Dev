Feature: Comment
	I can comment on ideas posted by myself or others.

Background: 
	Given test database is empty at first
		And user is logged in as "test"
		And an idea exists with values: "<titlelabel>","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
		And page title is "<titlelabel>" followed by " | Pitchdea"
		And comment field is visible
		And submit comment field is focused
			

Scenario: Post comment
	When I fill comment field with text "This is a comment" 
		And I click submit comment button
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And a comment field value is "This is a comment" 
		And submitted by field with text "test" is visible
		And timestamp of that comment is UTC time when submit button was pressed
