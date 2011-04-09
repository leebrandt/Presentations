Feature: Home Page Loads
	In order to use the website
	As an anonymous web user
	I want to be able to load the home page

Scenario: Navigating to the home page
	When I navigate to '/home'
	Then the 'Home' page should be displayed