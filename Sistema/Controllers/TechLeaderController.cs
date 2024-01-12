﻿using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Options
{
    public class TechLeaderController
    {

        private readonly TechLeader techLeader;
        
        // Funções da classe TechLead
        public TechLeaderController(TechLeader techLeader) => this.techLeader = techLeader ?? throw new ArgumentNullException(nameof(techLeader));

        public void AdicionarDev(UsuarioDTO usuarioDTO) => techLeader.AdicionarDev(usuarioDTO);

        public void ColocarDeadline(Tarefa tarefa, DateTime novaDeadline) => techLeader.ColocarDeadline(tarefa, novaDeadline);

        public Tarefa PesquisarTarefaId(int taskId) => techLeader.PesquisarTarefaId(taskId);

        public void CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado, DateTime deadLine, Usuario usuarioAtribuido) => techLeader.CriarTarefa(tarefaName, tarefaArea, tarefaEstado, deadLine, usuarioAtribuido);

        public void AssumirTarefa(Tarefa tarefa, Usuario usuario) => techLeader.AssumirTarefa(tarefa, usuario);
        
        
        // Funções da classe usuario
        public void AtualizarJsonDTO() => techLeader.AtualizarJsonDTO();

        public void VerTarefas(Usuario usuario) => VerTarefas(usuario);

        public void AdicionarTarefas(List<Tarefa> tarefas) => techLeader.AdicionarTarefas(tarefas);

        public void VerTarefasAtribuidas() => techLeader.VerTarefasAtribuidas();

        public void ImprimirInformacoesUsuario() => techLeader.ImprimirInformacoesUsuario();
    }
}