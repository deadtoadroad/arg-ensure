#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "${scriptRoot}")"
containerHome="/root"
containerSlnRoot="${containerHome}/arg-ensure"
containerName="deadtoadroad/dotnet-core-sdk-mono-devel:2.2"
buildContainer="echo '*** Building Docker image...' && docker build ${scriptRoot} -t ${containerName}"
runContainer="echo '*** Running Docker container...' && docker run --rm -v "${slnRoot}:${containerSlnRoot}" -v "${slnRoot}/packages:${containerHome}/.nuget" -w "${containerSlnRoot}" ${containerName} bash -c"

source "${scriptRoot}/f-contains.sh"
source "${scriptRoot}/f-join.sh"

targets=("$@")

if [[ "$#" -eq "0" ]]; then
    targets+=(test)
fi

if contains 'clean-all' "${targets[@]}"; then
    targets+=(clean-docker clean-repo)
fi

if contains 'pack' "${targets[@]}"; then
    targets+=(test)
fi

echo "*** Targets: $(join ', ' "${targets[@]}")"

if contains 'clean' "${targets[@]}" || \
   contains 'restore' "${targets[@]}" || \
   contains 'build' "${targets[@]}" || \
   contains 'test' "${targets[@]}" || \
   contains 'pack' "${targets[@]}"; then
    eval "${buildContainer}"
fi

if contains 'clean' "${targets[@]}"; then
    echo "*** clean"
    eval "${runContainer} 'dotnet clean'"
fi

if contains 'clean-docker' "${targets[@]}"; then
    echo "*** clean-docker"
    if [[ -n $(docker images -q ${containerName}) ]]; then
        docker rmi ${containerName}
    fi
fi

if contains 'clean-repo' "${targets[@]}"; then
    echo "*** clean-repo"
    cd "${slnRoot}"
    sudo git clean -fdx
fi

if contains 'restore' "${targets[@]}"; then
    echo "*** restore"
    eval "${runContainer} 'dotnet restore'"
fi

if contains 'build' "${targets[@]}"; then
    echo "*** build"
    eval "${runContainer} 'dotnet build'"
fi

if contains 'test' "${targets[@]}"; then
    echo "*** test"
    eval "${runContainer} 'dotnet test'"
fi

if contains 'pack' "${targets[@]}"; then
    echo "*** pack"
    eval "${runContainer} 'dotnet pack'"
fi
