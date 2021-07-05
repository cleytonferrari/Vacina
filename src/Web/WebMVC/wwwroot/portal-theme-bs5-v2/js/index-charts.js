'use strict';

/* Chart.js docs: https://www.chartjs.org/ */

window.chartColors = {
    green: '#75c181',
    gray: '#a9b5c9',
    text: '#252930',
    border: '#e7e9ed'
};

function configChartSexo(labels, dados) {
    var config = {
        type: 'pie',
        data: {
            datasets: [{
                data: dados,
                backgroundColor: [
                    window.chartColors.green,
                    window.chartColors.blue,
                ],
                label: ''
            }],
            labels: labels
        },
        options: {
            responsive: true,
            legend: {
                display: true,
                position: 'bottom',
                align: 'center',
            },

            tooltips: {
                titleMarginBottom: 10,
                bodySpacing: 10,
                xPadding: 16,
                yPadding: 16,
                borderColor: window.chartColors.border,
                borderWidth: 1,
                backgroundColor: '#fff',
                bodyFontColor: window.chartColors.text,
                titleFontColor: window.chartColors.text,

                /* Display % in tooltip - https://stackoverflow.com/questions/37257034/chart-js-2-0-doughnut-tooltip-percentages */
                callbacks: {
                    label: function (tooltipItem, data) {
                        //get the concerned dataset
                        var dataset = data.datasets[tooltipItem.datasetIndex];
                        //calculate the total of this data set
                        var total = dataset.data.reduce(function (previousValue, currentValue, currentIndex, array) {
                            return previousValue + currentValue;
                        });
                        //get the current items value
                        var currentValue = dataset.data[tooltipItem.index];
                        //calculate the precentage based on the total and current item, also this does a rough rounding to give a whole number
                        var percentage = Math.floor(((currentValue / total) * 100) + 0.5);

                        return percentage + "%";
                    },
                },


            },
        }
    }
    return config;
};

function configChartImunizados(labels, dados) {
    var config = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: dados,
                backgroundColor: [
                    window.chartColors.green,
                    window.chartColors.gray,

                ],
                label: 'Dataset 1'
            }],
            labels: labels
        },
        options: {
            responsive: true,
            legend: {
                display: true,
                position: 'bottom',
                align: 'center',
            },

            tooltips: {
                titleMarginBottom: 10,
                bodySpacing: 10,
                xPadding: 16,
                yPadding: 16,
                borderColor: window.chartColors.border,
                borderWidth: 1,
                backgroundColor: '#fff',
                bodyFontColor: window.chartColors.text,
                titleFontColor: window.chartColors.text,

                animation: {
                    animateScale: true,
                    animateRotate: true
                },

                /* Display % in tooltip - https://stackoverflow.com/questions/37257034/chart-js-2-0-doughnut-tooltip-percentages */
                callbacks: {
                    label: function (tooltipItem, data) {
                        //get the concerned dataset
                        var dataset = data.datasets[tooltipItem.datasetIndex];
                        //calculate the total of this data set
                        var total = dataset.data.reduce(function (previousValue, currentValue, currentIndex, array) {
                            return previousValue + currentValue;
                        });
                        //get the current items value
                        var currentValue = dataset.data[tooltipItem.index];
                        //calculate the precentage based on the total and current item, also this does a rough rounding to give a whole number
                        var percentage = Math.floor(((currentValue / total) * 100) + 0.5);

                        return percentage + "%";
                    },
                },


            },
        }
    };
    return config;
}
// Generate charts on load
window.addEventListener('load', function (response) {

    fetch('/api/v1/totalporsexo').then(function (response) {
        response.json().then(function (data) {
            var pieChart = document.getElementById('chart-pie').getContext('2d');

            var dados = data.map(function (e) {
                return e.total
            })
            var labels = data.map(function (e) {
                return `${e.label} (${e.total})`
            })

            window.myPie = new Chart(pieChart, configChartSexo(labels, dados));
        });
    }).catch(function (err) {
        console.error('Falha ao receber as informações', err);
    });

    fetch('/api/v1/totalimunizado').then(function (response) {
        response.json().then(function (data) {
            var doughnutChart = document.getElementById('chart-doughnut').getContext('2d');

            var dados = data.map(function (e) {
                return e.total
            })
            var labels = data.map(function (e) {
                return `${e.label} (${e.total})`
            })


            window.myDoughnut = new Chart(doughnutChart, configChartImunizados(labels, dados));
        });
    }).catch(function (err) {
        console.error('Falha ao receber as informações', err);
    });


});

