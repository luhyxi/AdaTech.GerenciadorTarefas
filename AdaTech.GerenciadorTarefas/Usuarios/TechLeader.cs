using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class TechLeader : Usuario, IUsuario
    {
        public readonly string path = Usuario.path;
        public TechLeader(string nome, List<Tarefa>? tarefas) : base(nome, tarefas)
        {
        }

        public void AdicionarDev(UsuarioDTO usuarioDTO)
        {
            // Leitura do Json
            string existingJson = File.ReadAllText(path);

            // Inicializar uma lista para adicionar o Desenvolvedor caso não exista nenhum Dev
            List<UsuarioDTO> usuarioList = new List<UsuarioDTO>();

            try
            {
                usuarioList = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();
            }
            catch (JsonSerializationException)
            {
                // Caso seja nessario criar um novo grupo de Desenvolvedores (e.g Inserindo o primeiro dev ou após remover todos)
                Console.WriteLine("Nenhum desenvolvedor encontrado, criando um novo grupo de desenvolvedores.");
            }

            // Adiciona o usuario DTO
            usuarioList.Add(usuarioDTO);


            // Serializa e atualiza o Json
            string updatedJson = JsonConvert.SerializeObject(usuarioList, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
            Console.WriteLine($"Novo desenvolvedor '{usuarioDTO.Nome}' registrado com sucesso!");

        }

        // Somente TechLead: Coloca Deadline em Tarefa
        public void ColocarDeadline(Tarefa tarefa, DateTime novaDeadline)
        {
            MudarDeadLine(tarefa, novaDeadline);
            AtualizarJsonDTO();
        }
        public Usuario PesquisarDevPorId(int devId)
        {
            string existingJson = File.ReadAllText(path);

            var usuarioList = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();

            var devDTO = usuarioList.FirstOrDefault(x => x.AutomaticId == devId);

            if (devDTO != null)
            {
                Desenvolvedor dev = new Desenvolvedor(devDTO.Nome, devDTO.TarefasAtribuidas)
                {
                    Id = (int)devDTO.AutomaticId,
                    jsonDTO = JsonConvert.SerializeObject(devDTO, Formatting.Indented)
                };

                Console.WriteLine($"Desenvolvedor encontrado: {dev.Nome}");
                return dev;
            }
            else
            {
                Console.WriteLine($"Desenvolvedor com ID {devId} não encontrado.");
                return null;
            }
        }
        private DateTime MudarDeadLine(Tarefa tarefa, DateTime novaDeadline) => (DateTime)(tarefa.tarefaDataDeadline = novaDeadline);

        // Totalmente funcional
        public Tarefa PesquisarTarefaId(int y) => EstatisticasTarefas.TarefasStaticEstatisticas
        .FirstOrDefault(x => x.TarefaId == y);

        public void CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado, DateTime deadLine, Usuario usuarioAtribuido)
        {
            Tarefa novaTarefa = Tarefa.CriarTarefa(tarefaName, tarefaArea, tarefaEstado);
            ColocarDeadline(novaTarefa, deadLine);
            usuarioAtribuido.tarefasAtribuidas.Add(novaTarefa);

            AtualizarJsonDTO();

            Console.WriteLine($"Tarefa '{novaTarefa.TarefaName}' criada e atribuída a {Nome}.");
        }


        private void MudarEstadoDeTarefa(Tarefa tarefa, TarefaEstado tarefaEstado)
        {
            tarefa.TarefaEstado = tarefaEstado;
            AtualizarJsonDTO();
        }

        private void MudarResponsavelDeTarefa(Tarefa tarefa, Usuario antigoResposavel, Usuario novoResposavel)
        {
            if (antigoResposavel.tarefasAtribuidas.Contains(tarefa))
            {
                novoResposavel.tarefasAtribuidas.Add(tarefa);
                antigoResposavel.tarefasAtribuidas.Remove(tarefa);
            }
            else Console.WriteLine($"O desenvolvedor {antigoResposavel.Nome} não possui essa tarefa em sua responsabilidade");
            AtualizarJsonDTO();
        }
        public void AssumirTarefa(Tarefa tarefa, Usuario usuario)
        {
            if (usuario.tarefasAtribuidas.Contains(tarefa))
            {
                tarefasAtribuidas.Add(tarefa);
                usuario.tarefasAtribuidas.Remove(tarefa);
            }
            else Console.WriteLine($"O TechLead {Nome} não possui essa tarefa em sua responsabilidade");
            AtualizarJsonDTO();
        }
    }
}
