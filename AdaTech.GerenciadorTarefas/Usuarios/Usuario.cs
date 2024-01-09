using AdaTech.GerenciadorTarefas.Tarefas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public abstract class Usuario
    {
        private static int idCounter = 1;
        public int AutomaticId { get; }
        public string Nome { get; set; }
        private List<Tarefa>? tarefasAtribuidas;
        public string jsonDTO; // To be filled by constructor

        protected Usuario(string nome, List<Tarefa>? tarefasatribuidas)
        {
            AutomaticId = idCounter++;
            Nome = nome;
            tarefasAtribuidas = tarefasatribuidas;
            UsuarioDTO usuarioDTO = new(AutomaticId, Nome, tarefasAtribuidas);
            jsonDTO = JsonConvert.SerializeObject(usuarioDTO);
        }

        public virtual void CriarTarefa(int tarefaId, string tarefaName, string tarefaArea, TarefaEstado tarefaestado, DateTime tarefaData)
        {
            Tarefa novaTarefa = Tarefa.CriarTarefa(tarefaId, tarefaName, tarefaArea, tarefaestado, tarefaData);

            tarefasAtribuidas.Add(novaTarefa);

            Console.WriteLine($"Tarefa '{novaTarefa.TarefaName}' criada e atribuida a {Nome}.");
        }

        public virtual void VerTarefas(Usuario usuario)
        {
        }

        public virtual void AssumirTarefa(Usuario usuario)
        {
        }

        public void AdicionarTarefas(List<Tarefa> tarefas)
        {
            tarefasAtribuidas.AddRange(tarefas);
        }

        public void VerTarefasAtribuidas()
        {
            Console.WriteLine($"Tarefas atribuidas a {Nome}:");
            foreach (var tarefa in tarefasAtribuidas)
            {
                Console.WriteLine($"- {tarefa.TarefaName}");
            }
        }
    }
}
