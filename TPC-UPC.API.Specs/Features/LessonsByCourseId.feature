Feature: LessonsByCourseId
	Simple calculator for adding two numbers

Background: 
	Given a course Id with number "1"

Scenario: Student look for tutorials
	Given I am in the finding tutorials section q
	When I try to look for a tutorial in a course q
	Then I should see all the Tutorials on the courseq

Scenario: Student looks for tutorials
	Given I am in the finding tutorials section a
	When I try to look for a tutorial in a course a
	Then I should see "There are no Tutorials on this course"