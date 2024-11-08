Feature: Verify Order functionality


  Scenario: Test to verify when clicking on Orders page as signed in user, earlier past months or past years orders listed
    Given I navigate to the AI Engine url "http://3.94.149.173:9090/"
    Then I click on Login option
    When I enter email "jane@testingxperts.com" and password "123456" on AI engine 
    Then I should see the homepage after successful login
    When I click on Your Orders option from Account and Lists dropdown
    Then I should see the orders page



