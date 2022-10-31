using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.FirstWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, 10, ErrorMessage = "Valor fora da faixa permitida")]
        public int Quantidade { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
