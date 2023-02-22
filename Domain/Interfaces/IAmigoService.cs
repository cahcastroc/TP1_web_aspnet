using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAmigoService
    {
        IList<AmigoViewModel> ListaTodas();
        IList<AmigoViewModel> ListaSelecionados(List<int> selecionado);

    }
}
