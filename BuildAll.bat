cd EnvMan
msbuild /p:Configuration=Release
msbuild /p:Configuration=Debug
cd ..
cd EnvManSetup
msbuild /p:Configuration=Release
cd ..
cd EnvManTest
msbuild /p:Configuration=Debug
cd EnvManTest\bin\Debug
NUnit.exe EnvManTest.dll

