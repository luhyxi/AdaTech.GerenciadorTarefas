using AdaTech.GerenciadorTarefas.Tarefas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class TechLeader : Usuario
    {
        public readonly string path = Usuario.path;
        public TechLeader(string nome, List<Tarefa>? tarefas) : base(nome, tarefas)
        {
        }

        public void AdicionarDev(UsuarioDTO usuarioDTO)
        {
            // Leitura do Json
            string existingJson = File.ReadAllText(path);

            // Initialize the list with the existing content or create a new list if it's null or not an array
            List<UsuarioDTO> usuarioList = new List<UsuarioDTO>();

            try
            {
                usuarioList = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();
            }
            catch (JsonSerializationException)
            {
                // Handle the case where existing content is not a valid JSON array
                Console.WriteLine("Nenhum desenvolvedor encontrado, criando um novo grupo de desenvolvedores.");
            }

            // Add the new UsuarioDTO
            usuarioList.Add(usuarioDTO);


            // Serialize the updated list and write it back to the file
            string updatedJson = JsonConvert.SerializeObject(usuarioList, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
            Console.WriteLine($"Novo desenvolvedor '{usuarioDTO.Nome}' registrado com sucesso!");

        }

        public override void VerTarefas(Usuario usuario)
        {

        }
        public override void AssumirTarefa(Usuario usuario)
        {

        }
        public void MudarEstadoDeTarefa(Tarefa tarefa)
        {

        }
        public void MudarResponsaveDeTarefa(Tarefa tarefa)
        {

        }
    }
}
