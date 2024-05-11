
@echo off
cls
chcp 65001

REM SETTING UP DATABASE
@echo ---- Deleting QLHSUT...
SQLCMD -E -dmaster -f65001 -i".\DB\DeleteQLHSUT.sql"
PAUSE