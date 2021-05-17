# About TimeKeeper
TimeKeeper is a time keeping application built using [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)

The purpose of the application is to provide a learning resource including how the below elements are handled within a Blazor project.

* Application State Management
* Authentication and authorization
* Blazor Client Side (WASM) or Server Side
* Database Model
* Dependency Injection
* Documentation
* Hosting and Continuous Integration/Deployment (CI/CD)
* Logging
* ORM Selection
* Project Architecture
* Testing
* User Stories

We are hoping to make the project accessible to all levels of developer and anyone is welcome to contribute to the project.

The project was started by members of the Practial ASP.NET community run by Jon Hilton and we would encourage you to check out his [blog](https://jonhilton.net/) and [courses](https://practicaldotnet.io/) and in particular [Blazor By Example](https://practicaldotnet.io/c/BlazorByExample).

The project is currently in it's infancy and you can check out the current [discussions](https://github.com/BlazingSaddlesSolutions/TimeKeeper/discussions) and [issues](https://github.com/BlazingSaddlesSolutions/TimeKeeper/issues) to see the areas we are currently tackling.

To drive the requirements of the application we created a fictional scenario which can be viewed in our [Wiki](https://github.com/BlazingSaddlesSolutions/TimeKeeper/wiki/Project-Scenario)

# Getting Started

### Clone the repository

See [GitHub Docs](https://docs.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository) for details on cloning repositories.

### Publish the database

In order to run the application you will need to create the TimeKeeper database on your local SQL Server or a SQL Server you have access to.

To do this publish the TimeKeeper.Database project by right cliking on TimeKeeper.Database within Visual Studio and select Publish.

You will be presented with the below screen.

![Publish](https://user-images.githubusercontent.com/52583820/118413586-016ae900-b698-11eb-99b3-25eb6178aaa2.png)

Select browse and choose the required SQL Server

![browse](https://user-images.githubusercontent.com/52583820/118413584-00d25280-b698-11eb-8e16-c5f0e4473797.png)

Enter TimeKeeper as the database name and click on Publish. Your database will now be created.

![Publish2](https://user-images.githubusercontent.com/52583820/118413582-00d25280-b698-11eb-84bd-071e114b39aa.png)

### Update Configuration Sections

Update the server name found within the DefaultConnection in the appsettings.json file of TimeKeeper.API



