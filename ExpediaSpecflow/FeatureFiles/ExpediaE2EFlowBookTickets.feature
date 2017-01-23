Feature: ExpediaTicketSearch

@Smoke
@High
Scenario Outline: E2EFlowBookTickets
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
	And press continue booking button
	And check traveler info page loaded
	And input title <title> first name <fName> middle name <mName> last name <lName>
	And input country code <countryCode> phone number <phNumber> country <country>
	And press continue button
	And check payment page loaded
	And input cardholder name <fName> <lName>
	And input card number <cardNumber> expiration month <expMonth> and year <expYear> security code <secureCode>
	And choose country <country> input billing addressone <bilAddress1> and addresstwo <bilAddress2> input city <city> input postal code <postCode>
	And input email <eMail>
	And check on payment page departure ticket credentials
	And check on payment page returning ticket credentials 
	And check on payment page amount of tickets
	And check on payment page total price of tickets
	#When press complete booking
	#Then tickets bought

	Examples: 
	| origCity | destCity | depDays | returnDays | adults | children | title | fName | mName      | lName  | countryCode  | phNumber   | country | cardNumber       | expMonth | expYear | secureCode | bilAddress1        | bilAddress2    | city   | postCode | eMail               |
	| Kiev     | Madrid   | 5		| 7		     | 1      | 0        | Mr.   | Roman | Vasylovych | Soroka | Ukraine +380 | 0637123309 | Ukraine | 349196723071383  | 02-Feb   | 2019    | 505        | Zabolotnogo 30 175 | Kydryashova 14 | Kiev   | 03175    | murdok173@ukr.net   |
	| Berlin   | Paris    | 15      | 35         | 1      | 0        | Dr.   | James | John		  | Gran   | Germany +49  | 0958392140 | Germany | 5105105105105100 | 03-Mar   | 2020    | 707        | Banshtrasse 40, 65 | Bans 18		| Berlin | 08176    | cready221@gamil.com |