using DataRepository;
using IBusinessLayer;
using IDataRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LivreBLL : ILivreBLL
    {


        //on doit passer par l'interface de la couche DataAccessLayer
        ILivreRepository _dataFactory;


        //Constructeur 1 - celui qui sera appelé
        public LivreBLL() : this(new LivreRepository())
        {

        }


        /// <summary>
        /// Constructeur 2
        /// Injection de dépendence par le constructeur
        /// </summary>
        /// <param name="dataFactory"></param>
        public LivreBLL(ILivreRepository dataFactory)
        {
            _dataFactory = dataFactory;
        }


        public IQueryable<Livre> GetLivres()
        {
            return _dataFactory.GetLivres();
        }


        public Livre PostLivre(Livre Livre)
        {
            return _dataFactory.PostLivre(Livre);
        }



        public void Dispose()
        {
            if (_dataFactory != null)
            {
                _dataFactory.Dispose();
            }
        }


    }
}
