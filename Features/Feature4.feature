Feature:Testing a REST API

	@api
	Scenario: The user can add Tourists to the event by calling api services

		Given A list of Tourists is available
		When I add the Tourist 'joao' to the tourist list
		And I add the Tourist table to the tourist list
			| Tourist_name | Tourist_email  | Tourist_location |
			| andre12      | andre12@ola.pt | Lisboa12         |
			| andre22      | andre22@ola.pt | Lisboa22         |
			| andre33      | andre32@ola.pt | Lisboa32         |
		Then I can see their presence at the tourist list