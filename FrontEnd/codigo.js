$(document).ready(function () {
    $.ajax({
        url: "https://localhost:5001/Deporte/ObtenerDeporte",
        type: "GET",
        success: function (result) {
            if (result.ok) {
                
            } else {
                cargarComboDeportes(result.return);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
});

function cargarComboDeportes(datos) {
    select = document.getElementById("cboDeportes");
    for (let i = 0; i < datos.length; i++) {
        var option = document.createElement('option');
        option.text = datos[i].nombre;
        option.value = datos[i].idDeporte;
        select.add(option);
    }
}

$("#btnRegistrar").click(function () {

    let nombre = $("#txtNombre").val();
    let apellido = $("#txtApellido").val();
    let calle = $("#txtCalle").val();
    let numero = $("#txtNumero").val();
    let deportes = $("#cboDeportes").val();

    if (nombre === "") {
        swal("Mal!", "Ingresa un nombre", "error");
    }
    else if (apellido === "") {
        swal("Mal!", "Ingresa un apellido", "error");
    }
    else if (calle === "") {
        swal("Mal!", "Ingresa una calle", "error");
    }
    else if (numero === "") {
        swal("Mal!", "Ingresa un numero", "error");
    }
    else if (deportes === "0") {
        swal("Mal!", "Seleccione un deporte", "error");
    }
    else {
        CargarSocio(nombre, apellido, calle, numero, deportes);
        swal("Buen trabajo", "Se registro tu socio", "success");
    }
});

function CargarSocio(nombre, apellido, calle, numero, deportes) {
    comando = {
        "nombre": nombre,
        "apellido": apellido,
        "calle": calle,
        "numero": numero,
        "idDeporte": deportes
    }
    $.ajax({
        url: "https://localhost:5001/Socio/CargarSocio",
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(comando),
        success: function (result) {
            if (result.ok) {
            }
            else {
                result.ok = false;
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

