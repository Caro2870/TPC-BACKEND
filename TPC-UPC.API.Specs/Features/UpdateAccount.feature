Feature: UpdateAccount
	Simple calculator for adding two numbers

@mytag
Scenario: Update Password Account
	Given I create a new Account(<Id>, <AccountName>, <Password>, <UniversityId>)
	When I update the password of this Account(<SameId>, <SameAccountName>, <NewPassword>, <SameUniversityId>)
	Then the system update the password<response>

Examples: 
| Id | AccountName | Password | UniversityId | SameId | SameAccountName | NewPassword | SameUniversityId | response |
| 1  | 201913771   | 123456   | 101          | 1      | 201913771       | 654321      | 101              | True     |

@mytag
Scenario: Update Account returns error
	Given I create a new Account(<Id>, <AccountName>, <Password>, <UniversityId>)
	When I don't update the password of this Account(<SameId>, <SameAccountName>, <SamePassword>, <SameUniversityId>)
	Then the error message that returns should be<response>

Examples: 
| Id | AccountName | Password | UniversityId | SameId | SameAccountName | SamePassword | SameUniversityId | response                                                              |
| 1  | 201913771   | 123456   | 101          | 1      | 201913771       | 123456       | 101              | You have entered your current password. Please enter a different one. |