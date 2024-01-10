using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using System.Collections;

namespace AdaTech.GerenciadorTarefas.Tarefas
{
    public class EstatisticasTarefas
    {
        public List<Tarefa> TarefasInstanciaEstatisticas = []; // Tarefas ligadas a tal instancia

        public TarefaArea AreaDaEstatistica = new TarefaArea(); // Area da estatistica na instancia

        public static List<Tarefa> TarefasStaticEstatisticas = []; // Todas as tarefas
        public static List<TarefaArea> AreasTarefas { get; private set; } = []; // Todas as possiveis areas das estatísticas


        public EstatisticasTarefas(TarefaArea AreaDaEstatistica)
        {
            this.AreaDaEstatistica = AreaDaEstatistica;

            foreach (TarefaArea area in Enum.GetValues(typeof(TarefaArea)))
            {
                AreasTarefas.Add(area);
            }

            foreach (var tarefa in TarefasStaticEstatisticas)
            {
                if (tarefa.TarefaArea == this.AreaDaEstatistica)
                {
                    TarefasInstanciaEstatisticas.Add(tarefa);
                }
            }
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            TarefasStaticEstatisticas.Add(tarefa);
        }
        public static void MostrarTarefasTodas()
        {
            Console.WriteLine($"Todas as tarefas:\n");
            foreach (var tarefa in TarefasStaticEstatisticas)
            {
                tarefa.PrintTarefa();
            }
        }
        public void MostrarTarefasArea()
        {
            Console.WriteLine($"Tarefas da Area de {AreaDaEstatistica}:\n");
            foreach (var tarefa in TarefasInstanciaEstatisticas)
            {
                tarefa.PrintTarefa();
            }
        }
    }
}
