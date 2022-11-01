using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottencialPayment.Models
{
    public class Venda
    {
        public int Id {get; set;}
        public DateTime Data { get; set; }
        public StatusVendaEnum Status { get; set; }
        public int VendedorId {get; set;}

        public List<Item> Itens {get; set;}
        public Vendedor Vendedor {get;set;}
    }
}