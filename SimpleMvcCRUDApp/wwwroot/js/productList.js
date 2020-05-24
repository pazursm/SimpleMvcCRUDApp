var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/products/getall",
            "type": "GET"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "description", "width": "20%" },
            { "data": "category", "width": "10%" },
            { "data": "manufacturer", "width": "20%" },
            { "data": "supplier", "width": "20%" },
            { "data": "price", "width": "10%", "render": $.fn.dataTable.render.number(',', '.', 2), "className": "dt-body-right"}
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    });
}
