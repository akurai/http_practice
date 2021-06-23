cls
rm ./updateAndRun.ps1
git init
git branch -m master main
git pull --set-upstream http://github.com/akurai/http_practice main
cls
Write-Host "**************************************** starting program ****************************************"
dotnet run
