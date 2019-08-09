# Add the Base Of Docker File
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base

#Define Working Dir

WORKDIR /app

# Copy the Conatint 
COPY . .

# Define URL
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CMDAPI.dll

