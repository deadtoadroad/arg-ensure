#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "${scriptRoot}")"
imagesRoot="${slnRoot}/build/images"
homeDocker="/home/${USER}"
slnRootDocker="${homeDocker}/arg-ensure"
mono="docker run --rm -u "$(id -u):$(id -g)" -v "${slnRoot}:${slnRootDocker}" -v "${HOME}/.nuget:${homeDocker}/.nuget" deadtoadroad/mono bash -c ${slnRootDocker}/build/mono"
# xunit requires the exact dependency (2.0.0), not the latest version.
dotnet="docker run --rm -u "$(id -u):$(id -g)" -v "${slnRoot}:${slnRootDocker}" -v "${HOME}/.nuget:${homeDocker}/.nuget" deadtoadroad/dotnet:2.0.0-sdk bash -c ${slnRootDocker}/build/dotnet"

source "${scriptRoot}/contains-f.sh"
source "${scriptRoot}/join-f.sh"

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
        targets=(build test)
        ;;
    'pack')
        targets=(build test pack)
        ;;
    *)
        echo "Unknown target: ${target}."
        exit 1
esac

echo "Targets: $(join ', ' "${targets[@]}")."

if contains 'clean' "${targets[@]}"; then
    eval "${imagesRoot}/clean.sh"
    cd "${slnRoot}"
    git clean -fdxe packages/
fi

if contains 'restore' "${targets[@]}"; then
    eval "${imagesRoot}/build.sh dotnet"
    eval "${dotnet}/restore.sh"
    eval "${imagesRoot}/build.sh mono"
    eval "${mono}/restore.sh"
fi

if contains 'build' "${targets[@]}"; then
    eval "${imagesRoot}/build.sh mono"
    eval "${mono}/build.sh"
fi

if contains 'test' "${targets[@]}"; then
    eval "${imagesRoot}/build.sh dotnet"
    eval "${dotnet}/test.sh"
fi

if contains 'pack' "${targets[@]}"; then
    eval "${imagesRoot}/build.sh mono"
    eval "${mono}/pack.sh"
fi
