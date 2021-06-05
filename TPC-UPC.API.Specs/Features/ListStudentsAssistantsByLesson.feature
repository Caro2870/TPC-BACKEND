Feature: ListStudentAssistantsByLesson
	list of students who attended a lesson

@mytag
Scenario: List of students who attended a specific lesson
	Given I am a tutor and want to see the list of students who enter to the lesson
	When I choose one lesson <MeetingId>
	Then the system shows the list

	Examples: 
| MeetingId |
| 1         |
| 2         |
| 100       |