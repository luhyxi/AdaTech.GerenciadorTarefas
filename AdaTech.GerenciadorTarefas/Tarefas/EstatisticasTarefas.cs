using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Tarefas
{
    public class EstatisticasTarefas
    {
        private List<Tarefa> tarefasLista = new List<Tarefa>();
        public Usuario? Responsavel
        {
            get => Responsavel;
            set
            {
                Responsavel = value;
                if (value != null)
                {
                    value.AdicionarTarefas(this.tarefasLista);
                }
            }
        }

        public List<Tarefa> TarefasLista
        {
            get => tarefasLista;
        }
    }
}
