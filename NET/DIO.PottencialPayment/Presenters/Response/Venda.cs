using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.PottencialPayment.Presenters.Response
{
    public class Venda
    {
        public int Id {get; set;}
        public DateTime Data {get; set;}
        public string Status {get; set;}
        public Vendedor Vendedor {get; set;} = new Vendedor();
        public List<Item> Items {get; set;} = new List<Item>();
    }
}