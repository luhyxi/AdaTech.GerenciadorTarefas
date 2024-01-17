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

        public DateTime tarefaDataDeadline;

        public Tarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado)
        {
            TarefaId = idCounter++;
            TarefaName = tarefaName;
            TarefaArea = tarefaArea;
            TarefaEstado = tarefaEstado;
            AdicionarStaticEstatisticas(this);
        }

        public static Tarefa CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado) => new Tarefa(tarefaName, tarefaArea, tarefaEstado);

        // Add the task instance to the list of all tasks
        public static void AdicionarStaticEstatisticas(Tarefa tarefa) => EstatisticasTarefas.TarefasStaticEstatisticas.Add(tarefa);

        // Printing the task
        public void PrintTarefa()
        {
            Console.WriteLine($"Tarefa ID: {TarefaId}");
            Console.WriteLine($"Nome: {TarefaName}");
            Console.WriteLine($"Área: {TarefaArea}");
            Console.WriteLine($"Estado: {TarefaEstado}");
            Console.WriteLine(tarefaDataDeadline != null ? $"Data Deadline: {tarefaDataDeadline}" : "Sem DeadLine");
            Console.WriteLine();
        }
    }
}
