#!/usr/bin/env bash

rm -rf ./*/bin ./*/obj ./build

VERSION=$(cat VERSION)-$(date +%s)

dotnet.exe publish BarLauncher.BaseConverter.Wox/BarLauncher.BaseConverter.Wox.csproj -c Debug -p:Version=${VERSION}
(cd build/BarLauncher.BaseConverter.Wox/bin/Debug/net48/publish; zip -r ../../../../../../../BarLauncher-Volume-${VERSION}.wox .)

dotnet.exe publish BarLauncher.BaseConverter.Flow.Launcher/BarLauncher.BaseConverter.Flow.Launcher.csproj -c Debug -p:Version=${VERSION}
(cd build/BarLauncher.BaseConverter.Flow.Launcher/bin/Debug/net5.0-windows/publish; zip -r ../../../../../../../BarLauncher-Volume-${VERSION}.zip .)
