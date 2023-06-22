#./start.sh & /opt/mssql/bin/sqlservr
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pass@word -d master -i vesisgestiontfhka.sql & /opt/mssql/bin/sqlservr