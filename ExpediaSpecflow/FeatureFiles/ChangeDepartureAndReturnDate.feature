Feature: ChangeDepartureAndReturnDate

@Major
Scenario Outline: ChangeDepartureAndReturnDate
	Given on the Expedia home page
	And check home page loaded
	And press flight button
	And press round-trip ticket button
	And input flyght from <origCity> and to <destCity> 
	And input and store content of departing <depDate> and returning <returnDate> date
	And input adults <adults> and children <children> amount
	And press search button
	And check departure select tickets page loaded
	And check departure date
	And select cheapest departing ticket
	And check returning select tickets page loaded
	And check return date
	And change and store content of departure 12/24/2016 and return 12/29/2016 date 
	And press search with diff info
	And close pop up email sing up
	And check departure select tickets page loaded
	And check departure date
	And select cheapest departing ticket
	And check returning select tickets page loaded
	And check return date

	Examples: 
	| origCity | destCity | depDate    | returnDate | adults | children |
	| Paris    | Berlin   | 12/25/2016 | 12/28/2016 | 1      | 0        |
	| Madrid   | Kiev     | 12/26/2016 | 01/15/2017 | 1      | 0        |
