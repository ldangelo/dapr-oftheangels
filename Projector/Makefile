SERVICE = projector

all: clean restore build publish docker-build docker-push

clean:
	dotnet clean

restore:
	dotnet restore

build:
	dotnet build

publish:
	dotnet publish -c Release

run:
	dotnet run

docker-build:
	docker build . -t ldangelo/$(SERVICE)

docker-push:
	docker push ldangelo/$(SERVICE)
