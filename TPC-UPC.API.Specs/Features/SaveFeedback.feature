Feature: SaveFeedback
	Simple calculator for adding two numbers

@mytag
Scenario: Do not select number of stars
	Given that the lesson has ended and the student must give a grade for that lesson(<LessonId>, <StudentId>)
	When the student sends unmarked number of stars(<SameLessonId>, <SameStudentId>, <Qualification>, <Comment>, <Complaint>)
	Then the message that returns should be<response>

Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | Qualification | Comment | Complaint | response                                  |
| 1        | 1         | 1            | 1             | 0             | -       | false     | It’s necessary to assign number of starts |

@mytag
Scenario: Rate the tutor by stars
	Given that the lesson has ended and the student must give a grade for that lesson(<LessonId>, <StudentId>)
	When the student sends the number of stars(<SameLessonId>, <SameStudentId>, <Qualification>, <Comment>, <Complaint>)
	Then the system should return<response>

Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | Qualification | Comment | Complaint | response |
| 1        | 1         | 1            | 1             | 1             | -       | false     | True     |

@mytag
Scenario: Send a comment about the lesson attended
	Given that the student wants to send a comment about the lesson attended(<LessonId>, <StudentId>)
	When fills in the information he wants to leave as a comment(<SameLessonId>, <SameStudentId>, <Qualification>, <Comment>, <Complaint>)
	Then the system should return<response>

Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | Qualification | Comment     | Complaint | response |
| 1        | 1         | 1            | 1             | 1             | Good class! | false     | True     |

@mytag
Scenario: Send a complaint about the lesson attended
	Given that the student wants to send a complaint about the lesson attended(<LessonId>, <StudentId>)
	When fills in the information he wants to leave as a complaint and identifies it as a complaint(<SameLessonId>, <SameStudentId>, <Qualification>, <Comment>, <Complaint>)
	Then the system should return<response>

Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | Qualification | Comment    | Complaint | response |
| 1        | 1         | 1            | 1             | 1             | Bad class! | true      | True     |


