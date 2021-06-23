cls
rm ./* -r -fo
git init
git pull --set-upstream http://github.com/akurai/http_practice main
git branch -m master main

Write-Host "**************************************** starting program ****************************************"
dotnet run
