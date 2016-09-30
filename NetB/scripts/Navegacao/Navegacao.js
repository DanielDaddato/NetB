function HomeIndex() {
    updatePanelGet('/Home/Index',HomeIndexCallback);
}

function HomeIndexCallback(data){
    var container = $("html").html(data);
}
function LoginIndex() {
    var parametros = new Object;
    parametros.Senha = $('#senha').val();    
    parametros.Email = $('#login').val();
    updatePanelPost('/Login/Index', parametros, LoginIndexCallBack);
}

function LoginIndexCallBack(data)
{
    var container = $("html").html(data);
}

function NavegacaoMacro() {
    updatePanelGet('Tarefas/TarefasPorUsuarios', NavegacaoMacroCallback);
}

function NavegacaoMacroCallback(data)
{
    var container = $('.container').html(data);
}

function NavegacaoCalendario() {
    updatePanelGet('Calendario/Index', NavegacaoCalendarioCallback);
}

function NavegacaoCalendarioCallback(data) {
    var container = $('.container').html(data);
}

