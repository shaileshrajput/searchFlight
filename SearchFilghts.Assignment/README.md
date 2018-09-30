# searchFlight
This is a sample ASP.NET MVC 4 application to search flight Details. The project is named as "SearchFilghts.Assignment". It reads flight data from three different files having separator as comma & pipe. After reading data, application filters and sorts it & pass it to view.
Orgin & Destination both have validation of 3 characters.

This includes Model, View, Controller, Business Logic, Data Access, Provider & Unit Testing section(modules). 
The features used in this project are Routing,Data Annotation, Valiation,ViewBag, Dependancy Injection, Ineritance, Encapsulation, Abstraction, Anonymous method, Unit testing etc.
# Providers 
There are three provier can be use as source of data namely DBProvider1,DBProvider2,DBProvider3. These provider has been implemented by iterface IDataProvider. This is a decoupling of the provider hence we can add more provier in future for new clinets as and when require.
# Business Logic
This section is used to write the business login. This section has two clasess SearchFlightsRepo,SearchFlights. These classes are used to read,filter and sort data from varioud providers.  
# Data Access
This section handles the varios data source and fetches data from them. Classes used are IDataRepository,DataRepository.
# Controller 
searchFlightsController is used to search flights by passing paameter as Origin & estination 
sample url to test is "http://{localhost}/searchflights/YYZ/YYC"
InvalidRequestController is used to show the message while request is not as per requirement.
# View
There are two views, one is use to display the formatted flight list and another is used to display the message of Invalid request.

