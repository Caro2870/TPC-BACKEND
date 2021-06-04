Feature: LessonStudentSignUp
![LessonStudentSignUp](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple test for the correct realization of a creation of a lesson student

Link to a feature: [LessonStudentSignUp](TPC-UPC.API.Specs/Features/LessonStudentSignUp.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**


#Background: 
#	Given the Student is created (<StudentId>, <FirstName>, <LastName>, <Mail>, <PhoneNumber>, <AccountId>, <CareerId>, <CycleNumber>)
#	And the lesson is created (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)

#Background: 
#	Given the Student is created ("1", "Brigitte", "Mendez", "bri@upc.pe", "998956565", "1", "1", "5")
#	And the lesson is created ("1", "4", "1st lesson", "3", "2", "1")


@mytag
Scenario: Student signs up for a lesson
	Given the Student is created (<StudentId>, <FirstName>, <LastName>, <Mail>, <PhoneNumber>, <AccountId>, <CareerId>, <CycleNumber>)
	And the lesson is created (<LessonId>, <ScheduleId>, <Description>, <TutorId>, <LessonTypeId>, <CourseId>)
	When the student signs up for the first time for this lesson <text>
	Then what returns should be <response>


#@secondtag
#Scenario: Student signs up for the same lesson
#	When the student signs up for the second time for this lesson
#	Then the returned result should be "You are already part of this lesson"

Examples:
| StudentId | FirstName | LastName | Mail     | PhoneNumber | AccountId | CareerId | CycleNumber | LessonId | ScheduleId | Description | TutorId | LessonTypeId | CourseId | response |text|
| 1         | Brigitte  | Mendez   | m@com.pe | 4589        | 1         | 1        | 5           | 1        | 4          | 1st Lesson  | 1       | 1            | 1        | True     |text|

