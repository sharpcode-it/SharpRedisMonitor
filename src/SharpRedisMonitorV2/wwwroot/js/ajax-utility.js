/**
 * Recupera il path corretto per la chiamata al corrispondente handler di ricerca.
 * Elimina eventuali path estesi.
 * @returns {path} path base + controller
 */
function GetCallLocation(params) {
    let path = window.location.pathname;
    //const pathSplit = path.split("/");
    //if (pathSplit.length >= 2) {
    //    //path = "/" + pathSplit.slice(0, 3).join("/");
    //}
    //return document.location.origin + path;
    var href = window.location.href;
    if (href.indexOf("?") == -1) {
        href = href + "?";
    } else {
        href = href + "&"
    }

    for (i = 0; i < params.length; i++) {
        href = href + params[i] + "&"
    }

    return href;
}

/**
 * Recupera il path base
 * @returns {path} path base
 */
function GetBaseLocation() {
    return document.location.origin;
}