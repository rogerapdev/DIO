using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottencialPayment.Models
{
    public class Vendedor
    {
        public int Id {get; set;}
        public string Nome {get;set;}
        public string CPF {get; set;}
        public string Email {get; set;}
        public string Telefone {get; set;}

        public List<Venda> Vendas {get; set;}
    }
}