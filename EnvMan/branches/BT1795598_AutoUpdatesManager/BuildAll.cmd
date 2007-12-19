msbuild EnvMan.sln /p:Configuration=Release
msbuild EnvMan.sln /p:Configuration=Debug
cd EnvManSetup
"C:\Program Files\Microsoft Visual Studio 8\Common7\IDE/devenv.com" EnvManSetup.sln /build "Debug" /project EnvManSetup.vdproj /projectconfig "Debug"
cd ..
cd EnvMan.Tests
msbuild /p:Configuration=Debug
msbuild EnvManagerTest\EnvManagerTest.csproj /p:Configuration=Debug
msbuild EnvManagerGUITest\EnvManagerGUITest.csproj /p:Configuration=Debug
NUnit.exe EnvMan.Tests.nunit
cd ..
