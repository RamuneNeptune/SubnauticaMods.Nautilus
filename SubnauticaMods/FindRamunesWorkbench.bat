@echo off
setlocal enabledelayedexpansion

set "search_dir=C:\Source\SubnauticaMods.Nautilus\SubnauticaMods"
set "search_string=RamunesWorkbench"
		
for /r "%search_dir%" %%F in (*.cs) do (
    findstr /C:"%search_string%" "%%F" > nul
    if !errorlevel! equ 0 (
        set "file=%%~fF"
        set "file=!file:%search_dir%\=!"
		
		set "blank= >> "
        echo !blank!
		
		set "spacing= >> - "
        echo !spacing!!file!
    )
)

endlocal