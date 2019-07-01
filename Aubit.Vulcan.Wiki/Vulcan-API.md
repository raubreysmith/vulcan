Contextual information about the API service

## A guide to follow
https://code-maze.com/aspnetcore-webapi-best-practices/

### Startup Class and the Service Configuration
In the Startup class, there are two methods: the ConfigureServices method for registering the services and the Configure method for adding the middleware components to the application’s pipeline.

So, the best practice is to keep the ConfigureServices method clean and readable as much as possible. Of course, we need to write the code inside that method to register the services, but we can do that in more readable and maintainable way by using the Extension methods.

### Project Organization
We should always try to split our application into smaller projects. That way we are getting the best project organization and separation of concerns (SoC). The business logic related to our entities, contracts, accessing the database, logging messages or sending an email message should always be in a separate .NET Core Class Library project.

### Environment Based Settings
While we develop our application, that application is in the development environment. But as soon as we publish our application it is going to be in the production environment. Therefore having a separate configuration for each environment is always a good practice.

In .NET Core, this is very easy to accomplish. As soon as we create the project, we are going to get the `appsettings.json` file and when we expand it we are going to see the `appsetings.Development.json`

[Multiple Evnironments in .NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1)

### Data Access Layer
In many examples and different tutorials, we may see the DAL implemented inside the main project and instantiated in every controller. This is something we shouldn’t do.

When we work with DAL we should always create it as a separate service. This is very important in the .NET Core project because when we have DAL as a separate service we can register it inside the IOC (Inversion of Control) container. The IOC is the .NET Core’s built-in feature and by registering a DAL as a service inside the IOC we are able to use it in any controller by simple constructor injection

etc