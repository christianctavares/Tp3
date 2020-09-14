using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp3.Data;
using Tp3.Models;

namespace Tp3.Repository
{
    public class AmigoRepository
    {

        private readonly Tp3Context _context;

        public AmigoRepository(Tp3Context context)
        {
            _context = context;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return _context.Amigo.AsEnumerable();

        }

        public Amigo GetAmigoById(Guid id)
        {
            return _context.Amigo.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Amigo amigo)
        {
            this._context.Amigo.Add(amigo);
            this._context.SaveChanges();
        }

        public Amigo GetAmigoByEmail(string email)
        {
            return _context.Amigo.FirstOrDefault(x => x.Email == email);
        }

        public void Delete(Guid id)
        {
            var amigo = _context.Amigo.FirstOrDefault(x => x.Id == id);
            this._context.Amigo.Remove(amigo);
            this._context.SaveChanges();
        }

        public void Update(Guid id, Amigo amigo)
        {
            var amigoOld = _context.Amigo.FirstOrDefault(x => x.Id == id);

            amigoOld.DataNiver = amigo.DataNiver;
            amigoOld.Email = amigo.Email;
            amigoOld.Sobrenome = amigo.Sobrenome;
            amigoOld.Telefone = amigo.Telefone;
            amigoOld.Nome = amigo.Nome;

            _context.Amigo.Update(amigoOld);
            this._context.SaveChanges();
        }
    }
}