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
        public TarefaEstado TarefaEstado { get; set; }
        public DateTime TarefaDataDeadline { get; set; }

        public Tarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado, DateTime tarefaData)
        {
            TarefaId = idCounter++;
            TarefaName = tarefaName;
            TarefaArea = tarefaArea;
            TarefaEstado = tarefaEstado;
            TarefaDataDeadline = tarefaData;
            AdicionarStaticEstatisticas(this);
        }

        public static Tarefa CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado, DateTime tarefaData)
        {
            return new Tarefa(tarefaName, tarefaArea, tarefaEstado, tarefaData);
        }



        // Adiciona a instancia da tarefa a lista de todas tarefas
        public static void AdicionarStaticEstatisticas(Tarefa tarefa) => EstatisticasTarefas.TarefasStaticEstatisticas.Add(tarefa);
        
        // Printing da tarefa
        public void PrintTarefa()
        {
            Console.WriteLine($"Tarefa ID: {TarefaId}");
            Console.WriteLine($"Nome: {TarefaName}");
            Console.WriteLine($"Área: {TarefaArea}");
            Console.WriteLine($"Estado: {TarefaEstado}");
            Console.WriteLine($"Data Deadline: {TarefaDataDeadline}");
            Console.WriteLine();
        }
    }
}
