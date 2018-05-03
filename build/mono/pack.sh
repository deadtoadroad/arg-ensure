#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "$(dirname "${scriptRoot}")")"
packagesRoot="${slnRoot}/packages"
buildRoot="${slnRoot}/build"

cd "${slnRoot}"
msbuild /t:Restore,Pack /p:RestorePackagesPath="${packagesRoot}" /p:Configuration=Release /p:PackageOutputPath="${buildRoot}"
