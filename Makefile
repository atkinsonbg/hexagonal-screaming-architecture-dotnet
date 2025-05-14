.PHONY: build
build:
	dotnet build -v detailed

.PHONY: run
run:
	dotnet run --project ./src/Port.MinimalAPI/Port.MinimalAPI.csproj

.PHONY: start
start: stop
	docker-compose up -d

.PHONY: stop
stop:
	docker-compose down --remove-orphans

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

add-db-adapter-project:
	dotnet new classlib -o ./src/Adapter.Postgres

update-sln-add-db-adpater:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.Postgres/Adapter.Postgres.csproj

add-core-reference-to-api:
	dotnet add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj reference ./src/Core/Core.csproj
