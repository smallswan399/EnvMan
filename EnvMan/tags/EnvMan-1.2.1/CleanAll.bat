cd EnvMan
msbuild /p:Configuration=Debug /t:clean
msbuild /p:Configuration=Release /t:clean
cd ..
rem cd EnvManSetup
rem msbuild /p:Configuration=Release /t:clean
rem cd ..
cd EnvManTest
msbuild /p:Configuration=Debug /t:clean
