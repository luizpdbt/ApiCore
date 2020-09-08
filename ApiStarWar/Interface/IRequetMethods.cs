using ApiStarWar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStarWar.Interface
{
    public interface IRequetMethods
    {
        Task<Filmes> GetFilmes(int pagina);
        Task<Planetas> GetPlaneta(int pagina);
        Task<Species> GetSpecies(int pagina);
        Task<Veiculo> GetVeiculo(int pagina);
    }
}
