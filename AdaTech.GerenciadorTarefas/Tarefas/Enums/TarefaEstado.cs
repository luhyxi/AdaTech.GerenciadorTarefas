using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Tarefas
{
    public enum TarefaEstado
    {
        NãoIniciada = 0,
        Desenvolvimento = 1,
        Concluida = 2,
        Abandonada = 3,
        Analise = 4,
    }
}
