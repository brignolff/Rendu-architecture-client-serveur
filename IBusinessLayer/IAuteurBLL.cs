using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLayer
{
    public interface IAuteurBLL: IDisposable
    {

        IQueryable<Auteur> GetAuteurs();

        Auteur PostAuteur(Auteur author);

    }
}