Feature: Weatherforecast

Scenario: Get Weatherforecast
	Given a request to a api
	When the get request is executed
	Then the response code should be 200