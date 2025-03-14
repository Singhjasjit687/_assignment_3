# Product API (Assignment 3)

A simple RESTful API built using ASP.NET Core to manage products in an inventory system. The API allows you to perform CRUD operations (Create, Read, Update, Delete) on products. It uses Entity Framework Core with SQL Server to persist the product data.

## Features
- Add new products.
- Retrieve a list of products.
- Update product details.
- Delete products.

## Technologies Used
- **ASP.NET Core 6.0** or higher
- **Entity Framework Core**
- **SQL Server** (or any relational database)
- **Swagger** for API documentation

## Prerequisites
Before running the application, make sure you have the following installed:
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any compatible IDE.
- .NET 6.0 SDK or higher: [Download here](https://dotnet.microsoft.com/download/dotnet).
- SQL Server or SQL Server Express (LocalDB).
- (Optional) Postman or Swagger UI for testing the API.

## Installation

### Clone the Repository
```bash
git clone https://github.com/yourusername/repository-name.git
cd repository-name
```

### Set Up the Database
1. Open `appsettings.json` and ensure that the connection string points to your local or remote SQL Server instance.
   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductsDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

2. Apply the migrations to create the database schema:
   ```bash
   dotnet ef database update
   ```

### Run the Application
You can run the application using the following command:
```bash
dotnet run
```
The application will start running on `http://localhost:5000` (or the port specified in the terminal). You can also open the Swagger UI at `http://localhost:5000/swagger` for interactive documentation.

### Testing the API
You can test the API using tools like Swagger UI (default provided) or Postman. Here are the API endpoints you can use:

- **POST /api/product** - Add a new product.
  - Request Body:
    ```json
    {
      "description": "Product Description",
      "image": "image_url.jpg",
      "price": 10.99,
      "shippingCost": 2.99
    }
    ```
  
- **GET /api/product** - Get all products.
  
- **GET /api/product/{id}** - Get product by ID.

- **PUT /api/product/{id}** - Update product by ID.
  
- **DELETE /api/product/{id}** - Delete product by ID.

## Database Schema
- **Products Table**:
  - `Id` (Primary Key, Auto Increment)
  - `Description` (VARCHAR)
  - `Image` (VARCHAR)
  - `Price` (DECIMAL)
  - `ShippingCost` (DECIMAL)

## Contributing
Feel free to fork this repository and submit pull requests. Contributions are always welcome!


## Postman Test Screenshot
![Screenshot (54)](https://github.com/user-attachments/assets/b0c481bf-8cdb-4b8f-9f5b-64eeefce054e)
![Screenshot (53)](https://github.com/user-attachments/assets/cf03e5c8-d1f1-4a34-a515-03335a38f1da)
![Screenshot (52)](https://github.com/user-attachments/assets/5433b339-a578-4219-9eef-37418bcb7ca0)
![Screenshot (55)](https://github.com/user-attachments/assets/1f6cb45e-c417-4c6b-beee-ffcf684428a7)
