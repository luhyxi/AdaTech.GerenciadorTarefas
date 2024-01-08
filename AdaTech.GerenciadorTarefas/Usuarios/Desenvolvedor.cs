using AdaTech.GerenciadorTarefas.Tarefas;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class Desenvolvedor : Usuario
    {
        public int Id { get; set; }
        public new string? Nome { get; set; }
        public List<Tarefa>? Tarefas { get; set; }

        public Desenvolvedor() : base(0, null, null) { }
    }
}