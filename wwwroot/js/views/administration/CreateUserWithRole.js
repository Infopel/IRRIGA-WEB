$(document).ready(function () {
    $('.select2').select2();
    const getInqueritos = () => {
        $.ajax({
            type: "GET",
            url: "/Inquerito/GetInqueritos",
            data: "{}",
            success: function (data) {
                const inqueirtos = data.d;
                dropwonInqueritoValue = '';
                for (let i = 0; i < inqueirtos.length; i++) {
                    dropwonInqueritoValue += '<option value="' + inqueirtos[i].id + '">' + inqueirtos[i].name + '</option>';
                }
                $("#IdInqueritos").html(dropwonInqueritoValue);
            }
        });
    };
    getInqueritos();

    const getRegadios = () => {
        $.ajax({
            type: "GET",
            url: "/Regadio/GetRegadios",
            data: "{}",
            success: function (data) {
                const regadios = data.d;
                dropwonRegadiosValue = '';
                for (let i = 0; i < regadios.length; i++) {
                    dropwonRegadiosValue += '<option value="' + regadios[i].id + '">' + regadios[i].name + '</option>';
                }
                $("#IdRegadios").html(dropwonRegadiosValue);
            }
        });
    };
    getRegadios();

    const getEscolas = () => {
        $.ajax({
            type: "GET",
            url: "/Escola/GetEscolas",
            data: "{}",
            success: function (data) {
                const escolas = data.d;
                dropwonRegadiosValue = '';
                for (let i = 0; i < escolas.length; i++) {
                    dropwonRegadiosValue += '<option value="' + escolas[i].id + '">' + escolas[i].name + '</option>';
                }
                $("#IdEscolas").html(dropwonRegadiosValue);
            }
        });
    };
    getEscolas();

    const getAssociacoes = () => {
        $.ajax({
            type: "GET",
            url: "/Associacao/GetAssociacoes",
            data: "{}",
            success: function (data) {
                const associacoes = data.d;
                dropwonRegadiosValue = '';
                for (let i = 0; i < associacoes.length; i++) {
                    dropwonRegadiosValue += '<option value="' + associacoes[i].id + '">' + associacoes[i].name + '</option>';
                }
                $("#IdAssociacaoes").html(dropwonRegadiosValue);
            }
        });
    };
    getAssociacoes();
})