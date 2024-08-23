# Ticketing System

This project is a comprehensive ticket management system built with a focus on applying CQRS (Command Query Responsibility Segregation) and Domain-Driven Design (DDD) principles. It also incorporates several key features to ensure robust functionality:

### Key Features
- **CQRS and DDD**: Clear separation of commands and queries with a well-structured domain layer.
- **Background Job Scheduling**: Seamlessly integrated with Hangfire for job management.
- **Global Exception Handling Middleware**: Centralized error handling for consistent API responses.
- **Base Repository and Unit of Work Patterns**: Efficient data access and transaction management.

### Technologies Used
- **Hangfire**: Background job processing and scheduling.
- **MediatR**: Implementation of CQRS with clean separation of concerns.
- **Entity Framework Core**: Data access and ORM.

### Setup and Configuration
Ensure that the required database exists for Hangfire. If recurring jobs face issues, manually create the database if it is missing.

---
