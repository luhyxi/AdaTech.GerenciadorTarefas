using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdaTech.GerenciadorTarefas.Usuarios;
using System;
using System.Collections.Generic;
using AdaTech.GerenciadorTarefas.Tarefas;

namespace Sistema.Autentificacao
{
    internal class AuthTechLead : AuthUsuario, IAuth // Serve mais para as funcionalidades dentro do console
    {
        private TechLeader? techLeadAtual = null;

        public AuthTechLead()
        {
            GenerateLogin();
        }

        public void GenerateLogin()
        {
            if (CredenciaisLogin.Count == 0)
            {
                Console.WriteLine("Nenhum TechLeader encontrado, por favor, registre-se.\n");

                Console.WriteLine("Insira o nome de Usuario, precisa conter pelo menos 8 caracteres e um caracter numérico.\n");
                do { SetUsername(Console.ReadLine()); } while (string.IsNullOrEmpty(username));
                Console.WriteLine("Insira a senha de Usuario, precisa conter pelo menos 8 caracteres e um caracter numérico.\n");
                do { SetPassword(Console.ReadLine()); } while (string.IsNullOrEmpty(password));

                Console.WriteLine("Credenciais criadas, registrando TechLead");
                techLeadAtual = new TechLeader(username, null);
            }
            else
            {
                Console.WriteLine("Já existe um TechLead registrado.");
            }
        }

        public void MudarSenha()
        {
            if (techLeadAtual != null)
            {
                try
                {
                    Console.WriteLine("Insira a nova senha:");
                    string input = Console.ReadLine();
                    do { SetPassword(input); } while (password != input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro ao alterar senha: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum TechLead registrado. Registre-se primeiro.");
                GenerateLogin();
            }
        }
        public void ExibirInfoTechLeadAtual()
        {
            if (techLeadAtual != null)
            {
                Console.WriteLine($"Informações do TechLead Atual:\n{techLeadAtual.ImprimirInformacoesUsuario}");
            }
            else
            {
                Console.WriteLine("Nenhum TechLead registrado. Registre-se primeiro.");
                GenerateLogin();
            }
        }
        protected static void VerTarefas(Usuario usuario) => EstatisticasTarefas.MostrarTarefasTodas();

    }
}
