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
    public class PessoaService : IPessoaService      
    {
        private readonly PessoaDbContext _dbContext;

        public PessoaService(PessoaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
            

        IList<PessoaViewModel> IPessoaService.ListaTodas()
        {
            return PessoaViewModel.ListaTodos(_dbContext.Pessoa.ToList());       
        }

        public IList<PessoaViewModel> ListaSelecionados(List<int> selecionados)
        {
            var listaSelecionadosVM = PessoaViewModel.ListaTodos(_dbContext.Pessoa.ToList());
            return listaSelecionadosVM.Where(pessoa => selecionados.Contains(pessoa.Id)).ToList();
        }
    }
}
