using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Controllers
{
    public class EstatisticasController
    {
        private readonly EstatisticasTarefas _estatisticasTarefas;

        public EstatisticasController(EstatisticasTarefas estatisticasTarefas) => _estatisticasTarefas = estatisticasTarefas;

        public void AdicionarTarefa(Tarefa tarefa) => _estatisticasTarefas.AdicionarTarefa(tarefa);

        public static void MostrarTodasAsTarefas() => EstatisticasTarefas.MostrarTarefasTodas();

        public void MostrarTarefasPorArea() => _estatisticasTarefas.MostrarTarefasArea();
    }
}
