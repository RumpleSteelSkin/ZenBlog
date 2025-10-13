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

<img width="1897" height="1018" alt="Screenshot 2025-10-13 201017" src="https://github.com/user-attachments/assets/3eabc428-11c8-4693-adb1-c391b232dbdc" />
<img width="1899" height="947" alt="Screenshot 2025-10-13 201125" src="https://github.com/user-attachments/assets/b34e8647-e50f-4038-b66b-f025662dcd0b" />
<img width="912" height="916" alt="Screenshot 2025-10-13 201301" src="https://github.com/user-attachments/assets/08e70f84-9bc8-42f2-836b-31ba11062f3a" />
<img width="1912" height="989" alt="Screenshot 2025-10-13 201330" src="https://github.com/user-attachments/assets/e48da949-d6ce-4c00-9e9b-fe2903951bf3" />
<img width="1910" height="983" alt="Screenshot 2025-10-13 201409" src="https://github.com/user-attachments/assets/3b730c09-f568-4a36-b130-06398b1fc8bd" />
<img width="1901" height="994" alt="Screenshot 2025-10-13 201455" src="https://github.com/user-attachments/assets/5d92c330-d65d-48a1-9ecd-6ce8375ffcf1" />
<img width="1909" height="985" alt="Screenshot 2025-10-13 201658" src="https://github.com/user-attachments/assets/dbbabd1f-bd54-46ad-a44c-f358b5290189" />
<img width="1910" height="1037" alt="Screenshot 2025-10-13 201930" src="https://github.com/user-attachments/assets/96cb8e50-78ba-4d85-9aa4-2585b5697f55" />

---
