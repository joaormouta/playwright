Feature: Feature1

	@tms:12 @trivial @web
	Scenario: Change location for de deliver of products at Amazon
		Given i access to 'Amazon'
		When change location to SG
		Then the at the banner appears Deliver to Singapore

	@bangood @web
	Scenario: Search a product with a range price
		Given i access to 'Banggood'
		And hover the category 'Computers & Office'
		And select the product 'Android Tablet' from the subcategory 'Tablet PC'
		When i search an item with the price from '50' to '200'
		Then the following items are listed
			| item                             |
			| UMIDIGI A11 Tab Helio P22 MT8768 |
			| BMAX MaxPad I11 UNISOC T618      |
			| TECLAST P85 Allwinner A133 Quad  |