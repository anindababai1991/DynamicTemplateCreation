Param(
[Parameter(Mandatory=$true)]
[String] $PathToConfig,
[Parameter(Mandatory=$true)]
[String] $SolutionName,
[Parameter(Mandatory=$true)]
[String] $FriendlyName,
[Parameter(Mandatory=$true)]
[String] $OutputPath,
[Parameter(Mandatory=$true)]
[String]$AddKey,
[Parameter(Mandatory=$true)]
[String]$AddValue
)

$splitKeys=$AddKey.Split(',');
$splitValues=$AddValue.Split(',');

$splitKeys
$splitValues

Clear-Variable -Name "finalParams"

for($key=0;$key -lt $splitKeys.Length;$key++)
{
    Write-Host "Key $key"

        if($splitValues[$key] -eq "true")
        {
            Write-Host "$finalParams"
            $finalParams=$finalParams+ $splitKeys[$key] + ' '+[System.Boolean]$true+' '
        }
        else
        {
            Write-Host "$finalParams"
            $finalParams=$finalParams+$splitKeys[$key]  +' '+[System.Boolean]$false+' '
        }
}

Write-Output "Path- $PathToConfig ||  Solution - $SolutionName  ||  Name - $FriendlyName || Output - $OutputPath"

$isInstall=dotnet new --install "$PathToConfig"

Write-Host ""$FriendlyName" -n "$SolutionName" -o "$OutputPath" $finalParams"


Invoke-Command -ScriptBlock ([Scriptblock]::Create("dotnet new $FriendlyName -n $SolutionName -o $OutputPath $finalParams --force"))