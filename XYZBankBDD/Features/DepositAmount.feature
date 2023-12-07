Feature:Customer Depositing the Amount
 
 
@E2E-Deposit_Amount
Scenario: Deposit Amount
	Given User will be on Homepage
	When  User will click on the Customer Login Button
	Then  Customer Page is loaded in the same page
	When User selects a '<customer>' from the list
	*   Clicks the Login Button
	*   Selecting the deposit option
	*   Enter the  amount '<amount>' to Deposit
	*   Clicks the Deposit Button
	Then Deposit Success Message Appears
 
Examples:
	 | customer | amount |
	 | Harry Potter | 23000 |
	