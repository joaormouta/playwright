Feature: Feature3
	Check if login functionality is working
	as expected with different permutations and
	combinations of data

	@oi @web
	Scenario: Check Login with correct username and password
		Given I have navigated to the application
		And I see the application opened
		When I click the login link
		And I click the login button
		Then I should see the username with hello