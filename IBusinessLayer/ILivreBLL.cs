using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLayer
{
		public interface ILivreBLL: IDisposable
		{
				IQueryable<Livre> GetLivres();

				Livre PostLivre(Livre livre);
		}
}
