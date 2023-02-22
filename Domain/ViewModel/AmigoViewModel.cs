using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class AmigoViewModel
    {
        public int Id { get; set; }
        public string Nome { get;set; }
        public string Sobrenome { get; set;}
        public string Email { get; set;}
        public DateTime Aniversario { get; set;}
        public bool Selecionado { get; set;}


        public AmigoViewModel(Amigo amigo)          
        {
            this.Id = amigo.Id;
            this.Nome = amigo.Nome;
            this.Sobrenome = amigo.Sobrenome;
            this.Email = amigo.Email;
            this.Aniversario = amigo.Aniversario;
            this.Selecionado = false;
        }


        public static List<AmigoViewModel> ListaTodos(List<Amigo> amigoList) { 
            var listaAmigoVM = new List<AmigoViewModel>();

            foreach (var pessoa in amigoList)
            {
                listaAmigoVM.Add(new AmigoViewModel(pessoa));
            }

            return listaAmigoVM;
        } 

    }

   
}
