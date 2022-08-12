

@echo off

SETLOCAL ENABLEDELAYEDEXPANSION

set dataHora=%date:~7,2%_%date:~4,2%_%date:~10,4%__%time:~0,2%_%time:~3,2%_%time:~6,2%
rem set dataHora=%date:~7,2%_%date:~4,2%_%date:~10,4%
set arqLog=LOG_SCRIPTS__%dataHora%__.log

@echo -------------------------  >> %arqLog%
@ECHO ---------Inicio----------
@ECHO ---------Inicio----------  >> %arqLog%
@echo -------------------------  >> %arqLog%




rem Ajuste as informacoes abaixo:

set usuario=USUARIO
set senha=SENHA

set servidor=SERVIDOR

set banco=dbAgencia

set caminho=C:\ProjetoAgencia\

rem FIM Ajuste
