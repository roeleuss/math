param($params)
Remove-Item -Force -Recurse "./bin"
New-Item -ItemType Directory -Force -Path "./obj", "./bin" | Out-Null
g++ -c BinarySet.cpp -o .\obj\BinarySet.o
g++ -c Program.cpp -o .\obj\Program.o
g++ -Wall -o .\bin\Set.exe .\obj\*.o
strip --strip-unneeded .\bin\Set.exe
& .\bin\Set.exe $params