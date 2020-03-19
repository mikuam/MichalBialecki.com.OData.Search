# MichalBialecki.com.OData.Search
This project is an example how to use flexibility of OData and combine it with React app. The whole solution is widely explaind in my blog post: http://www.michalbialecki.com/2020/03/19/odata-as-a-flexible-data-feed-for-react-search/

## Technology stack
In this project I used most up-to-date frameworks and packages available. So this is:
- Web API project in .Net Core 3.1
- Entity Framework Core, version 3.1.2
- OData from package Microsoft.AspNetCore.OData, version 7.4.0-beta
- React, version 16 with many other front-end packages

## Core features of this app
I created it as an example how any kind of search and filtering on the fron-end can be easily solved on the back-end side with OData integration.
- OData is a great technology that is very easy and fast to integrate with Entity Framework Core and gives powerful filtering options. It allows you to define operations in url like: filtering, ordering, getting count and top elements. Without and coding needed, it generates a SQL scripts and run it agains MS SQL database.
- to ease working with the API, I integrated Swagger, an interactive documentation, that is available under `/swagger` url
- I used hooks in React to follow the latest standards and implement the greatest coding experance. However, I don't feel very strong in React, so please don't take front-end part as a best solution reference

## How to run the project
Note that this project needs to be connected to MS SQL database, so you would need to have one to run it
1. Copy a connection string to `appsettings.json` file, as a value for element `LocalDB`. Mine looks like this: `Data Source=localhost;Initial Catalog=aspnetcore;Integrated Security=True`
2. Go to `/MichalBialecki.com.OData.Search.Web` directory and run command `dotnet build`
3. Go to `/MichalBialecki.com.OData.Search.Web/ClientApp` and run command `npm install`
4. Go back to `/MichalBialecki.com.OData.Search.Web` and run command `dotnet run`

## How it looks in practice
I recorded a short video that shows how it works in practice. Have a look:

[![Michał Białecki OData + React](http://img.youtube.com/vi/H_PNsMHgipA/0.jpg)](http://www.youtube.com/watch?v=H_PNsMHgipA "Example of connecting OData and React in .Net Core 3.1")
