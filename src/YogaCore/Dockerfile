FROM microsoft/dotnet:latest

# Uncomment below, if your environment are behind proxy
# ENV http_proxy "http://192.168.56.1:8889"
# ENV https_proxy "http://192.168.56.1:8889"

COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]

EXPOSE 5000
ENTRYPOINT ["dotnet", "run"]
