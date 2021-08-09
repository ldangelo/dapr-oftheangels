all: clean restore build install publish docker-build

clean:
	dotnet clean

restore:
	dotnet restore

build:
	dotnet build

publish: build
	dotnet publish -c Release
#	./warp-packer --arch linux-x64 --input_dir bin/Release/net5.0/linux-x64/publish --exec userservice --output userservice

run:
	dotnet run

install: publish warp-packer
	echo "Fetching warp-packer"
	curl -Lo warp-packer https://github.com/dgiagio/warp/releases/download/v0.3.0/macos-x64.warp-packer
	chmod +x warp-packer

docker-build: publish
	docker build . -t ldangelo/userservice

docker-push: docker-build
	docker push ldangelo/userservice
