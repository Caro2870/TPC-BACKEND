Feature: ShowSuggestions
	Simple calculator for adding two numbers

Scenario: Show suggestions to a Coordinator
	Given I am in the suggestions section
	When I try to look up all the suggestions
	Then the system should show me all the suggestions

Scenario: Show There are no suggestions
	Given I am in the suggestions section (t)
	When I try to look up all the suggestions (t)
	Then I should SEE "There are no suggestions"