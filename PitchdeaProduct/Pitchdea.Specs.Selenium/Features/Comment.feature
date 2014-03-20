﻿Feature: Comment
	I can comment on ideas posted by myself or others.

Background: 
	
	Given test database is empty at first
		And user is logged in as "test"
		And an idea exists with values: "<titlelabel>","<summarylabel>","<descriptionlabel>","<questionLabel>" and the page for that idea is open.
	Then page title is "<titlelabel>" followed by " | Pitchdea"			
	
Scenario: Post comment
	
	When I fill comment field with text "This is a comment" 
		And I click submit comment button
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And first comment is "This is a comment"
		And first comment was submitted by "test"
		And first comment has posted time field

Scenario: Post two comment
	
	When I fill comment field with text "This is a comment" 
		And I click submit comment button
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And first comment is "This is a comment"
		And first comment was submitted by "test"
		And first comment has posted time field
	When I fill comment field with text "This is a comment too" 
		And I click submit comment button
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And first comment is "This is a comment too"
		And first comment was submitted by "test"
		And first comment has posted time field
		And there are 2 comments

Scenario: Trying to post empty comment

	When I click submit comment button
	Then page title is "<titlelabel>" followed by " | Pitchdea"
		And there are 0 comments
		#TODO: Notify user?