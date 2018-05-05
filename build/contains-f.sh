function contains {
    local m="$1" e
    shift
    for e; do [[ $e == $m ]] && return 0; done
    return 1
}
