using AdaTech.GerenciadorTarefas.Tarefas;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    internal class Desenvolvedor : Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; }


        public Desenvolvedor(int id, string nome, List<Tarefa> tarefas) : base(id, nome, tarefas)
        {
            Id = id;
            Nome = nome;
            Tarefas = tarefas;
        }
    }
}
