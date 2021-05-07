using Series.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Interfaces
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>();        
        public void Atualiza(int Id, Serie entidade)
        {
            ListaSerie[Id] = entidade;
        }

        public void Exclui(int Id)
        {
            ListaSerie[Id].Exclui();  
        }

        public void Insere(Serie entidade)
        {
            ListaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaId(int Id)
        {
            return ListaSerie[Id];
        }
    }
}
