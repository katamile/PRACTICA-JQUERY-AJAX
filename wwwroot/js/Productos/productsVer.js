// Exporta correctamente la función 'cargarProducto'
export function cargarProducto(id) {
    $.ajax({
        url: `/Products/VerProducto/${id}`,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data !== null) {
                // Llenar los campos del modal con los datos del producto
                $('#tituloProducto').text(data.titulo);
                $('#descripcionProducto').text(data.descripcion);
                $('#pvpProducto').text(data.precio);
                $('#categoriaProducto').text(data.category.nombre);
                $('#imagenProducto').attr('src', data.images[0]);
            } else {
                mostrarMensaje("No se encontró el producto.");
            }
        },
        error: function () {
            mostrarMensaje("Error al cargar el producto.");
        }
    });
}


function mostrarMensaje(mensaje) {
    $('#mensaje').text(mensaje);
}

