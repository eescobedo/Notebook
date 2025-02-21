# CrudNotebook

## Description
CrudNotebook is a practice project that implements the basic CRUD (Create, Read, Update, Delete) operations to manage contacts. This project is developed using Razor Pages in .NET 6.

## Main Features
- List all contacts stored in the database.
- Create a new contact.
- Edit an existing contact.
- Delete a contact.
- Connect to the database using a connection string.
- Execute stored procedures for CRUD operations.

## Installation Instructions
1. Clone the repository to your local machine.
2. Make sure you have a database configured. The database structure should match the `ModelContact` model:

```csharp

    public class ModelContact { 
        public int IdContact { get; set; }
        
        [Required(ErrorMessage = "The field Name is required!")]
        public string? Name { get; set; }
        
        [Required (ErrorMessage = "The field Phone is required!")]
        public string? Phone { get; set; }
        
        [Required (ErrorMessage="The field Email is required!")]
        public string? Email { get; set; }
}
```

3. Configure the connection string in the `appsettings.json` file or in the `Connection` class to point to your database.
4. Execute the necessary stored procedures in your database:
    - `SP_LIST`
    - `SP_GET`
    - `SP_SAVE`
    - `SP_EDIT`
    - `SP_DELETE`
5. Open the project in Visual Studio 2022 and run the application.

## Dependencies
- .NET 6
- SQL Server (or any database compatible with ADO.NET)
- Visual Studio 2022

## Usage
Once the application is running, you can access the following routes to manage contacts:
- `/Maintenance/ListContacts` - List all contacts.
- `/Maintenance/Save` - Create a new contact.
- `/Maintenance/Edit/{IdContact}` - Edit an existing contact.
- `/Maintenance/Delete/{IdContact}` - Delete a contact.

## Contributions
Contributions are welcome. Please open an issue or a pull request to discuss any changes you would like to make.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
