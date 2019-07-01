# About

This .NET solution aims to serve as a learning space for development and testing within the Microsoft ecosystem.

## Dependencies

- .NET Core SDK

## Intro to .NET Core

.NET is a free, cross-platform, open source developer platform for building many different types of applications. You can follow [Microsoft's guide](https://www.microsoft.com/net/learn/get-started/windows) to get up and running in 10 minutes

## Getting started

1. Clone this repo to your local machine via Git
2. Use `dotnet build` to download package dependencies and build the app
3. Switch to the API directory and build the SQLite db with Entity Framework using `dotnet ef database update`
4. Start the API service with `dotnet run`
5. Try the users endpoint in your browser: http://localhost:5000/api/users

```
[
    {
        "id": 1,
        "firstName": "Ross",
        "lastName": "Aubrey-Smith",
        "email": "ross.aubrey-smith@vulcan"
    },
    {
        "id": 2,
        "firstName": "Captain",
        "lastName": "Deadpool",
        "email": null
    }
]
```

6. To test the app, run the `dotnet test --no-build` command from the tests directory in a new terminal
7. You can rebuild the test project after updates while the API app is still running by using `dotnet build --no-dependencies`

## Entity framework

If you make changes to the model, you can use the `dotnet ef migrations add` command to scaffold a new migration. Once you have checked the scaffolded code (and made any required changes), you can use the `dotnet ef database update` command to apply the schema changes to the database.

## Contribute

Feel free to develop the API, add more tests, setup a UI or anything else you can think of!

### Git

This project makes use of git and for now it is recommended to follow a [Feature Branch model](https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow)

### Pull requests

The master branch uses a policy restriction to enforce code reviews via Pull Request. Simply make your changes locally (in your feature branch), then Commit and Push. Please use [good commit messages](https://github.com/elsewhencode/project-guidelines#13-writing-good-commit-messages) and naming for your PR

### Troubleshooting Git

Forgot to branch? Commited straight to master and now can't push your changes? Simply create a new branch from your local, then revert master to the same commit as origin.
