# Orders Manager API

This is a Web API project beta version for managing user's orders, giving the users an easy and standard way to create orders,
add, update or remove items from the order, clear all items and delete order.

## Getting Started

After you clone or download the code from the repository all you have to do is just build the solution, and run it over IIS Express.

### Prerequisites
.Net Core

### Assumptions

* User Management Module is assumed to be isolated in an Identity Server or IAM Service.
* It is supposed to have some stored Items in our database
* As per the requirements the checkout functionality will be the responsibility of another team,
        and therefore this API has been developed with Domain Events in case you would like to listen to some certain events
        that you might be interested in like(ItemAdded, OrderCreated, and so on ...)

### Technologies and Patterns Used

* .Net Core
* Domain - Driven Design
* Domain Events
* Dependency Injection
* SOLID Principles
* TDD and BDD
* Unit of work and Repository Patterns
* Web API
* Specification Pattern
* Swagger Documentation


### Web API documentation

In case you want to start creating a client for Orders Manager API you will find Swagger Documentation in the following URL:

```
http://localhost:58483/swagger/
```

## Running the tests

You will find the Unit Tests are categorized by modules such as (Controllers Tests, Service Tests, Domain Tests and Repository Tests)

