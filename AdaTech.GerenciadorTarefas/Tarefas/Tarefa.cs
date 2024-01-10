using AdaTech.GerenciadorTarefas.Tarefas.Enums;

namespace AdaTech.GerenciadorTarefas.Tarefas
{
    public class Tarefa
    {
        private static uint idCounter = 0;
        public uint TarefaId { get; }
        public string TarefaName { get; set; }
        public TarefaArea TarefaArea { get; set; }
        public TarefaEstado TarefaEstado { get; set; }
        public bool TemDeadline { get; set; } // Seta se a tarefa tem ou não tem deadline setada pelo Tech Lead
        public DateTime? tarefaDataDeadline; // Deadline do projeto

        public DateTime? TarefaDataDeadline
        {
            get
            {
                return TemDeadline ? null : tarefaDataDeadline;
            }
            set
            {
                if (TemDeadline)
                {
                    // If TemDeadline is true, set TarefaDataDeadline to null
                    tarefaDataDeadline = null;
                }
                else
                {
                    // Otherwise, set TarefaDataDeadline to the provided value
                    tarefaDataDeadline = value;
                }
            }
        }

        public Tarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado)
        {
            TarefaId = idCounter++;
            TarefaName = tarefaName;
            TarefaArea = tarefaArea;
            TarefaEstado = tarefaEstado;
            AdicionarStaticEstatisticas(this);
        }


        

        public static Tarefa CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado) => new Tarefa(tarefaName, tarefaArea, tarefaEstado);

        // Adiciona a instancia da tarefa a lista de todas tarefas
        public static void AdicionarStaticEstatisticas(Tarefa tarefa) => EstatisticasTarefas.TarefasStaticEstatisticas.Add(tarefa);

        // Printing da tarefa
        public void PrintTarefa()
        {
            Console.WriteLine($"Tarefa ID: {TarefaId}");
            Console.WriteLine($"Nome: {TarefaName}");
            Console.WriteLine($"Área: {TarefaArea}");
            Console.WriteLine($"Estado: {TarefaEstado}");
            Console.WriteLine(TarefaDataDeadline != null ? $"Data Deadline: {TarefaDataDeadline}" : "Sem DeadLine");
            Console.WriteLine();
        }
    }
}
