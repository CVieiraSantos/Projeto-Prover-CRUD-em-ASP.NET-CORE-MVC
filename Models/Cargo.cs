using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Prover.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Por favor insira o nome do cargo")]
        [Display(Name ="Descrição")]
        public string Description { get; set; }

        public List<Cadastro> Cadastros { get; set; }

        [Required(ErrorMessage ="Por favor marque a caixa ativo")]
        [Display(Name ="Ativo")]                
        public bool Active { get; set; }

        [DisplayName("Usuario")]
        public string User { get; set; }

    }
}