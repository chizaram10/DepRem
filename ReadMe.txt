# Project Setup and Configuration

## Prerequisites

- .NET 6 SDK
- SQL Server

## Setup Instructions

1. Clone the Repository

    ```
    git clone https://github.com/chizaram10/DepRem.git
    ```

2. Update Connection String

    Update the connection string in `appsettings.json` to point to your SQL Server instance. The `appsettings.json` file is located in the root of the project.
    ```

3. Run Migrations

    Run an update database command to create the database and tables using already existing migrations.
    ```

4. Run the Application

    Run the application using the following command:

    ```
    dotnet run

## Additional Notes

- Ensure your SQL Server is running and accessible.
- Make sure to use the correct SQL Server credentials in the connection string.

## Troubleshooting

If you encounter any issues, ensure that:

- Your connection string is correctly configured.
- SQL Server is running and accessible.
- You have run the `dotnet ef database update` command to apply migrations.
- You have the necessary .NET SDK installed.


