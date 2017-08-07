# escape=`
FROM microsoft/dotnet-framework:4.6.2 AS build

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

RUN Install-WindowsFeature NET-Framework-45-Core
RUN Invoke-WebRequest "https://aka.ms/vs/15/release/vs_BuildTools.exe" -OutFile vs_BuildTools.exe -UseBasicParsing ; `
	Start-Process -FilePath 'vs_BuildTools.exe' -ArgumentList '--quiet', '--norestart', '--locale en-US' -Wait ; `
	Remove-Item .\vs_BuildTools.exe ; `
	Remove-Item -Force -Recurse 'C:\Program Files (x86)\Microsoft Visual Studio\Installer'
RUN setx /M PATH $($Env:PATH + ';' + ${Env:ProgramFiles(x86)} + '\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin')

RUN Install-WindowsFeature NET-Framework-45-ASPNET
RUN Install-WindowsFeature Web-Asp-Net45

RUN Invoke-WebRequest https://download.microsoft.com/download/4/3/B/43B61315-B2CE-4F5B-9E32-34CCA07B2F0E/NDP452-KB2901951-x86-x64-DevPack.exe -OutFile NDP452-KB2901951-x86-x64-DevPack.exe -UseBasicParsing

RUN Start-Process .\NDP452-KB2901951-x86-x64-DevPack.exe -Wait -ArgumentList '/q /norestart'

RUN mkdir C:\tools

RUN Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile "C:\tools\nuget.exe" -UseBasicParsing

COPY . TalkNotesFront

WORKDIR TalkNotesFront

RUN C:\tools\nuget.exe restore

RUN msbuild /p:Configuration=Release

RUN mkdir C:\Published

RUN Copy-Item -Recurse TalkNotesFront\bin C:\Published\bin

RUN Copy-Item -Recurse TalkNotesFront\Content C:\Published\Content

RUN Copy-Item TalkNotesFront\favicon.ico C:\Published\favicon.ico

RUN Copy-Item TalkNotesFront\Global.asax C:\Published\Global.asax

RUN Copy-Item -Recurse TalkNotesFront\Scripts C:\Published\Scripts

RUN Copy-Item -Recurse TalkNotesFront\Views C:\Published\Views

RUN Copy-Item TalkNotesFront\web.config C:\Published\web.config

RUN $wc = [xml](Get-Content C:\Published\web.config); $oldAddress = $wc.configuration.'system.serviceModel'.client.endpoint.address; `
     $newAddress = $oldAddress -Replace 'localhost:\d+', 'talk-notes-back:8082'; `
     $wc.configuration.'system.serviceModel'.client.endpoint.address = $newAddress ; `
     $wc.Save('C:\Published\web.config')

FROM microsoft/iis:windowsservercore-10.0.14393.1480
SHELL ["powershell", "-command"]

# Install ASP.NET
RUN Install-WindowsFeature NET-Framework-45-ASPNET; `
    Install-WindowsFeature Web-Asp-Net45

EXPOSE 8081

RUN Remove-Website -Name 'Default Web Site'; `
    md 'C:\TalkNotesFront'; `
    New-Website -Name 'TalkNotesFront' `
                -Port 8081 -PhysicalPath 'C:\TalkNotesFront' `
                -ApplicationPool '.NET v4.5'

COPY --from=build C:\Published TalkNotesFront

ENTRYPOINT Start-Service W3SVC; `
    Invoke-WebRequest http://localhost:8081/api/TalkNotes -UseBasicParsing | Out-Null; `
    netsh http flush logbuffer | Out-Null; `
    Get-Content -path c:\TalkNotesFront\*TraceOutput.log -Tail 1 -Wait 