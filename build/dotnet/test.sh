#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "$(dirname "${scriptRoot}")")"
packagesRoot="${slnRoot}/packages"
srcFragment='DeadToadRoad.ArgEnsure'
testsFragment="${srcFragment}.Tests"
testsProjRoot="${slnRoot}/tests/unit/${testsFragment}"

cd "${slnRoot}"
dotnet restore --packages "${packagesRoot}"
cd "${testsProjRoot}"
dotnet build
dotnet xunit
