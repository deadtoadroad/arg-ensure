#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "$(dirname "${scriptRoot}")")"
packagesRoot="${slnRoot}/packages"

cd "${slnRoot}"
msbuild /t:Restore,Build /p:RestorePackagesPath="${packagesRoot}" /p:Configuration=Debug
