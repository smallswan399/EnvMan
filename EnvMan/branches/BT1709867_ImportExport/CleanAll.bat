cd EnvMan
msbuild /p:Configuration=Debug /t:clean
msbuild /p:Configuration=Release /t:clean
cd ..
cd EnvManSetup
msbuild /p:Configuration=Release /t:clean
cd ..
cd EnvManTest
msbuild /p:Configuration=Debug /t:clean
