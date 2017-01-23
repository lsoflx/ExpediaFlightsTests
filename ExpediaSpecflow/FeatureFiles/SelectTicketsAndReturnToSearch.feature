Feature: SelectTicketsAndReturnToSearch

@Major
Scenario Outline: SelectTicketsAndReturnToSearch
	Given on the Expedia home page
	And check home page loaded
	And press flight button
	And press round-trip ticket button
	And input and store content of flyght from <origCity> and to <destCity>
	And input and store content of departing date <depDays> days from today and returning date <returnDays> days from today
	And input and store content of adults <adults> and children <children> amount
	And press search button
	And check departure select tickets page loaded
	And select and store content of cheapest departing ticket
	And check returning select tickets page loaded
	And select and store content of cheapest returning ticket
	And press no thanks on pop up
	And check search result page loaded
	And check on result page departure ticket credentials
	And check on result page returning ticket credentials 
	And check on result page amount of travelers(tickets)
	And check on result page total price of tickets
	And press return to search
	And check departure select tickets page loaded

	Examples: 
	| origCity | destCity | depDays    | returnDays | adults | children |
	| Paris    | Berlin   | 10		   | 16		    | 1      | 0        |
	| Kiev     | Madrid   | 25		   | 38		    | 1      | 0        |
