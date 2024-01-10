// See https://aka.ms/new-console-template for more information
using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using AdaTech.GerenciadorTarefas.Usuarios;

// Inicialização de devs
TechLeader techie = new TechLeader("fredie", null);
Desenvolvedor lana = new Desenvolvedor("lana", null);
Desenvolvedor basic = new Desenvolvedor("basic", null);
techie.AdicionarDev(lana.ConvertJsonDTOToObject());
techie.AdicionarDev(basic.ConvertJsonDTOToObject());


// Inicialização de Tarefas
lana.CriarTarefa("Daora", TarefaArea.Frontend,TarefaEstado.NãoIniciada, DateTime.Now);
lana.CriarTarefa("Banuina", TarefaArea.Frontend, TarefaEstado.NãoIniciada, DateTime.Now);
lana.CriarTarefa("Papapapa", TarefaArea.Frontend, TarefaEstado.NãoIniciada, DateTime.Now);
lana.CriarTarefa("Banzinga", TarefaArea.Backend, TarefaEstado.NãoIniciada, DateTime.Now);


// Inicialização estatisticas
EstatisticasTarefas estatisticasFront = new EstatisticasTarefas(TarefaArea.Frontend);
EstatisticasTarefas estatisticasBack= new EstatisticasTarefas(TarefaArea.Backend);

string dbJsonContent = ReadDbJson();

// Print the contents of db.json
Console.WriteLine("Contents of db.json:");
Console.WriteLine(dbJsonContent);

estatisticasBack.MostrarTarefasArea();
estatisticasFront.MostrarTarefasArea();
EstatisticasTarefas.MostrarTarefasTodas();
static string ReadDbJson()
{
    var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json");
    string dbJsonContent = File.ReadAllText(path);
    return dbJsonContent;
}
