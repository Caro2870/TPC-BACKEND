Feature: ListLessonByLessonType
	List Lessons by LessonType

@mytag
Scenario: List all lessons by LessonTypeId
	Given I want to see detailed information of the lessons by a determinated lesson type
	When I choose one lessontype (<LessonTypeId>, <LessonTypeName>)
	Then the system returns list of lessons by lessontype <Response>

	Examples: 
| LessonTypeId | LessonTypeName | Response |
| 1            | Tutoria        | True     |
| 2            | Taller         | True     |
| 3            | BadLessonType  | False    |