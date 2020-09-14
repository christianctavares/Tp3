using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3.Models
{
    public class Amigo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNiver { get; set; }
        //teste
        public Amigo()
        {

        }
        public Amigo(Guid id, string nome, string sobrenome, string email, string telefone, DateTime dataNiver)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
            DataNiver = dataNiver;
        }
    }
}
