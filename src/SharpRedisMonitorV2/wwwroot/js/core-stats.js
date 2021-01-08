/**
 * Retrieve the new Redis statistics values
 * */
function UpdateCommands() {
    $.ajax({
        url: GetCallLocation() + "?handler=UpdateCommands",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            UpdateValues(result);
            UpdateChartData(result.commandModel);
        },
        fail: function (response) {
            console.log(response);
        },
        error: function (error) {
            console.log(error.status);
        },
        complete: function () {
        }
    });
}

function UpdateValues(model) {
    if (model !== null) {
        $("#connectedClientValue").html(model.clientsModel.connectedClients);
        $("#usedMemoryValue").html(model.memoryModel.usedMemory);
        $("#serverLoadValue").html(model.cpuModel.serverLoad);
        $("#hitsValue").html(model.keyspaceModel.hits);
        $("#missesValue").html(model.keyspaceModel.misses);
        $("#expiredValue").html(model.keyspaceModel.expired);
    }
}

function UpdateChartData(commandModel) {
    if (commandModel !== null) { 
        data.push(commandModel.operationPerSec); 
        dataBytes.push(commandModel.bytesReceivedPerSec); 
    }
}