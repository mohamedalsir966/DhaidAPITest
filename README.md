
# Introduction  
Building microservice on .Net 6 for inspector and let the customer makes an appointment with the inspector.


Project Structere:
- ASP.NET Core Web API application
- REST API principles, CRUD operations
- SqlServer database
- CQRS and Mediator 
- Swagger Open API implementation
- Repository Pattern Implementation

## Whats Including In This Repository

#### CustomerPortal microservice which includes; 
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **SqlServer database** 
* Repository Pattern Implementation
* Swagger Open API implementation

#### Inspector microservice which includes; 
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **SqlServer database** 
* Repository Pattern Implementation
* Swagger Open API implementation

### Identity Server
* In order to get new token,you can make POST call to this URL (http://localhost:4004/connect/token) with flowing parameter
* client_id=customer
* client_secret=customersecret
* username=Alsir
* password=1234
* grant_type=password

#### API Gateway Ocelot Microservice
* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways

#### Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
	



## Run The Project
You will need to Rebuild Solution



# Getting Started You can **launch microservices** as below urls:

* **CustomerPortal API -> http://host.docker.internal:4001/swagger/index.html**
* **Inspector API -> http://host.docker.internal:4002/swagger/index.html**
* **Identity Server -> http://host.docker.internal:4004/swagger/index.html**
* **API Gateway -> http://host.docker.internal:4010**



