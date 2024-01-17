using AdaTech.GerenciadorTarefas.Usuarios;
using Sistema.Autentificacao;
using System.Data;
using Sistema.UI;
using Sistema.Controllers;

var authAtual = new AuthTechLead(); // Autentificação
var usuarioAtual = authAtual.techLeadAtual; // Usuario/Techlead
var techLeaderController = new TechLeaderController(usuarioAtual); // Controler



do
{
    Console.Clear();
    int choice = ReceiveOptions();
    SelectOption(choice);

} while (authAtual.IsAuthenticated == true);



int ReceiveOptions()
{
    Console.WriteLine("\n-------DESENVOLVEDORES-------\n");

    DesenvolvedorController.LerEImprimirDesenvolvedores();

    Console.WriteLine("\n-------TAREFAS-------\n");


    EstatisticasController.MostrarTodasAsTarefas();

    Console.WriteLine("\n-------AÇÕES-------");

    Console.WriteLine($@"
1 - Adicionar desenvolvedor
2 - Colocar deadline em tarefa
3 - Criar tarefa
4 - Ver tarefas atribuidas
5 - Imprimir info do usuario");
    return GeneralUtils.ReadOption(1, 10);
}

void SelectOption(int select)
{
    switch (select)
    {
        case 1:
            techLeaderController.AdicionarDev();
            break;
        case 2:
            techLeaderController.ColocarDeadline();
            break;
        case 3:
            techLeaderController.CriarTarefa();
            break;
        case 4:
            techLeaderController.VerTarefasAtribuidas();
            break;
        case 5:
            techLeaderController.ImprimirInformacoesUsuario();
            break;
        default:
            return;
    }
}