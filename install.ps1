# curl "https://raw.githubusercontent.com/akurai/http_practice/main/install.ps1" > install.ps1

cls
if(Test-Path -Path './.git' -PathType Container ){
    if((Read-Host "!!!WARNING!!! this will delete all files in this directory! Continue? [y/n]") -eq "y"){
        rm ./* -r -fo
    }
    else{
        exit
    }
}
else{
    rm ./install.ps1
}

git init
$param = $args[0]
if($param -eq "conti"){
    git config --global http.proxy http://199.19.250.205:80
    git config --global https.proxy https://199.19.250.205:80
}
git pull --set-upstream http://github.com/akurai/http_practice main
git branch -m master main

Write-Host "**************************************** starting program ****************************************"
dotnet run

