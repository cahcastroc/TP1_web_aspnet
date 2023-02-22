using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get;set; }
        public string Sobrenome { get; set;}
        public string Email { get; set;}
        public DateTime Aniversario { get; set;}
        public bool Selecionado { get; set;}


        public PessoaViewModel(Pessoa pessoa)          
        {
            this.Id = pessoa.Id;
            this.Nome = pessoa.Nome;
            this.Sobrenome = pessoa.Sobrenome;
            this.Email = pessoa.Email;
            this.Aniversario = pessoa.Aniversario;
            this.Selecionado = false;
        }


        public static List<PessoaViewModel> ListaTodos(List<Pessoa> pessoaList) { 
            var listaPessoaVM = new List<PessoaViewModel>();

            foreach (var pessoa in pessoaList)
            {
                listaPessoaVM.Add(new PessoaViewModel(pessoa));
            }

            return listaPessoaVM;
        } 

    }

   
}
