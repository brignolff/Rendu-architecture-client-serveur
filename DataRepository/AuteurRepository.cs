using IDataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ORM;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataRepository
{
    public class AuteurRepository : IAuteurRepository
    {

        //context DB
        private ArchiNTiersContext _context;

        //Constructeur qui instance une ConDB avec le pattern singleton
        //Injection de dépendence par le constructeur
        public AuteurRepository()
        {
            _context = new();
        }



        public IQueryable<Auteur> GetAuteurs()
        {
            return _context.Auteurs;
        }

        public Auteur PostAuteur(Auteur author)
        {
            EntityEntry auth = _context.Auteurs.Add(author);
            if (auth.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                var saveTask = _context.SaveChangesAsync();

                if (saveTask.Result == 1)
                {
                    return author;
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
