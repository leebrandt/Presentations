Feature: About Us Page
	In order to find out more about NAHP
	As a curious web user
	I want to view an About Us page

Scenario: Navigate to the About Us page
	Given I am on the '/home' page
	When I click the 'About Us' link
	Then the 'About Us' page should be displayed