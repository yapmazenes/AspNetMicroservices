# AspNetMicroservices
AspNetMicroservices Infrastructure for E-Commerce Application

![image](https://user-images.githubusercontent.com/43409805/179344150-acfe8fe6-062d-4283-b233-d4485489e01a.png)

## Whats Stack Including In This Repository
- .Net 5
- RabbitMq 
- MassTransit
- MongoDb
- Redis
- PostgreSQL
- Dapper
- MsSQL
- EntityFramework
- Grpc
- Ocelot

- Portainer.io
- Docker

#### Catalog microservice which includes; 
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **MongoDB database** connection and containerization
* Repository Pattern Implementation
* Swagger Open API implementation	

#### Basket microservice which includes;
* ASP.NET Web API application
* REST API principles, CRUD operations
* **Redis database** connection and containerization
* Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**
  
#### Discount microservice which includes;
* ASP.NET **Grpc Server** application
* Build a Highly Performant **inter-service gRPC Communication** with Basket Microservice
* Exposing Grpc Services with creating **Protobuf messages**
* Using **Dapper for micro-orm implementation** to simplify data access and ensure high performance
* **PostgreSQL database** connection and containerization

#### Microservices Communication
* Sync inter-service **gRPC Communication**
* Async Microservices Communication with **RabbitMQ Message-Broker Service**
* Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
* Using **MassTransit** for abstraction over RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices	
* Create **RabbitMQ EventBus.Messages library** and add references Microservices

#### Ordering Microservice
* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, FluentValidation and AutoMapper packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup
	
#### API Gateway Ocelot Microservice
* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways
* Run multiple different **API Gateway/BFF** container types	
* The Gateway aggregation pattern in Shopping.Aggregator

#### WebUI ShoppingApp Microservice
* ASP.NET Core Web Application with Bootstrap 4 and Razor template
* Call **Ocelot APIs with HttpClientFactory** and **Polly**

#### Ancillary Containers
* Use **Portainer** for Container lightweight management UI which allows you to easily manage your different Docker environments
* **pgAdmin PostgreSQL Tools** feature rich Open Source administration and development platform for PostgreSQL

#### Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables

## Installation & Setup
#### To start, run below command:
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```
#### To stop, run below command:
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
```

### Endpoints & Credentials
- Catalog Api = 8000
- Basket Api = 8001
- Discount Api = 8002
- Discount Grpc = 8003
- Ordering Api = 8004
- Shopping Aggregator = 8005
- Web Application = 8006
- Health Check Portal = 8007
- Ocelot Api Gateway = 8010
- MongoDB = 27017
- Redis = 6379
- pgAdmin4 = 5050 (yapmazenes@gmail.com / EnesYapmaz123)
- Kibana = 5601
- Portainer = 9000 (admin / Abcd123456789)
- Elasticsearch = 9200
- RabbitMQ = 15672 (guest / guest)

I Have implemented this base project from Microservices Architecture and Implementation on .NET 5 Course - [mehmetozkaya](https://github.com/mehmetozkaya)
