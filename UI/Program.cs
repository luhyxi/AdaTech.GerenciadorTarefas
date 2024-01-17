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
1 - Adicionar Desenvolvedor
2 - Colocar deadline em tarefa
3 - Criar Tarefa");
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
            techLeaderController.CriarTarefa();
            break;
        default:
            return;
    }
}