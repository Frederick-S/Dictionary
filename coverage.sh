#!/bin/bash

# Install OpenCover and ReportGenerator, and save the path to their executables.
nuget install -Verbosity quiet -OutputDirectory packages -Version 4.7.922 OpenCover
nuget install -Verbosity quiet -OutputDirectory packages -Version 4.1.4 ReportGenerator

OPENCOVER=$PWD/packages/OpenCover.4.7.922/tools/OpenCover.Console.exe
REPORTGENERATOR=$PWD/packages/ReportGenerator.4.1.4/tools/netcoreapp2.0/ReportGenerator.dll

ls $PWD/packages/ReportGenerator.4.1.4

coverage=./coverage
mkdir $coverage

echo "Calculating coverage with OpenCover"
$OPENCOVER \
  -target:"c:\Program Files\dotnet\dotnet.exe" \
  -targetargs:"test ./Dict.Tests/Dict.Tests.csproj" \
  -output:$coverage/coverage.xml \
  -oldStyle \
  -filter:"+[Dict*]* -[Dict.*Tests*]*" \
  -register:user

echo "Generating HTML report"
dotnet $REPORTGENERATOR \
  -reports:$coverage/coverage.xml \
  -targetdir:$coverage \
  -verbosity:Error
