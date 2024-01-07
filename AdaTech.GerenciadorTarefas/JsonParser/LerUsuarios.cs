using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

internal class LerUsuarios<T> where T : class
{
    public static List<T> ReceberJson()
    {
        string tipo = typeof(T).Name; // Receives the name of the class

        // Absolute path to the JSON file
        string absolutePath = @"C:\Users\luanar\Documents\AdaTech.GerenciadorTarefas\AdaTech.GerenciadorTarefas\JsonParser\db.json";

        try
        {
            // Read JSON from file
            string jsonString = File.ReadAllText(absolutePath);

            // Deserialize JSON into a List<T>
            List<T> itemList = JsonSerializer.Deserialize<List<T>>(jsonString);

            // Simple JSON print example
            Console.WriteLine($"JSON Data for {tipo}:");
            foreach (var item in itemList)
            {
                Console.WriteLine(JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true }));
            }

            return itemList;
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
