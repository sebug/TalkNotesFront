# escape=`

FROM microsoft/iis
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

COPY TalkNotesFront\bin\Release\PublishOutput TalkNotesFront

CMD Start-Service W3SVC; `
    Invoke-WebRequest http://localhost:8081/api/TalkNotes -UseBasicParsing | Out-Null; `
    netsh http flush logbuffer | Out-Null; `
    Get-Content -path 'c:\TraceOutput.log' -Tail 1 -Wait 