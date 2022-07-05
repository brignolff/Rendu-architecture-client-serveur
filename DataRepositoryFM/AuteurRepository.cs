using IDataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ORM;


namespace DataRepository
{
    public class AuteurRepository : IAuteurRepository
    {

        //context DB
        private ArchiNTiersContext _context = null;

        //Constructeur qui instance une ConDB avec le pattern singleton
        //Injection de dépendence par le constructeur
        public AuteurRepository()
        {
            _context = ArchiNTiersContext.Instance;
        }



        public IQueryable<Auteur> GetAuteurs()
        {
            return _context.Auteurs;
        }

        public Auteur PostAuteur(Auteur author)
        {
            Auteur aut = _context.Auteurs.Add(author);
            _context.SaveChangesAsync();

            return aut;
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
