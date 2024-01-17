using AdaTech.GerenciadorTarefas.Tarefas.Enums;
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

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // INTERATIVAS

        public void AdicionarDev()
        {
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
            int tarefaID;

            do
            {
                Console.WriteLine("Insira o ID da tarefa selecionada");

                if (!int.TryParse(Console.ReadLine(), out tarefaID))
                {
                    Console.WriteLine("Por favor, insira um ID válido ");
                }
            } while (!int.TryParse(Console.ReadLine(), out tarefaID));

            Console.WriteLine("Tarefa encontrada e selecionada");
            Console.ReadKey();

            DateTime newDeadline;

            do
            {
                Console.WriteLine("Insira uma DeadLine para a tarefa selecionada");

                if (!DateTime.TryParse(Console.ReadLine(), out newDeadline))
                {
                    Console.WriteLine("Por favor, insira uma DeadLine válida");
                }
            } while (!DateTime.TryParse(Console.ReadLine(), out newDeadline));

            Console.WriteLine("Data selecionada");
            Console.ReadKey();

            var tarefa = PesquisarTarefaId(tarefaID);
            if (tarefa == null) Console.WriteLine("ID não encontrado");
            ColocarDeadline(tarefa, newDeadline);
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.

        public void CriarTarefa()
        {
            // Instanciando objetos na memoria
            TarefaArea tarefaArea;
            TarefaEstado tarefaEstado;
            DateTime deadLine;
            int idUsuario;


            Console.WriteLine("Insira o nome da tarefa:");
            string tarefaName = Console.ReadLine();

            // Area da tarefa

            Console.WriteLine($@"Escolha a área da tarefa:
Frontend = 0,
Backend = 1,
Devops = 2,");
            do
            {
                Console.WriteLine("A area escolhida não foi encontrada");
                Console.ReadKey();
                Console.Clear();
            } while (!Enum.TryParse<TarefaArea>(Console.ReadLine(), out tarefaArea));

            // Estado da tarefa

            Console.WriteLine($@"Escolha a área da tarefa:
NãoIniciada = 0,
Desenvolvimento = 0,
Concluida = 1,
Abandonada = 2,
Analise = 3,");

            do
            {
                Console.WriteLine("O estado escolhido não foi encontrado");
                Console.ReadKey();
                Console.Clear();
            } while (!Enum.TryParse<TarefaEstado>(Console.ReadLine(), out tarefaEstado));

            // Deadline

            Console.WriteLine("Insira a data limite (DD/MM/YYYY):");

            while (!DateTime.TryParse(Console.ReadLine(), out deadLine))
            {
                Console.WriteLine("Por favor, insira uma data válida:");
                Console.ReadKey();
                Console.Clear();
            }

            // Id de Usuario

            Console.WriteLine("Insira o ID do usuário a ser atribuído:");

            while (!int.TryParse(Console.ReadLine(), out idUsuario))
            {
                Console.WriteLine("Por favor, insira um ID válido:");
                Console.ReadKey();
                Console.Clear();
            }

            Usuario usuarioAtribuido = PesquisarDevPorId(idUsuario);

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

        public void VerTarefasAtribuidas() => techLeader.VerTarefasAtribuidas();

        public void ImprimirInformacoesUsuario() => techLeader.ImprimirInformacoesUsuario();
    }
}
