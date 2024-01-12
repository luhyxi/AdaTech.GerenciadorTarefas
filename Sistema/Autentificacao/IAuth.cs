using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema.Autentificacao
{
    internal interface IAuth
    {
        string GetUsername();
        string GetPassword();
        void SetUsername(string username);
        void SetPassword(string password);
        bool IsAuthenticated { get; set; }
        string Username { get; set; }
        string Password { get; set; }

    }

}
