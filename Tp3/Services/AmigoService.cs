using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp3.Models;
using Tp3.Repository;

namespace Tp3.Services
{
    public class AmigoService
    {
        private AmigoRepository Repository { get; set; }

        public AmigoService(AmigoRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return Repository.GetAll();
        }

        public Amigo GetAmigoById(Guid id)
        {
            return Repository.GetAmigoById(id);
        }

        public void Save(Amigo amigo)
        {
            if (this.GetAmigoByEmail(amigo.Email) != null)
            {
                throw new Exception("Já existe um amigo com este email, por favor cadastre outro email");
            }

            var anoAtual = DateTime.Now.Date.Year;

            if ((anoAtual - Convert.ToDateTime(amigo.DataNiver).Date.Year) < 21)
            {
                throw new Exception("Para cadastrar um novo amigo ele deve no minimo 21 anos");
            }


            this.Repository.Save(amigo);
        }

        public Amigo GetAmigoByEmail(string email)
        {
            return Repository.GetAmigoByEmail(email);
        }

        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public void Update(Guid id, Amigo amigo)
        {
            Repository.Update(id, amigo);
        }

    }
}