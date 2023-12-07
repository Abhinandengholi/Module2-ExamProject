Feature: AddCustomer



@E2E-Add_Customer
Scenario: Adding the Customer Details
	Given User will be on Homepage
	When User will click on the BankManager Login Button
	Then Bankmanager Page is loaded in the same page
	When Selecting Add-Customer option
	* Fills the Customer Details '<firstname>','<lastname>','<postcode>'
	* Clicks the Add Customer
	Then Customer details added successfully
	
 
Examples:
	| firstname | lastname | postcode |
	| Mery | xym | 695585  |
 