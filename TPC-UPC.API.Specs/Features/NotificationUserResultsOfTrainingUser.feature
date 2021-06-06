Feature: NotificationUserResultsOfTrainingUser
	A coordinator create a training for tutors (users), so a notification is send to the tutor.

@mytag
Scenario: Coordinator create a training for tutors and the system automatically send a notification to them
	Given a session of training is created <TrainingId>
	When I add a tutor for the training (<FirstTutorId>, <FirstTutorName>)
	Then the system send notification for each tutor selected (<NotificationId>, <NotificationDescription>)

	Examples:
| TrainingId | FirstTutorId | FirstTutorName | NotificationId | NotificationDescription          |
| 1          | 101          | Piero          | 903            | Aviso enviado por el coordinador |
| 2          | 101          | Piero          | 903            | Aviso enviado por el coordinador |
| 3          | 102          | Julian         | 903            | Aviso enviado por el coordinador |