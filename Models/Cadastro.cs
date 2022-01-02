using System.ComponentModel.DataAnnotations;
using System;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Prover.Models
{
    [Table("Cadastros")]
    public class Cadastro
    {
         public int Id { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Por favor insira o nome")]
        [StringLength(20)]        
        public string Name { get; set; }
        
        [Display(Name = "Telefone")]
        [Required(ErrorMessage ="Por favor insira o telfone")]
        [StringLength(15)]
        public string Telephone { get; set; }


        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
                              
        [Required(ErrorMessage ="Por favor insira a idade")]
        [Display(Name ="Idade")]        
        public int Age { get; set; }

        [Required(ErrorMessage = "Por favor insira o sexo")]
        [Display(Name = "Sexo")]        
        public char MaleOrFemale { get; set; }

        [Required(ErrorMessage = "Por favor insira o cargo")]
        [Display(Name = "Cargo")]        
        public int CargoId { get; set; }
        public Cargo Cargos { get; set; }

        [DisplayName("Usuario")]
        public string User { get; set; }

        [Required(ErrorMessage ="Marque a caixa ativo")]
        [Display(Name="Ativo")]        
        public bool Active { get; set; }

       

    }
}