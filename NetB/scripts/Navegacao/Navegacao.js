function HomeIndex() {
    updatePanelGet('../Home/Index',HomeIndexCallback);
}

function HomeIndexCallback(data){
    var container = $("html").html(data);
}
function LoginIndex() {
    var parametros = new Object;
    parametros.Senha = $('#senha').val();    
    parametros.Email = $('#login').val();
    updatePanelPost('../Login/Index', parametros, LoginIndexCallBack);
}

function LoginIndexCallBack(data)
{
    var container = $("html").html(data);
}

function NavegacaoMacro() {
    updatePanelGet('../Tarefas/TarefasPorUsuarios', NavegacaoMacroCallback);
}

function NavegacaoMacroCallback(data)
{
    var container = $('.container').html(data);
}

function NavegacaoCalendario() {
    updatePanelGet('../Calendario/Index', NavegacaoCalendarioCallback);
}

function NavegacaoCalendarioCallback(data) {
    $('.container').html(data);
}

function CarregaCalendario()
{
    debugger;
    $(document).ready(function () {

        $('#calendar').fullCalendar({
            locale: 'pt-br',
            events: '../Calendario/Eventos/',
            eventClick: function (event, element) {
                BuscaEventoModal(event.id);
                $('#calendar').fullCalendar('updateEvent', event);
            },
            //eventRender: function (event, element) {
            //    element.qtip({
            //        content: event.descricao,
            //        content: event.responsavel,
            //        content: event.projeto
            //    });
            //},
        });
        $(function () {
            $("#datepicker").datepicker();
        });
    });
}

function NavegacaoTarefasProjeto() {
    updatePanelGet('../Tarefas/TarefasPorProjeto', NavegacaoTarefasProjetoCallback);
}

function NavegacaoTarefasProjetoCallback(data) {
    $('.container').html(data);
}

function NavegacaoGraficoHoras() {
    updatePanelGet('../Graficos/GraficoHoras', NavegacaoGraficoHorasCallback);
}

function NavegacaoGraficoHorasCallback(data) {
    $('.container').html(data);
}

function NavegacaoGraficoCusto() {
    updatePanelGet('../Graficos/GraficoCusto', NavegacaoGraficoCustoCallback);
}

function NavegacaoGraficoCustoCallback(data) {
    $('.container').html(data);
}

function NavegacaoGraficoTarefas() {
    updatePanelGet('../Graficos/GraficoTarefas', NavegacaoGraficoTarefasCallback);
}

function NavegacaoGraficoTarefasCallback(data) {
    $('.container').html(data);
}

function NavegacaoUsuarios() {
    updatePanelGet('../Usuarios/Index', NavegacaoUsuariosCallback);
}

function NavegacaoUsuariossCallback(data) {
    $('.container').html(data);
}


function BuscaEventoModal(data) {
    updatePanelGet('../Calendario/BuscaTarefaDetalhes?id='+data, BuscaEventoModalCallback);
}
function BuscaEventoModalCallback(data) {
    $('#numero').val(data.id);
    $('#titulo').html(data.nome);
    $('#descricao').html("<span>Descrição: </span>"+data.descricao);
    $('#projeto').html("<span>Projeto: </span>"+data.projeto);
    $('#responsavel').val(data.responsavel_id);
    $('#datepicker').datepicker('setDate', new Date(data.previsao));
    $('#basic').modal('show');
}

function AtualizaTarefa() {
    var tarefa = new Object;
    tarefa.id = $('#numero').val();
    tarefa.responsavel_id = $('#responsavel').val();
    tarefa.previsao = $('#datepicker').val();
    updatePanelPost('../Calendario/GravaTarefaDetalhe', tarefa, AtualizaTarefaCallback);
}
function AtualizaTarefaCallback(data) {

}

function BuscaTarefas() {
    var projeto = $('#select').val();
    updatePanelGet("../Tarefas/BuscaTarefas?idProjeto=" + projeto, BuscaTarefasCallback, true, true);
}

function BuscaTarefasCallback(data) {

    var container = $("#tabelaBody");
    data.forEach(function (item) {
        var content = "<tr>" +
            '<td>' + item.nome + '</td>' +
            '<td>' + item.projeto + '</td>' +
            '<td>' + new Date(item.previsao).getDate() + '</td>' +
            '<td>' + item.observacoes + '</td>' +
        '</tr>'
        container.html(content);
    });

}

function BuscaHoras() {
    var projeto = $('#select').val();
    updatePanelGet("../Graficos/BuscaHorasProjeto?idProjeto=" + projeto, BuscaHorasCallback, true, true);
}

function BuscaHorasCallback(data) {

    var ctx = $("#myChart");
    var myChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: ["Horas Estimadas", "Horas Trabalhadas"],
            datasets: [{
                label: '# Horas',
                data: data,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero:true
                    }
                }],
                xAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function BuscaCusto() {
    var projeto = $('#select').val();
    updatePanelGet("../Graficos/BuscaCustoProjeto?idProjeto=" + projeto, BuscaCustoCallback, true, true);
}

function BuscaCustoCallback(data) {

    var ctx = $("#myChart");
    var myChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: ["Valor Estimado", "Valor Real"],
            datasets: [{
                label: 'Custo',
                data: data,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
                xAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function BuscaContagemTarefas() {
    var projeto = $('#select').val();
    updatePanelGet("../Graficos/BuscaTarefasProjeto?idProjeto=" + projeto, BuscaContagemTarefasCallback, true, true);
}

function BuscaContagemTarefasCallback(data) {

    var ctx = $("#myChart");
    // For a pie chart
    var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: [
                "Tarefas Agendadas",
                "Tarefas Atrasadas",
                "Tarefas Concluidas"
            ],
            datasets: [
                {
                    data: data,
                    backgroundColor: [
                        "#FF6384",
                        "#36A2EB",
                        "#FFCE56"
                    ],
                    hoverBackgroundColor: [
                        "#FF6384",
                        "#36A2EB",
                        "#FFCE56"
                    ]
                }]
        }
    });
}

