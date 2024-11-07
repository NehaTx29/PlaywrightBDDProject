Feature: Login and Apply for Leave

  Scenario: User logs in successfully
    Given I am on the login page
    When I enter "Admin" , "admin123" and login
    And I click on Apply Leave
    Then I enter the details in the form and Apply
    
    Feature: User is able to fill info
    Scenario: User logs in successfully
    And I click on My info
    Then I enter the details in the form and Save
    