*Project: RESTful API for Task Management*

Project Overview

Create a RESTful API that serves as the backend for a task management application. This project will let trainees develop API endpoints to handle tasks, users, and categories. They’ll gain experience with ASP.NET Core Web API, Entity Framework Core, and learn to structure a multi-functional API.
Features and Endpoints

User Management
Register User: An endpoint for user registration.
Authenticate User: An endpoint for logging in and generating JWT tokens.
Get User Profile: Fetch user profile data using a secure endpoint with JWT.

Task Management
Create Task: Allow users to add new tasks.
Get Tasks: Retrieve a list of tasks with optional filters (e.g., by status, category, or due date).
Get Task by ID: Fetch a specific task by its ID.
Update Task: Update the details of an existing task.
Delete Task: Remove a task by its ID.

Task Categorization
Add Category: Create a new category for organizing tasks.
Get Categories: Retrieve all categories associated with the user.
Update Category: Edit the name or description of a category.
Delete Category: Remove a category and its association with tasks.
Task Completion Status
Mark Task as Complete/Incomplete: Toggle the completion status of a task.
Task Prioritization
Prioritize Tasks: Sort tasks by priority (e.g., High, Medium, Low) and retrieve them accordingly.

Technical Requirements
ASP.NET Core Web API: Use ASP.NET Core Web API controllers to create and structure endpoints.
Entity Framework Core: Implement data storage with a SQL Server or SQLite database.
Authentication & Authorization: Secure the API with JWT tokens for protected routes.
Data Validation: Use model validation to ensure data integrity.
Error Handling: Implement structured error responses (e.g., HTTP 400 for bad requests, HTTP 404 for not found).
API Structure
AuthenticationController
POST /api/auth/register: Register a new user.
POST /api/auth/login: Authenticate a user and issue a JWT token.
TasksController
POST /api/tasks: Create a new task.
GET /api/tasks: Get all tasks, with optional query parameters for filtering.
GET /api/tasks/{id}: Get details of a specific task.
PUT /api/tasks/{id}: Update an existing task.
DELETE /api/tasks/{id}: Delete a task by its ID.
CategoriesController
POST /api/categories: Create a new category.
GET /api/categories: Retrieve all categories.
PUT /api/categories/{id}: Update a specific category.
DELETE /api/categories/{id}: Delete a category.