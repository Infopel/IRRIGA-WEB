$(document).ready(function () {
    $('.select2').select2();
    let userCanais;
    let saveCanais;
    let setCanais = [];

    const getCanals = () => {
        $.ajax({
            type: "GET",
            data: "{}",
            url: "/api/Canals/getCanaisUserBy/" + location.href.split('/').pop(),
            success: function (data) {
                userCanais = data.result;

                if (userCanais.length == 0) {
                    $('.display-if').show();
                } else {
                    $('.display-if').hide();
                    var trHTML = '';
                    $.each(data.result, function (i, item) {
                        trHTML += '<tr><td>' + (i + 1) + '</td><td>' + item.name + '</td></tr>';
                    });
                    $('#records_table').append(trHTML);
                }

            }
        });
    };
    getCanals();

    const getAllCanals = () => {
        $.ajax({
            type: "GET",
            url: "/api/Canals",
            data: "{}",
            success: function (data) {
                dropwonValue = '';
                for (let i = 0; i < data.length; i++) {
                    dropwonValue += '<option value="' + data[i].id + '">' + data[i].designacao + '</option>';
                }
                $("#IdCanal").html(dropwonValue);
                $.each(userCanais, function (i, item) {
                    setCanais.push(item.id)
                });

                $("#IdCanal").val(setCanais).trigger('change');
            }
        });
    };
    setTimeout(() => {
        getAllCanals();
    }, 1000);


    $('#IdCanal').on('input', function () {
        const canal = $('#IdCanal').val();
        if (canal.length >= 1) {
            $(".isDisabled ").prop("disabled", false);
        } else {
            $(".isDisabled ").prop("disabled", true);
        }
    })

    $('.canceling').on('click', function () {
        $("#IdCanal").val(saveCanais).trigger('change');
        $(".isDisabled ").prop("disabled", true);
    })

    const saveUpdateCanal = () => {

        const usuario = {
            IdUserAsp: location.href.split('/').pop(),
            NewIdCanais: $("#IdCanal").val(),
            OldIdCanais: setCanais
        }

        $.ajax({
            url: "/api/Canals/usuarioCanalUpdate",
            type: "post",
            data: { usuario: usuario },
            success: function (data) {
                swal.close();
                if (parseInt(data.data) == -1) {
                    $('.canceling').click();
                    Swal.fire({
                        icon: 'error',
                        title: 'Não foi possível associar o CANAL. Por favor, associe um ROLE primeiro.',
                        showConfirmButton: false,
                        timer: 3000
                    })
                } else {
                    location.reload();
                }

            },
            error: function (xhr, status, error) {
                swal.close();
                console.log(xhr)
            }
        });
    }

    $('.salvarEstado').on('click', () => {
        Swal.fire({
            title: 'Por favor, aguarde !',
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading()
            },
        });
        saveUpdateCanal();
    })
})