var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#prodTable').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "id",
              "render": function (data) {
                 return 
                  `
                     <div>
                         <a href="/Admin/Product/Upsert?id=" class="btn btn-primary">Edit</a>
                         <a class="btn btn-secondary">Delete</a>
                     </div>
                     `;
              },
              "width": "15%"
        }
        ]
    });
}