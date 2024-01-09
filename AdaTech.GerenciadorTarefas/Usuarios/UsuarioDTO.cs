using AdaTech.GerenciadorTarefas.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class UsuarioDTO
    {
        public uint AutomaticId { get; set; }
        public string Nome { get; set; }
        public List<Tarefa>? TarefasAtribuidas { get; set; }

        public UsuarioDTO(uint automaticId, string nome, List<Tarefa>? tarefasAtribuidas)
        {
            AutomaticId = automaticId;
            Nome = nome;
            TarefasAtribuidas = tarefasAtribuidas;
        }
    }

}

