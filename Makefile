PHONY: build
build:
	dotnet build -v detailed

PHONY: run
run:
	dotnet run --project ./src/ApplicationHost.API/ApplicationHost.API.csproj

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

PHONY: add-postgres-adapter-project
add-postgres-adapter-project:
	dotnet new classlib -o ./src/Adapter.Postgres

PHONY: update-sln-add-postgres-adpater
update-sln-add-postgres-adpater:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.Postgres/Adapter.Postgres.csproj

PHONY: add-core-reference-to-api
add-core-reference-to-api:
	dotnet add ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj reference ./src/Core/Core.csproj

PHONY: add-application-host-project
add-application-host-project:
	dotnet new console -o ./src/ApplicationHost.API

PHONY: update-sln-add-host-adpater
update-sln-add-host-adpater:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/ApplicationHost.API/ApplicationHost.API.csproj

PHONY: add-mysql-adapter-project
add-mysql-adapter-project:
	dotnet new classlib -o ./src/Adapter.MySQL

PHONY: add-core-reference-to-mysql
add-core-reference-to-mysql:
	dotnet add ./src/Adapter.MySQL/Adapter.MySQL.csproj reference ./src/Core/Core.csproj

PHONY: update-sln-add-mysql
update-sln-add-mysql:
	dotnet sln hexagonal-screaming-architecture-dotnet.sln add ./src/Adapter.MySQL/Adapter.MySQL.csproj

PHONY: add-all-references-to-host
add-all-references-to-host:
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Core/Core.csproj
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Adapter.MinimalAPI/Adapter.MinimalAPI.csproj
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Adapter.Postgres/Adapter.Postgres.csproj
	dotnet add ./src/ApplicationHost.API/ApplicationHost.API.csproj reference ./src/Adapter.MySQL/Adapter.MySQL.csproj