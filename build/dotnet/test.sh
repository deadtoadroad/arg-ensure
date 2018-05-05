#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "$(dirname "${scriptRoot}")")"
srcFragment='DeadToadRoad.ArgEnsure'
testsFragment="${srcFragment}.Tests"
testsProjRoot="${slnRoot}/tests/unit/${testsFragment}"

cd "${testsProjRoot}"
dotnet xunit -nobuild
