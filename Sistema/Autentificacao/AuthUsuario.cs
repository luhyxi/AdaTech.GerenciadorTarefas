using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema.Autentificacao
{
    public abstract class AuthUsuario : IAuth
    {
        protected string? username = null;
        protected string? password = null;

        protected readonly Dictionary<string, string> CredenciaisLogin = new Dictionary<string, string>();

        public bool IsAuthenticated { get; set; }

        bool Authenticate(string username, string password)
        {
            if (CredenciaisLogin.TryGetValue(username, out var storedPassword))
            {
                IsAuthenticated = password == storedPassword;
                return IsAuthenticated;
            }
            return false;
        }
        public bool Login(string username, string password)
        {
            if (Authenticate(username, password))
            {
                Console.WriteLine($"{username} logged in successfully.");
                return true;
            }

            Console.WriteLine($"Login failed for {username}.");
            return false;
        }

        public void Logout()
        {
            IsAuthenticated = false;
            Console.WriteLine("Logged out.");
        }

        public string GetUsername() => username;

        public string GetPassword() => password;

        public void SetUsername(string newUsername)
        {
            while (true)
            {
                if (Regex.IsMatch(newUsername, "^(?=.*[A-Z])(?=.*[0-9]).{8,}$"))
                {
                    username = newUsername;
                    break;
                }
                else
                {
                    Console.WriteLine("Formato inválido.");
                    newUsername = Console.ReadLine();
                }
            }
            Console.Clear();
        }

        public void SetPassword(string newPassword)
        {
            while (true)
            {
                if (Regex.IsMatch(newPassword, "^(?=.*[A-Z])(?=.*[0-9]).{8,}$"))
                {
                    password = newPassword;
                    break;
                }
                else
                {
                    Console.WriteLine("Formato inválido.");
                    newPassword = Console.ReadLine();
                }
            }
        }

        public string Username
        {
            get => GetUsername();
            set => SetUsername(value);
        }

        public string Password
        {
            get => GetPassword();
            set => SetPassword(value);
        }
    }


}
