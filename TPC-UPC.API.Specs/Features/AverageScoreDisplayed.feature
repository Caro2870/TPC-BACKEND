Feature: AverageScoreDisplayed
	Simple test for calculatin the average of the quality of teaching

@mytag
Scenario: The tutor wants to see the average of the scores given to him during the cycle and it returns

	Given the tutor 1 wants to see the average score for a course 1 and type of course 1
	When the tutor makes the petition
	Then the system returns the average score given to him of the whole cycle  4

@mytag
Scenario: The tutor wants to see the average of the scores given to him during the cycle but he hasn't dictated according to the parameters

	Given the tutor 1 wants to see the average score for a course 1 and type of course 1
	And there are not lessons for the specified parameters for tutor 1 course 1 and type of course 1
	When the tutor asks for the data
	Then the system returns the following message 0