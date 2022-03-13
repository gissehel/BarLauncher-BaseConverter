rm -rf */bin */obj */build build

dotnet.exe publish BarLauncher.BaseConverter.Wox/BarLauncher.BaseConverter.Wox.csproj -c Release
dotnet.exe publish BarLauncher.BaseConverter.Flow.Launcher/BarLauncher.BaseConverter.Flow.Launcher.csproj -c Release -r win-x64

