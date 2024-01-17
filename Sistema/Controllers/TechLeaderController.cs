using AdaTech.GerenciadorTarefas.Tarefas.Enums;
using AdaTech.GerenciadorTarefas.Tarefas;
using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Sistema.Controllers
{
    public class TechLeaderController
    {

        private readonly TechLeader techLeader;



        // Funções da classe TechLead
        public TechLeaderController(TechLeader techLeader) => this.techLeader = techLeader ?? throw new ArgumentNullException(nameof(techLeader));

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // INTERATIVAS



        public void AdicionarDev()
        {
            Console.Clear();
            string nome;
            do
            {
                Console.WriteLine("Insira o nome do desenvolvedor");
                nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Por favor, insira um nome válido");
                }
            } while (string.IsNullOrWhiteSpace(nome));
            Console.Clear();
            var newDev = new Desenvolvedor(nome, null);
            AdicionarDev(newDev.ConvertJsonDTOToObject());
        }

        public void ColocarDeadline()
        {
            Console.Clear();
            int tarefaID;

            Console.WriteLine("Insira o ID da tarefa selecionada");

            while (!int.TryParse(Console.ReadLine(), out tarefaID))
            {
                Console.Clear();
                Console.WriteLine("Por favor, insira um ID válido ");
                Console.ReadKey();
                Console.Clear();
            }

            if (PesquisarTarefaId(tarefaID) == null)
            {
                Console.WriteLine("Tarefa não encontrada, por favor tentar novamente");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Tarefa encontrada e selecionada");
            Console.ReadKey();
            Console.Clear();

            DateTime newDeadline;

            Console.WriteLine("Insira uma DeadLine para a tarefa selecionada (dd/MM/yy):");


            while (!DateTime.TryParse(Console.ReadLine(), out newDeadline))
            {
                Console.Clear();
                Console.WriteLine("Por favor, insira uma DeadLine válida");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine($"Tarefa: {PesquisarTarefaId(tarefaID).TarefaName}, Nova Data: {newDeadline}, Antiga Data:{PesquisarTarefaId(tarefaID).tarefaDataDeadline}");
            Console.ReadKey();

            var tarefa = PesquisarTarefaId(tarefaID);
            if (tarefa == null) Console.WriteLine("ID não encontrado");
            ColocarDeadline(tarefa, newDeadline);
        }


        public void CriarTarefa()
        {
            Console.Clear();

            if (!DesenvolvedorController.TemDesenvolvedor())
            {
                Console.WriteLine("Nenhum desenvolvedor encontrado. Registre um antes de criar uma tarefa.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("========== Criar Tarefa ==========");

            // Task name
            Console.Write("Nome da tarefa: ");
            string tarefaName = Console.ReadLine();

            // Task area
            Console.WriteLine("Escolha a área da tarefa:");
            Console.WriteLine("0 - Frontend");
            Console.WriteLine("1 - Backend");
            Console.WriteLine("2 - DevOps");

            TarefaArea tarefaArea;
            while (!Enum.TryParse(Console.ReadLine(), out tarefaArea))
            {
                Console.WriteLine("Área inválida. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            // Task state
            Console.WriteLine("Escolha o estado da tarefa:");
            Console.WriteLine("0 - Não Iniciada");
            Console.WriteLine("1 - Desenvolvimento");
            Console.WriteLine("2 - Concluída");
            Console.WriteLine("3 - Abandonada");
            Console.WriteLine("4 - Análise");

            TarefaEstado tarefaEstado;
            while (!Enum.TryParse(Console.ReadLine(), out tarefaEstado))
            {
                Console.WriteLine("Estado inválido. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            // Deadline
            Console.Write("Insira a data limite (DD/MM/YYYY): ");
            DateTime deadLine;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out deadLine))
            {
                Console.WriteLine("Data inválida. Por favor, insira no formato correto (DD/MM/YYYY):");
            }

            // User ID
            Console.Write("Insira o ID do usuário a ser atribuído: ");
            int idUsuario;
            while (!int.TryParse(Console.ReadLine(), out idUsuario))
            {
                Console.WriteLine("ID inválido. Por favor, insira um ID válido:");
            }

            

            Usuario usuarioAtribuido = PesquisarDevPorId(idUsuario);

            if (usuarioAtribuido == null)
            {
                Console.WriteLine("Id não encontrado, por favor tente novamente");
                Console.ReadKey();
                return;
            }

            // Create task
            CriarTarefa(tarefaName, tarefaArea, tarefaEstado, deadLine, usuarioAtribuido);
        }


        // INTERATIVAS
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // Não interativas abaixo!!

        internal Usuario PesquisarDevPorId(int devId) => techLeader.PesquisarDevPorId(devId);

        internal void AdicionarDev(UsuarioDTO usuarioDTO) => techLeader.AdicionarDev(usuarioDTO);

        internal void ColocarDeadline(Tarefa tarefa, DateTime novaDeadline) => techLeader.ColocarDeadline(tarefa, novaDeadline);

        public Tarefa PesquisarTarefaId(int taskId) => techLeader.PesquisarTarefaId(taskId);

        public void CriarTarefa(string tarefaName, TarefaArea tarefaArea, TarefaEstado tarefaEstado, DateTime deadLine, Usuario usuarioAtribuido) => techLeader.CriarTarefa(tarefaName, tarefaArea, tarefaEstado, deadLine, usuarioAtribuido);

        public void AssumirTarefa(Tarefa tarefa, Usuario usuario) => techLeader.AssumirTarefa(tarefa, usuario);


        // Funções da classe usuario
        public void AtualizarJsonDTO() => techLeader.AtualizarJsonDTO();

        public void VerTarefas(Usuario usuario) => VerTarefas(usuario);

        public void AdicionarTarefas(List<Tarefa> tarefas) => techLeader.AdicionarTarefas(tarefas);

        public void VerTarefasAtribuidas()
        {
            Console.Clear();
            techLeader.VerTarefasAtribuidas();
            Console.ReadKey();
            Console.Clear();
        }

        public void ImprimirInformacoesUsuario()
        {
            Console.Clear();
            techLeader.ImprimirInformacoesUsuario();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
