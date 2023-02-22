using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaService
    {
        IList<PessoaViewModel> ListaTodas();
        IList<PessoaViewModel> ListaSelecionados(List<int> selecionados);

    }
}
