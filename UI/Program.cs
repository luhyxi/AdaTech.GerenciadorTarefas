using AdaTech.GerenciadorTarefas.Usuarios;
using Sistema.Autentificacao;
using System.Data;
using Sistema.UI;
using Sistema.Options;

var authAtual = new AuthTechLead(); // Autentificação
var usuarioAtual = authAtual.techLeadAtual; // Usuario/Techlead
var techLeaderController = new TechLeaderController(usuarioAtual); // Controler



do
{
    int choice = ReceiveOptions();
    SelectOption(choice);

} while (authAtual.IsAuthenticated == true);



int ReceiveOptions()
{
    Console.WriteLine($@"
1 - Adicionar Desenvolvedor
2 - Colocar deadline em tarefa
");
    return GeneralUtils.ReadOption(1, 10);
}

void SelectOption(int select)
{
    switch (select)
    {
        default:
            techLeaderController.AdicionarDev();
            break;
    }
}