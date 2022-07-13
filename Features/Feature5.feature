Feature: Playwright on Tabs

	@web @tab
	Scenario: Access to a tab
		Given i access to 'Tab'
		When open a 'New Tab'
		Then i see the following message 'This is a sample page'
