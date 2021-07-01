let customerId = 0;
let codDpto = "";
let med_ref = "";
let ModalEdit = $("#modal_edit");
let btnSearchContrato = $("#Btn_buscar");
let contrato_input = $('#txtContrato_Val');
$(function () {
    GetMunicipiosSadm()

});
function GetMunicipiosSadm() {
    let data = { destino: "" };
    var url = "/Reportes/GetMunicipios";
    fetch(url, {
        method: "post",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(data)
    }).then(function (response) {
        return response.json().then(function (response) {
            var option = '<option value="0" selected>Selecciona una Opcion</option>';
            $('#txtMunicipio').append(option);
            $.each(response, function (i, r) {
                var option = '<option value="' + r.COD_DEPTO + '">' + r.NOM_DEPTO + '</option>';
                $('#txtMunicipio').append(option);
            });
        });
    }).catch(function (err) {
        console.log(err);
    });
}
$('#txtReferencia_Medio').change(function () {
    var Medio_Rep = $("#txtReferencia_Medio option:selected").val();
    med_ref = Medio_Rep
    console.log("************++");
    console.log(Medio_Rep);

    if (Medio_Rep == "1") {
        $('#Div_Direccion').removeClass("hide");
        $('#Div_Contratos').addClass("hide");
    }
    if (Medio_Rep == "2") {
        $('#Div_Contratos').removeClass("hide");
        $('#Div_Direccion').addClass("hide");
    }
    if (Medio_Rep == "0") {
        $('#Div_Direccion').addClass("hide");
        $('#Div_Contratos').addClass("hide");
    }
   
})
$('#txtMunicipio').change(function () {
    $('#txtColonia').children().remove();
    $('#txtColonia').removeAttr("readonly");
    var NombreDepto = $('#txtMunicipio option:selected').text();
    $('#Municipio').val(NombreDepto);
    $('#txtMunicipio_V').val(NombreDepto);
    var CodigoDpto = $('#txtMunicipio').val();
    codDpto = CodigoDpto
    let data = { CodigoDpto: CodigoDpto };
    var url = "/Reportes/GetColonias";
    fetch(url, {
        method: "post",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(data)
    }).then(function (response) {
        return response.json().then(function (response) {
            var option = '<option value="0" selected>Selecciona una Opcion</option>';
            $('#txtColonia').append(option);
            $.each(response, function (i, r) {
                //console.log(r);
                var option = '<option value="' + r.COD_LOCAL + '">' + r.NOM_LOCAL + '</option>';
                $('#txtColonia').append(option);
            });
        });
    }).catch(function (err) {
        console.log(err);
    });
})
$('#txtColonia').change(function () {
    $('#txtCalle').children().remove();
    $('#txtCalle').removeAttr("readonly");
    var NombreColonia = $('#txtColonia option:selected').text();
    $('#Colonia').val(NombreColonia);
    $('#txtColonia_V').val(NombreColonia);
    var Localidad = $('#txtColonia').val();
    let data = { Localidad: Localidad, CodigoDpto: codDpto};
    var url = "/Reportes/GetCalles";
    fetch(url, {
        method: "post",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(data)
    }).then(function (response) {
        return response.json().then(function (response) {
            var option = '<option value="0" selected>Selecciona una Opcion</option>';
            $('#txtCalle').append(option);
            $.each(response, function (i, r) {
                var option = '<option value="' + r.COD_CALLE + '">' + r.NOM_CALLE + '</option>';
                $('#txtCalle').append(option);
            });
        });
    }).catch(function (err) {
        console.log(err);
    });
})
$('#txtCalle').change(function () {
    var NombreCalle = $('#txtCalle option:selected').text();
    $('#Calle').val(NombreCalle);
    $('#txtCalle_V').val(NombreCalle);
})

$("body").on("click", "#btnAdd", function () {

    if (med_ref !== "0") {
        if (med_ref == "1") {

            var Sub_Cat = $("#txtTipoReporte option:selected").val();
            var Municipio = $('#Municipio').val();
            var Colonia = $('#Colonia').val();
            var Calle = $('#Calle').val();
            var Puerta = $("#txtNumE_V").val();
            var Email = "sadm.generico@gmail.com"
            var Comentarios = $('#txtReferencia_V').val();

            if (Sub_Cat !== "0" &&
                Municipio !== "" &&
                Colonia !== "" &&
                Calle !== "" &&
                Puerta !== "" &&
                Email !== "" &&
                Comentarios !== ""
            ) {

                $.ajax({
                    type: "POST",
                    url: "/Reportes/InsertReport",
                    data: '{Sub_Cat: "' + Sub_Cat +
                        '", Municipio: "' + Municipio +
                        '", Colonia: "' + Colonia +
                        '", Calle: "' + Calle +
                        '", Puerta: "' + Puerta +
                        '", Email: "' + Email +
                        '", Comentario: "' + Comentarios +
                        '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        console.log("***********************+")
                        console.log(r.folio)
                        swal({
                            text: "Reporte Creado con Exito!",
                            title: "Se generó el número de reporte:" + r.folio,
                            icon: "success",
                            button: "Aceptar!"
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    setTimeout(function () {

                                        location.reload();
                                    }, 1000);
                                } else {
                                    setTimeout(function () {

                                        location.reload();
                                    }, 1000);
                                }
                            });

                    },
                    error: function (jqXHR, exception) {
                        swal({
                            title: "Ocurrio un error al generar reporte!",
                            icon: "error",
                            button: "Aceptar!"
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    setTimeout(function () {
                                        location.reload();
                                    }, 1000);
                                } else {
                                    setTimeout(function () {
                                        location.reload();
                                    }, 1000);
                                }
                            });
                    }

                });
            } else {
                console.log("******")

                swal({
                    title: "Ingresa los datos requeridos!",

                })
            }
        } else
        {

            var Sub_Cat = $("#txtTipoReporte option:selected").val();
            var Email = "sadm.generico@gmail.com"
            var Comentario = $('#txtReferencia_V').val();
            var Contrato = $('#txtContrato_Val').val();

            if (Sub_Cat !== "0" &&
                Email !== "" &&
                Contrato !== "" &&
                Comentario !== ""
            ) {
                //(string Comentario, string Contrato, string Correo, string Calle, string SubCatego)
                $.ajax({
                    type: "POST",
                    url: "/Reportes/InsertReportNir",
                    data: '{Comentario: "' + Comentario +
                        '", Contrato: "' + Contrato +
                        '", Correo: "' + Email +
                        '", SubCatego: "' + Sub_Cat +
                        '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        console.log("***********************+")
                        console.log(r.folio)
                        swal({
                            text: "Reporte Creado con Exito!",
                            title: "Se generó el número de reporte:" + r.folio,
                            icon: "success",
                            button: "Aceptar!"
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    setTimeout(function () {

                                        location.reload();
                                    }, 1000);
                                } else {
                                    setTimeout(function () {

                                        location.reload();
                                    }, 1000);
                                }
                            });

                    },
                    error: function (jqXHR, exception) {
                        swal({
                            title: "Ocurrio un error al generar reporte!",
                            icon: "error",
                            button: "Aceptar!"
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    setTimeout(function () {
                                        location.reload();
                                    }, 1000);
                                } else {
                                    setTimeout(function () {
                                        location.reload();
                                    }, 1000);
                                }
                            });
                    }

                });
            } else {
                console.log("******")

                swal({
                    title: "Ingresa los datos requeridos!",

                })
            }
        }
    } else {
        
        swal({
            title: "Selecciona referencia!",

        })
    }

    

});

btnSearchContrato.on('click', function () {


    let contrato = $('#txtContrato_Val').val();
    console.log(contrato);

    if (contrato !== "" && contrato.length == 9) {
        $.ajax({
            type: "POST",
            url: "/Reportes/GetContratoDetalle",
            data: '{contrato: "' + contrato +
                '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                console.log("***********************+")
                console.log(r.NIS)
                var Direccion = r.Direccion;
                var Dir = Direccion.split("|");
                var Municipio = Dir[2];
                var Colonia = Dir[1];
                var Calle = Dir[0];
                var numPuerta = Calle.match(/(\d+)/);
                var numPuerta2 = numPuerta[0];
                swal({
                    text: "Resultado exitoso de la busqueda!",
                    title: "Contrato a nombre de:" + r.Nombre,
                    icon: "success",
                    button: "Aceptar!"
                })
                    .then((willDelete) => {
                        if (willDelete) {
                            setTimeout(function () {
                                                         
                                $('#txtMunicipio_V').val(Municipio);
                                $('#txtColonia_V').val(Colonia);
                                $('#txtCalle_V').val(Calle);
                                $('#txtNumE_V').val(numPuerta2);
                            }, 1000);
                        } else {
                            setTimeout(function () {
                         
                                $('#txtMunicipio_V').val(Municipio);
                                $('#txtColonia_V').val(Colonia);
                                $('#txtCalle_V').val(Calle);
                                $('#txtNumE_V').val(numPuerta2);
                            }, 1000);
                        }
                    });

            },
            error: function (jqXHR, exception) {
                swal({
                    title: "Ocurrio un error en la busqueda!",
                    icon: "error",
                    button: "Aceptar!"
                })
                    .then((willDelete) => {
                        if (willDelete) {
                            setTimeout(function () {
                           
                                $('#txtMunicipio_V').val("");
                                $('#txtColonia_V').val("");
                                $('#txtCalle_V').val("");
                                $('#txtNumE_V').val("");
                            }, 1000);
                        } else {
                            setTimeout(function () {

                                $('#txtMunicipio_V').val("");
                                $('#txtColonia_V').val("");
                                $('#txtCalle_V').val("");
                                $('#txtNumE_V').val("");
                            }, 1000);
                        }
                    });
            }

        });
    } else {
        console.log("******")

        swal({
            title: "Ingresa número de contrato!",

        })
    }

});
