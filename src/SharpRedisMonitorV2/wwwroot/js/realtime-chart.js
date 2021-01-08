$(function () {
    /*
     * Flot Interactive Chart
     * -----------------------
     */

    function getData(sourceData) {
        if (sourceData.length > totalPoints)
            sourceData = sourceData.slice(1);
        // Zip the generated y values with the x values
        var res = []
        for (var i = 0; i < sourceData.length; ++i) {
            res.push([i, sourceData[i]])
        }
        return res
    }

    function getMax(sourceData) {
        let max = sourceData[0];
        for (var i = 0; i < sourceData.length; ++i) {
            if (max < sourceData[i])
                max = sourceData[i];
        }
        return max;
    }

    var updateInterval = 1000; //Fetch data ever x milliseconds
    var realtime = "on"; //If == to on then fetch data every x seconds. else stop fetching
    function update() {
        // Operations/sec chart
        var interactivePlot = $.plot("#interactive",
            [getData(data)],
            {
                grid: {
                    borderColor: "#f3f3f3",
                    borderWidth: 1,
                    tickColor: "#f3f3f3"
                },
                series: {
                    shadowSize: 0, // Drawing is faster without shadows
                    color: "#3c8dbc"
                },
                lines: {
                    fill: true, //Converts the line chart to area chart
                    color: "#3c8dbc"
                },
                yaxis: {
                    min: 0,
                    max: getMax(data),
                    show: true
                },
                xaxis: {
                    min: 0,
                    show: true
                }
            });
        interactivePlot.setData([getData(data)]);
        interactivePlot.draw();

        if (realtime === "on")
            setTimeout(update, updateInterval + Math.floor(Math.random() * 100));
    }

    function updateBytesPerSec() {
        // BytesReceived/sec chart
        var interactivePlotBytes = $.plot("#interactiveBytesPerSec",
            [getData(dataBytes)],
            {
                grid: {
                    borderColor: "#f3f3f3",
                    borderWidth: 1,
                    tickColor: "#f3f3f3"
                },
                series: {
                    shadowSize: 0, // Drawing is faster without shadows
                    color: "#3c8dbc"
                },
                lines: {
                    fill: true, //Converts the line chart to area chart
                    color: "#3c8dbc"
                },
                yaxis: {
                    min: 0,
                    max: getMax(dataBytes),
                    show: true
                },
                xaxis: {
                    min: 0,
                    show: true
                }
            });
        interactivePlotBytes.setData([getData(dataBytes)]);
        interactivePlotBytes.draw();

        if (realtime === "on")
            setTimeout(updateBytesPerSec, updateInterval + Math.floor(Math.random() * 100));
    }

    //INITIALIZE REALTIME DATA FETCHING
    if (realtime === "on") {
        update();
        updateBytesPerSec();
    }

    //REALTIME TOGGLE
    $("#realtime .btn").click(function() {
        if ($(this).data("toggle") === "on") {
            realtime = "on";
        } else {
            realtime = "off";
        }
        update();
    });
})