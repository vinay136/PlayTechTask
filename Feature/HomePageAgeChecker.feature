Feature: HomePageAgeChecker
	Check Valid Age

@smoke
Scenario: Check User is having Legal age to continue in Website
	Given I launch the PlayTech Application
	And I select My Age
	    |Day|Month|Year|
	    |31|10|1980|
	And I Click on Enter Site CTA.
	Then I should See HomePage of PlayTech


Scenario: Check User is NOT having Legal age to continue in Website
	Given I launch the PlayTech Application
	And I select My Age
	    |Day|Month|Year|
	    |31|10|2020|
	And I Click on Enter Site CTA.
	Then I should Not See HomePage of PlayTech


