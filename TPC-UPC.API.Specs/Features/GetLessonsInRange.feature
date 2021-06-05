Feature: GetLessonsInRange
	Simple test for getting some lessons according to some params

@mytag
Scenario: Tutor gets a list of lessons according to a range of dates
	Given the tutor wants to list lessons according to a range of dates (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)
	When the tutor enters the parans (<start>, <end>)
	Then the result for this scenario should be the number of lessons in this range 3

Examples:
| LessonId | ScheduleId | Description | TutorId | LessonTypeId | CourseId | start      | end        |
| 1        | 4          | 1st Lesson  | 1       | 1            | 1        | 05/05/2021 | 05/07/2021 |

@mytag
Scenario: Tutor doens't get any list of lessons according to a range of dates
	Given the tutor wants to list lessons according to a range of dates (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)
	When the tutor enters the parans (<start>, <end>)
	And any lesson is returned (<start>, <end>)
	Then the message that returns for this scenario should be <message>

Examples:
| LessonId | ScheduleId | Description | TutorId | LessonTypeId | CourseId | start      | end        | message                                  |
| 1        | 4          | 1st Lesson  | 1       | 1            | 1        | 05/05/2021 | 05/07/2021 | One or more errors occurred. (You don't have any lessons in this range) |