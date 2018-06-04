// Write your JavaScript code.
$(document).ready(function () {
    
});

$('#btn-air-pressure').on('click', function () {
    $.getJSON("/Chart/AirPressure", function (result) {
        console.log(result);
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

    console.log(lable);
    console.log(dataa);


    var myChart = new Chart(ctx, {
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