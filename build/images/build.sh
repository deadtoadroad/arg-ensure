#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

target=${1-mono}

if [[ $target != 'mono' && $target != 'dotnet' ]]; then
    echo "Unknown target: ${target}."
    exit 1
fi

cd "${scriptRoot}"
echo "addgroup --system -gid $(id -g) ${USER}" > user.sh
echo "adduser --system --shell /bin/bash --uid $(id -u) --gid $(id -g) ${USER}" >> user.sh

if [[ $target == 'mono' ]]; then
    cp ./user.sh ./mono/
    docker build -t deadtoadroad/mono mono
fi

if [[ $target == 'dotnet' ]]; then
    cp ./user.sh ./dotnet/
    docker build -t deadtoadroad/dotnet:2.0.0-sdk dotnet
fi
