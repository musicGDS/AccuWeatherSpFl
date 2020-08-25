Feature: Get City
	

@mytag
Scenario: Request 
	Given the country code "LT"
	When requesting Admin Area List
	Then the first city should be "Alytus"