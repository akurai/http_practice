cls
if(Test-Path -Path './.git' -PathType Container ){
    if((Read-Host "!!!WARNING!!! this will delete all files in this directory! Continue? [y/n]") -eq "y"){
        rm ./* -r -fo
    }
    
}

git init
git pull --set-upstream http://github.com/akurai/http_practice main
git branch -m master main

Write-Host "**************************************** starting program ****************************************"
dotnet run

