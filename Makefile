.PHONY: build
build:
	dotnet build -v detailed

.PHONY: run
run:
	dotnet run --project ./src/Port.MinimalAPI/Port.MinimalAPI.csproj

sln:
	dotnet new sln --name hexagonal-screaming-architecture-dotnet
	
add-minimal-api:
	dotnet new web -o ./src/Adapter.MinimalAPI
	
update-sln-add-api:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj