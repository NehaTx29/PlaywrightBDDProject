Feature: Verify Add to Wishlist functionality

Scenario: Test to check if user is able to create a wishlist from the products detail page
    Given I navigate to Tx website "http://3.94.149.173:9090/" Wishlist section
    When I click on Login button Wishlist section
    Then I should see the Login Page Wishlist section
    When I login using email "jane@testingxperts.com" and password "123456" Wishlist section
    Then I should see Homepage Wishlist section
    When I click on first product
    When I scroll and click on Add To Wishlist
    When I click on Your Wishlist option from Account and Lists dropdown
    Then I should see the product in wishlist page
