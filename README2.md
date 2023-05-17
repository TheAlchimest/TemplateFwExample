# TemplateFw Web App Documentation

## Project Overview
TemplateFw is a .NET Core web application that serves as a foundation for building web applications using a template-based approach. It provides a set of common features and functionality to kickstart the development process.

## Architecture
The web app follows a layered architecture pattern with the following layers:

1. **Presentation Layer**:
   - The `TemplateFw.Web` project contains the presentation layer components.
   - It includes controllers, views, and static assets used for rendering web pages.

2. **Business Logic Layer**:
   - The `TemplateFw.Core` project contains the business logic layer.
   - It includes services, models, and utilities used for implementing the application's core functionality.

3. **Data Access Layer**:
   - The `TemplateFw.Data` project contains the data access layer components.
   - It includes repositories, database contexts, and entity models used for interacting with the underlying data store.

## Installation and Setup
To set up the web app locally, follow these steps:

1. **Clone the repository**:

2. **Install the .NET Core SDK**:
- Ensure that you have the .NET Core SDK installed. If not, download and install it from the official .NET Core website.

3. **Restore Dependencies**:
- Open a terminal or command prompt and navigate to the `TemplateFw` directory.
- Run the following command to restore the project dependencies:
  ```
  dotnet restore
  ```

4. **Configure the Database Connection**:
- Open the `appsettings.json` file in the `TemplateFw.Web` project.
- Update the `DefaultConnection` connection string to point to your desired database server.

5. **Run the Application**:
- In the terminal or command prompt, run the following command to start the web app:
  ```
  dotnet run --project TemplateFw.Web
  ```

6. **Access the Web App**:
- Open a web browser and navigate to `http://localhost:5000` to access the running web app.

## Project Structure
The project structure of the repository is as follows:

- `TemplateFw.Web`: Contains the web application's presentation layer components.
- `TemplateFw.Core`: Contains the business logic layer components.
- `TemplateFw.Data`: Contains the data access layer components.
- `TemplateFw.Tests`: Contains unit tests for the application.
- `TemplateFw.sln`: The solution file that includes all the projects.

## Dependencies
The web app relies on the following dependencies:

- ASP.NET Core
- Entity Framework Core
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Logging
- Newtonsoft.Json
