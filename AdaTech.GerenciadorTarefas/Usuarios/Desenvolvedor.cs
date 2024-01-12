using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class Desenvolvedor : Usuario, IUsuario
    {
        public Desenvolvedor(string nome, List<Tarefa>? tarefasatribuidas) : base(nome, tarefasatribuidas)
        {
        }

        public int Id { get; set; }
        public new string? Nome { get; set; }
        public List<Tarefa>? Tarefas { get; set; }

        public UsuarioDTO ConvertJsonDTOToObject() => JsonConvert.DeserializeObject<UsuarioDTO>(jsonDTO);
        public void CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado)
        {
            Tarefa novaTarefa = Tarefa.CriarTarefa(tarefaName, tarefaArea, tarefaEstado);
            tarefasAtribuidas.Add(novaTarefa);

            AtualizarJsonDTO();

            Console.WriteLine($"Tarefa '{novaTarefa.TarefaName}' criada e atribuída a {Nome}.");
        }   
    }
}