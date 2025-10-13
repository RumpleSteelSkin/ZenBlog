# ZenBlog

[![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4.svg?logo=dotnet)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
[![Angular Version](https://img.shields.io/badge/Angular-20-DD0031.svg?logo=angular)](https://angular.io/)

## 📝 About The Project

This project is a full-featured Blog Management System (CMS) developed using modern software architectures and design patterns. It is built upon **Clean Architecture**, **Domain-Driven Design (DDD)**, and **CQRS** principles. Its goal is to combine a scalable, testable, and maintainable backend infrastructure with a rich user experience provided by a sophisticated frontend application.

## 🚀 Key Features

### General
* **Comprehensive CRUD Operations:** Full management capabilities for Blogs, Categories, Comments, Contact Information, and Social Media Links.
* **JWT-Based Authorization:** Secure access for all sensitive API endpoints using JWT Bearer tokens.
* **Flexible Frontend:** Separate layouts for Admin and Public user interfaces, designed with responsiveness in mind.
* **Enhanced UX:** Utilizes notifications (`Alertify`, `SweetAlert`), animations (`AOS`), and a slider (`Swiper`) for a dynamic user experience.

### Backend (API)
* **CQRS & Mediator:** Separation of concerns for business logic and data retrieval through Commands and Queries using `MediatR`.
* **Fluent Validation:** Robust and clean implementation of business rules for data integrity.
* **Pipeline Behavior:** Centralized validation error handling for all requests.
* **Database:** MSSQL with Entity Framework Core using a Code-First approach.

### Frontend (Angular)
* **Reusability:** Implementation of a `BaseService` to abstract common API interaction logic.
* **Security:** An HTTP Interceptor automatically attaches the JWT token to request headers for authenticated calls.
* **Detailed Error Handling:** Proper and understandable display of API-originated error messages to the user.

## ⚙️ Technologies Used

| Category | Technology | Description |
| :--- | :--- | :--- |
| **Architecture** | Clean Architecture, Monolith | Layered and clean code structure for maintainability. |
| **Design Patterns** | CQRS, DDD, Mediator, Repository, Unit of Work | Fundamental patterns for managing business logic and data flow. |
| **Backend** | .NET 9, C# | Robust and high-performance API development. |
| **Database** | MSSQL, EF Core | Relational database management and Object-Relational Mapping. |
| **Security** | JWT, Bearer, CORS | Authentication, authorization, and cross-origin resource sharing management. |
| **Frontend** | Angular 20, TypeScript, HTML, CSS | Modern, component-based user interface framework. |
| **UI/Styling** | Bootstrap 5.3, Bootstrap Icons | Responsive design and rapid styling. |
| **Libraries (BE)** | MediatR, FluentValidation, AutoMapper | Command/Query management, validation, and object mapping. |
| **Libraries (FE)** | Alertify, SweetAlert2, Swiper, AOS, @auth0/angular-jwt | Notifications, animations, slider management, and JWT helper services. |
| **Development Tools**| Postman, Scalar | API testing and comprehensive API documentation. |

## 👤 Contributors

* RumpleSteelSkin - Developer

---
