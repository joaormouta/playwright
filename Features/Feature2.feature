Feature: Amazone - one feature file

	@PTA-70
	Scenario: Amazon1
		Given i access to 'Amazon'
		When change location to RO
		Then the at the banner appears Deliver to Romssania
