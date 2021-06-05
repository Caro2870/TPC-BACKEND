Feature: LessonStudentSignUp
![LessonStudentSignUp](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple test for the correct realization of a creation of a lesson student

Link to a feature: [LessonStudentSignUp](TPC-UPC.API.Specs/Features/LessonStudentSignUp.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Student signs up for a lesson
	Given the Student is created (<StudentId>, <FirstName>, <LastName>, <Mail>, <PhoneNumber>, <AccountId>, <CareerId>, <CycleNumber>)
	And the lesson is created (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)
	When the student signs up for the first time for this lesson
	Then what returns should be <response>

Examples:
| StudentId | FirstName | LastName | Mail     | PhoneNumber | AccountId | CareerId | CycleNumber | LessonId | ScheduleId | Description | TutorId | LessonTypeId | CourseId | response | text                                |
| 1         | Brigitte  | Mendez   | m@com.pe | 4589        | 1         | 1        | 5           | 1        | 4          | 1st Lesson  | 1       | 1            | 1        | True     | You are already part of this lesson |


@mytag
Scenario: Student signs up for the same lesson
	Given the Student is created (<StudentId>, <FirstName>, <LastName>, <Mail>, <PhoneNumber>, <AccountId>, <CareerId>, <CycleNumber>)
	And the lesson is created (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)
	When the student signs up for the second time for this lesson 
	Then the returned result should be <text>

Examples:
| StudentId | FirstName | LastName | Mail     | PhoneNumber | AccountId | CareerId | CycleNumber | LessonId | ScheduleId | Description | TutorId | LessonTypeId | CourseId | response | text                                |
| 1         | Brigitte  | Mendez   | m@com.pe | 4589        | 1         | 1        | 5           | 1        | 4          | 1st Lesson  | 1       | 1            | 1        | True     | You are already part of this lesson |

@mytag
Scenario: Student signs up for a full lesson
	Given the Student is created (<StudentId>, <FirstName>, <LastName>, <Mail>, <PhoneNumber>, <AccountId>, <CareerId>, <CycleNumber>)
	And the lesson is created (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)
	When the student signs up for the a lesson that is full
	Then the result for this operation should be <text>

Examples:
| StudentId | FirstName | LastName | Mail     | PhoneNumber | AccountId | CareerId | CycleNumber | LessonId | ScheduleId | Description | TutorId | LessonTypeId | CourseId | response | text                |
| 1         | Brigitte  | Mendez   | m@com.pe | 4589        | 1         | 1        | 5           | 1        | 4          | 1st Lesson  | 1       | 1            | 1        | True     | This lesson is full |
