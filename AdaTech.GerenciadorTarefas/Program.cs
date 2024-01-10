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
lana.CriarTarefa("Daora", TarefaArea.Frontend,TarefaEstado.NãoIniciada);
lana.CriarTarefa("Banuina", TarefaArea.Frontend, TarefaEstado.NãoIniciada);
lana.CriarTarefa("Papapapa", TarefaArea.Frontend, TarefaEstado.NãoIniciada);
lana.CriarTarefa("Banzinga", TarefaArea.Backend, TarefaEstado.NãoIniciada);


// Inicialização estatisticas
EstatisticasTarefas estatisticasFront = new EstatisticasTarefas(TarefaArea.Frontend);
EstatisticasTarefas estatisticasBack= new EstatisticasTarefas(TarefaArea.Backend);

string dbJsonContent = ReadDbJson();

// Print the contents of db.json
Console.WriteLine("Contents of db.json:");
Console.WriteLine(dbJsonContent);

estatisticasFront.MostrarTarefasArea();


// Exemplo de como colocar Deadlines nas tarefas
techie.ColocarDeadline(EstatisticasTarefas.TarefasStaticEstatisticas
.FirstOrDefault(x => x.TarefaId == 1), DateTime.Now);

estatisticasFront.MostrarTarefasArea();
static string ReadDbJson()
{
    var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json");
    string dbJsonContent = File.ReadAllText(path);
    return dbJsonContent;
}
