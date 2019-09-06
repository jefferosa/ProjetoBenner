var j;
var data = new Date().toLocaleDateString();
for (j = 0; j < 30; j += 3) {
    var teste = $(".diaTeste" + j).text();
    if (teste == data) {
        $("#ativar").addClass("active");
    }
}


var pegaValClick;
$(".pegaHoraFuncionario").click(function () {
    var horaDia = $(this).text();
    console.log(horaDia);
    $('#horaSelecionadaFuncionario').val(horaDia);

    var dataDia = $(this).data("dia");
    $('#dataFuncionario').val(dataDia);

    pegaValClick = $(this);
});

function AgendarHorario() {
    var horaSelecionada = $("#horaSelecionadaFuncionario").val();
    var data = $("#data").val();
    var servicoId = $('#servico').val();
    var clienteId = $("#clienteId").text();
    console.log(clienteId);

    $.ajax({
        type: 'POST',
        dataType: 'json',
        cache: false,
        url: Url.Action("AgendarHorario", "Agenda"), // webmethod or web serivces URL
        data: {
            HoraSelecionada: horaSelecionada,
            Data: data,
            ServicoId: servicoId,
            ClienteId: clienteId
        },
        complete:
            function validar(jqXHR, resposta) {
                if (jqXHR.responseJSON == true) {
                    pegaValClick.addClass("bg-success");
                    pegaValClick.removeAttr("data-toggle");
                    alert("Sucesso ao agendar Horario");
                } else {
                    pegaValClick.addClass("bg-warning");
                    alert("Falha ao Agendar Horario");
                }
            },
    }
    )
};