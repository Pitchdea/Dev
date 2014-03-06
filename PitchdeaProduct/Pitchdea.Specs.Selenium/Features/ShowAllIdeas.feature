Feature: Show all ideas on the page

Background: 
	Given "idea" table is empty at first
		And "user" table is empty at first

#TODO: separate idea insertion and registeration into different steps
Scenario: All 3 ideas are shown
	Given an idea exists with values: "title1","summary1","summary1","question1"
		And an idea exists with values: "title2","summary2","summary2","question2"
		And an idea with image exists with values: "title3","testImage.jpg","summary3","summary3","question3"
		And page "mainPage.aspx" is open
	Then idea with "title1" should be on the page
		And idea with "title2" should be on the page
		And idea with "title3" should be on the page

Scenario: Open an idea
	Given an idea exists with values: "title1","summary1","summary1","question1"
		And page "mainPage.aspx" is open
	When I click idea "title1"
	Then page title is "title1" followed by " | Pitchdea"