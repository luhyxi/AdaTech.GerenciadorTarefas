using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Tarefas
{
    public class Tarefa
    {
        private static uint idCounter = 0;
        public uint TarefaId { get; }
        public string TarefaName { get; set; }
        public TarefaArea TarefaArea { get; set; }
        public TarefaEstado Tarefaestado { get; set; }
        public DateTime TarefaDataDeadline{ get; set; }

        public Tarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaestado, DateTime tarefaData)
        {
            TarefaId = idCounter++;
            TarefaName = tarefaName;
            TarefaArea = tarefaArea;
            Tarefaestado = tarefaestado;
            TarefaDataDeadline = tarefaData;
        }
        public static Tarefa CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaestado, DateTime tarefaData)
        {
            return new Tarefa(tarefaName, tarefaArea, tarefaestado, tarefaData);
        }
    }
}
