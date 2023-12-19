# Project-S14

## Prerequisites

Before you begin, ensure you have met the following requirements:
* You have installed the latest version of [PostgreSQL](https://www.postgresql.org/download/).
* You have a Windows/Linux/Mac machine.
* You have installed the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

## Cloning the Repository

To clone the Visual Studio Solution from the repository, run the following command in your terminal or command prompt:

```bash
git clone https://github.com/Initial-Dev/Project-S14.git
```

## Setting Up the Database

* Install PostgreSQL following the official guide provided by PostgreSQL.
* Import the database dump from the repository:

```bash
psql -f dump.sql
```

Or import from pgAdmin.

## Building the Application

Navigate to the solution directory where the `.sln` file is located and run the following command to restore any depedencies and build the project:

```bash
dotnet restore
dotnet build
```

or Launch the solution in Visual Studio and build

## Running the Application

Run the following command to launch the application

```bash
dotnet run --project path_to_project_folder
```

Or Launch from Visual Studio

## Accessing the Application

Once the application is running you can access the different parts of the application using following URLs :

* API: `https://localhost:7075/api/`
* Swagger Doc: `https://localhost:7075/swagger/index.html`
* WebApplication: `https://localhost:7216/`

## Navigating the UI

* Once the application is started navigate to the application url in your web browser
* Use the Classes menu to navigate. On this page you will see the list of classes as well as other listing
* By clicking on any class you will get a list of students
* Click on "See Grades" in the Action column to see the grades of a student (BROKEN*)
* From the main menu click on any of the 2 listings to get a detailed listing of both students and teachers.

\* Deserialization issues because of loop references in the data. Fix not found atm.
## Other Features

* Add/Modify/Delete Grades (API Ready - Not implemented)
* Add a Student to a Class (API Ready - Not implemented)
* Add comments to Students by Subject (Not considered)
