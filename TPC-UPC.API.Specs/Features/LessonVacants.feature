Feature: LessonVacants
	Simple calculator for adding two numbers

Background: 
	Given a Lesson "id"
Scenario: Student look for vacants in a lesson
	Given I am in the lesson section
	When I see the lesson description
	Then I should see the number of vacants

Scenario: Student look for vacant in a lesson
	Given I am in the lesson section__
	When I see the lesson description__
	Then I should--SEE "There no vacants for this lesson"
