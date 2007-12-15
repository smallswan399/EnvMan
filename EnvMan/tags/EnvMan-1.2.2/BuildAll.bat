cd EnvMan
msbuild /p:Configuration=Release
msbuild /p:Configuration=Debug
cd ..
rem cd EnvManSetup
rem "C:\Program Files\Microsoft Visual Studio 8\Common7\IDE/devenv.com" EnvManSetup.sln /build "Debug" /project EnvManSetup.vdproj /projectconfig "Debug"
rem cd ..
cd EnvManTest
msbuild /p:Configuration=Debug
cd EnvManTest\bin\Debug
NUnit.exe EnvManTest.dll

