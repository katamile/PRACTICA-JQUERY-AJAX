import { cargarProducto } from './productsVer.js';

$(document).ready(function () {
    cargarProductos();
    // Cuando haces clic en el botón "Ver" en la tabla
    $('#tablaProductos').on('click', '.ver-btn', function () {
        var productoId = $(this).data('id'); // Obtener el ID del producto
        cargaProductosjs(productoId); // Llamar a la función para cargar los datos del producto
        $('#detalleProductoModal').modal('show'); // Mostrar el modal
        $('.cerrar-btn').click(function () {
            $('#detalleProductoModal').modal('hide');
        });
        $('.close').click(function () {
            $('#detalleProductoModal').modal('hide');
        });
    });
});

// Función para cargar y mostrar los productos
function cargarProductos() {
    $.ajax({
        url: `/Products/ListaProductos`,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data && data.length > 0) {
                construirTablaProductos(data);
                console.log(data)
            } else {
                mostrarMensaje("No se encontraron productos.");
            }
        },
        error: function () {
            mostrarMensaje("Error al cargar los productos.");
        }
    });
}

// Función para agregar filas de datos a la tabla
function construirTablaProductos(productos) {
    var tabla = '';
    $.each(productos, function (index, producto) {
        tabla += '<tr>';
        tabla += '<td>' + producto.id + '</td>';
        tabla += '<td>' + producto.titulo + '</td>';
        tabla += '<td>' + producto.descripcion + '</td>';
        tabla += '<td>' + producto.precio + '</td>';
        tabla += '<td>' + producto.category.nombre + '</td>';
        tabla += '<td> <img src="' + producto.images[0] + '" width="50px"> </td>';
        tabla += '<td>';
        tabla += '<a class="btn btn-primary btn-sm edit-btn" href="/Products/Edit/' + producto.id + '">Editar</a>';
        tabla += '<a class="btn btn-secondary btn-sm ver-btn" data-id="' + producto.id + '">Ver</a> ';
        tabla += '<a class="btn btn-danger btn-sm borrar-btn" href="/Products/Delete/' + producto.id + '">Eliminar</a>';
        tabla += '</td>';
        tabla += '</tr>';
    });
    // Agrega las filas de datos al tbody de la tabla
    $('#tablaProductos').html(tabla);
}

/* Función para mostrar mensajes de error o información*/
function mostrarMensaje(mensaje) {
    $('#mensaje').text(mensaje);
}

function cargaProductosjs(productoId) {
    cargarProducto(productoId);
}