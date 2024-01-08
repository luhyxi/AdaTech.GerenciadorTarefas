using AdaTech.GerenciadorTarefas.Tarefas;
using System;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public abstract class Usuario
    {
        private int id;
        public string Nome { get; set; }
        private List<Tarefa> tarefasAtribuidas;

        protected Usuario(int id, string nome, List<Tarefa> tarefasatribuidas)
        {
            this.id = id;
            Nome = nome;
            tarefasAtribuidas = tarefasatribuidas;
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
