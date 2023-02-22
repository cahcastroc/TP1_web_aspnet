using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AmigoService : IAmigoService      
    {
        private readonly AmigoDbContext _dbContext;

        public AmigoService(AmigoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
            

        IList<AmigoViewModel> IAmigoService.ListaTodas()
        {
            return AmigoViewModel.ListaTodos(_dbContext.Amigo.ToList());       
        }

        public IList<AmigoViewModel> ListaSelecionados(List<int> selecionado)
        {
            var listaSelecionadosVM = AmigoViewModel.ListaTodos(_dbContext.Amigo.ToList());
            return listaSelecionadosVM.Where(amigo => selecionado.Contains(amigo.Id)).ToList();
        }
    }
}
