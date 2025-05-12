PHONY: build
build:
	dotnet build

PHONY: run
run:
	dotnet run --project ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj

PHONY: start
start: stop
	docker-compose up -d

PHONY: stop
stop:
	docker-compose down --remove-orphans

PHONY: sln
sln:
	dotnet new sln --name hexagonal-screaming-architecture-dotnet

PHONY: add-minimal-api
add-minimal-api:
	dotnet new web -o ./src/Adapter.MinimalAPI

PHONY: update-sln-add-api
update-sln-add-api:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj
	
PHONY: add-core-project
add-core-project:
	dotnet new classlib -o ./src/Core

PHONY: update-sln-add-core
update-sln-add-core:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Core/Core.csproj

PHONY: add-db-project
add-db-adapter-project:
	dotnet new classlib -o ./src/Adapter.Postgres

PHONY: update-sln-add-db
update-sln-add-db-adpater:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.Postgres/Adapter.Postgres.csproj

PHONY: add-db-reference-to-api
add-core-reference-to-api:
	dotnet add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj reference ./src/Core/Core.csproj

PHONY: add-db-reference-to-api
add-application-host-project:
	dotnet new console -o ./src/ApplicationHost.API

PHONY: update-sln-add-host
update-sln-add-host-adpater:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/ApplicationHost.API/ApplicationHost.API.csproj

PHONY: add-all-references-to-host
add-all-references-to-host:
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Core/Core.csproj
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Adapter.Postgres/Adapter.Postgres.csproj