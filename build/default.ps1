Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
#------------------------------

if (Test-Path 'Env:\TEAMCITY_VERSION') {
	FormatTaskName "##teamcity[progressMessage '{0}']"
}

Import-Module "$BuildToolsRoot\modules\msbuild.psm1" -DisableNameChecking
Import-Module "$BuildToolsRoot\modules\nuget.psm1" -DisableNameChecking
Import-Module "$BuildToolsRoot\modules\versioning.psm1" -DisableNameChecking
Import-Module "$BuildToolsRoot\modules\unittests.psm1" -DisableNameChecking

Task Default -depends Hello
Task Hello { "Билдскрипт запущен без цели, укажите цель" }

Task Set-BuildNumber {
	$version = Get-Version
	
	if (Test-Path 'Env:\TEAMCITY_VERSION') {
		Write-Host "##teamcity[buildNumber '$($version.SemanticVersion)']"
	}
}

Task Update-AssemblyInfo {
	$globalDir = Join-Path $global:Context.Dir.Solution '.'
	$assemblyInfos = Get-ChildItem $globalDir -Filter 'AssemblyInfo.cs' -Recurse
	Update-AssemblyInfo $assemblyInfos
}

Task Build-NuGetPackages -depends Set-BuildNumber, Update-AssemblyInfo {

    $SolutionRelatedAllProjectsDir = '.'

    $tempDir = Join-Path $global:Context.Dir.Temp 'NuGet'
    if (!(Test-Path $tempDir)){
        md $tempDir | Out-Null
    }

    $projects = Find-Projects $SolutionRelatedAllProjectsDir -Filter '*.nuproj'
	Build-PackagesFromNuProjs $projects $tempDir

    Publish-Artifacts $tempDir 'NuGet'
}

Task Deploy-NuGet {
	$artifactName = Get-Artifacts 'NuGet'
	Deploy-Packages $artifactName
}

Task Run-UnitTests -depends Set-BuildNumber, Update-AssemblyInfo{
	$SolutionRelatedAllProjectsDir = '.'
	
	$projects = Find-Projects $SolutionRelatedAllProjectsDir '*Tests*'
	foreach($project in $Projects){
		$buildFileName = Create-BuildFile $project.FullName
		Invoke-MSBuild $buildFileName
	}

	Run-UnitTests $projects
}