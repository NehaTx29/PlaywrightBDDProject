Feature: Verify Home Page Functionality

Scenario: User should be able to see all options from All dropdown
    Given I navigate to Tx website "http://3.94.149.173:9090/"
    When I click on Login Button
    Then I should see the Login Page
    When I login using email "noorsre@gmail.com" and password "12345678"
    Then I should see Homepage
    When I scroll down & click on All dropdown 
    Then I should see all the products in the dropdown
