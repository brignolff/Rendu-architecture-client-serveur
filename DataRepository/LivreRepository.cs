using IDataRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class LivreRepository : ILivreRepository
    {

        //context DB
        private ArchiNTiersContext _context;

        //Constructeur qui instance une ConDB avec le pattern singleton
        //Injection de dépendence par le constructeur
        public LivreRepository()
        {
            _context = new();
        }



        public IQueryable<Livre> GetLivres()
        {
            return _context.Livres;
        }

        public Livre PostLivre(Livre livre)
        {
            EntityEntry auth = _context.Livres.Add(livre);
            if (auth.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                var saveTask = _context.SaveChangesAsync();

                if (saveTask.Result == 1)
                {
                    return livre;
                }
            }
            return null;
        }


        //faire le ménage
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}



