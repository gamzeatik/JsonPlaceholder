# RestfulAPI Project

This project is a RESTful API built using ASP.NET Core 6.0. 
It provides various endpoints for managing resources. 
The project is inspired by and closely models the API provided by [JSONPlaceholder](https://jsonplaceholder.typicode.com/), 
a free online REST API that you can use for testing and prototyping.

## Installation

### Prerequisites
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022
- SQL Server or another database supported by Entity Framework Core

### Steps
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/RestfulAPI.git
    cd RestfulAPI
    ```

2. Restore the dependencies:
    ```bash
    dotnet restore
    ```

3. Update the database connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "YourConnectionStringHere"
    }
    ```

4. Apply migrations and update the database:
    ```bash
    dotnet ef database update
    ```

5. Run the project:
    ```bash
    dotnet run
    ```
Swagger UI
This project includes Swagger UI for API documentation and testing. Once the application is running, 
you can access the Swagger UI by navigating to the following URL in your web browser:
https://localhost:7235/swagger/index.html


JSONPlaceholder
This project was inspired by the JSONPlaceholder API, 
a popular tool for developers to use when building and testing front-end or back-end applications. 
The endpoints and data models in this project are designed to closely resemble those of JSONPlaceholder, making it a useful local alternative for testing and development.

Official JSONPlaceholder API: https://jsonplaceholder.typicode.com/


## Usage
Once the application is running, you can use tools like [Postman](https://www.postman.com/) 
or [curl](https://curl.se/) to interact with the API.

### Example: Create a Post
```bash
curl -X POST "https://localhost:5001/api/posts" -H "Content-Type: application/json" -d '{
  "title": "Sample Post",
  "content": "This is a sample post.",
  "userId": 1
}'
