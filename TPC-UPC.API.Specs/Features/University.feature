Feature: University
![University](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple test for adding a university

Link to a feature: [University](TPC-UPC.API.Specs/Features/University.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add University
	Given  I  create  a  new  University  (<Id>, <UniversityName>)
	Then  the  system  should  return  <responseCode>

Examples: 
| Id | UniversityName | responseCode |
|  1 | USMP           | True         |