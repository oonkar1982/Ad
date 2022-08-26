$(document).ready(function () {
    "use strict";

    fnLineChart();
    fnBarChart();
    fnPieChart();
    fnDonutChart();

    function fnLineChart() {
        var ctx = document.getElementById('myLineChart').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'line',

            // The data for our dataset
            data: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
                datasets: [{
                    label: 'Sales',
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: [63, 59, 65, 56, 55, 53, 54]
                }]
            },

        });
    }
    function fnBarChart() {
        var ctx2 = document.getElementById('myBarChart');
        var barChart = new Chart(ctx2, {
            type: 'bar',
            data: {
                labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
                datasets: [{
                    label: 'Total Visitors',
                    data: [37, 31, 36, 34, 43, 31],
                    backgroundColor: '#1ab394',
                    borderColor: '#1ab394',
                    borderWidth: 1.5
                }, {
                    label: 'New Visitors',
                    data: [12, 16, 20, 14, 23, 21],
                    backgroundColor: '#ebeff2',
                    borderColor: '#ebeff2',
                    borderWidth: 1.5
                }]
            }
        });

    }

    function fnPieChart() {
        var ctxPie = document.getElementById('myPieChart').getContext('2d');
        var myPieChart = new Chart(ctxPie, {
            type: "pie",
            data: {
                labels: ["Australia", "India", "Canada"],
                datasets: [{
                    label: "My First Dataset",
                    data: [360, 140, 90],
                    backgroundColor: ["#1ab394", "#3a94d8", "#f0ad4e"]
                }]
            }

        });
    }

    function fnDonutChart() {
        var ctxDonut = document.getElementById('myDonutChart').getContext('2d');
        var myDonutChart = new Chart(ctxDonut, {
            type: "doughnut",
            data: {
                labels: ["Desktop", "Mobile", "Tablet"],
                datasets: [{
                    label: "My First Dataset",
                    data: [360, 140, 90],
                    backgroundColor: ["#1ab394", "#3a94d8", "#f0ad4e"]
                }]
            }

        });
    }

});