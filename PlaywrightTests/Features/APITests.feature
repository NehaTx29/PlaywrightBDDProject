Feature: API Tests

 @APItests @1 
 Scenario Outline: Retrieve information from the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users/7623251"
  When I send a GET request to the endpoint
  Then I should receive a response with status code 200
  Then the JSON path "id" should have value "7623251"


 @APItests @2
 Scenario Outline: POST new data to the endpoint with authentication
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users"
  When I send a POST request with access token in the header and "Jane Smith" "jane.smith@exampletesting.com" "male" "active" to the endpoint
  Then I should receive a response with status code 201
  Then the JSON path "name" should have value "Jane Smith"
  Then the JSON path "email" should have value "jane.smith@exampletesting.com"
  Then the JSON path "gender" should have value "male"
  Then the JSON path "status" should have value "active"


 @APItests @3
 Scenario Outline: PUT new data to the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users/7623260"
  When I send a PUT request with access token in the header and "Alex" "alex.johnson@example.com" "male" "active" to the endpoint
  Then I should receive a response with status code 200
  Then the JSON path "name" should have value "Alex"
  Then the JSON path "email" should have value "alex.johnson@example.com"
  Then the JSON path "gender" should have value "male"
  Then the JSON path "status" should have value "active"


 @APItests @4
 Scenario Outline: DELETE data from the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users/7623249"
  When I send a DELETE request with access token in the header and "sen_bhattathiri_ambar@kris.example" to the endpoint
  Then I should receive a response with status code 204


 @APItests @5
 Scenario Outline: Create new post to the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users/7625110/posts"
  When I send a CREATE POST request with access token in the header and "Arto arceo tutis error custodia pecunia adaugeo totidem." "Quo curso candidus. Stabilis curriculum calcar. Voluptatum aegre defaeco. Sit fugiat cerno. Nemo sordeo socius. Reprehenderit facere coma. Depraedor solutio subito. Astrum alias dedico. Tepesco ter tremo. Cribro dolorem et. Sint vester corrigo. Aestivus decretum nemo. Dolore vitae cattus. Deorsum curto vel. Cotidie tollo usque." to the endpoint
  Then I should receive a response with status code 201
  Then the JSON path "title" should have value "Arto arceo tutis error custodia pecunia adaugeo totidem."
  Then the JSON path "body" should have value "Quo curso candidus. Stabilis curriculum calcar. Voluptatum aegre defaeco. Sit fugiat cerno. Nemo sordeo socius. Reprehenderit facere coma. Depraedor solutio subito. Astrum alias dedico. Tepesco ter tremo. Cribro dolorem et. Sint vester corrigo. Aestivus decretum nemo. Dolore vitae cattus. Deorsum curto vel. Cotidie tollo usque."


 @APItests @6
 Scenario Outline: Create new todo to the endpoint
  Given The API endpoint has baseURI "https://gorest.co.in" and basePath "/public/v2/users/7623260/todos"
  When I send a CREATE TODO request with access token in the header and "This is a new todo." "completed" to the endpoint
  Then I should receive a response with status code 201
  Then the JSON path "title" should have value "This is a new todo."
  Then the JSON path "status" should have value "completed"

