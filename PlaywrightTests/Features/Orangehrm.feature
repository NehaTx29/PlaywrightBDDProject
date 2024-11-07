Feature: Login and Apply for Leave

  Scenario: User logs in successfully
    Given I am on the login page
    When I enter "Admin" , "admin123" and login
    And I click on Apply Leave
    Then I enter the details in the form and Apply
  
    