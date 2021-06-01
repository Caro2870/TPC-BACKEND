Feature: ModifyPersonalInfo
![ModifyPersonalInfo](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple test for updating the info of a tutor

Link to a feature: [ModifyPersonalInfo](TPC-UPC.API.Specs/Features/ModifyPersonalInfo.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Update or check personal info
	Given I create a new Tutor (<Id>, <FirstName>, <LastName>, <Mail>, <PhoneNumber>, <AccountId>, <FacultyId>)
	When I Update the info of this Tutor (<SameId>,<NewFirstName>, <NewLastName>, <NewPhoneNumber>)
	Then the updated Info should return <response>
Examples: 
| Id | FirstName | LastName | Mail         | PhoneNumber | AccountId | FacultyId | SameId | NewFirstName | NewLastName | NewPhoneNumber | response |
| 1  | Renzo     | Diaz     | renzo@upc.pe | 998654846   | 1         | 1         |    1   | Alvaro       | Torres      | 992585684      | True     |
