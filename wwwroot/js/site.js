﻿var myChart;

// Write your JavaScript code.
$(document).ready(function () {
    
});


// Top Ten Air pressure 
$('#btn-air-pressure').on('click', function () {
    $.getJSON("/Chart/AirPressure", function (result) {
        initGraph(result.queryName, result.values);
    });
    
});

// V8 
$('#btn-v8-air-pressure').on('click', function () {
    $.getJSON("/Chart/AirPressureByCelinder", function (result) {
        initGraph(result.queryName, result.values);
    });

});



function initGraph(queryName, values) {
    console.log(queryName);
    console.log(values);
    var ctx = document.getElementById("myChart");
    var lable = [];
    var dataa = [];
    
    for (x = 0; x < values.length; x++) {
        console.log(x);
        lable[x] = values[x].name;
        dataa[x] = values[x].value;
    }

    if (myChart != null) {
        myChart.destroy();
    }

    myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: lable,
            datasets: [{
                label: queryName,
                data: dataa,
                backgroundColor: 'rgba(54, 162, 235, 1)'
                
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}