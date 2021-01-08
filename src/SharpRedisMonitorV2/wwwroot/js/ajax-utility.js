/**
 * Recupera il path corretto per la chiamata al corrispondente handler di ricerca.
 * Elimina eventuali path estesi.
 * @returns {path} path base + controller
 */
function GetCallLocation() {
    let path = window.location.pathname;
    const pathSplit = path.split("/");
    if (pathSplit.length >= 2)
        path = "/" + pathSplit[1];
    return document.location.origin + path;
}

/**
 * Recupera il path base
 * @returns {path} path base
 */
function GetBaseLocation() {
    return document.location.origin;
}