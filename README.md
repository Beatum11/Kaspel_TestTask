# Kaspel Test Task

## Overview
This project is a test task for Kaspel. 
It represents a small book store where users can create orders and add various books to those orders. 
The project emphasizes the use of real-world development practices and tools, such as Entity Framework Core and AutoMapper.

## Features

### Book Management
- **Add Books**: Allows users to add new books to the inventory.
- **Update Books**: Users can edit the details of existing books.
- **Delete Books**: Removes books from the inventory.
- **List Books**: Provides a listing of all available books.

### Order Management
- **Create Orders**: Users can create new orders.
- **Update Orders**: Modify existing orders, including the addition or removal of books.
- **Delete Orders**: Removes orders from the system.
- **List Orders**: View all current orders.

### Filtering
- **Filter by Order Number**: Allows users to filter orders based on the order number.
- **Filter by Order Date**: Enables users to filter orders by the date of the order.

## Technologies Used
- **Entity Framework Core**: Used for data access, modeling, and ORM functionalities.
- **AutoMapper**: Utilized for mapping between the domain models and the Data Transfer Objects (DTOs).

## Getting Started

### Prerequisites
- .NET Core SDK
- A supported database engine (e.g., MSSQL)

### Installation
1. Clone the repository
   ```bash
   git clone https://github.com/Beatum11/Kaspel_TestTask.git
   ```
2. Navigate to the project directory
   ```bash
   cd Kaspel_TestTask
   ```
3. Restore the required packages
   ```bash
   dotnet restore
   ```
4. Run the application
   ```bash
   dotnet run
   ```

## Database Configuration
This application uses Entity Framework Core, and you can configure it to work with the desired database engine.

### Connecting to the Database
1. In the `appsettings.json` file, locate the connection string section:
   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Your_Connection_String_Here"
   }
   ```
2. Replace `Your_Connection_String_Here` with the actual connection string for your database.

### Migrations
Before running the application, apply the database migrations to create the database schema and update it:

```bash
add-migration Initial1
update-database
```

## Acknowledgments
Special thanks to Kaspel for providing this exciting opportunity to demonstrate the skills in .NET Core development.
