all: clean restore build publish

clean:
	dotnet clean

restore:
	dotnet restore

build:
	dotnet build

publish: build
	dotnet publish -c Release -r linux-x64
#	./warp-packer --arch linux-x64 --input_dir bin/Release/net5.0/linux-x64/publish --exec userservice --output userservice

run:
	dotnet run
