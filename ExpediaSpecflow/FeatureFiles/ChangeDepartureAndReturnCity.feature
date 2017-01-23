Feature: ChangeDepartureAndReturnCity

@Major
Scenario Outline: ChangeDepartureAndReturnCity
	Given on the Expedia home page
	And check home page loaded
	And press flight button
	And press round-trip ticket button
	And input and store content of flyght from <origCity> and to <destCity>
	And input and store content of departing date <depDays> days from today and returning date <returnDays> days from today 
	And input adults <adults> and children <children> amount
	And press search button
	And check departure select tickets page loaded
	And check destination city
	And select cheapest departing ticket
	And check returning select tickets page loaded
	And check origin city	
	And change and store content of departure Kiev and return Madrid city 
	And press search with diff info
	And close pop up email sing up
	And check departure select tickets page loaded	
	And check destination city
	And select cheapest departing ticket
	And check returning select tickets page loaded
	And check origin city	

	Examples: 
	| origCity | destCity | depDays    | returnDays | adults | children |
	| Paris    | Berlin   | 20		   | 25		    | 1      | 0        |
	| Madrid   | Kiev     | 3		   | 6		    | 1      | 0        |
