build:
	dotnet build

run:
	dotnet run --project ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj

sln:
	dotnet new sln --name hexagonal-screaming-architecture-dotnet
	
add-minimal-api:
	dotnet new web -o ./src/Adapter.MinimalAPI
	
update-sln-add-api:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj
	
add-core-project:
	dotnet new classlib -o ./src/Core
	
update-sln-add-core:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Core/Core.csproj

add-core-reference-to-api:
	dotnet add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj reference ./src/Core/Core.csproj
