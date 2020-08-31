# CI Cog

This cog presents the ideas of CI pipeline design, Kubernetes, docker-compose and dockerfile for dotnet core projects

The sample projects are provided under `server` folder. Try to keep them as simple as possible.

## Console App

### Docker Files
`consoleApp.dockerfile` shows a way of building a dotnet console application.

This app requires neither volumes to mount nor ports to open.

``` shell

# Build
docker build -f ./consoleApp.dockerfile -t dotnetConsoleApp .

# Run
docker run dotnetConsoleApp

```