dotnet tool uninstall -g Library.Cli
dotnet pack
dotnet tool install --global --add-source ./nupkg Library.Cli


