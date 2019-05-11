dotnet-webapi-fibonacci
===

Repo to play a little with dotnet core webapi in fibonacci algorithm in some different ways.

_Actually, this repo makes no real sense, but has TDD, CI and others good engineering pratices._  

_Oh, it runs on Windows and Linux at least, both visual studio and visual code._

[![CircleCI](https://circleci.com/gh/lucastagliani/dotnet-webapi-fibonacci.svg?style=svg)](https://circleci.com/gh/lucastagliani/dotnet-webapi-fibonacci)

## Before running it

You need to have .NET Core!

You can download it here: https://dotnet.microsoft.com/download

After install this, you can check if everything is OK by typing `dotnet --version` in your command line.

## How to run it

In command line:

1. Clone the repository: 

    SSH: `git clone git@github.com:lucastagliani/dotnet-webapi-fibonacci.git`  
    or  
    HTTP: `git clone https://github.com/lucastagliani/dotnet-webapi-fibonacci.git`

2. Enter the repository folder: `cd dotnet-webapi-fibonacci`

3. Restore dependencies: `dotnet restore src`

4. Run API: `dotnet run --project src`

    _It will be running on http://localhost:5050_

    If you hit http://localhost:5050/api/fibonacci on your brower or API app like Postamn, you should get some data returned. 

![Image](how-to-run-it.png "How to run it")

## How to test it 

`dotnet test test`

![Image](how-to-test-it.png "How to test it")

## Documentation

_At this moment, this API has these options:_

`GET` https://dotnet-webapi-fibonacci.herokuapp.com/api/fibonacci/until  
`GET` https://dotnet-webapi-fibonacci.herokuapp.com/api/fibonacci/until/1000  
`GET` https://dotnet-webapi-fibonacci.herokuapp.com/api/fibonacci/length  
`GET` https://dotnet-webapi-fibonacci.herokuapp.com/api/fibonacci/length/1000  


