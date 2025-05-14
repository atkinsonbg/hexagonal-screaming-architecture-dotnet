.PHONY: build
build:
	dotnet build -v detailed

sln:
	dotnet new sln --name hexagonal-screaming-architecture-dotnet