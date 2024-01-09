using AdaTech.GerenciadorTarefas.Tarefas;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class Desenvolvedor : Usuario
    {
        public Desenvolvedor(string nome, List<Tarefa>? tarefasatribuidas) : base(nome, tarefasatribuidas)
        {
        }

        public int Id { get; set; }
        public new string? Nome { get; set; }
        public List<Tarefa>? Tarefas { get; set; }

        public UsuarioDTO ConvertJsonDTOToObject() => JsonConvert.DeserializeObject<UsuarioDTO>(jsonDTO);
    }
}