Feature: CancelLessonReservation
	Simple calculator for adding two numbers

@mytag
Scenario: Cancel workshop reservation
Given that the student wants to cancel reservation(<LessonId>, <StudentId>)
When the student cancels the reservation before the allowed cancellation time(<SameLessonId>, <SameStudentId>)
Then the system deletes the reservation<response>
Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | response |
| 1        | 1         | 1            | 1             | True     |

@mytag
Scenario: Cancel tutoring reservation
Given that the student wants to cancel reservation(<LessonId>, <StudentId>)
When the student cancels the reservation before the allowed cancellation time(<SameLessonId>, <SameStudentId>)
Then the system deletes the reservation<response>
Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | response |
| 1        | 1         | 1            | 1             | True     |

@mytag
Scenario: Cancel reservation returns error
Given that the student wants to cancel reservation late(<LessonId>, <StudentId>)
When the student tries to cancel his reservation after the allowed cancellation time(<SameLessonId>, <SameStudentId>)
Then the student displays an error message indicating that the cancellation was not completed due to time constraints<response>
Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | response                                       |
| 1        | 1         | 1            | 1             | The time to cancel the reservation has expired |
