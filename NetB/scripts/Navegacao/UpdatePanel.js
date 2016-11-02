/// <reference path="../jquery-3.1.0.intellisense.js" />
function updatePanelGet(url, callBack) {
    $.ajax({
        type: 'GET',
        url: url,
        async: true,
        success: function (data) { callBack(data); }
    });
}
function updatePanelGetnoCallback(url) {
    $.ajax({
        type: 'GET',
        url: url,
        async: true
    });
}


function UpdatePainelFunction(pagina, callbackFunction, exibe, async) {
    $.ajax({
        url: pagina,
        async: async,
        beforeSend: function (xhr) {
            BlockScreen();
        }
    })
        .done(function (data) {
            callbackFunction(data);
        })
        .always(function () {
            Metronic.unblockUI();
        });
}

function UpdatePainelFunctionPost(url, parametros, functionCallback) {
    BlockScreen();
    $.post(url,parametros)
        .done(function (data) {
            functionCallback(data);
        })
        .always(function () {
            Metronic.unblockUI();
        });
}

function updatePanelPost(url, parametros, callBack) {
    $.post(url, parametros)
    .done(function (data) {
        callBack(data);
    });
}