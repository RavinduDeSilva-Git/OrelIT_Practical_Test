$(document).ready(function () {
    //$('#myTable').DataTable({
    //    "scrollY": "450px",
    //    "scrollCollapse": true,
    //    "paging": false
    //});

    if ($.fn.dataTable.isDataTable('#myTable')) {
        table = $('#myTable').DataTable();
        paging: true
        scrollCollapse: true
    }
    else {
        table = $('#myTable').DataTable({
            paging: true
        });
    }
});

