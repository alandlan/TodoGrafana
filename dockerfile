FROM mcr.microsoft.com/dotnet/sdk:7.0 as dev
RUN mkdir /work/
WORKDIR /work
COPY ./src/TodoGrafana/TodoGrafana.csproj /work/TodoGrafana.csproj
RUN dotnet restore

COPY ./src/TodoGrafana/ /work
RUN mkdir /out/
RUN cd /work/
RUN dotnet publish  --output /out/ --configuration Release

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as prod
RUN mkdir /app/
WORKDIR /app/
COPY --from=dev /out/ /app/
RUN chmod +x /app/
ENTRYPOINT ["dotnet", "TodoGrafana.dll" ]