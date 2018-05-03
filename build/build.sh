#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "${scriptRoot}")"
slnRootDocker="/home/${USER}/arg-ensure"
mono="docker run --rm -u "${USER}:${USER}" -v "${slnRoot}:${slnRootDocker}" deadtoadroad/mono bash -c ${slnRootDocker}/build/mono"
# xunit requires the exact dependency (2.0.0), not the latest version.
dotnet="docker run --rm -u "${USER}:${USER}" -v "${slnRoot}:${slnRootDocker}" deadtoadroad/dotnet:2.0.0-sdk bash -c ${slnRootDocker}/build/dotnet"

function contains {
    local m="$1" e
    shift
    for e; do [[ $e == $m ]] && return 0; done
    return 1
}

function join {
    local s="$1" e1="$2"
    shift 2
    printf %s "$e1${@/#/$s}"
}

target="${1:-test}"

case "${target}" in
    'clean')
        targets=(clean)
        ;;
    'restore')
        targets=(restore)
        ;;
    'build')
        targets=(build)
        ;;
    'test')
        targets=(test)
        ;;
    'pack')
        targets=(test pack)
        ;;
    *)
        echo "Unknown target: ${target}."
        exit 1
esac

echo "Targets: $(join ', ' "${targets[@]}")."

if contains 'clean' "${targets[@]}"; then
    cd "${scriptRoot}"
    ./images/clean.sh
    cd "${slnRoot}"
    git clean -fdxe packages/
fi

if contains 'restore' "${targets[@]}"; then
    cd "${scriptRoot}"
    ./images/build.sh mono
    eval "${mono}/restore.sh"
fi

if contains 'build' "${targets[@]}"; then
    cd "${scriptRoot}"
    ./images/build.sh mono
    eval "${mono}/build.sh"
fi

if contains 'test' "${targets[@]}"; then
    cd "${scriptRoot}"
    ./images/build.sh dotnet
    eval "${dotnet}/test.sh"
fi

if contains 'pack' "${targets[@]}"; then
    cd "${scriptRoot}"
    ./images/build.sh mono
    eval "${mono}/pack.sh"
fi
