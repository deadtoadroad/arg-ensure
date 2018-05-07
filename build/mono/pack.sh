#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "$(dirname "${scriptRoot}")")"

cd "${slnRoot}"
msbuild /t:Pack /p:Configuration=Release /p:PublicRelease=True /p:PackageOutputPath="${slnRoot}"
