FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic

ARG MONO_VERSION=6.0.0.334

RUN apt-get update && \
    apt-get install -y gnupg ca-certificates && \
    apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF && \
    echo "deb https://download.mono-project.com/repo/ubuntu stable-bionic/snapshots/${MONO_VERSION} main" | tee /etc/apt/sources.list.d/mono-official-stable.list && \
    apt-get update

RUN apt-get install -y mono-devel

WORKDIR /root
