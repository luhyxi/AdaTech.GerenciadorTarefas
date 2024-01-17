using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Json;

namespace Sistema.Controllers
{
    public class DesenvolvedorController
    {
        private readonly Desenvolvedor _desenvolvedor;
        private static readonly string path = Path.Combine(Environment.CurrentDirectory, "JsonParser", "db.json");

        public DesenvolvedorController(Desenvolvedor desenvolvedor) => _desenvolvedor = desenvolvedor;

        public void AtribuirTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado) => _desenvolvedor.CriarTarefa(tarefaName, tarefaArea, tarefaEstado);

        public void MostrarTarefasAtribuidas()
        {
            Console.WriteLine($"Tarefas atribuídas a {_desenvolvedor.Nome}:\n");

            if (_desenvolvedor.Tarefas == null || _desenvolvedor.Tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa atribuída.");
                return;
            }

            foreach (var tarefa in _desenvolvedor.Tarefas)
            {
                Console.WriteLine($"ID: {tarefa.TarefaId} | Nome: {tarefa.TarefaName} | Área: {tarefa.TarefaArea} | Estado: {tarefa.TarefaEstado}");
            }
        }

        public static void LerEImprimirDesenvolvedores()
        {

            string existingJson = File.ReadAllText(path);

            List<UsuarioDTO> desenvolvedorDTOs;

            try
            {
                desenvolvedorDTOs = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();
            }
            catch (JsonSerializationException)
            {
                Console.WriteLine("Desenvolvedores no banco de dados:");
                Console.WriteLine("Nenhum desenvolvedor encontrado.");
                return;
            }

            if (desenvolvedorDTOs.Count == 0)
            {
                Console.WriteLine("Desenvolvedores no banco de dados:");
                Console.WriteLine("Nenhum desenvolvedor encontrado.");
                return;
            }

            Console.WriteLine("Desenvolvedores no banco de dados:");

            foreach (var devDTO in desenvolvedorDTOs)
            {
                var role = devDTO.AutomaticId == 0 ? "TechLead" : "Desenovlvedor";
                Console.WriteLine($"ID: {devDTO.AutomaticId} | Nome: {devDTO.Nome} | Role: {role}");
            }
        }

        public static bool TemDesenvolvedor()
        {
            string existingJson = File.ReadAllText(path);

            List<UsuarioDTO> desenvolvedorDTOs;

            try
            {
                desenvolvedorDTOs = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();
            }
            catch (JsonSerializationException)
            {
                return false;
            }

            // Check if there is any developer in the list
            return desenvolvedorDTOs.Any();
        }


    }

}
