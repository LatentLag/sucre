ARG WEBBY_DIR=/opt/webby/
ARG WEBBY_PUBLISH=${WEBBY_DIR}/publish
ARG WEBBY_BUILD_CONFIGURATION=Release
ARG WEBBY_BUILD_DEBUG_SYMOBOLS=false

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG WEBBY_PUBLISH
ARG WEBBY_DIR
ARG WEBBY_BUILD_CONFIGURATION
ARG WEBBY_BUILD_DEBUG_SYMOBOLS

RUN mkdir -vp ${WEBBY_DIR}
WORKDIR ${WEBBY_DIR}

COPY . .

RUN dotnet clean \
    && dotnet restore \
    && dotnet build -p:DebugSymbols=${WEBBY_BUILD_DEBUG_SYMOBOLS} --configuration=${WEBBY_BUILD_CONFIGURATION} \
    && dotnet publish LatentLag.Sucre.Webby/LatentLag.Sucre.Webby.csproj --no-build --output ${WEBBY_PUBLISH} -p:DebugSymbols=${WEBBY_BUILD_DEBUG_SYMOBOLS}


FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
ARG WEBBY_PUBLISH
ARG WEBBY_DIR
ARG WEBBY_BUILD_CONFIGURATION
ENV WEBBY_BUILD_CONFIGURATION=${WEBBY_BUILD_CONFIGURATION}

RUN adduser -D webby \
    && mkdir -vp ${WEBBY_DIR}

COPY --from=build ${WEBBY_PUBLISH} ${WEBBY_DIR}

WORKDIR ${WEBBY_DIR}

USER webby
ENTRYPOINT [ "dotnet", "LatentLag.Sucre.Webby.dll" ]
