function join {
    local s="$1" e1="$2"
    shift 2
    printf %s "$e1${@/#/$s}"
}
