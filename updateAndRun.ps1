cls
rm ./updateAndRun.ps1
git init
git pull --set-upstream http://github.com/akurai/http_practice main --rebase
cls
Write-Host "**************************************** starting program ****************************************"
dotnet run
