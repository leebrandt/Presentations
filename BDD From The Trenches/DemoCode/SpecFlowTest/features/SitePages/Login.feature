Feature: User logs in
	In order to be recognized by the website
	As a registered user
	I want to be able to log in

Scenario: Load login page
	Given I am on the '/home' page
	When I click the 'Log In' link
	Then the 'Login' page should be displayed

@data
Scenario: Login with valid credentials
  Given I am on the '/account/login' page
  And that a user with a username of 'joeuser' and a password of 'p@55w0rd' exists
  And I have entered 'joeuser' in the 'Username' textbox
  And I have entered 'p@55w0rd' in the 'Password' textbox
  When I click the 'LOG IN' button
  Then the 'Home' page should be displayed
  And the 'Log Out' link should be visible

@data
Scenario: Login with invalid password
  Given I am on the '/account/login' page
  And that a user with a username of 'joeuser' and a password of 'p@55w0rd' exists
  And I have entered 'joeuser' in the 'Username' textbox
  And I have entered 'password' in the 'Password' textbox
  When I click the 'LOG IN' button
  Then the 'Login' page should be displayed
  And I should see 'Username or password appears to be invalid' on the page

@data
Scenario: Login with invalid username
  Given I am on the '/account/login' page
  And that a user with a username of 'joeuser' and a password of 'p@55w0rd' exists
  And I have entered 'notauser' in the 'Username' textbox
  And I have entered 'p@55w0rd' in the 'Password' textbox
  When I click the 'LOG IN' button
  Then the 'Login' page should be displayed
  And I should see 'Username or password appears to be invalid' on the page
