using AdaTech.GerenciadorTarefas.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    internal class TechLeader : Usuario
    {
        public TechLeader(int id, string nome, List<Tarefa> tarefas) : base(id, nome, tarefas)
        {
        }

        public override void CriarTarefa()
        {

        }
        public override void VerTarefas(Usuario usuario)
        {


        }
        public override void AssumirTarefa(Usuario usuario)
        {

        }
        public void MudarEstadoDeTarefa(Tarefa tarefa)
        {

        }
        public void MudarResponsaveDeTarefa(Tarefa tarefa)
        {

        }
    }
}
