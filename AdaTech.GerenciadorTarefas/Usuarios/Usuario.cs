﻿using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public abstract class Usuario : IUsuario
    {
        protected static readonly string path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json"); // Path da db herdada por todas as filhas

        private static uint idCounter = 0;
        public uint UsuarioId { get; }
        public string Nome { get; set; }
        public List<Tarefa>? tarefasAtribuidas;
        public string jsonDTO; // Preenchida durante o constructor
        protected Usuario(string nome, List<Tarefa>? tarefasatribuidas)
        {
            UsuarioId = idCounter++;
            Nome = nome;
            tarefasAtribuidas = tarefasatribuidas ?? new List<Tarefa>();
            UsuarioDTO usuarioDTO = new(UsuarioId, Nome, tarefasAtribuidas);
            jsonDTO = JsonConvert.SerializeObject(usuarioDTO);
        }



        public void AtualizarJsonDTO()
        {
            UsuarioDTO usuarioDTO = new(UsuarioId, Nome, tarefasAtribuidas);


            // Lista de usuarios para serem atualizadas
            string existingJson = File.ReadAllText(path);
            List<UsuarioDTO> usuarioList = new List<UsuarioDTO>();

            try
            {
                usuarioList = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();
            }
            catch (JsonSerializationException)
            {

                Console.WriteLine("Nenhum desenvolvedor encontrado, criando um novo grupo de desenvolvedores.");
            }

            // Adicionar usurioDTO a lista de usuarios
            int index = usuarioList.FindIndex(u => u.AutomaticId == UsuarioId);

            if (index >= 0) usuarioList[index] = usuarioDTO;
            else usuarioList.Add(usuarioDTO);

            // Serializar e atualizar JSON
            string updatedJson = JsonConvert.SerializeObject(usuarioList, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
        }
        protected void VerTarefas(Usuario usuario) => EstatisticasTarefas.MostrarTarefasTodas();

        public void AdicionarTarefas(List<Tarefa> tarefas) => tarefasAtribuidas.AddRange(tarefas);

        public void VerTarefasAtribuidas()
        {
            Console.WriteLine($"=== Tarefas Atribuídas a {Nome} ===");
            foreach (var tarefa in tarefasAtribuidas)
            {
                Console.WriteLine($"  - {tarefa.TarefaName}");
            }
            Console.WriteLine("===============================");
        }

        public void ImprimirInformacoesUsuario()
        {
            Console.WriteLine($"=== Informações do Usuário ===");
            Console.WriteLine($"ID do Usuário: {UsuarioId}");
            Console.WriteLine($"Nome: {Nome}");

            if (tarefasAtribuidas != null && tarefasAtribuidas.Any())
            {
                Console.WriteLine("Tarefas Atribuídas:");
                foreach (var tarefa in tarefasAtribuidas)
                {
                    Console.WriteLine($"  - {tarefa.TarefaName}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa atribuída.");
            }

            Console.WriteLine("===============================");
            Console.WriteLine($"JSON DTO:\n{jsonDTO}");
            Console.WriteLine("===============================");
        }



        // Não usadas
        void IUsuario.CriarTarefa() { }
        void IUsuario.AssumirTarefa() { }
    }
}
