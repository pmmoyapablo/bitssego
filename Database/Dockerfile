FROM mcr.microsoft.com/mssql/server:2019-latest
COPY Database/DataBase-MsSQLServer/vesisgestiontfhka.sql .
COPY Database/start.sh .
COPY Database/entrypoint.sh .
#RUN chmod +x ./start.sh
CMD /bin/bash ./entrypoint.sh