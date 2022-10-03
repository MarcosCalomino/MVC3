var datatable;

$(document).ready(function () {
    loadDataTable();
    var id = document.getElementById("clienteId");
    if (id.value > 0) {
        $('#myModal').modal('show');
    }
});

function limpiar() {
    var clienteId = documento.getElementById("clienteId");
    var clienteNombres = document.getElementById("clienteNombres");
    var clienteApellidos = document.getElementById("clienteApellidos");
    var clienteDireccion = document.getElementById("clienteDireccion");
    var clienteTelefono = document.getElementById("clienteTelefono");
    var clienteEstado = document.getElementById("clienteEstado");

    clienteId.value = 0;
    clienteNombres.value = "";
    clienteApellidos.value = "";
    clienteDireccion.value = "";
    clienteTelefono.value = "";
    clienteEstado.value = "";
}

function loadDataTable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Cliente/ObtenerTodos"
        },
        "columns": [
            { "data": "nombre", "width": "20%" },
            { "data": "apellidos", "width": "20%" },
            { "data": "direccion", "width": "20%" },
            { "data": "telefono", "width": "20%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "width": "10%",
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div>
                         <a href="/Cliente/Crear/${data}" class="btn btn-sucess text-white" style="cursor:pointer;">
                            Editar
                         </a>
                       </div>
                    `;
                }, "width": "10%"
            }   
        ]
    });
}