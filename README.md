# Hexagonal & Screaming Architecture in .NET
This repo supports the talk by the same name given at various .NET and Software User Groups/Meetups. The goal is to showcase how you can use Hexagonal and Screaming architecture in your .NET projects to enfore de-coupling of your code, make it extremely transparent, easy to update, and easy to test.

## What the Application Does
The simple API allows users to upload, edit, and delete recipes. We've intentionally kept the functionality small to showcase the architecture, but also have a complete solution we can build and demo in a single presentation.

The following endpoints are supported:
- __POST__ /recipe
- __GET__ /recipe/{id}
- __PUT__ /recipe/{id}
- __DELETE__ /recipe/{id}

  The following Models are used for each endpoint:

  ### POST /recipe
  ```
  {
    "title": "Recipe title",
    "description": "A description of the recipe"
    "instructions": "Instructions for the recipe",
    "ingredients": [
      {
         "name": "Name of the ingredient",
         "amount": "Amount of the ingedient, just a string to keep it simple"
      }
    ]
  }
  ```
