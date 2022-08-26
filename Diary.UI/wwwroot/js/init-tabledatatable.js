$(document).ready(function () {

    "use strict";

    var buttonCommon = {
        exportOptions: {
            format: {
                body: function (data, row, column, node) {
                    // Strip $ from salary column to make it numeric
                    return column === 5 ?
                        data.replace(/[$,]/g, '') :
                        data;
                }
            }
        }
    };
    $('#example').DataTable({
        responsive: true,
        dom: 'Bfrtip',
        buttons: [
            $.extend(true, {}, buttonCommon, {
                extend: 'copyHtml5'
            }),
            $.extend(true, {}, buttonCommon, {
                extend: 'excelHtml5'
            }),
            $.extend(true, {}, buttonCommon, {
                extend: 'pdfHtml5'
            }), $.extend(true, {}, buttonCommon, {
                extend: 'print'
            }),
        ]
    });

    $('#example2').DataTable({

        "scrollY": "250px",
        "scrollCollapse": true,
        "paging": false,
        "responsive": true
    });

    $('#example3').DataTable({ responsive: true });
});