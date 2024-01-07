using AdaTech.GerenciadorTarefas.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public abstract class Usuario
    {
        private int id;
        public string Nome { get; set; }
        private List<Tarefa> tarefasAtribuidas = new List<Tarefa>();

        protected Usuario(int id, string nome, List<Tarefa> tarefasatribuidas )
        {
            this.id = id;
            Nome = nome;
            tarefasAtribuidas = tarefasatribuidas;
        }

        public virtual void CriarTarefa()
        {
            // Implementation for creating a task
        }

        public virtual void VerTarefas(Usuario usuario)
        {
            // Implementation for viewing tasks
        }

        public virtual void AssumirTarefa(Usuario usuario)
        {
            // Implementation for taking ownership of a task
        }

        public void AdicionarTarefas(List<Tarefa> tarefas)
        {
            // Add logic to handle adding tasks to the user's list
            // For example: this.Tarefas.AddRange(tarefas);
            tarefasAtribuidas.AddRange(tarefas);
        }

        public void VerTarefasAtribuidas()
        {
            Console.WriteLine($"Tasks assigned to {Nome}:");
            foreach (var tarefa in tarefasAtribuidas)
            {
                Console.WriteLine($"- {tarefa.TarefaName}");
            }
        }
    }
}


