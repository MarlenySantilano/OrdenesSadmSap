let customerId = 0;
$(function () {
    initializedDataTable()
    var row = $("#WebGrid TBODY tr:eq(0)");
    if ($("#WebGrid TBODY tr").length > 1) {
        row.remove();
    } else {
        row.find(".label").html("");
        row.find(".text").val("");
        row.find(".link").hide();
    }
});
function AppendRow(row, isUsuario, nombre,email,password) {
    //Bind CustomerId.
    $(".id", row).find(".label").html(isUsuario);
    $(".id", row).find(".text").val(isUsuario);
    //Bind Name.
    $(".nombre", row).find(".label").html(nombre);
    $(".nombre", row).find(".text").val(nombre);

    $(".email", row).find(".label").html(email);
    $(".email", row).find(".text").val(email);

    $(".password", row).find(".label").html(password);
    $(".password", row).find(".text").val(password);

    row.find(".link").show();
    $("#WebGrid TBODY").append(row);
};

//Add event handler.
$("body").on("click", "#btnAdd", function () {

    var txtName = $("#txtName");
    var txtEmail = $("#txtEmail");
    var txtPassword = $("#txtPassword");
  
    if (txtName.val() !== "" & txtEmail.val !== "" & txtPassword.val !== "") {
        $.ajax({
            type: "POST",
            url: "/Usuarios/InsertUsuario",
            data: '{nombre: "' + txtName.val() +
                '", email: "' + txtEmail.val() +
                '", password: "' + txtPassword.val() +
                '"}',        
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                debugger;
               
            }
             
        });
        setTimeout(function () {
            swal({
                title: "Usuario creado con exito!",

            })
            setTimeout(function () {

                location.reload();
            }, 1000);
        }, 1000);
       
    } else {

        swal({
            title: "Llenar campo de texto",

        })
    }
});

//Edit event handler.
$("body").on("click", "#WebGrid TBODY .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find(".text").length > 0) {
            $(this).find(".text").show();
            $(this).find(".label").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();
});

//Update event handler.
$("body").on("click", "#WebGrid TBODY .Update", function () {
 
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find(".text").length > 0) {
            var span = $(this).find(".label");
            var input = $(this).find(".text");
            span.html(input.val());
            span.show();
            input.hide();
            span.addClass("initialized");
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();

    var usuario = {};

    usuario.id = row.find(".id").find(".label").html();
    usuario.nombre = row.find(".nombre").find(".label").html();
    usuario.email = row.find(".email").find(".label").html();
    usuario.password = row.find(".password").find(".label").html();
    console.log("**********+")
    console.log(usuario)
    $.ajax({
        type: "POST",
        url: "/Usuarios/UpdateUsuario",
        data: '{user_values: ' + JSON.stringify(usuario) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});

//Cancel event handler.
$("body").on("click", "#WebGrid TBODY .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find(".text").length > 0) {
            var span = $(this).find(".label");
            var input = $(this).find(".text");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//Delete event handler.
$("body").on("click", "#WebGrid TBODY .Delete", function () {

    var row = $(this).closest("tr");
    customerId = row.find(".label").html();
    swal({
        title: "Seguro de eliminar usuario?",
        // text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: ["No!",
            "SI"
        ],
        dangerMode: true,
    })
        .then((willDelete) => {

            if (willDelete) {

                swal("Se elimino el usuario", {
                    icon: "success",
                });
                setTimeout(function () {
                    $.ajax({
                        type: "POST",
                        url: "/Usuarios/DeleteUsuario",
                        data: '{id: ' + customerId + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            if ($("#WebGrid TBODY tr").length == 1) {
                                row.find(".label").html("");
                                row.find(".text").val("");
                                row.find(".link").hide();
                            } else {
                                row.remove();
                            }
                            /*setTimeout(function () {
                                location.replace("/Usuarios");
                            }, 1000);
                            */
                        }
                    });
                }, 2000);
              
                setTimeout(function () {

                    location.reload();
                }, 2000);
            
            }

            else {


            }

        });  
    
});

function initializedDataTable() {

    oTable = $('#WebGrid').dataTable({
        "dom": 'ftipr',
        "language": {
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente"
            },
            //"url": "/Scripts/translation/spanish.json",
            "search": '', searchPlaceholder: "Buscar",
            //"previous":  "Anterior"
        }
    });

    $("tfoot input").keyup(function () {
        /* Filter on the column (the index) of this element */
        oTable.fnFilter(this.value, $("tfoot input").index(this));
    });
    /*
     * Support functions to provide a little bit of 'user friendlyness' to the textboxes in
     * the footer
     */
    $("tfoot input").each(function (i) {
        asInitVals[i] = this.value;
    });
    $("select[name='WebGrid_length']").val('10');
    $("select[name='WebGrid_length']").addClass("initialized");
    //$("select[name='WebGrid_length']").material_select();
}