msbuild /p:Configuration=Debug /t:clean
msbuild /p:Configuration=Release /t:clean
cd ..
cd EnvManSetup
msbuild /p:Configuration=Release /t:clean
cd ..
cd EnvMan.Tests
msbuild EnvManagerTest\EnvManagerTest.csproj /p:Configuration=Debug /t:clean
msbuild EnvManagerGUITest\EnvManagerGUITest.csproj /p:Configuration=Debug /t:clean
cd ..
cd EnvMan
del Release /Q
cd ..
