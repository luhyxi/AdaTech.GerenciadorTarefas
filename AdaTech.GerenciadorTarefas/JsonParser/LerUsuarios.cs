using System.Text.Json;
using AdaTech.GerenciadorTarefas;
internal class LerUsuarios<T> where T : class
{
    public static List<T> ReceberJson()
    {
        string tipo = typeof(T).Name; 
        var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json");

        try
        {
            string jsonString = File.ReadAllText(path);
            JsonData<T> data = JsonSerializer.Deserialize<JsonData<T>>(jsonString);

            Console.WriteLine($"JSON Data for {tipo}:");
            foreach (var item in data.Values)
            {
                Console.WriteLine(JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true }));
            }

            return null;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File not found: {ex.FileName}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }

        return null;
    }
}
