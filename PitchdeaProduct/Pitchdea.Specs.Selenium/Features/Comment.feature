Feature: Comment
	I can comment on ideas posted by myself or others.

Background: 
	Given I am logged in as "test"
		And idea with title "test title" exists
		And idea page with title "test title" is open
		And comment field is visible
		And submit comment field is visible


Scenario: Post comment
	When I fill comment field with text "This is a comment" 
		And I click submit comment button
	Then idea page with title "test title" is open
		And a comment field with text "This is a comment" is visible
		And submitted by field with text "test" is visible
		And timestamp of that comment is UTC time when submit button was pressed
