#!/bin/bash

curl https://open.kattis.com/problems/$1/file/statement/samples.zip > samples.zip
mkdir $1
mv samples.zip $1/samples.zip
cd $1
unzip samples.zip
rm samples.zip

cp -r ../_template/* .

#Start default program (visual studio)
start Kattis.sln &



