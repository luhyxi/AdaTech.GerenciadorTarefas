// See https://aka.ms/new-console-template for more information
using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using AdaTech.GerenciadorTarefas.Usuarios;

TechLeader techie = new TechLeader("fredie", null);
Desenvolvedor lana = new Desenvolvedor("lana", null);
Desenvolvedor basic = new Desenvolvedor("basic", null);
techie.AdicionarDev(lana.ConvertJsonDTOToObject());
techie.AdicionarDev(basic.ConvertJsonDTOToObject());

lana.CriarTarefa("Daora", TarefaArea.Frontend,TarefaEstado.NãoIniciada, DateTime.Now);


string dbJsonContent = ReadDbJson();

// Print the contents of db.json
Console.WriteLine("Contents of db.json:");
Console.WriteLine(dbJsonContent);

static string ReadDbJson()
{
    var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json");
    string dbJsonContent = File.ReadAllText(path);
    return dbJsonContent;
}
