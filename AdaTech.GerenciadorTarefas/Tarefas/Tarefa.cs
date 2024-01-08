using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Tarefas
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string TarefaName { get; set; }
        public string TarefaArea { get; set; }
        public TarefaEstado Tarefaestado { get; set; }
        public DateTime TarefaData{ get; set; }

        public Tarefa(int tarefaId, string tarefaName, string tarefaArea, TarefaEstado tarefaestado, DateTime tarefaData)
        {
            TarefaId = tarefaId;
            TarefaName = tarefaName;
            TarefaArea = tarefaArea;
            Tarefaestado = tarefaestado;
            TarefaData = tarefaData;
        }
        public static Tarefa CriarTarefa(int tarefaId, string tarefaName, string tarefaArea, TarefaEstado tarefaestado, DateTime tarefaData)
        {
            return new Tarefa(tarefaId, tarefaName, tarefaArea, tarefaestado, tarefaData);
        }
    }
}
