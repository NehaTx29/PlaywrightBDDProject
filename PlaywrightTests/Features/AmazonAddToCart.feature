Feature: Amazon Add to Cart
    As an online shopper
    I want to add a product to my Amazon cart
    So that I can validate the product is successfully added to the cart

Scenario: Add a product to Amazon cart and validate in cart
    Given I am on the Amazon homepage
    When I search for "laptop"
    And I select the first product from the search results
    And I add the product to the cart
    Then I should see the product in the cart
