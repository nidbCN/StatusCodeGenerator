#！/bin/bash

echo "[I]Start Build Project."
./build.sh

echo "[II]Copy Dockerfile."
cp Dockerfile Release/Dockerfile
 
echo "[III]Build Docker Image."
docker build -t status-code-generator:0.1.3 Release/ 
