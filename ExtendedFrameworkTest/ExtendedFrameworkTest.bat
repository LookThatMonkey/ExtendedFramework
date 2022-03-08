@echo off&color 17
set anotherVariable=%~dp0
if exist "%SystemRoot%\SysWOW64" path %path%;%windir%\SysNative;%SystemRoot%\SysWOW64;%anotherVariable%
bcdedit >nul
if '%errorlevel%' NEQ '0' (goto UACPrompt) else (goto UACAdmin)
:UACPrompt
%1 start "" mshta vbscript:createobject("shell.application").shellexecute("""%~0""","::",,"runas",1)(window.close)&exit
exit /B
:UACAdmin

chcp 65001
setlocal EnableDelayedExpansion

cd /d %anotherVariable%

(for /F "delims=" %%a in (ExtendedFrameworkTest/ExtendedFrameworkTest.csproj.user) do (
   set "line=%%a"
   set "newLine=!line:StartProgram>=!"
   if "!newLine!" neq "!line!" (
      set "newLine=　　<StartProgram>%anotherVariable%ExtendedFrameworkTest\bin\Debug\ExtendedFramework.exe</StartProgram>"
   )
   echo !newLine!
)) > ExtendedFrameworkTest/newExtendedFrameworkTest.csproj.user

del ExtendedFrameworkTest\ExtendedFrameworkTest.csproj.user /q
ren ExtendedFrameworkTest\newExtendedFrameworkTest.csproj.user ExtendedFrameworkTest.csproj.user
start "" "ExtendedFrameworkTest.sln"