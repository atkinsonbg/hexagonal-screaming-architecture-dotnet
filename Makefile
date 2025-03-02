sln:
	dotnet new sln --name hexagonal-screaming-architecture-dotnet
	
add-minimal-api:
	dotnet new web -o ./src/Adapter.MinimalAPI