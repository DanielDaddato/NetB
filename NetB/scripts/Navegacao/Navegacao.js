function HomeIndex() {
    updatePanelGet('../Home/Index',HomeIndexCallback);
}

function HomeIndexCallback(data){
    var container = $("body").html(data);
}
function LoginIndex() {
    var parametros = new Object;
    parametros.Senha = $('#senha').val();    
    parametros.Email = $('#login').val();
    updatePanelPost('../Login/Index', parametros, LoginIndexCallBack);
}

function LoginIndexCallBack(data)
{
    var container = $("body").html(data);
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

function NavegacaoUsuariosCallback(data) {
    $('.container').html(data);
}

function NavegacaoResponsaveis() {
    updatePanelGet('../Responsavel/Index', NavegacaoResponsaveisCallback);
}

function NavegacaoResponsaveisCallback(data) {
    $('.container').html(data);
}

function NavegacaoListaTarefas() {
    updatePanelGet('../Tarefas/ListaTarefas', NavegacaoListaTarefasCallback);
}

function NavegacaoListaTarefasCallback(data) {
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

function NovoUsuarioModal() {
    $('#numero').val(null);
    $('#nome').val('');
    $('#email').val('');
    $('#senha').val('');
    $('#departamento').val(0);
    $('#basic').modal('show');
}

function EditarUsuarioModal(data) {
    updatePanelGet('../Usuarios/Editar?id=' + data, EditarUsuarioModalCallback);
}
function EditarUsuarioModalCallback(data) {
    $('#numero').val(data.id);
    $('#nome').val(data.nome);
    $('#email').val(data.senha);
    $('#senha').val(data.senha);
    $('#departamento').val(data.departamento_id);
    $('#basic').modal('show');
}

function GravaUsuario() {
    var data = new Object();
    data.id = $('#numero').val();
    data.nome = $('#nome').val();
    data.email = $('#email').val();
    data.senha = $('#senha').val();
    data.departamento_id = $('#departamento').val();
    updatePanelPost('../Usuarios/Gravar', data, GravaUsuarioCallback);
    $('#basic').modal("hide");
}

function GravaUsuarioCallback(data) {
    if (data != 0) {
        NavegacaoUsuarios();
        ToastNotification("success", "", "Usuario registrado com sucesso!");

    }
    else {
        ToastNotification("error", "", "Erro ao registrar Usuario!");
    }
}

function DeletaUsuario(data) {
    updatePanelGet('../Usuarios/Deletar?id=' + data, DeletaUsuarioCallback);
}

function DeletaUsuarioCallback(data) {  
    if (data != 0) {
        NavegacaoUsuarios();
        ToastNotification("success", "", "Usuario deletado com sucesso!");

    }
    else {
        ToastNotification("error", "", "Erro ao deletar Usuario!");
    }
}

function NovoResponsavelModal() {
    $('#numero').val(null);
    $('#nome').val('');
    $('#email').val('');
    $('#telefone').val('');
    $('#celular').val('');
    $('#basic').modal('show');
}

function EditarResponsavelModal(data) {
    updatePanelGet('../Responsavel/Editar?id=' + data, EditarUsuarioModalCallback);
}
function EditarResponsavelModalCallback(data) {
    $('#numero').val(data.id);
    $('#nome').val(data.nome);
    $('#email').val(data.email);
    $('#telefone').val(data.telefone);
    $('#celular').val(data.celular);
    $('#basic').modal('show');
}

function DeletaResponsavel(data) {
    updatePanelGet('../Responsavel/Deletar?id=' + data, DeletaResponsavelCallback);
}

function DeletaResponsavelCallback(data) {
    if (data != 0) {
        NavegacaoResponsaveis();
        ToastNotification("success", "", "Responsavel Deletado com Sucesso!");

    }
    else {
        ToastNotification("error", "", "Erro ao deletar Responsavel!");
    }
}

function GravaResponsavel() {
    var data = new Object();
    data.id = $('#numero').val();
    data.nome = $('#nome').val();
    data.email = $('#email').val();
    data.telefone = $('#telefone').val();
    data.celular = $('#celular').val();
    updatePanelPost('../Responsavel/Gravar', data, GravaResponsavelCallback);
    $('#basic').modal("hide");
}

function GravaResponsavelCallback(data) {
    if (data != 0) {
        NavegacaoResponsaveis();
        ToastNotification("success", "", "Responsavel registrado com sucesso!");

    }
    else {
        ToastNotification("error", "", "Erro ao registrar Resonsavel!");
    }
    
}


function AtualizaTarefa() {
    var tarefa = new Object;
    tarefa.id = $('#numero').val();
    tarefa.responsavel_id = $('#responsavel').val();
    tarefa.previsao = $('#datepicker').val();
    tarefa.justificativa = $('#justificativa').val();
    updatePanelPost('../Calendario/GravaTarefaDetalhe', tarefa, AtualizaTarefaCallback);
    $('#basic').modal("hide");
}
function AtualizaTarefaCallback(data) {
    if (data != 0) {
        NavegacaoCalendario();        
        ToastNotification("success", "", "Tarefa alterada com sucesso!");
        
    }
    else {
        ToastNotification("error", "", "Erro ao alterar Tarefa!");
    }
}

function BuscaTarefas() {
    var projeto = $('#select').val();
    updatePanelGet("../Tarefas/BuscaTarefas?idProjeto=" + projeto, BuscaTarefasCallback, true, true);
}

function BuscaTarefasCallback(data) {
    $("#tabelaBody").empty();
    var container = $("#tabelaBody");
    data.forEach(function (item) {
        var inicio = new Date(item.inicio);
        var previsao = new Date(item.previsao);
        var myDate = new Date;
        if (item.conclusao !== "") {
            item.statusCor = "Green";
            item.conclusao = new Date(item.conclusao).toLocaleDateString();
        }
        else if (previsao < myDate) {
            item.statusCor = "Red";
        }
        else if (previsao >= myDate.setDate(myDate.getDate() - 7) && previsao <= myDate) {
            item.statusCor = "Yellow";
        }
        else {
            item.statusCor = "Blue";
        }
        var content = "<tr>" +
            '<td>' + item.nome + '</td>' +
            '<td>' + item.responsavel_id + '</td>' +
            '<td>' + item.descricao + '</td>' +
            '<td>' + inicio.toLocaleDateString() + '</td>' +
            '<td><span style="color:' + item.statusCor + '">' + previsao.toLocaleDateString() + '</span></td>' +
            '<td>' + item.conclusao + '</td>' +
            '<td>' + item.observacoes + '</td>' +
        '</tr>'
        container.append(content);
    });

}

function BuscaHoras() {
    var projeto = $('#select').val();
    updatePanelGet("../Graficos/BuscaHorasProjeto?idProjeto=" + projeto, BuscaHorasCallback, true, true);
}

function BuscaHorasCallback(data) {

    var ctx = $("#myChart");
    var dados = new Array();
    data.forEach(function (item) {
        dados.push(
            {
                label: item.Nome,
                data: [item.Estimado, item.Real],
                borderWidth: 1,
                borderColor: item.Cor,
                backgroundColor: item.Cor,
            });
    })
    var myChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: ["Man-Days Projetado", "Man-Days Executados"],
            datasets:dados
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero:true
                    },
                    stacked: true
                }],
                xAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    stacked: true
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
    var dados = new Array();
    data.forEach(function (item) {
        dados.push(
            {
                label: item.Nome,
                data: [item.Estimado, item.Real],
                borderWidth: 1,
                borderColor: item.Cor,
                backgroundColor: item.Cor,
            });
    })
    var myChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: ["Custo Projetado", "Custo Real"],
            datasets: dados
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    stacked: true
                }],
                xAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    stacked:true
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
                        "#FFCE56",
                        "#FF6384",
                        "#36A2EB",
                    ],
                    hoverBackgroundColor: [
                        "#FFCE56",
                        "#FF6384",
                        "#36A2EB",
                        
                    ]
                }]
        }
    });
}

function BuscaHorasGeral() {
    updatePanelGet("../Graficos/HorasGeral", BuscaHorasGeralCallback, true, true);
}

function BuscaHorasGeralCallback(data) {
    $('.container').html(data);
    BuscaDadosHorasGeral();
}

function BuscaDadosHorasGeral() {
    updatePanelGet("../Graficos/BuscaHorasGeral", BuscaDadosHorasGeralCallback, true, true);
}

function BuscaDadosHorasGeralCallback(data) {
    var dados = new Array();
    data.ListaDataset.forEach(function (item) {
        dados.push(
            {
                label: item.Nome,
                data: item.Estimado,
                borderWidth: 1,
                borderColor: item.Cor,
                backgroundColor: item.Cor,
                stack: 1
            });
        dados.push(
            {
                label: item.Nome,
                data: item.Realizado,
                borderWidth: 1,
                borderColor: item.Cor,
                backgroundColor: item.Cor,
                stack: 2
            });
    });
    Chart.defaults.groupableBar = Chart.helpers.clone(Chart.defaults.bar);

    var helpers = Chart.helpers;
    Chart.controllers.groupableBar = Chart.controllers.bar.extend({
        calculateBarX: function (index, datasetIndex) {
            // position the bars based on the stack index
            var stackIndex = this.getMeta().stackIndex;
            return Chart.controllers.bar.prototype.calculateBarX.apply(this, [index, stackIndex]);
        },

        hideOtherStacks: function (datasetIndex) {
            var meta = this.getMeta();
            var stackIndex = meta.stackIndex;

            this.hiddens = [];
            for (var i = 0; i < datasetIndex; i++) {
                var dsMeta = this.chart.getDatasetMeta(i);
                if (dsMeta.stackIndex !== stackIndex) {
                    this.hiddens.push(dsMeta.hidden);
                    dsMeta.hidden = true;
                }
            }
        },

        unhideOtherStacks: function (datasetIndex) {
            var meta = this.getMeta();
            var stackIndex = meta.stackIndex;

            for (var i = 0; i < datasetIndex; i++) {
                var dsMeta = this.chart.getDatasetMeta(i);
                if (dsMeta.stackIndex !== stackIndex) {
                    dsMeta.hidden = this.hiddens.unshift();
                }
            }
        },

        calculateBarY: function (index, datasetIndex) {
            this.hideOtherStacks(datasetIndex);
            var barY = Chart.controllers.bar.prototype.calculateBarY.apply(this, [index, datasetIndex]);
            this.unhideOtherStacks(datasetIndex);
            return barY;
        },

        calculateBarBase: function (datasetIndex, index) {
            this.hideOtherStacks(datasetIndex);
            var barBase = Chart.controllers.bar.prototype.calculateBarBase.apply(this, [datasetIndex, index]);
            this.unhideOtherStacks(datasetIndex);
            return barBase;
        },

        getBarCount: function () {
            var stacks = [];

            // put the stack index in the dataset meta
            Chart.helpers.each(this.chart.data.datasets, function (dataset, datasetIndex) {
                var meta = this.chart.getDatasetMeta(datasetIndex);
                if (meta.bar && this.chart.isDatasetVisible(datasetIndex)) {
                    var stackIndex = stacks.indexOf(dataset.stack);
                    if (stackIndex === -1) {
                        stackIndex = stacks.length;
                        stacks.push(dataset.stack);
                    }
                    meta.stackIndex = stackIndex;
                }
            }, this);

            this.getMeta().stacks = stacks;
            return stacks.length;
        },
    });

    var dataGraf = {
        labels: data.Projetos,
        datasets: dados
    };

    var ctx = document.getElementById("myChart").getContext("2d");
    new Chart(ctx, {
        type: 'groupableBar',
        data: dataGraf,
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    },
                    stacked: true,
                }]
            }
        }
    });
}

function BuscaListaTarefas() {
    var projeto = $('#select').val();
    updatePanelGet("../Tarefas/BuscaListaTarefas?idProjeto=" + projeto, BuscaListaTarefasCallback, true, true);
}

function BuscaListaTarefasCallback(data) {
    $('tarefas').html(data);
}

