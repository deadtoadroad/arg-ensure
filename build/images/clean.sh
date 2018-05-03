#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

if [[ -n $(docker images -q deadtoadroad/mono) ]]; then
    docker rmi deadtoadroad/mono
fi

if [[ -n $(docker images -q deadtoadroad/dotnet:2.0.0-sdk) ]]; then
    docker rmi deadtoadroad/dotnet:2.0.0-sdk
fi
