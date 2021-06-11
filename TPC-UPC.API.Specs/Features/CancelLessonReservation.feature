Feature: CancelLessonReservation
	Simple calculator for adding two numbers

@mytag
Scenario: Cancel workshop reservation
Given a student exist(<StudentId>)
And a workshop lesson exist(<LessonId>)
And that the student have a reservation
When the student cancels the reservation before the allowed cancellation time(<SameLessonId>, <SameStudentId>)
Then the system deletes the reservation<response>
Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | response |
| 1        | 1         | 1            | 1             | True     |

@mytag
Scenario: Cancel tutoring reservation
Given a student exist(<StudentId>)
And a tutoring lesson exist(<LessonId>)
And that the student have a reservation
When the student cancels the reservation before the allowed cancellation time(<SameLessonId>, <SameStudentId>)
Then the system deletes the reservation<response>
Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | response |
| 2        | 1         | 2            | 1             | True     |

@mytag
Scenario: Cancel reservation returns error
Given a student exist(<StudentId>)
And a lesson exist(<LessonId>)
And that the student have a reservation
When the student tries to cancel his reservation after the allowed cancellation time(<SameLessonId>, <SameStudentId>)
Then the student displays an error message indicating that the cancellation was not completed due to time constraints<response>
Examples: 
| LessonId | StudentId | SameLessonId | SameStudentId | response                                       |
| 3        | 1         | 3            | 1             | The time to cancel the reservation has expired |
