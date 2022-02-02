var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#table_programas").DataTable({
        "processing": true,
        "serverSide": true,
        "pageLength": 10,
        "filter": true,
        "responsivePriority": 1,
        "data": null,
        "ajax": {
            "url": "/Programa/Json",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "programaId", "name": "programaId", "autoWidth": true },
            { "data": "nombre", "name": "nombre", "autoWidth": true },
            { "data": "version", "name": "version", "autoWidth": true },
            { "data": "codigo", "name": "codigo", "autoWidth": true },
            {
                "data": "programaId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Programa/Edit/${data}' class='btn btn-outline-success' style='cursor:pointer; width100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            
                            <a onclick=Delete("/Programa/Delete/${data}") class='btn btn-outline-danger' style='cursor:pointer; width100px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                           `;
                },
                "width": "auto"
            }
        ],
        "language": {
            "emptyTable": "No Hay Registros"
        },
        "width": "100%"
    });
};

function Delete(url) {
    Swal.fire({
        title: "Esta seguro de borrar el programa?",
        text: "Este contenido no se puede recuperar!",
        type: "warnig",
        showCancelButton: true,
        confirmButtonColor: "DD6B55",
        confirmButtonText: "si, borrar",
        closeOnconfirm: true
    }).then((e) => {
        if (e.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url
            }).then(e => {
                if (e.success) {
                    toastr.success(e.message);
                    dataTable.ajax.reload()
                } else {
                    toastr.error(data.message);
                    console.log("Error");
                }
            }
            )
        }
    })
}
