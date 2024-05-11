
@echo off
cls
chcp 65001

REM SETTING UP DATABASE
@echo ---- Creating QLHSUT...
SQLCMD -E -dmaster -f65001 -i".\DB\QLHSUT.sql"

@echo ---- Creating NopHoSoUngTuyen_Proc...
for %%G in (.\NopHoSoUngTuyen\NopHoSoUngTuyen_Proc.sql\*.sql) do SQLCMD -E -dmaster -f65001 -i"%%G"

@echo ---- Creating Granting...
for %%G in (.\DangKiThanhVien\GRANT\*.sql) do SQLCMD -E -dmaster -f65001 -i"%%G"

@echo ---- Creating Procedure...
for %%G in (.\DangKiThanhVien\PROC\*.sql) do SQLCMD -E -dmaster -f65001 -i"%%G"

REM POPULATING DATA
@echo ---- Populating Data...
SQLCMD -E -dmaster -f65001 -i".\MockData\Data.sql"

PAUSE