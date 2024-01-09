using AdaTech.GerenciadorTarefas.Tarefas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.GerenciadorTarefas.Usuarios
{
    public class TechLeader : Usuario
    {
        public TechLeader(string nome, List<Tarefa>? tarefas) : base(nome, tarefas)
        {
        }

        public void AdicionarDev(UsuarioDTO usuarioDTO)
        {
            var path = Path.Join(Environment.CurrentDirectory, "JsonParser", "db.json");

            string existingJson = File.ReadAllText(path);
            List<UsuarioDTO> usuarioList = JsonConvert.DeserializeObject<List<UsuarioDTO>>(existingJson) ?? new List<UsuarioDTO>();

            usuarioList.Add(usuarioDTO);

            string updatedJson = JsonConvert.SerializeObject(usuarioList, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
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
