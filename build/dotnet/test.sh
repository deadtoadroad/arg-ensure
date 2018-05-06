#!/usr/bin/env bash

set -euo pipefail

scriptRoot="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
slnRoot="$(dirname "$(dirname "${scriptRoot}")")"
testsFragment='DeadToadRoad.ArgEnsure.Tests'
testsUnitProjRoot="${slnRoot}/tests/unit/${testsFragment}"
testsFunctionalProjRoot="${slnRoot}/tests/functional/${testsFragment}"

cd "${testsUnitProjRoot}"
dotnet xunit -nobuild
cd "${testsFunctionalProjRoot}"
dotnet xunit -nobuild
