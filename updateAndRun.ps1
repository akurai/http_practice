cls
rm ./updateAndRun.ps1
git pull -u http://github.com/akurai/http_practice main
Write-Host "**************************************** starting program ****************************************"
dotnet run
