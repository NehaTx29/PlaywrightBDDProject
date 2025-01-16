Feature: API Tests

 @APItests @1 
 Scenario Outline: Retrieve information from the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath '/public/v2/users/' and ID '<ID>'
  When I send a GET request to the endpoint
  Then I should receive a response with status code 200
  Then the JSON path "id" should have value "<ID>"
  Examples: 
  | ID      |
  | 7636791 |


 @APItests @2
 Scenario Outline: POST new data to the endpoint with authentication
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users"
  When I send a POST request with access token in the header and "<Name>" "<Email>" "<Gender>" "<Status>" to the endpoint
  Then I should receive a response with status code 201
  Then the JSON path "name" should have value "<Name>"
  Then the JSON path "email" should have value "<Email>"
  Then the JSON path "gender" should have value "<Gender>"
  Then the JSON path "status" should have value "<Status>"
  Examples: 
  | Name       | Email               | Gender | Status |
  | Jane Smith | jane_Smith@test.com | male   | active |


 @APItests @3
 Scenario Outline: PUT new data to the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath '/public/v2/users/' and ID '<ID>'
  When I send a PUT request with access token in the header and "<Name>" "<Email>" "<Gender>" "<Status>" to the endpoint
  Then I should receive a response with status code 200
  Then the JSON path "name" should have value "<Name>"
  Then the JSON path "email" should have value "<Email>"
  Then the JSON path "gender" should have value "<Gender>"
  Then the JSON path "status" should have value "<Status>"
  Examples: 
  | ID      | Name  | Email             | Gender | Status |
  | 7636791 | kamal | kamal@example.com | male   | active |

   @APItests @4
 Scenario Outline: PATCH new Name and Gender to the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath '/public/v2/users/' and ID '<ID>'
  When I send a PATCH request with access token in the header and "<Name>" "<Gender>" to the endpoint
  Then I should receive a response with status code 200
  Then the JSON path "name" should have value "<Name>"
  Then the JSON path "email" should have value "<Email>"
  Then the JSON path "gender" should have value "<Gender>"
  Then the JSON path "status" should have value "<Status>"
  Examples: 
  | ID      | Name  | Email             | Gender | Status |
  | 7636791 | kane  | kamal@example.com | female   | active |

 @APItests @5
 Scenario Outline: DELETE data from the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath '/public/v2/users/' and ID '<ID>'
  When I send a DELETE request with access token in the header and "<ID>" to the endpoint
  Then I should receive a response with status code 204  
  Examples: 
  | ID      |
  | 7632167 |

 @APItests @6
 Scenario Outline: Create new post to the endpoint
  Given The API endpoint has baseURL "https://gorest.co.in" and basePath "/public/v2/users/" and ID "<ID>" and endpoint "/posts"
  When I send a CREATE POST request with access token in the header and "<Title>" "<Body>" to the endpoint
  Then I should receive a response with status code 201
  Then the JSON path "title" should have value "<Title>"
  Then the JSON path "body" should have value "<Body>"
  Examples: 
  | ID      | Title                           | Body                                                                              |
  | 7631899 | To create a new post for a user. | New post for the given user is created and unquie ID is assigned for the new post. |


 @APItests @7
 Scenario Outline: Create new todo to the endpoint
  Given The API endpoint has baseURL "https://gorest.co.in" and basePath "/public/v2/users/" and ID "<ID>" and endpoint "/todos"
  When I send a CREATE TODO request with access token in the header and "<Title>" "<Status>" to the endpoint
  Then I should receive a response with status code 201
  Then the JSON path "title" should have value "<Title>"
  Then the JSON path "status" should have value "<Status>"
  Examples: 
  | ID      | Title               | Status    |
  | 7631899 | This is a new todo. | completed |

