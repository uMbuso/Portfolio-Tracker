## Project Description

### **Portfolio Tracker API**

The **Portfolio Tracker API** is a clean and scalable ASP.NET Core Web API designed for managing investment portfolios across multiple asset types, including crypto, stocks, and commodities. It uses a 3-layer architecture (Controllers → Services → Repositories) with Entity Framework Core for data access and JWT authentication for secure user management.

Users can register, log in, add investments, record buy/sell transactions, and view portfolio summaries with allocation insights. The API is fully asynchronous, supports CORS for Angular (PrimeNG) dashboards, and includes secure password hashing, relational models, and RESTful endpoints.

This backend serves as the foundation for a modern investment dashboard, offering high maintainability, testability, and room for future expansion such as live pricing, analytics, and multi-currency support.

* * *

## Key Features

Here are **short, clean, punchy key features** for your Portfolio Tracker API:

* * *

### **Key Features**

*   **JWT Authentication** — Secure user registration, login, and protected API access.
*   **Investment Management** — Create, update, and delete investments across crypto, stocks, and other assets.
*   **Transaction Tracking** — Record buy/sell operations with full historical logs.
*   **Portfolio Summary** — View allocation percentages, total value, and asset grouping insights.
*   **3-Layer Architecture** — Controllers, Services, and Repositories for clean, maintainable code.
*   **Entity Framework Core** — Full relational mapping with SQL Server or SQLite support.
*   **Async Codebase** — Fully asynchronous operations for scalability and performance.
*   **Password Hashing** — Built-in SHA256 secure hashing for user credentials.
*   **CORS Support** — Ready for Angular/PrimeNG frontend integration.
*   **RESTful API Endpoints** — Clean and consistent resource-based routes.

* * *

## Tech Stack

**Backend Framework:**

*   ASP.NET Core 6.0+

**Database:**

*   SQL Server (LocalDB or full instance)
*   SQLite (optional lightweight mode)

**ORM:**

*   Entity Framework Core

**Authentication:**

*   JSON Web Tokens (JWT)

**Architecture:**

*   3-Layer Architecture (Controllers → Services → Repositories)

**Languages & Tools:**

*   C#
*   LINQ
*   EF Core Migrations
*   Dependency Injection (built-in)

**API Style:**

*   RESTful API
*   Swagger (optional)

**Frontend Target:**

*   Angular + PrimeNG Dashboard (future integration)

* * *
