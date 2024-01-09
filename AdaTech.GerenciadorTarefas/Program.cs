// See https://aka.ms/new-console-template for more information
using AdaTech.GerenciadorTarefas.Usuarios;

TechLeader techie = new TechLeader("fredie", null);
Desenvolvedor lana = new Desenvolvedor("lana", null);
Desenvolvedor basic = new Desenvolvedor("basic", null);
techie.AdicionarDev(lana.ConvertJsonDTOToObject());
techie.AdicionarDev(basic.ConvertJsonDTOToObject());



string dbJsonContent = ReadDbJson();

// Print the contents of db.json
Console.WriteLine("Contents of db.json:");
Console.WriteLine(dbJsonContent);

static string ReadDbJson()
{
    // Read the contents of db.json using appropriate file reading logic
    var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json"); ; // Replace with the actual path
    string dbJsonContent = File.ReadAllText(path);
    return dbJsonContent;
}
