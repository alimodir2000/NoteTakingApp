.NET Note Taking Application

This project applies principles of Clean Architecture to provide solution for note taking app. It uses following technologies:

- ASP.NET Core 7
- Entity Framework Core 7
- MediatR
- AutoMapper
- FluentValidation
- XUnit, NUnit, FluentAssertions and Moq 
#
# Getting Started
In order to test the app simply run the Presentation.Web.App project. It is a MVC web application, that shown all requested functionalities. You can easily create a note by double clicking on the screen. Each note consists of a header and a body. You can also update and delete note as well. 
# Overview
## Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer. There are two main entities for this project: Note and Notebook. Each note can be store in one notebook. And notebooks consists of many notes. 
## Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. The important issue here is, application uses abstraction to implement the logic of the application. For instance the repository interfaces defined here, however their implementation defined in the Infrastructure.
Application has 3 main features: Common, Notebook and Note. CQRS applied, with MediatR, to implement required commands and queries.
### Notes
This folder, presents all required features for note. it consists of two sub folders that presents commands and queries.
#
### Notebooks
CQRS commands and quries related to the notebook are presented in this sections

All validations defined here in this layer. 
## Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.
## Presentation 
There are two presentations for this project.  One is web api and the other is web app. 
