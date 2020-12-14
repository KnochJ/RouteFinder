# RouteFinder
## Jerry Knoch

RouteFinder is an web API which determines truck routes when given a three-letter code for trucks operating in North America. I developed the API in Visual Studio using .NET Core and I deployed to Azure. I created a controller that has an endpoint looking for a three-letter code entered at the end of the URL and determines the best route for the truck. The result is then constructed into a JSON object and returned as a response to the user.

To determine the best route, I developed my own Graph/Vertex classes and constructed a graph with each country as an individual vertex in the graph. With this graph, I also utilized breadth-first search to determine the best route from the starting country (USA) to the destination country (ranging from Canada down to Panama).

URL: https://jjkroutefinder.azurewebsites.net/RouteFinder/

#### Enter any of the following three-letter codes to the end of the URL:
CAN, USA, MEX, BLZ, GTM, SLV, HND, NIC, CRI, PAN

#### Example:
 (...).net/RouteFinder/PAN    will return -> {"destination":"PAN","list":["USA","MEX","GTM","HND","NIC","CRI","PAN"]}

### Assumptions: 
The user can enter in the three-letter code in either lowercase, uppercase, or any combination of the two. The API will determine the correct code and determine the route to that
country.
USA is always the starting point in the route.
Edge weights between vertices are all equal.
If a three-letter code is input and not in the graph, a 404 Not Found is returned.

### Resources:
Utilized Stack Overflow, GeeksForGeeks, and Microsoft .NET Core/Azure documentation.
