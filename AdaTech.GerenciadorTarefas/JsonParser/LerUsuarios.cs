using System.Text.Json;
using AdaTech.GerenciadorTarefas;
internal class LerUsuarios<T> where T : class
{
    public static List<T> ReceberJson()
    {
        string tipo = typeof(T).Name; // Receives the name of the class
        var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json");

        try
        {
            // Read JSON from file
            string jsonString = File.ReadAllText(path);
            // Deserialize JSON into a List<T>
            JsonData<T> data = JsonSerializer.Deserialize<JsonData<T>>(jsonString);

            // Simple JSON print example
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
