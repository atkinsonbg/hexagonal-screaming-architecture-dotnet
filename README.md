# Hexagonal & Screaming Architecture in .NET
This repo supports the talk by the same name given at various .NET and Software User Groups/Meetups. The goal is to showcase how you can use Hexagonal and Screaming architecture in your .NET projects to enfore de-coupling of your code, make it extremely transparent, easy to update, and easy to test.

## What the Application Does
The simple API allows users to upload, edit, and delete recipes. We've intentionally kept the functionality small to showcase the architecture, but also have a complete solution we can build and demo in a single presentation.

The following endpoints are supported:
- __POST__ /recipe
- __GET__ /recipe/{id}
- __PUT__ /recipe/{id}
- __DELETE__ /recipe/{id}

The following recipe model is used:
```
{
  "title": "Recipe title",
  "description": "A description of the recipe",
  "instructions": "Instructions for the recipe",
  "ingredients": [
    {
       "name": "Name of the ingredient",
       "amount": "Amount of the ingedient, just a string to keep it simple"
    }
  ]
}
```

## Branches
To help move the presentation along there are several branches implemented so we can showcase the evolution of the application while maximizing our time for the presentation.

### [main](https://github.com/atkinsonbg/hexagonal-screaming-architecture-dotnet)
Main is simply the initial scaffold of the project, there is not much here at the moment, but this is where we will begin. This branch includes the following folder structure:
- src: All source code and .NET projects land in this folder
- tests: All .NET test projects land in this folder
- sln: We will only have 1 solution file and its in the root of the repo
- Docker Compose: We'll use Docker Compose to run our infrastrcture for easy development and testing
- Makefile: Our Makefile holds all the commnads used to gen projects, the solution, as well as any Docker commands

This is the extent of the scaffold for main.

### [add-minimal-api](https://github.com/atkinsonbg/hexagonal-screaming-architecture-dotnet/tree/add-minimal-api)
This branch is the initial Adapter we will build and only holds a scaffold of the project to begin with. This is our API
and in this branch we are simply creating all our Screaming directories, which hold our endpoints as well as our
response objects. In this branch we do nothing more than scaffold out the endpoints and wire everything up so that
they return responses, but there is no business logic implemented just yet.
